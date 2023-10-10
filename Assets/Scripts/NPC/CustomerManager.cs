using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CustomerManager : MonoBehaviour
{
    public static CustomerManager Instance = new CustomerManager();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        //씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않음
    }

    //변수 선언
    public GameObject[] target = new GameObject[3];     //손님 좌석 배열이지만, 여기서 순서를 정해줄 수 있다면? 왜 이동좌표만 해놨을까
    public float createTimer;                      //손님 생성 텀
    public float waitTimer = 50f;                        //손님 대기시간
    public bool[] targetCheck;                          //좌석에 손님 존재 여부 (false = 손님 없음 / true = 손님 존재)
    public bool noTarget = false;                       //빈 좌석 존재 여부 (false = 빈 좌석 존재 / true = 빈 좌석 없음)
    public int targetNum;                               //좌석 개수
    public Transform endTargetvec;                        //손님 퇴장 좌표
    public Transform createTargetvec;                     //손님 생성 좌표
    public bool[] orderCom;                             //주문 완료 여부 (false = 손님 대기중 / true = 주문 완료)
    public bool[] orderSuc;                             //주문 성공 여부 (false = 주문 실패 / true = 주문 성공)
    public Sprite[] numberImg = new Sprite[6];          //주문 출력 갯수 이미지

    public Sprite[] emg = new Sprite[2];                //반응 출력 이미지 ( [0] = 성공 / [1] = 실패)

    public class OrderSucTarget                             //음식을 받을 자리 배열 클래스
    {
        public int[] sucOrderType = new int[2];             //좌석마다 있는 손님이 한 주문 배열 ([0] = 고기만두 / [1] = 김치만두)
    }
    public OrderSucTarget[] orderSucTarget;                 //음식 받을 자리

    void Start()
    {
        //초기화
        targetNum = target.Length;
        orderSucTarget = new OrderSucTarget[targetNum];
        targetCheck = new bool[targetNum];
        orderCom = new bool[targetNum];
        orderSuc = new bool[targetNum];
        createTimer = 5f;

        for (int i = 0; i < targetNum; i++)
        {
            orderCom[i] = false;
            orderSuc[i] = false;
            targetCheck[i] = false;
        }
    }

    //함수 선언
    public bool RecipeCheck(int npcNum, bool[] customer)
    {
        return customer[npcNum] = false;
    }

}
