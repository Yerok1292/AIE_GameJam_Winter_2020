using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    public float repairTime = 2;
    public float repairTimeCurrent;
    public float progressPercent;
    [SerializeField]
    private RectTransform RepairImageRoot;
    [SerializeField]
    private Image repairProgressImage;
    [SerializeField]
    private TextMeshProUGUI interactText;
    // Start is called before the first frame update
    void Start()
    {
        repairTimeCurrent = 0;
    }

    // Update is called once per frame
    void Update()
    {



        
    }

    private void OnTriggerStay(Collider collision)
    {

        Debug.Log("collided with player/machine");

        if(collision.tag == "RepairItem" && collision.gameObject.GetComponent<BreakRepairItem>().broken == true)
        {

            RepairImageRoot.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.Mouse1))
            {
                repairTimeCurrent += Time.deltaTime;
                progressPercent = repairTimeCurrent / repairTime;
                repairProgressImage.fillAmount = progressPercent;
            }
            if (progressPercent >= 1)
            {
                RepairImageRoot.gameObject.SetActive(false);
                collision.GetComponent<BreakRepairItem>().repairItem();
            }


            //collision.GetComponent<BreakRepairItem>().repairItem();
            //Debug.Log("Repaired Machine");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        repairProgressImage.fillAmount = 0;
        repairTimeCurrent = 0;
        progressPercent = 0;
        Debug.Log("exited player/machine");
        RepairImageRoot.gameObject.SetActive(false);
    }

}
