using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskTracker : MonoBehaviour
{

    public int maxMask = 5;
    private int minMask = 0;
    public int publicMask = 5; //Display value for masks
    private int currentMask;

    // Start is called before the first frame update
    void Start()
    {
        if (maxMask < 1) maxMask = 1;

        currentMask = maxMask;
        publicMask = currentMask;
    }

   public bool HasMask ()
   {
       if (currentMask > 0) return (true);
       else return (false);
   }

   public bool Use ()
   {
       if (currentMask >= 1)
       {
           currentMask--;
           publicMask = currentMask;
           return(true);
       }
       else
       {
           return(false);
       }
   }

   public void Refresh ()
   {
       currentMask = maxMask;
       publicMask = currentMask;
   }


}
