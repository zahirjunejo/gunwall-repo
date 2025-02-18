using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float angleSpeed = 90.0f;
    float angle = 0.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime * angleSpeed;
        float yPos = transform.position.y;
        float zPos = transform.position.z;
        transform.position =  new Vector3(Mathf.Sin(angle), yPos , zPos); 
    }
}
