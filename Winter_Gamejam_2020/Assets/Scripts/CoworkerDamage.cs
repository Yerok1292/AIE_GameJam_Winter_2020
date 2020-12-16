using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoworkerDamage : MonoBehaviour
{
    public HealthBar hBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Customer")
        {
            FindObjectOfType<AudioManager>().Play("register");

        }

        if (other.gameObject.GetComponent<WearingMask>().masked == false && other.tag == "Customer")
        {
            hBar.coworkerTakeDamage();
        }
    }
}
