using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSeat : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other)
        {
            this.GetComponent<BoxCollider>().enabled = false;
        }

    }

}
