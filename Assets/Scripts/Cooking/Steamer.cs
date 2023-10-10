using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steamer : MonoBehaviour
{

    [SerializeField]
    ParticleSystem collectParticle = null;

    public Transform[] arrPos = new Transform[5];

    private GameObject[] DumplingInfo = new GameObject[5];
    private int arrState = 0;
    private float ftime = 0;
    private bool checkSteaming = false;

    AudioSource audioS;
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Mandu" || collision.gameObject.tag == "Kmandu") && arrState < DumplingInfo.Length)
        {
            Destroy(collision.gameObject.GetComponentInParent<FixedJoint>());
            collision.gameObject.GetComponentInParent<VRGrap>().TakeWeapon(false);
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;

            collision.transform.position = arrPos[arrState].transform.position;
            DumplingInfo[arrState] = collision.gameObject;
            arrState++;
        }
        else if (collision.gameObject.tag == "SteamerHead")
        {
            audioS.Play();
            collectParticle.Play();
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            checkSteaming = true;
        }
        else if(collision.gameObject.tag == "CKMandu" || collision.gameObject.tag == "CKkmandu")
        {
            arrState++;
        }
        else
            return;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "SteamerHead")
        {
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            for (int i = 0; i < arrState; i++)
            {
                if (DumplingInfo[i] !=null)
                {
                    DumplingInfo[i].gameObject.GetComponent<BoxCollider>().enabled = true;
                }
            }
            checkSteaming = false;
        }
        else if (collision.gameObject.tag == "CKMandu" || collision.gameObject.tag == "CKkmandu")
        {
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            arrState--;
            DumplingInfo[arrState] = null;
            
        }
    }
    private void Start()
    {
        audioS = GetComponent<AudioSource>();

    }
    private void Update()
    {
        if (checkSteaming)
        {
            ftime += Time.deltaTime;
        }
        else
        {
            audioS.Stop();
            collectParticle.Stop();
        }

        if (ftime >= 3f)
        {
           
            Steaming();
            checkSteaming = false;
            ftime = 0;
        }
        Debug.Log(arrState);
    }

    void Steaming()
    {
        if (DumplingInfo[0] != null)
        {
            for (int i = 0; i < arrState; i++)
            {
                if (DumplingInfo[i].tag == "Mandu")
                {
                    DumplingInfo[i].tag = "CKMandu";
                    DumplingInfo[i].transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = GameManager.Instance.dumplingColor[0].color;
                }
                else if (DumplingInfo[i].tag == "Kmandu")
                {
                    DumplingInfo[i].tag = "CKkmandu";
                    DumplingInfo[i].transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = GameManager.Instance.dumplingColor[1].color;
                }
                else return;
            }
        }
    }

}
