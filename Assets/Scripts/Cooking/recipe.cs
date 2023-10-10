using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class recipe : MonoBehaviour
{
    public static bool checkTrigger = false;
    public Image shaking;

    [SerializeField]
    private int maxlnside; //최대로 재료를 넣을 수 있는 인터


    private List<string> ManduInside = new List<string>(); //스트링 형식 정보 교환
    private bool[] RecipeCheck = new bool[5]; //속에 들어간 체크
    private float fTime; //2초 동안 누르기 담당 변수
    private bool doubleCheck = false; //2초 동안 누리기 담당 변수 2
    private enum State { emtpy, kimchi, gogi};
    State state;

    public static int count = 0;

    bool on = false;


    // ---- 재료 프리팹들 -----------------------------------------

    public GameObject[] ManduPre = new GameObject[7]; //만두 재료 프리팹
    //순서: 김치 / 고기 / 부추 / 당면 / 간장 / 김치 속 / 고기 속


    void Start()
    {
        for (int i = 0; i < RecipeCheck.Length; i++) //배열의 크기만큼 반복
        {
            RecipeCheck[i] = false;//flase로 초기화
        }
        for (int j = 0; j < RecipeCheck.Length; j++)
        {
            ManduPre[j].SetActive(false);
        }
        state = State.emtpy;
        //shaking = gameObject.GetComponent<Image>();
    }

    //충돌한 태그가 각각 재료일 경우 그 재료의 오브젝트 setActive를 켜줍니다

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Kimchi")
        {
            AddString("김치");
            ManduPre[0].SetActive(true);
            Destroy(other.gameObject.GetComponentInParent<FixedJoint>());
            Destroy(other.gameObject);
        }
        if (other.tag == "Meat")
        {
            AddString("고기");
            ManduPre[1].SetActive(true);
            Destroy(other.gameObject.GetComponentInParent<FixedJoint>());
            Destroy(other.gameObject);
        }
        if (other.tag == "Leek")
        {
            AddString("부추");
            ManduPre[2].SetActive(true);
            Destroy(other.gameObject.GetComponentInParent<FixedJoint>());
            Destroy(other.gameObject);
        }
        if (other.tag == "Noodle")
        {
            AddString("당면");
            ManduPre[3].SetActive(true);
            Destroy(other.gameObject.GetComponentInParent<FixedJoint>());
            Destroy(other.gameObject);
        }

    }

    void Update()
    {
        if (ManduPre[4].activeSelf == true && !on)
        {
            on = true;
            AddString("간장");
        }

        if (checkTrigger)
        {
            fTime =fTime+ (Time.deltaTime)/2;
            shaking.fillAmount = fTime;
            Debug.Log("진입");
            if (!doubleCheck && fTime >= 1f)
            {
                CheckList();
                ManduMenu();
                doubleCheck = true;
            }
        }
        else
        {
            doubleCheck = false;
            fTime = 0f;
            shaking.fillAmount = 0;
        }

        if(state == State.emtpy)
        {
            return;
        }
        
        else if (state == State.kimchi && count == 0)
        {
            ManduPre[5].SetActive(false);
        }
        else if (state == State.gogi && count == 0)
        {
            ManduPre[6].SetActive(false);
        }

    }


    void AddString(string inputString) //string형식을 리스트에 넣는다
    {
        if (count > 0)
        {
            return;
        }
        else if (count == 0)
        {
            if (maxlnside > ManduInside.Count) //만두의 최대 갯수가 들어있는 재료 갯수보다 크다면(아직 자리가 있다면)
            {
                if (!ManduInside.Contains(inputString)) //안에 재료가 들어있지 않다면
                {
                    ManduInside.Add(inputString); //생성
                }
                else
                {
                     //재료가 중복일 시 나온다
                }
            }
            else
            {
                //재료가 꽉 찼을 시 나온다.
            }
        }
    }


    void CheckList()
    {
        for (int i = 0; i <= ManduInside.Count - 1; i++) //어떤 재료가 들어갔는지 체그
        {
            switch (ManduInside[i])
            {
                case "김치":
                    RecipeCheck[0] = true;
                    break;
                case "고기":
                    RecipeCheck[1] = true;
                    break;
                case "부추":
                    RecipeCheck[2] = true;
                    break;
                case "당면":
                    RecipeCheck[3] = true;
                    break;
                case "간장":
                    RecipeCheck[4] = true;
                    break;

            }
        }
    }

    void ManduMenu() //체크된 배열에 따라 레시피를 비교하여 만든다.
    {
        if (RecipeCheck[0] && RecipeCheck[1] && RecipeCheck[2] && RecipeCheck[3] && RecipeCheck[4]) //김치만두 레시피
        {
            state = State.kimchi;
            count = 5;
            //김치만두 오브젝트 켜기
            ManduPre[5].SetActive(true);
            //재료 오브젝트 끄기
            ManduPre[0].SetActive(false);
            ManduPre[1].SetActive(false);
            ManduPre[2].SetActive(false);
            ManduPre[3].SetActive(false);
            ManduPre[4].SetActive(false);

            on = false;

        }
        else if (RecipeCheck[1] && RecipeCheck[2] && RecipeCheck[3] && RecipeCheck[4]) //고기만두 레시피
        {
            state = State.gogi;
            count = 5;

            //고기만두 오브젝트 켜기
            ManduPre[6].SetActive(true);
            //재료 오브젝트 끄기
            ManduPre[1].SetActive(false);
            ManduPre[2].SetActive(false);
            ManduPre[3].SetActive(false);
            ManduPre[4].SetActive(false);

            on = false;

            //GameObject mt = Instantiate(GogiMandu);
        }
        else
        {
            //실패 이미지 출력
        }

        ManduInside = new List<string>();
        for (int i = 0; i < RecipeCheck.Length; i++) //초기화
        {
            RecipeCheck[i] = false;
        }
    }
}