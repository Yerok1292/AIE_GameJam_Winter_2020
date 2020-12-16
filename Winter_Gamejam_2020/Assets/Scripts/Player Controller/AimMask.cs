using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMask : MonoBehaviour
{
    private PlayerMove mMovement;
    public bool canAim = true;
    private Vector3 targetPos;

    public float aimSpeed = 5f;
    private float aimStep;

    public Camera mCam;
    private Ray targetRay;
    float rayDist = 30f;

    public Transform rotateCharacter;
    public Transform aimTarget;

    public GameObject aimArrow;

    // Start is called before the first frame update
    void Start()
    {
        mMovement = gameObject.GetComponent<PlayerMove>();
        //mCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (mMovement)
        {
            if (Input.GetButton("Fire1") && canAim && mCam)
            {
                if (aimArrow)
                {
                    aimArrow.SetActive(true);
                }
                FindObjectOfType<AudioManager>().Play("throw mask sound");

                
                mMovement.isThrowing = true;
                targetRay = mCam.ScreenPointToRay(Input.mousePosition);
                targetPos = targetRay.GetPoint(rayDist);
                targetPos.y = 0f;
                //Debug.Log("pos is " + targetPos);
                aimTarget.LookAt(targetPos);
                //aimTarget.rotation.x = 0;


            }
            else
            {
                if (aimArrow)
                {
                    aimArrow.SetActive(false);
                }
                mMovement.isThrowing = false;
            }
        }
    }


    private void FixedUpdate()
    {
        aimStep = aimSpeed * Time.fixedDeltaTime;

        if (mMovement)
        {
            if (mMovement.isThrowing == true)
            {
                //rotateCharacter.rotation = Quaternion.RotateTowards(rotateCharacter.rotation, aimTarget.rotation, aimStep);
            }
        }


    }
}
