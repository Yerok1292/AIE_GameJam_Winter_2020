using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    public float currentHealth;

    public Timer timer;


    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        currentHealth = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    private void Update()
    {
        currentHealth = slider.value;
        if (currentHealth <= 0)
        {
            timer.gameEnd = true;
            gameOverUI.SetActive(true);
        }
    }

    public void GameOver()
    {

    }
}
