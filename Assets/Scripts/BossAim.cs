using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAim : MonoBehaviour
{
    public GameObject player;
    public GameObject BossBomb;
    public float rate;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootBomb", rate, rate);        
    }

    void ShootBomb()
    {
        GameManager gameManagerScript;
        
        if (gameManager.TryGetComponent<GameManager>(out gameManagerScript) && gameManagerScript.isGameActive)
        {
            Instantiate(BossBomb, transform.position, transform.rotation);
        }
    }



    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(player.transform.position);
    }
}
