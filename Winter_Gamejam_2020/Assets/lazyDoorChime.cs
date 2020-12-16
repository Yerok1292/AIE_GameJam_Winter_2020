using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazyDoorChime : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Customer")
        {
            FindObjectOfType<AudioManager>().Play("people entering");

        }
    }
}
