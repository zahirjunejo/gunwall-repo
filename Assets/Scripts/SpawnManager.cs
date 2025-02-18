using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject enemy;
    public float spawnRate;
    public GameObject gameManager;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateEnemies", 1.0f, spawnRate);
    }

    void GenerateEnemies()
    {
        if (gameManager.GetComponent<GameManager>().isGameActive)
        {
            Instantiate(enemy, spawnPoint.transform.position, spawnPoint.transform.rotation);   
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
