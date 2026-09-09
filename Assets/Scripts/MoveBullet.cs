using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out var hitTarget))
        {
            hitTarget.TakeDamage(50);
            Destroy(gameObject);
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -4)
        {
            Destroy(gameObject);
        }

        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}
