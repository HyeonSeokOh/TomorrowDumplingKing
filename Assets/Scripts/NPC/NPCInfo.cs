using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInfo : MonoBehaviour
{
    private void Awake()
    {

        switch (GameManager.Instance.FindMyWork)
        {
            case 1:
                this.GetComponent<MoveNPC>().enabled = true;
                break;
            case 2:
                this.GetComponent<MoveCustomer>().enabled = true;
                //민경이 코드 실행
                break;
        }

    }


}
