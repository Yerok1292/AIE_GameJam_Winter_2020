using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskImpact : MonoBehaviour
{
  private WearingMask cMask;
  private Collider cCollider;

    private void OnCollisionEnter(Collision other) 
    {
        cCollider = other.collider;
        cMask = cCollider.GetComponent<WearingMask>();

        Debug.Log (cMask);

        if (cMask)
        {
            cMask.Mask();
            Destroy(gameObject, .5f);
        }
    }

}
