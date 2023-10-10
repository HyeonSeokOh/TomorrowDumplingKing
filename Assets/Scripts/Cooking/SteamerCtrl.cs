using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamerCtrl : MonoBehaviour
{
    private Vector3 defPos;
    private Quaternion defRot;
    private void Start()
    {
        defRot = this.transform.rotation;
        defPos = this.transform.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Steamer" && !GameManager.Instance.Grapping)
        {
            this.transform.position = defPos;
            this.transform.rotation = defRot;
        }
    }
}
