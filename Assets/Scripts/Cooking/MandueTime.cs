using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MandueTime : MonoBehaviour
{
    //재료가 만들어지고 사라지는 시간 스크립트 입니다
    //그냥 15초로 늘리는 것을 선택하였습니다

    private float times; //생성된 재료의 사라질 시간
    private static bool DragOn; //드래그 상태인지
    private float times1; //생성된 재료의 사라질 시간


    private void Start()
    {
        times = 15f; //4초
        DragOn = false;
    }

    // Update is called once per frame
    private void Update() 
    {
        if (times > 0) //0초가 될때까지 
        {
            times -= Time.deltaTime;
        }
        else if (times <= 0) //만약 0이거나 0보다 작다면
        {
            Destroy(this.gameObject); //오브젝트 삭제
        }

        //Debug.Log(times1);
        //if (Player.Check)
        //{
            //if (Input.GetMouseButton(0)) //누르고 있는 상태라면
            //{
            //    DragOn = true; //드래그를 true로
            //    Debug.Log("누르고있다!");
            //}

            //if (Input.GetMouseButtonUp(0)) //마우스를 뗀 상태라면
            //{
            //    DragOn = false; //드래그를 false로 
            //    Debug.Log("누르고있지 않다!");
            //    manduDelete(); //만두 삭제 함수를 불러온다
            //}
            //times1 += Time.deltaTime;
            //if(times1 > 10f)
            //{
            //    Destroy(gameObject);
            //}

        //}
    }
}
// 함수(오브젝트 만두)
//{
     
//}
