using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    public float health = 0.0f;
    public GameObject DeathExplosion;
    public GameObject HitFlash;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void ReduceHealth()
    {
        health -= Time.deltaTime;
        HitFlash.GetComponent<HitFlash>().alpha = 0.5f;
        HitFlash.SetActive(true);

        if (health <= 0.0f)
        {
            Instantiate(DeathExplosion, transform.position, DeathExplosion.transform.rotation);
            Destroy(gameObject);
        }
    }


}
