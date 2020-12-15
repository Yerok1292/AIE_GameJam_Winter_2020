using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Playgame()
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("IsLoading");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
