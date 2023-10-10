using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text text_Timer; //타이머 출력할 텍스트
    private float LimitTime; //시간(타이머)
    public static bool GameEnd; //게임이 끝났는지
    bool Shutter_up; //셔터가 올려져 있는지

    public GameObject ShutterObject; //셔터 오브젝트 
    Vector3 uppos = new Vector3(0, 8, -7); //셔터가 올라갈 위치
    Vector3 downpos = new Vector3(0, 3, -7); //셔터가 내려갈 위치(원 위치)

    void Start()
    {
        LimitTime = 10; //10초
        GameEnd = true; //게임이 아직 시작을 안함(즉 게임이 끝난 상태)
        Shutter_up = false; //셔터가 안 올라감
    }


    void Update()
    {
        GameStart(); 

        if (Shutter_up == true) //셔터가 true라면
        {
            ShutterObject.transform.position = Vector3.Lerp(ShutterObject.transform.position, uppos, Time.deltaTime); //pos의 위치로 이동(셔터가 올라간다)
         
            Limit_Timer(); //게임이 시작됐으니 타이머가 돌아간다.
        }
        else if(Shutter_up == false)
        {
            ShutterObject.transform.position = Vector3.Lerp(ShutterObject.transform.position, downpos, Time.deltaTime);
        }
    }

    void Limit_Timer() //타이머
    {
        if (GameEnd == false) //게임이 시작 되었다면 
        {
            if (LimitTime > 0) //타이머 0 보다 크다면
            {
                LimitTime -= Time.deltaTime; //점점 줄인다
            }
            else if (LimitTime <= 0) //만약 0보다 작거나 같다면 (이걸 설정 안할 시 -1로 넘어간다.)
            {
                LimitTime = 0; 
                GameEnd = true; //게임이 끝남
                Shutter_up = false;//셔터 내림
            }
            text_Timer.text = ((int)LimitTime / 60).ToString() + "분 " + ((int)LimitTime % 60).ToString() + "초"; //분 , 초 출력
        }
    }

    void GameStart()
    {
        if (Input.GetKeyUp(KeyCode.Space)) //스페이스바를 누르면
        {
            Shutter_up = true; //셔터를 true로
            GameEnd = false; //셔터를 올렸으니 장사 시작(게임이 시작되어 false)
        }
    }

}
