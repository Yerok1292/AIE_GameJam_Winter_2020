using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakRepairItem : MonoBehaviour
{

    public float dotTimerMax = 3;
    public float dotTimerCurrent;
    public float dotTickRate = 1;

    //Dont edit
    [HideInInspector]
    public float dotTickRateCurrent;

    public float sanitizationDamage = 1;

    public bool broken = false;

    [Range(1, 100)]
    public float BreakingChance = 50;

    //Healthbar functionallity mostly from Brackeys
    //www.youtube.com/watch?v=BLfNP4Sc_iA
    public float maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        dotTickRateCurrent = 0;
        dotTimerCurrent = 0;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    void Update()
    {

        // If machine is broken for longer than dottimer
        // damage the sanitization healthbar, everytime the tickrate hits
        // its max, ie every one second take damage.

        //Might need to update later to check for bars current health
        // before updating incase multiple broken items save
        // separate bars
        // fixed ^ keeping note for future reference
        if (broken == true)
        {
            dotTimerCurrent += Time.deltaTime;
            dotTickRateCurrent += Time.deltaTime;
        }

        if(dotTimerCurrent >= dotTimerMax && dotTickRateCurrent >=dotTickRate)
        {
            currentHealth = healthBar.currentHealth;
            currentHealth -= sanitizationDamage;
            dotTickRateCurrent = 0;
            healthBar.SetHealth(currentHealth);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Touched Machine");
        FindObjectOfType<AudioManager>().Play("broken slushee machine");

        //First childed model = fixed
        GameObject repairedObject = transform.GetChild(0).gameObject;
        //Second childed model = broken
        GameObject brokenObject = transform.GetChild(1).gameObject;
        if (collision.tag == "Customer" && broken == false)
        {
            //Play audio for using

            Debug.Log("Used Machine");

            if (Random.value <= BreakingChance / 100)
            {
                Debug.Log("Broke machine");
                broken = true;
                repairedObject.SetActive(false);
                brokenObject.SetActive(true);
            }


        }
    }

    public void repairItem()
    {
        FindObjectOfType<AudioManager>().Stop("broken slushee machine");
        //First childed model = fixed
        GameObject repairedObject = transform.GetChild(0).gameObject;
        //Second childed model = broken
        GameObject brokenObject = transform.GetChild(1).gameObject;
        repairedObject.SetActive(true);
        brokenObject.SetActive(false);
        broken = false;
    }
}
