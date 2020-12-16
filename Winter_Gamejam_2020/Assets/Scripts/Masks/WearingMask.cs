using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class WearingMask : MonoBehaviour
{
    [Range(1, 100)]
    public float coughChance = 50;
    public float coughTimer = 5;
    public float currentCoughTimer;
    public bool masked = false;
    public VisualEffect sickness;
    public GameObject myMask;
    // Start is called before the first frame update
   
   private void Start() 
   {
       currentCoughTimer = 0;
       if (masked == true)
       {
           if (sickness)
           {
               sickness.Stop();
           }

           if (myMask)
           {
               myMask.SetActive(true);
           }
       }
       else
       {
            if (myMask)
            {
                myMask.SetActive(false);
            }
       }
   }

    private void Update()
    {
        if (masked == false)
        {
            currentCoughTimer += Time.deltaTime;

            if (currentCoughTimer >= coughTimer)
            {
                if (Random.value <= coughChance / 100)
                {
                    FindObjectOfType<AudioManager>().Play("coughing");
                }
                currentCoughTimer = 0;
            }
        }
    }



    public void Mask ()
   {
       masked = true;

        if (sickness)
        {
            sickness.Stop();
        }

        if (myMask)
        {
            myMask.SetActive(true);
        }
   }

   public void UnMask ()
   {
        FindObjectOfType<AudioManager>().Play("taking off mask");
        masked = false;
        if (sickness)
        {
            sickness.Play();
        }

        if (myMask)
        {
            myMask.SetActive(false);
        }

   }

   public bool isMasked ()
   {
       return (masked);
   }
}
