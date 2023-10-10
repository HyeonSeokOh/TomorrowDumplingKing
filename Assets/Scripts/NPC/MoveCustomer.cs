using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCustomer : DumplingInfo
{

    public int randTarget;                     //손님이 타겟으로 잡을 랜덤 좌석 번호
    private Vector3 randTargetvec;              //손님이 타겟으로 잡은 랜덤 좌석 좌표
    private bool customerGoal = false;          //손님의 좌석 도착 여부 (false = 이동중 / true = 도착)
    private int RandomSpeed;                    //손님의 랜덤 스피드
    private float waitTimer;                    //손님 대기시간 임시저장
    private int[] orderType = new int[2];       //주문 종류 ([0] = 고기만두 / [1] = 김치만두)
    private Transform lookPos;                  //바라볼 방향
    private Animator ani;                       //애니메이터
    [SerializeField]
    private Canvas can;                         //손님 캔버스
    [SerializeField]
    private Image img;                          //손님 대기 타이머 출력 이미지
    [SerializeField]
    private Image[] orderImg = new Image[2];    //주문 갯수 출력 ([0] = 고기만두 / [1] = 김치만두)
    [SerializeField]
    private Image[] manduImg = new Image[2];    //주문 갯수 출력 ([0] = 고기만두 / [1] = 김치만두)
    [SerializeField]
    private Image cum;          //성공반응


    private Camera cameraToLookAt; //메인 카메라
 
    public int orderSucces = 0;
    private float ResponseOutput = 0f;

    

    void Start()
    {
        this.gameObject.GetComponent<Animator>();
        ani = GetComponent<Animator>();
        waitTimer = CustomerManager.Instance.waitTimer;
        cameraToLookAt = Camera.main;
        RandomTarget();
        CustomerOrder();
        ArrangeOrderType();
        orderImg[0].sprite = CustomerManager.Instance.numberImg[orderType[0]];
        orderImg[1].sprite = CustomerManager.Instance.numberImg[orderType[1]];

        //for(int i = 0; i < orderType.Length; i++)
        //{
        //    CustomerManager.Instance.orderSucTarget[randTarget].sucOrderType[i] = orderType[i];         //좌석별 손님 주문 저장
        //}
    }

    void RandomTarget()
    {//좌석 결정 함수
        randTarget = Random.Range(0, CustomerManager.Instance.targetNum);
        if (CustomerManager.Instance.targetCheck[randTarget]) //랜덤으로 정해진 좌석에 손님이 있으면
        {
            RandomTarget(); //함수 재실행
        }
        else
        {
            lookPos = CustomerManager.Instance.target[randTarget].transform;
            randTargetvec = CustomerManager.Instance.target[randTarget].transform.position;  //타겟 좌표를 선택된 좌석 좌표로
            CustomerManager.Instance.targetCheck[randTarget] = true;  //선택된 좌석이 빈 자리가 아닌 것으로 체크
        }
    }

    void ComeCustomer()
    { 
        if (!customerGoal)  //손님이 아직 도착하지 않았으면
        {
            transform.position = Vector3.MoveTowards(transform.position, randTargetvec, GameManager.Instance.FindRand(RandomSpeed, 1, 4) * Time.deltaTime); //손님 이동
            //이미지 끄기;
            can.gameObject.SetActive(false);
        }

        else if (customerGoal && orderSucces != 1)  //손님이 도착했으면
        {
            waitTimer -= Time.deltaTime;    //대기시간 카운트
                                            //+주문메뉴 이미지 출력;
            img.fillAmount = waitTimer/CustomerManager.Instance.waitTimer;  //타이머 출력
             can.gameObject.SetActive(true);    //캔버스 켜기
        }
    }

    void GoAwayCustomer()
    { //손님 퇴장 함수
        if (waitTimer <= 0 || orderSucces ==2) //타임오버시
        {
            //애니메이터 바꾸기
            for(int i = 0; i < 2; i++)
            {
                orderImg[i].gameObject.SetActive(false);
                manduImg[i].gameObject.SetActive(false);
            }
            cum.sprite = CustomerManager.Instance.emg[1];
            cum.gameObject.SetActive(true);
            OrderCom();

        }
        //else if (CustomerManager.Instance.orderCom[randTarget] && CustomerManager.Instance.orderSuc[randTarget]) //주문 성공시
        else if (orderSucces == 1)
        {
            //성공반응 출력
            for (int i = 0; i < 2; i++)
            {
                orderImg[i].gameObject.SetActive(false);
                manduImg[i].gameObject.SetActive(false);
            }
            cum.sprite = CustomerManager.Instance.emg[0];
            cum.gameObject.SetActive(true);
            OrderCom();
        }
    }

    void OrderCom()
    {
        ResponseOutput += Time.deltaTime;
        if (ResponseOutput > 1f)
        {
            can.gameObject.SetActive(false);    //캔버스 끄기
            ani.SetBool("customerWalk", true);
            transform.position = Vector3.MoveTowards(transform.position, CustomerManager.Instance.endTargetvec.transform.position, GameManager.Instance.FindRand(RandomSpeed, 1, 4) * Time.deltaTime);
            lookPos = CustomerManager.Instance.endTargetvec.transform;
        }
    }

    void CustomerOrder()
    {  //주문메뉴 결정함수
        int ordersum = 0; //주문 개수 총합 초기화

        for (int i = 0; i < 2; i++)
        {
            orderType[i] = Random.Range(0, 6);  //주문 랜덤 설정
            ordersum += orderType[i];
        }

        if (ordersum > 5 || ordersum == 0)  //주문을 안하거나 5개 초과면
        {
            CustomerOrder();    //재실행
        }

        ////테스트
        //orderType[0] = 2;
        //orderType[1] = 3;
    }

    void Update()
    {
        ComeCustomer();
        GoAwayCustomer();
        can.transform.LookAt(cameraToLookAt.transform.position);

        if (this.transform.position == randTargetvec)
        {
            customerGoal = true;
            lookPos = GameManager.Instance.player.transform;
            //애니메이터 바꾸기
            ani.SetBool("customerWalk", false);
        }
        if(this.transform.position == CustomerManager.Instance.endTargetvec.transform.position)
        {
            Destroy(this.gameObject);
            CustomerManager.Instance.targetCheck[randTarget] = false;
        }

        this.transform.LookAt(lookPos);
    }
    void ArrangeOrderType()
    {
        int meatType = 0;
        int kimchetype = 0;

        meatType = orderType[0]; //2
        kimchetype = orderType[1]; //2

        for (int i = 0; i < meatType; i++) //0,1
        {
            dumplingType[i] = 1;
        }
        for (int i = meatType; i < (meatType + kimchetype); i++)
        {
            dumplingType[i] = 2;
        }
    }
}
