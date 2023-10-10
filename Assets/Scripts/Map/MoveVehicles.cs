using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVehicles : MonoBehaviour
{
    public GameObject Car;
    public Transform EndPosition;
    public int startTime;

    private int CarSpeed;
    private bool CheckEnd = false;
    private void Start()
    {
        Invoke("StartTime", startTime);
    }

    private void Update()
    {
        if (CheckEnd)
        {
            Car.transform.position = Vector3.MoveTowards(Car.transform.position, EndPosition.transform.position, GameManager.Instance.FindRand(CarSpeed,4,30) * Time.deltaTime);
        }

        if (Car.transform.position == EndPosition.transform.position)
        {
            CheckEnd = false;
            Car.transform.position = this.transform.position;
            CheckEnd = true;
        }
    }


    private void StartTime()
    {
        Car.transform.position = this.transform.position;
        CheckEnd = true;

    }





    //public GameObject[] CarList = new GameObject[6]; // 차량이 있는 오브젝트 배열
    //public Transform StartPos01, StartPos02, StartPos03, StartPos04,
    //    EndPos01,EndPos02,EndPos03,EndPos04; // 각 차선 시작 끝점 위치

    //private GameObject Line01, Line02, Line03, Line04; // 각 차선을 움직일 게임 오브젝트
    //private Vector3 RotateInfo, DefRotate;
    //private int FindCar, CarSpeed;
    //private bool EndCheck01, EndCheck02, EndCheck03, EndCheck04 = false;
    //void Start()
    //{
    //    Line01 = CarList[SelectCar()];
    //    Line02 = CarList[SelectCar()];
    //    Line03 = CarList[SelectCar()];
    //    Line04 = CarList[SelectCar()];
    //    OverlapCar();

    //    SetStartPos(1);
    //    SetStartPos(2);
    //    SetStartPos(3);
    //    SetStartPos(4);

    //    EndCheck01 = true;
    //    EndCheck02 = true;
    //    EndCheck03 = true; 
    //    EndCheck04 = true;
    //}

    //void Update()
    //{
    //    Debug.Log(Line01);
    //    Debug.Log(Line02);
    //    Debug.Log(Line03);
    //    Debug.Log(Line04);

    //    EndCheck();
    //    if (EndCheck01) { Line01.transform.position = Vector3.MoveTowards(Line01.transform.position, EndPos01.transform.position, RandomCarSpeed() * Time.deltaTime); };
    //    if (EndCheck02) { Line02.transform.position = Vector3.MoveTowards(Line02.transform.position, EndPos02.transform.position, RandomCarSpeed() * Time.deltaTime); };
    //    if (EndCheck03) { Line03.transform.position = Vector3.MoveTowards(Line03.transform.position, EndPos03.transform.position, RandomCarSpeed() * Time.deltaTime); };
    //    if (EndCheck04) { Line04.transform.position = Vector3.MoveTowards(Line04.transform.position, EndPos04.transform.position, RandomCarSpeed() * Time.deltaTime); };

    //}
    //int SelectCar()
    //{
    //    FindCar = Random.Range(0, 6);
    //    return FindCar;
    //}

    //int RandomCarSpeed()
    //{
    //    CarSpeed = Random.Range(0, 30);
    //    return CarSpeed;
    //}

    //void OverlapCar()
    //{
    //    for (int i = 0; i <= CarList.Length; i++)
    //    {
    //        if (Line01 == Line02 || Line01 ==Line03 || Line01 == Line04)
    //        {
    //            Line01 = CarList[i + 1];
    //            if (Line01 == CarList[5]) { Line01 = CarList[0]; OverlapCar(); };
    //        }
    //        else if(Line02 == Line01 || Line02 == Line03 || Line02 ==Line04)
    //        {
    //            Line02 = CarList[i + 1];
    //            if (Line02 == CarList[5]) { Line02 = CarList[0]; OverlapCar(); };
    //        }
    //        else if (Line03 == Line01 || Line03 == Line02 || Line03 == Line04)
    //        {
    //            Line03 = CarList[i + 1];
    //            if (Line03 == CarList[5]) { Line03 = CarList[0]; OverlapCar(); };
    //        }
    //        else if (Line04 == Line01 || Line04 == Line02 || Line04 == Line03)
    //        {
    //            Line04 = CarList[i + 1];
    //            if (Line04 == CarList[5]) { Line04 = CarList[0]; OverlapCar(); };
    //        }
    //    }

    //} //  사용중이지 않는 자동차 찾기

    //void SetStartPos(int FindLine)
    //{

    //    switch (FindLine)
    //    {
    //        case 01:
    //            Line01.transform.position = StartPos01.transform.position;
    //            Line01.transform.Rotate(0, 0, 0);
    //            EndCheck01 = true;
    //            break;
    //        case 02:
    //            Line02.transform.position = StartPos02.transform.position;
    //            Line02.transform.Rotate(0, 0, 0);
    //            EndCheck02 = true;
    //            break;
    //        case 03:
    //            Line03.transform.position = StartPos03.transform.position;
    //            Line03.transform.Rotate(0, 180, 0);
    //            EndCheck03 = true;
    //            break;
    //        case 04:
    //            Line04.transform.position = StartPos04.transform.position;
    //            Line04.transform.Rotate(0, 180, 0);
    //            EndCheck04 = true;
    //            break;
    //    }

    //} //시작지점 이동

    //void EndCheck()
    //{
    //    if(Line01.transform.position == EndPos01.transform.position)
    //    {
    //        EndCheck01 = false;
    //        Line01 = CarList[SelectCar()];
    //        OverlapCar();
    //        SetStartPos(1);
    //    }
    //    else if(Line02.transform.position ==EndPos02.transform.position)
    //    {
    //        EndCheck02 = false;
    //        Line02 = CarList[SelectCar()];
    //        OverlapCar();
    //        SetStartPos(2);

    //    }
    //    else if(Line03.transform.position ==EndPos03.transform.position)
    //    {
    //        EndCheck03 = false;
    //        Line03 = CarList[SelectCar()];
    //        OverlapCar();
    //        SetStartPos(3);

    //    }
    //    else if(Line04.transform.position ==EndPos04.transform.position)
    //    {
    //        EndCheck04 = false;
    //        Line04 = CarList[SelectCar()];
    //        OverlapCar();
    //        SetStartPos(4);
    //    }
    //} // 도착 체크
}
