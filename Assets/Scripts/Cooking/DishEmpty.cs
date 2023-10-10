using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishEmpty : MonoBehaviour
{
    public GameObject createObject;

    private float ftime = 0f;
    private bool checkOutColl = false;
    private Transform defPos;

    private void Start()
    {
        defPos = createObject.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == createObject)
        {
            checkOutColl = true;
        }
    }

    private void Update()
    {
        if(checkOutColl)
        {
            ftime += Time.deltaTime;
        }
        if (ftime >= 1.0f)
        {
            Instantiate(createObject, defPos);
            checkOutColl = false;
            ftime = 0f;
        }
    }
}
