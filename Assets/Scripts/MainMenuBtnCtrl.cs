using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;            //타임라인 쓸려면 필요한것
public class MainMenuBtnCtrl : MonoBehaviour
{
    #region public
    public GameObject MainPaenl;        //메인 메뉴 판넬
    public GameObject OptionPaenl;      //옵션 판넬
    public GameObject EndPaenl;         //게임 오버 판넬
    public PlayableDirector playable;   //타임라인을 담기위한 변수
    public Text timeText;               //타이머 텍스트
    public static MainMenuBtnCtrl instance;
    #endregion 

    //#region bool
    //bool GameStart = false;             //게임상태 =false
    //#endregion
    
    #region private
    private float time;
    #endregion


    private void Awake()
    {
        instance = this;
        time = GameManager.Instance.playTime;                 //초기 시간을 10초로 정의(이건 게임 시간 정하면 바꾸면 됨)
                                        //시간을 바꾸면 타임라인에서도 시간 조정 필요
    }

    private void Update()
    {
        Timer();                        //타이머 실행
    }

    #region timer
    public void Timer()
    {
        if (GameManager.Instance.GameStart == true)         //게임시작이나 다시시작 버튼을 누르면 GameStart =true
        {
            if (time > 0)
            {
                time -= Time.deltaTime; //시간이 흐름
            }

            timeText.text = Mathf.Ceil(((int)time)).ToString(); //타이머 텍스에 시간을 정수형태로 바꿔서 스트링 형변환

            if (Mathf.Ceil(((int)time)) == 0)           //타이머가 0초 =게임이 끝날때
            {
                GameManager.Instance.GameStart = false;                      //게임의 상태=false;
                EndPaenl.SetActive(true);               //게임오버 판넬 활성화
                Time.timeScale = 0;
            }
        }
    }
    #endregion

    #region BtnCtrl
    public void ClickGameStart()
    {
        MainPaenl.SetActive(false);
        GameManager.Instance.GameStart = true;
        timeText.gameObject.SetActive(true);
        playable.Play();                                //platable.play() 이것이 타임라인을 실행시키는 함수
        GameManager.Instance.GameStart = true;

    }
    public void ClickOption()
    {
        MainPaenl.SetActive(false);
        OptionPaenl.SetActive(true);
    }
    public void ClickExit()
    {
        Application.Quit();
    }

    public void ClickBackBtn()
    {
        OptionPaenl.SetActive(false);
        MainPaenl.SetActive(true);
    }
    public void ClickReplayBtn()
    {
        EndPaenl.SetActive(false);
        GameManager.Instance.GameStart = true;
        playable.Play();
        time = GameManager.Instance.playTime;
    }
    public void GotoMain()
    {
        time = GameManager.Instance.playTime;
        EndPaenl.SetActive(false);
        MainPaenl.SetActive(true);
        timeText.gameObject.SetActive(false);
    }
    #endregion
}



