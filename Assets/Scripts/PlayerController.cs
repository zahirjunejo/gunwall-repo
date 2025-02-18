using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    Animator anim;
    AudioSource playerAudioSource;
    public float speed = 10.0f;
    public float health = 100.0f;
    public GameObject MuzzleFlashEffect;
    public GameObject ImpactEffect;
    public GameObject raystart;
    public GameObject playerBody;
    public GameObject gameManager;
    public GameObject healthBar;
    float HealthBarWidth, HealthBarHeight;

    // Start is called before the first frame update
    void Start()
    {
        anim = playerBody.GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();

        HealthBarWidth = healthBar.GetComponent<RectTransform>().sizeDelta.x;
        HealthBarHeight = healthBar.GetComponent<RectTransform>().sizeDelta.y;
    }

    void Die()
    {
        healthBar.SetActive(false);
        MuzzleFlashEffect.SetActive(false);
        if (playerAudioSource.isPlaying)
        {
            playerAudioSource.Stop();
        }
        anim.SetTrigger("dead");
        anim.SetBool("run", false);
    }

    public void ReduceHealth(float damage) {
        health -= damage;

        healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(health / 100 * HealthBarWidth, HealthBarHeight);

        if (health <= 0) {
            Die();
            gameManager.GetComponent<GameManager>().GameOver();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameManager.GetComponent<GameManager>().isGameActive)
        {
            float HInput = Input.GetAxis("Horizontal");
            float VInput = Input.GetAxis("Vertical");

            Vector3 direction = new(HInput, 0.0f, VInput);

            if (Input.GetMouseButton(0))
            {
                MuzzleFlashEffect.SetActive(true);

                if (!playerAudioSource.isPlaying)
                {
                    playerAudioSource.Play();
                } 
            }
            else
            {
                MuzzleFlashEffect.SetActive(false);
                if (playerAudioSource.isPlaying)
                {
                    playerAudioSource.Stop();
                }
            }
        
            if (direction.magnitude > 0.0f)
            {
                anim.SetBool("run", true);
            }
            else
            {
                anim.SetBool("run", false);
            }

            transform.Translate(speed * Time.deltaTime * direction, Space.World);

        }

    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && gameManager.GetComponent<GameManager>().isGameActive)
        {

            Ray ray = new Ray(raystart.transform.position, raystart.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);

                //Instantiate(ImpactEffect, hit.point, ImpactEffect.transform.rotation);
                Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));

                if (hit.rigidbody != null)
                {

                    if (hit.rigidbody.gameObject.CompareTag("Minion") || hit.rigidbody.gameObject.CompareTag("Boss"))
                    {

                        hit.rigidbody.gameObject.BroadcastMessage("ReduceHealth");

                    }
                }

            }
        }
    }


}
