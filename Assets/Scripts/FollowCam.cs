using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    Camera MainCam;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        MainCam = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        
            RaycastHit hit;
            Ray ray = MainCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                player.transform.LookAt(new Vector3(hit.point.x,player.transform.position.y, hit.point.z));            
            }

        
    }

}
