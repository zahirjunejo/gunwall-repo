using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{

    public float health = 0.0f;
    public GameObject DeathExplosion;
    public GameObject HitFlash;
    public GameObject HealthBar;
    public GameObject ExplosionDecal;
    float HealthBarWidth, HealthBarHeight;

    

    // Start is called before the first frame update
    void Start()
    {
        RectTransform rect;
        HealthBar.TryGetComponent<RectTransform>(out rect);
        HealthBarWidth = rect.sizeDelta.x;
        HealthBarHeight = rect.sizeDelta.y;
    }

    public void ReduceHealth()
    {
        health -= Time.deltaTime;
        HitFlash.GetComponent<HitFlash>().alpha = 0.5f;
        HitFlash.SetActive(true);
        HealthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(health / 100 * HealthBarWidth, HealthBarHeight);

        if (health <= 0.0f)
        {
            Instantiate(DeathExplosion, transform.position, DeathExplosion.transform.rotation);
            ExplosionDecal.SetActive(true);
            GameObject.Find("GameManager").GetComponent<GameManager>().ShakeMainCamera();

            Destroy(gameObject);
        }
    }

}
