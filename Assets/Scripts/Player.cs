using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{

    //들어올릴 모든 오브젝트와 프리팹에 들어있습니다 마우스를 누른 상태로 들어올릴 수 있는 내용입니다.
    public static bool Check = false;
    private Vector3 mOffset;
    private float mZcoord;
    Quaternion defRot;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defRot = this.transform.rotation;
    }
    private void Update()
    {
        this.transform.rotation = defRot;
    }

    private void OnMouseDown()
    {
        mZcoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZcoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        Check = true;
        transform.position = GetMouseWorldPos() + mOffset;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        rb.isKinematic = false;
        Check = false;
    }

}
