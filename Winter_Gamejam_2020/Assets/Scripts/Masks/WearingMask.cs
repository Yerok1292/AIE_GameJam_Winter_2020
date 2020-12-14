using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearingMask : MonoBehaviour
{

    public bool masked = false;
    // Start is called before the first frame update
   

   public void Mask ()
   {
       masked = true;
   }

   public bool isMasked ()
   {
       return (masked);
   }
}
