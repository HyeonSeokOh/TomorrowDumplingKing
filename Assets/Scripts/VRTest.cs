using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRTest : MonoBehaviour
{
    public SteamVR_Action_Boolean bl;
    public SteamVR_Input_Sources input_Sources;


    // Start is called before the first frame update
    void Start()
    {
        input_Sources = GetComponent<SteamVR_Behaviour_Pose>().inputSource;
    }

    // Update is called once per frame
    void Update()
    {
        if(bl.GetLastStateDown(input_Sources))
        {

        }
    }
}
