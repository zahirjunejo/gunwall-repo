using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 50.0f;
    private float currentHealth = 0.0f;
    public GameObject DeathExplosion;
    public GameObject HitFlash;
    
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
    }

    public float CurrentHealth => currentHealth;

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
        HitFlash.GetComponent<HitFlash>().alpha = 0.5f;
        HitFlash.SetActive(true);

        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(DeathExplosion, transform.position, DeathExplosion.transform.rotation);
        Destroy(gameObject);
    }
}
