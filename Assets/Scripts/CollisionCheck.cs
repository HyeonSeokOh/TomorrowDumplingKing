using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollisionCheck : MonoBehaviour
{
    //재료 그릇 오브젝트에 있습니다, 마우스를 누르면 그 자리에 재료 프리팹을 생성하는 내용입니다.
    public GameObject obj;
    private GameObject Z;
    private void OnMouseDrag()
    {

        float Distance = 1.5f; // 이게 집었을때의 거리를 나타냄 아까는 10f라서 멀리 보였던 것.
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        if (Z)
        {
            Z.transform.position = objPosition;
        }
    }

    private void OnMouseDown() //마우스의 위치에 오브젝트 생성
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        
        if (Physics.Raycast(ray , out hit, 100f))
        {

            Vector3 hitPos = hit.point;
            // 오브젝트 생성을 다른 오브젝트에 넣으면 된다.
            Z = Instantiate(obj);
            Z.transform.position = hitPos;
            //Z = obj;
        }
    }
}
