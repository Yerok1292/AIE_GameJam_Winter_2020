using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakRepairItem : MonoBehaviour
{
    public bool broken = false;

    [Range(1, 100)]
    public float BreakingChance = 50;

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Touched Machine");
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
        //First childed model = fixed
        GameObject repairedObject = transform.GetChild(0).gameObject;
        //Second childed model = broken
        GameObject brokenObject = transform.GetChild(1).gameObject;
        repairedObject.SetActive(true);
        brokenObject.SetActive(false);
        broken = false;
    }
}
