using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

  

    public float restartDelay = 0f;

    int nextSceneIndex = 0;

    private GameObject trapAcorns;
    public GameObject acorn;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.R))
       
            Restart();

        if ((SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4) && Input.GetKeyDown(KeyCode.Space))
            ReturnToMenu();

        if (SceneManager.GetActiveScene().buildIndex == 0 && Input.GetKeyDown(KeyCode.Space))
            ProceedToGame();



    }

    public void EndGame()
    {

        // Invoke("Restart", restartDelay);
        if(SceneManager.GetActiveScene().buildIndex == 1)
            SceneManager.LoadScene(1);
        else
            SceneManager.LoadScene(4);


    }

    public void ProceedGame()
    {
     
            // Invoke("Restart", restartDelay);
            
            nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        


    }

    void ProceedToGame()
    {
        
            SceneManager.LoadScene(1);
    }

    void ReturnToMenu()
    {
            SceneManager.LoadScene(0);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AcornTrap()
    {
     
        for (int i = 0; i < 15; i++)
        {
            trapAcorns = Instantiate(acorn, player.transform.position + new Vector3((i-10)*0.45f, 20, 0) , Quaternion.identity);
            trapAcorns.GetComponent<AcornController>().InitializeEnemyProjectile(Vector3.down, 12.0f);
        }
        
    }
}
