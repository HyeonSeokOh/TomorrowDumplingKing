using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤 패턴을 사용하기 위한 인스턴스 변수
    private static GameManager _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static GameManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    // 변수 선언
    public GameObject[] prefabList = new GameObject[10];
    public Material[] dumplingColor = new Material[2];
    public GameObject[] NPCList = new GameObject[8];
    public GameObject[] SpNPCList = new GameObject[4];
    public GameObject[] checkLayer = new GameObject[2];
    public AudioSource[] audioSources = new AudioSource[99];
    public int FindMyWork;
    public GameObject player;
    public bool GameStart = false;
    public bool Grapping = false;
    public float playTime = 20f;
    public enum grapState { None, Kdumpling, dumpling};


    private int SelectNPCcount;
    // 함수 선언
    public int SelectNPC(GameObject[] GetNPCtype)
    {
        
        if(GetNPCtype == NPCList)
        {
            SelectNPCcount = Random.Range(0, NPCList.Length - 1);
        }
        else if(GetNPCtype == SpNPCList)
        {
            SelectNPCcount = Random.Range(0, SpNPCList.Length - 1);
        }

        return SelectNPCcount;
    }

    private void Update()
    {
        if (GameStart)
        {
            Time.timeScale = 1f;
            for (int i = 0; i > 2; i++)
            {
                checkLayer[i].gameObject.GetComponent<LayserPointer>().enabled = false;
            }
        }
        else
            Time.timeScale = 0f;
        for (int i = 0; i > 2; i++)
        {
            checkLayer[i].gameObject.GetComponent<LayserPointer>().enabled = true;
        }
    }

    public int FindRand(int ReturnValue,int MinValue,int MaxValue)
    {
        ReturnValue = Random.Range(MinValue, MaxValue);

        return ReturnValue;
    }


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
        DontDestroyOnLoad(gameObject);
    }
}

public class DumplingInfo : MonoBehaviour
{
    public DumplingInfo dumplingInfo;

    [HideInInspector]
    public int[] dumplingType = new int[5];
    [HideInInspector]
    public int myTable = 0;

}


