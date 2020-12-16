using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInteraction : MonoBehaviour
{

    public float repairTime;
    public float repairTimeCurrent;
    public float progressPercent;
    public GameObject click1;
    public GameObject click2;
    public GameObject click3;
    public GameObject click4;
    [SerializeField]
    private Image repairProgressImage;
    //private bool isBroken;




    // Start is called before the first frame update
    void Start()
    {
        repairTimeCurrent = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MaskReload" && gameObject.GetComponent<MaskTracker>().currentMask < gameObject.gameObject.GetComponent<MaskTracker>().maxMask)
        {
            click1.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.Mouse1))
            {
                repairTimeCurrent += Time.deltaTime;
                progressPercent = repairTimeCurrent / repairTime;
                repairProgressImage.fillAmount = progressPercent;
            }
            if (progressPercent >= 1)
            {
                gameObject.GetComponent<MaskTracker>().Refresh();
                //RepairImageRoot.gameObject.SetActive(false);
                click1.gameObject.SetActive(false);
                repairProgressImage.fillAmount = 0;
                repairTimeCurrent = 0;
                progressPercent = 0;
                Debug.Log("Trigger Repair/mask exit");
                //RepairImageRoot.gameObject.SetActive(false);
            }
        }

        if (other.gameObject.tag == "Slush" && other.gameObject.GetComponent<BreakRepairItem>().broken == true)
        {
            
            click2.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.Mouse1))
            {
                repairTimeCurrent += Time.deltaTime;
                progressPercent = repairTimeCurrent / repairTime;
                repairProgressImage.fillAmount = progressPercent;
            }
            if (progressPercent >= 1)
            {
                
                click2.gameObject.SetActive(false);
                other.GetComponent<BreakRepairItem>().repairItem();
            }
        }
       
        if(other.gameObject.tag == "Table" && other.gameObject.GetComponent<BreakRepairItem>().broken == true)
        {
            click3.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.Mouse1))
            {
                repairTimeCurrent += Time.deltaTime;
                progressPercent = repairTimeCurrent / repairTime;
                repairProgressImage.fillAmount = progressPercent;
            }
            if (progressPercent >= 1)
            {

                click3.gameObject.SetActive(false);
                other.GetComponent<BreakRepairItem>().repairItem();
            }
        }

        if(other.gameObject.tag == "Bathroom" && other.gameObject.GetComponent<BreakRepairItem>().broken == true)
        {
            click4.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.Mouse1))
            {
                repairTimeCurrent += Time.deltaTime;
                progressPercent = repairTimeCurrent / repairTime;
                repairProgressImage.fillAmount = progressPercent;
            }
            if (progressPercent >= 1)
            {

                click4.gameObject.SetActive(false);
                other.GetComponent<BreakRepairItem>().repairItem();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(click1.gameObject.activeSelf == true)
        {
            repairTimeCurrent = 0;
            progressPercent = 0;
            click1.gameObject.SetActive(false);
            Debug.Log("1Off");
        }
        if (click2.gameObject.activeSelf == true)
        {
            repairTimeCurrent = 0;
            progressPercent = 0;
            click2.gameObject.SetActive(false);
            Debug.Log("2Off");
        }
        if (click3.gameObject.activeSelf == true)
        {
            repairTimeCurrent = 0;
            progressPercent = 0;
            click3.gameObject.SetActive(false);
            Debug.Log("3Off");
        }
        if (click4.gameObject.activeSelf == true)
        {
            repairTimeCurrent = 0;
            progressPercent = 0;
            click4.gameObject.SetActive(false);
            Debug.Log("4Off");
        }
        
    }
}
