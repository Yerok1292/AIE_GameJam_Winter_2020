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
        if (collision.tag == "MaskReload" && gameObject.GetComponent<MaskTracker>().currentMask < gameObject.gameObject.GetComponent<MaskTracker>().maxMask)
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
                gameObject.GetComponent<MaskTracker>().Refresh();
                RepairImageRoot.gameObject.SetActive(false);
                repairProgressImage.fillAmount = 0;
                repairTimeCurrent = 0;
                progressPercent = 0;
                Debug.Log("Trigger Repair/mask exit");
                RepairImageRoot.gameObject.SetActive(false);
            }
        }





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
        if (collision.tag == "RepairItem" || collision.tag == "MaskReload")
        {
            repairProgressImage.fillAmount = 0;
            repairTimeCurrent = 0;
            progressPercent = 0;
            Debug.Log("Trigger Repair/mask exit");
            RepairImageRoot.gameObject.SetActive(false);
        }
    }

}
