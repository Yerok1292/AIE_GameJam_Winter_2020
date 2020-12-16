using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseUi;
    public GameObject maskUi;
    public GameObject timerUi;
    public string levelName;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }


    }
    public void Resume()
    {
        pauseUi.SetActive(false);
        timerUi.SetActive(true);
        maskUi.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    void Pause()
    {
        pauseUi.SetActive(true);
        timerUi.SetActive(false);
        maskUi.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(levelName);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
