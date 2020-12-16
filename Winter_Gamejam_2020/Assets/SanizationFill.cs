using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanizationFill : MonoBehaviour
{

    public HealthBar hBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject excellent = transform.GetChild(0).gameObject;
        GameObject good = transform.GetChild(1).gameObject;
        GameObject okay = transform.GetChild(2).gameObject;
        GameObject improve = transform.GetChild(3).gameObject;

        if (hBar.currentHealth <= 75)
        {
            excellent.SetActive(false);
            good.SetActive(true);
            okay.SetActive(false);
            improve.SetActive(false);

        }
        else if (hBar.currentHealth <= 50)
        {
            excellent.SetActive(false);
            good.SetActive(false);
            okay.SetActive(true);
            improve.SetActive(false);
        }
        else if (hBar.currentHealth <= 25)
        {
            excellent.SetActive(false);
            good.SetActive(false);
            okay.SetActive(false);
            improve.SetActive(true);
        }
    }
}
