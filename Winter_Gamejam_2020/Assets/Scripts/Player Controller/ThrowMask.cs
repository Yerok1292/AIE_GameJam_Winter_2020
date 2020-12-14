using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowMask : MonoBehaviour
{

    public GameObject maskProjectile;
    private GameObject tempMask;
    private Rigidbody rbPackage;
    public float throwForce = 25f;
    private PlayerMove mPlayer;
    private bool fireNow = false;
    public AudioSource mailThrow;
    public Transform launchPosition;

    public MaskTracker mMaskTracker;
    // Start is called before the first frame update
    void Start()
    {
        mPlayer = gameObject.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            //Debug.Log ("Fire1 is up");
            bool hasAmmo = mMaskTracker.HasMask();
            //Debug.Log (hasAmmo);

            if (hasAmmo == true)
            {
                fireNow = true;
                //Debug.Log("Should now fire");
            } 
        }
    }


    private void FixedUpdate()
    {
        if (fireNow == true)
        {
            //Debug.Log("Mask should be thrown");
            // AudioManager.PlaySound();
            fireNow = false;
            mMaskTracker.Use();

           
                if (maskProjectile)
                {

                    tempMask = Instantiate(maskProjectile, launchPosition);

                    rbPackage = tempMask.GetComponent<Rigidbody>();

                    tempMask.transform.parent = null;

                    if (rbPackage)
                    {
                        //rbPackage.isKinematic = false;
                        rbPackage.AddForce(transform.forward * throwForce, ForceMode.Impulse);
                    }




                }
            
        }
    }
}
