using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishesInside : DumplingInfo
{
    public GameObject[] dumplingGraphics = new GameObject[5];

    private void Start()
    {
        //
        for (int i = 0; i  < dumplingType.Length; i++)
        {
            if (dumplingType[i] == 0) { return; }
            else if (dumplingType[i] == 1)
            {
                dumplingGraphics[i].SetActive(true);
                dumplingGraphics[i].transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = GameManager.Instance.dumplingColor[0].color;
            }
            else if (dumplingType[i] == 2)
            {
                dumplingGraphics[i].SetActive(true);
                dumplingGraphics[i].transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = GameManager.Instance.dumplingColor[1].color;
            }
        }
    }

}
