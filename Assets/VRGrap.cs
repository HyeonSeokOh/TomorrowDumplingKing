using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class VRGrap : MonoBehaviour
{
    recipe recipe;
    private SteamVR_Behaviour_Pose controllerPose;
    private SteamVR_Action_Boolean trigger = SteamVR_Actions.default_GrabPinch;
    public SteamVR_Input_Sources handType;


    private GameObject collidingObject;
    public GameObject objectInHand;
    private GameObject inside;
    public AudioClip[] audioClip = new AudioClip[3];
    AudioSource aS;

    private void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }
    private void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }
    private void OnTriggerExit(Collider other)
    {
        if(!collidingObject)
        {
            return;
        }
        collidingObject = null;
    }

    private void SetCollidingObject(Collider col)
    {
        if(collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = col.gameObject;
    }

    public void TakeWeapon(bool value)
    {
        if (value)
        {
            if (collidingObject)
            {
                aS.clip = audioClip[0];
                aS.Play();
                GrabObject();
            }
        }
        else
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
    }

    public void GrabObject()
    {
        // 8 고기 9 당면 10 부추 11 김치 12 간장 13 만두피
        // 14 고기만두속 15 김치만두속 16 만두 17 찜기뚜껑 18 그릇 19 생성될 그릇 20 속담는 그릇
        // true = 생성해야하는것 false = 생성 안되는 것
        if (collidingObject.layer == 8) { CreateInside(0, true); } // 고기
        else if (collidingObject.layer == 9) { CreateInside(1, true); } // 당면
        else if (collidingObject.layer == 10) { CreateInside(2, true); } // 부추
        else if (collidingObject.layer == 11) { CreateInside(3,true); } // 김치
        else if (collidingObject.layer == 12) { CreateInside(4, false); } // 간장
        else if (collidingObject.layer == 13) { CreateInside(5, true); } // 만두피
        else if (collidingObject.layer == 14 && recipe.count >=0) { CreateInside(6, true); recipe.count--; } // 고기만두 속
        else if (collidingObject.layer == 15 && recipe.count >= 0) { CreateInside(7, true); recipe.count--; } // 김치만두 속
        else if (collidingObject.layer == 16) {
            CreateInside(8, false); } // 만두
        else if (collidingObject.layer == 17) { CreateInside(4, false); } // 찜기뚜껑
        else if (collidingObject.layer == 18) { CreateInside(9, true);  } // 그릇
        else if (collidingObject.layer ==  20) { recipe.checkTrigger = true; } // 속담는 그릇

    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = this.gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }


    void Start()
    {
        recipe = GetComponent<recipe>();
        controllerPose = GetComponent<SteamVR_Behaviour_Pose>();
        aS = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (trigger.GetStateDown(handType))
        {
            TakeWeapon(true);
            GameManager.Instance.Grapping = true;

        }
        else if (trigger.GetStateUp(handType))
        {
            TakeWeapon(false);
            recipe.checkTrigger = false;
            GameManager.Instance.Grapping = false;
        }

    }

    public void ReleaseObject()
    {
        if(GetComponent<FixedJoint>())
        {
            objectInHand.transform.parent = null;
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();
        }
    }

    void CreateInside(int findObjType, bool GarbValue)
    {
        if (GarbValue)
        {
            inside = Instantiate(GameManager.Instance.prefabList[findObjType]);
            //그릇을 소환할때
            if (findObjType == 9)
            {
                for (int i = 0; i < CreateDish.dishList.Length; i++)
                {
                    inside.GetComponent<DishesInside>().dumplingType[i] = CreateDish.dishList[i];
                }

                for (int i = 0; i < CreateDish.dishList.Length; i++)
                {
                    CreateDish.dumplingGraphic[i].SetActive(false);
                    CreateDish.dishList[i] = 0;
                    CreateDish.stateDish = 0;
                }
            }
            objectInHand = inside;
            inside = null;
        }
        else if(!GarbValue)
        {
            objectInHand = collidingObject;
            collidingObject = null;
        }
            objectInHand.transform.parent = this.transform;
            objectInHand.transform.localPosition = Vector3.zero;
            objectInHand.transform.localRotation = Quaternion.identity;

            var joint = AddFixedJoint();
            joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }
}
