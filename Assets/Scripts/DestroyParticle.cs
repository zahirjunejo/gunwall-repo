using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
   
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ParticleDestroy", duration);
    }

    void ParticleDestroy()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
