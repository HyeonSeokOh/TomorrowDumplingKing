using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundNPC : MonoBehaviour
{
    private GameObject NPC;
    private float ftime;
    private float Maxftime = 10f;
    public Transform pos0, pos1;
    void Update()
    {
        ftime += Time.deltaTime;

        if (ftime > Maxftime)
        {
            Maxftime = Random.Range(10f,15f);
            int i = Random.Range(0, 2);
            switch (i)
            {
                case 0:
                    CreateNPC(pos0);
                    break;
                case 1:
                    CreateNPC(pos1);
                    break;
            }
            ftime = 0f;
        }
    }

    void CreateNPC(Transform pos)
    {
        NPC = GameManager.Instance.NPCList[GameManager.Instance.SelectNPC(GameManager.Instance.NPCList)];
        //NPC = GameManager.Instance.NPCList[0];
        GameManager.Instance.FindMyWork = 1;
        GameObject cNpc;
        cNpc = Instantiate(NPC,pos.position, Quaternion.identity);
        cNpc.gameObject.tag = pos.name;
        GameManager.Instance.FindMyWork = 0;
    }
}
