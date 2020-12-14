/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPackage : MonoBehaviour
{
    public GameObject myPackage;
    private Rigidbody rbPackage;
    public bool mailInWorld;
    public bool packageheld = false;
    public float throwForce = 25f;
    private PlayerMovement mPlayer;
    private MailPickup mPickup;
    private bool fireNow = false;
    public AudioSource mailThrow;

    // Start is called before the first frame update
    void Start()
    {
        mPlayer = gameObject.GetComponent<PlayerMovement>();
        mPickup = gameObject.GetComponent<MailPickup>();

    }

    private void Update() 
    {
        if (Input.GetButtonUp("Fire1"))
        {
            fireNow = true;
        }
    }
    
    private void FixedUpdate() 
    {
        if (fireNow == true)
        {
            Debug.Log("package should be thrown");
           // AudioManager.PlaySound();
            fireNow = false;
            
            if (packageheld == true)
            {
                if (myPackage)
                {
                    
                    //Throw the package
                    myPackage.transform.parent = null;
                    if (mPickup)
                    {
                        mPickup.timer = 0;
                    }

                    rbPackage = myPackage.GetComponent<Rigidbody>();

                    if (rbPackage)
                    {
                        rbPackage.isKinematic = false;
                        rbPackage.AddForce(transform.forward * throwForce, ForceMode.Impulse);
                    }

                   


                }
            }
        }
    }
}
*/