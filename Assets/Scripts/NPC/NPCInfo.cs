using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInfo : MonoBehaviour
{
    private void Awake()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        switch (GameManager.Instance.FindMyWork)
        {
            case 1:
                this.GetComponent<MoveNPC>().enabled = true;
                break;
            case 2:
                break;
        }

    }
    private void Start()
    {

    }

}

