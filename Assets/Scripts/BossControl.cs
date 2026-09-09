using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour, IDamageable
{

    [SerializeField] private float maxHealth = 100.0f;
    private float currentHealth = 0.0f;
    public GameObject DeathExplosion;
    public GameObject HitFlash;
    public GameObject HealthBar;
    public GameObject ExplosionDecal;
    float HealthBarWidth, HealthBarHeight;

    
    void Awake()
    {
        currentHealth = maxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        RectTransform rect;
        HealthBar.TryGetComponent<RectTransform>(out rect);
        HealthBarWidth = rect.sizeDelta.x;
        HealthBarHeight = rect.sizeDelta.y;
    }



    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
        HitFlash.GetComponent<HitFlash>().alpha = 0.5f;
        HitFlash.SetActive(true);
        HealthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(currentHealth / maxHealth * HealthBarWidth, HealthBarHeight);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(DeathExplosion, transform.position, DeathExplosion.transform.rotation);
        ExplosionDecal.SetActive(true);
        GameObject.Find("GameManager").GetComponent<GameManager>().ShakeMainCamera();

        Destroy(gameObject);
    }
}
