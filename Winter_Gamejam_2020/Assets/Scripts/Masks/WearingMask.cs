using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class WearingMask : MonoBehaviour
{

    public bool masked = false;
    public VisualEffect sickness;
    // Start is called before the first frame update
   
   private void Start() 
   {
       if (masked == true)
       {
           if (sickness)
           {
               sickness.Stop();
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
   }

   public void UnMask ()
   {
       masked = false;
        if (sickness)
        {
            sickness.Play();
        }
   }

   public bool isMasked ()
   {
       return (masked);
   }
}
