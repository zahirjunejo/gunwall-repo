using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFlash : MonoBehaviour
{
    public float speed = 12.0f;
    public float alpha = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color objectColor = GetComponent<Renderer>().material.color;
        //float alpha = Mathf.PingPong(Time.time * speed, 1.0f);
        alpha -= Time.deltaTime * speed;
        GetComponent<Renderer>().material.color = new Color(objectColor.r, objectColor.g, objectColor.b, alpha);
        if (alpha <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
