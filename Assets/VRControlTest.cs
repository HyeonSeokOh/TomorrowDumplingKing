using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using Valve.VR;

public class VRControlTest : MonoBehaviour
{
    [SerializeField]
    private SteamVR_Input_Sources[] handType;


    [SerializeField]
    private VRGrap[] graps;

    [SerializeField]
    private Text countText = null;


    [SerializeField]
    private Transform headTransform = null;

    [SerializeField]
    private GameObject magicCircle = null;


    private SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    private SteamVR_Action_Boolean teleport = SteamVR_Actions.default_Teleport;
    private SteamVR_Action_Boolean grap = SteamVR_Actions.default_GrabGrip;

    private int count = 0;
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < handType.Length; i++)
        {
            if (trigger.GetState(handType[i]))
            {
                //graps[i].DownTrigger();
            }


            if (trigger.GetStateDown(handType[i]))
            {
                SetMagicCircle(true, graps[i].transform);
            }

            if (trigger.GetStateUp(handType[i]))
            {
                SetMagicCircle(false, graps[i].transform);
            }

            if (teleport.GetStateDown(handType[i]))
            {
                graps[i].TakeWeapon(true);
            }

           

            if (grap.GetStateDown(handType[i]))
            {
                graps[i].TakeWeapon(false);
            }

           
        }


    }

    private void SetMagicCircle(bool value, Transform tr)
    {
        if (value)
        {
            if (!magicCircle.gameObject.activeSelf)
            {
                magicCircle.gameObject.SetActive(true);
                magicCircle.transform.position = tr.position;
                magicCircle.transform.LookAt(headTransform);
            }
        }
        else
        {
            magicCircle.gameObject.SetActive(false);
        }
    }

  
    public void OnClickButton(bool value)
    {
        if (value)
        {
            count++;
        }
        else
        {
            count--;
        }
        countText.text = string.Format("{0}", count);
    }

  
}
