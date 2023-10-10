using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCustomer : MonoBehaviour
{

    float npctimer = CustomerManager.Instance.createTimer;

    void CheckTarget()          //빈 자리 존재 여부 확인 함수
    {
        for (int i = 0; i < CustomerManager.Instance.targetNum; i++)
        {
            if (!CustomerManager.Instance.targetCheck[i])
            {
                CustomerManager.Instance.noTarget = false;
                break;
            }
            else if(CustomerManager.Instance.targetCheck[i])
            {
                CustomerManager.Instance.noTarget = true;
            }
        }
    }

    void CustomerMaker()            //NPC 생성함수
    {
        npctimer -= Time.deltaTime;
        if (npctimer <= 0 && CustomerManager.Instance.noTarget == false)
        {
            GameManager.Instance.FindMyWork = 2;
            Instantiate(FindNPC(), CustomerManager.Instance.createTargetvec.transform.position, Quaternion.identity);
            CustomerManager.Instance.createTimer = Random.Range(3f, 10f);
            npctimer = CustomerManager.Instance.createTimer;
            GameManager.Instance.FindMyWork = 0;
        }
    }

    void Update()
    {
        CheckTarget();


        if(GameManager.Instance.GameStart == true)
        CustomerMaker();
    }


    private GameObject FindNPC()
    {
        int i = Random.Range(0, 10);
        int j;
        if (i < 3)
        {
            j = Random.Range(0, GameManager.Instance.SpNPCList.Length);

            return GameManager.Instance.SpNPCList[j];
        }
        else
        {
            j = Random.Range(0, GameManager.Instance.NPCList.Length);

            return GameManager.Instance.NPCList[j];
        }
    }
}
