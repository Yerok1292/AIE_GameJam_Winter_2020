using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaskTracker : MonoBehaviour
{

    public int maxMask = 5;
    private int minMask = 0;
    public int publicMask = 5; //Display value for masks
    public int currentMask;
    public TextMeshProUGUI maskText;

    // Start is called before the first frame update
    void Start()
    {
        if (maxMask < 1) maxMask = 1;

        currentMask = maxMask;
        publicMask = currentMask;

        if (maskText)
        {
            maskText.SetText(publicMask.ToString());
        }
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

            if (maskText)
            {
                maskText.SetText(publicMask.ToString());
            }
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
        if (maskText)
        {
            maskText.SetText(publicMask.ToString());
        }
   }


}
