using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumplingIn : MonoBehaviour //defg
{
    public GameObject obj;
    private GameObject Z;
    private void OnMouseDrag()
    {
        if (recipe.count > 0)
        {
            float Distance = 4f; // 이게 집었을때의 거리를 나타냄 아까는 10f라서 멀리 보였던 것.
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            if (Z)
            {
                Z.transform.position = objPosition;
            }
        }
    }

    private void OnMouseDown() //마우스의 위치에 오브젝트 생성
    {
        if (recipe.count > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 100f))
            {
                Vector3 hitPos = hit.point;
                // 오브젝트 생성을 다른 오브젝트에 넣으면 된다.
                Z = Instantiate(obj);
                Z.transform.position = hitPos;
                //Z = obj;
            }
            recipe.count--;
        }
    }

}
