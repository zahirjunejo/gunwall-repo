using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigate : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject SuicideExplosion;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision collision)
    {         
        if(collision.gameObject.TryGetComponent<IDamageable>(out var hitTarget))
        {
            Instantiate(SuicideExplosion, transform.position, SuicideExplosion.transform.rotation);
            Destroy(gameObject);
            hitTarget.TakeDamage(10);
        }   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            agent.SetDestination(player.transform.position);
        }
    }
}
