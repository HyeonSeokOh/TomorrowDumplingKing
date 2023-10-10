using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDish : MonoBehaviour
{
    public static GameObject[] dumplingGraphic = new GameObject[5];


    //private GameObject createdish;
    // 0 = 없음, 1 = 고기만두, 2 = 김치만두
    public static int[] dishList = new int[5];


    public static int stateDish = 0;
    public static int maxDish =5;

    private void Start()
    {
        maxDish = dishList.Length - 1;
        for (int i = 0; i < dishList.Length; i++)
        {
            dishList[i] = 0;
        }

        for(int i  =0; i < dumplingGraphic.Length; i++)
        {
            dumplingGraphic[i] = this.gameObject.transform.GetChild(i).gameObject;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CKMandu" && dishList[stateDish] <= dishList[maxDish])
        {
            dishList[stateDish] = 1;
            dumplingGraphic[stateDish].SetActive(true);
            dumplingGraphic[stateDish].transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = GameManager.Instance.dumplingColor[0].color;
            Destroy(collision.gameObject);
            stateDish++;
        }
        else if (collision.gameObject.tag == "CKkmandu" && dishList[stateDish] <= dishList[maxDish])
        {
            dishList[stateDish] = 2;
            dumplingGraphic[stateDish].SetActive(true);
            dumplingGraphic[stateDish].transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = GameManager.Instance.dumplingColor[1].color;
            Destroy(collision.gameObject);
            stateDish++;
        }
    }


}
