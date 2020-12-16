using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float myTime;
    public float zeroSeconds = 0;
    public bool gameEnd;
    public GameObject WinScreen;
    public TextMeshProUGUI secondsDisplayed;

    // Start is called before the first frame update
    void Start()
    {
        myTime = 60;
        gameEnd = false;

    }

    // Update is called once per frame
    void Update()
    {
        myTime -= Time.deltaTime;
        if (secondsDisplayed)
        {
            secondsDisplayed.SetText(myTime.ToString("#"));
        }

        if (myTime <= zeroSeconds)
        {
            gameEnd = true;
            EndGame();

        }

    }

    void EndGame()
    {
        if (gameEnd == true)
        {
            Time.timeScale = 0f;
            WinScreen.SetActive(true);
        }
    }
}
