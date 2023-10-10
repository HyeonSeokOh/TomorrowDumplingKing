using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour 
{
    
    public DishesInside dishes;
    public MoveCustomer npc;

    private int[] dumplingNum = new int[2];
    private int[] dishDumplingNum = new int[2];

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MoveCustomer>())
        {
            npc = other.GetComponent<MoveCustomer>();
        }
        if(other.GetComponent<DishesInside>())
        {
            dishes = other.GetComponent<DishesInside>();
            CompareOrder();
        }

    }

    void CompareOrder()
    {
        for (int i = 0; i < npc.dumplingType.Length; i++)
        {
            if (npc.dumplingType[i] == 1) //고기만두라면
            {
                dumplingNum[0]++;
            }
            else if (npc.dumplingType[i] == 2) //김치만두라면
            {
                dumplingNum[1]++;
            }
        }
        for (int i = 0; i < dishes.dumplingType.Length; i++)
        {
            if (dishes.dumplingType[i] == 1) //고기만두라면
            {
                dishDumplingNum[0]++;
            }
            else if (dishes.dumplingType[i] == 2) //김치만두라면
            {
                dishDumplingNum[1]++;
            }
        }

        if (dishDumplingNum[0] == dumplingNum[0] && dishDumplingNum[1] == dumplingNum[1])
        {
            npc.orderSucces = 1;
            Destroy(dishes.gameObject.GetComponentInParent<FixedJoint>());
            Destroy(dishes.gameObject);
        }
        else
        {
            Destroy(dishes.gameObject.GetComponentInParent<FixedJoint>());
            Destroy(dishes.gameObject);
            npc.orderSucces = 2;
        }
    }
}
