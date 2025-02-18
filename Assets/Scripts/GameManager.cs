using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject HUD;
    public GameObject MainCamera;
    public bool isGameActive;
    public bool playerDead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void StartGame()
    {
        isGameActive = true;
        titleScreen.SetActive(false);
    }

    public void GameOver()
    {
        MainCamera.GetComponent<FollowCam>().enabled = false;
        gameOverScreen.gameObject.SetActive(true);
        isGameActive = false;
        playerDead = true;
    }

    public void ShakeMainCamera()
    {
        MainCamera.GetComponent<CameraShake>().enabled = true;
        MainCamera.GetComponent<AudioSource>().enabled = false;
        Invoke("StopShakeMainCamera", 2.0f);
    }

    public void StopShakeMainCamera()
    {
        MainCamera.transform.position = new Vector3(0, 4.7f, -14);
        MainCamera.GetComponent<CameraShake>().enabled = false;
        // TODO: Show win screen after this.
       
    }

    

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
