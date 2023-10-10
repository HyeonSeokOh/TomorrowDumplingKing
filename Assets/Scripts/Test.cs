using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject obj;

    private void OnMouseDrag()
    {
        float Distance = 10f;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        obj.transform.position = objPosition;
    }
    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Vector3 hitPos = hit.point;
            obj = Instantiate(obj);
            obj.transform.position = hitPos;
        }
    }

    //private void Update()
    //{ 
    //}

    //private void OnMouseDrag()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;
    //    if (Input.GetMouseButton(0))
    //    {
    //        if (Physics.Raycast(ray, out hit, 100f))
    //        {
    //            Vector3 hitPos = hit.point;
    //            obj.transform.position = hitPos;
    //        }
    //    }
    //}
}
