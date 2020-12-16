using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class WearingMask : MonoBehaviour
{

    public bool masked = false;
    public VisualEffect sickness;
    public GameObject myMask;
    // Start is called before the first frame update
   
   private void Start() 
   {
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
