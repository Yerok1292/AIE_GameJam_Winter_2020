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

    public float currentCoworkerHealth;
    public float coworkerHealthMax = 4;
    public float coworkerDamage = 1;

    public float coworkerHealthPercent;

    [SerializeField]
    private Image coworkerHealthImage;

    public Timer timer;

    private void Start()
    {
        currentCoworkerHealth = coworkerHealthMax;
    }


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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            coworkerTakeDamage();
        }

        currentHealth = slider.value;
        if (currentHealth <= 0 || currentCoworkerHealth <= 0)
        {
            timer.gameEnd = true;
            gameOverUI.SetActive(true);
        }
    }

    public void coworkerTakeDamage()
    {
        currentCoworkerHealth -= coworkerDamage;
        coworkerHealthPercent = currentCoworkerHealth / coworkerHealthMax;
        coworkerHealthImage.fillAmount = coworkerHealthPercent;
    }
}
