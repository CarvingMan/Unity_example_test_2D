using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 반드시 임포트를 해야 한다. UI관련
using UnityEngine.SceneManagement; //유니티 scene을 불러오기 위해 사용

public class GameDirector : MonoBehaviour
{// 감독 스크립트 
    //UI를 갱신
    GameObject gCar;  //GameObject형 변수 선언
    GameObject gFlag; // 컴포넌트를 담을 빈 상자를 만든 것과 같다.
    GameObject gDitance;
    GameObject gScoreUI;
    GameObject gChance;
    GameObject gBtnRE;



    float fLength = 0.0f;
    float fDelta = 0.0f; //한 프레임에 걸리는 시간을 담을 변수
    int nScore = 0; // 점수
   

    public void ReStart()
    { //버튼을 눌렀을때 실행되는 함수

        nScore = 0; //점수 초기화        

        SceneManager.LoadScene("GameScene"); // LoadScene 메소드를 사용하여 초기에 저장된
                                             // GameSene를 불러온다 

    }

    void ReposCar() //차 위치 초기화 함수
    {
        
            this.gCar.transform.position = CarController.vRePos; //차동차의 위치를 처음으로 돌린다.   
            
            
        
    }

    //점수 증가
    void UpScore() {

        
            nScore += 10; //10점 증가
        
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gCar = GameObject.Find("car"); // UnityEngine에서 제공하는 Find메소드
        this.gFlag = GameObject.Find("flag"); // 유니티 씬의 오브젝트를 인수값으로 찾아 
        this.gDitance = GameObject.Find("Distance"); // GameObject의 변수와 연결해 주는 문장이다.
        this.gScoreUI = GameObject.Find("ScoreUI");
        this.gChance = GameObject.Find("Chance");
        this.gBtnRE = GameObject.Find("BtnRe");
    }

    // Update is called once per frame
    void Update()
    {
        gBtnRE.SetActive(false);

        fLength = this.gFlag.transform.position.x - this.gCar.transform.position.x;
        //                     깃발의 좌표              -      자동차의 좌표 
        //                    = 목표지점까지의 남은 거리


        //폰트 사이즈와 색상 초기화
        this.gDitance.GetComponent<Text>().color = Color.black; //색상 변경 color는 unityengine
                                                                //네임스페이스에 포함
        this.gDitance.GetComponent<Text>().fontSize = 64;   //폰트 사이즈

        this.gDitance.GetComponent<Text>().text = "목표지점까지" + fLength.ToString("F2") + "m";
        this.gChance.GetComponent<Text>().text = "남은 기회: " + CarController.nCount.ToString("D2");
        this.gScoreUI.GetComponent<Text>().text = "점수 : " + nScore.ToString();
        // text컴포넌트를 사용하여 distance오브젝트의 텍스트 변경
        // fLength(남은거리)
        //ToString() 메소드는 값을 문자열로 변환해 준다.
        //인수 값으로 F2는 F(고정 소수점형).2(자리수)   => 즉 실수형 값을 소수점 둘 째 자리까지
        //                                               문자열로 변환 (정수형은D이다.)

        if (CarController.fSpeed <= 0.001f) //차의 속도가 0.001과 같거나 작다면
        {

            CarController.fSpeed = 0.0f; // 속도는 0이되지 않기에 다시 초기화해야 멈춘다.


            if (CarController.nCount <= 0) //횟수가 0이면
            {
                this.gDitance.GetComponent<Text>().text = "게임 끝!";
                this.gScoreUI.GetComponent<Text>().text = "점수 : " + ToString();
                this.gChance.GetComponent<Text>().text = "남은 기회: " + CarController.nCount.ToString("D2");
                gBtnRE.SetActive(true); //초기화 버튼을 활성화
            }



            if (fLength > 1.5 && gCar.transform.position.x != CarController.vRePos.x) // 깃발에 도달하지 못하였을때
            {
                this.gDitance.GetComponent<Text>().fontSize = 180;// 폰트 사이즈 변경
                this.gDitance.GetComponent<Text>().color = Color.red; //색상 변경 color는 unityengine
                                                                      //네임스페이스에 포함
                this.gDitance.GetComponent<Text>().text = "ㅎ..";

                fDelta += Time.deltaTime; // 한 프레임에 걸리는 시간을 담는다.
                if (fDelta >= 1.0f) //만약 fDelta가 1초 이상이 되면
                {
                    fDelta = 0.0f; //초기화
              
                    ReposCar(); //차 위치 초기화
                }
         
            }
            else if (fLength >= -1.5 && fLength <= 1.5)
            { //남은 거리가 1 이하 -1 이상 이라면



                this.gDitance.GetComponent<Text>().fontSize = 180;
                this.gDitance.GetComponent<Text>().color = Color.yellow; //색상 변경 color는 unityengine
                                                                         //네임스페이스에 포함
                this.gDitance.GetComponent<Text>().text = "성공!";
                fDelta += Time.deltaTime; // 한 프레임에 걸리는 시간을 담는다.
                if (fDelta >= 1.0f) //만약 fDelta가 1초 이상이 되면
                {
                    fDelta = 0.0f; //초기화
                    UpScore(); //점수 증가
                    ReposCar(); //차 위치 초기화
                }
            }
            else if (fLength < -1.5f)
            { // 지나치면  

                this.gDitance.GetComponent<Text>().fontSize = 180;//폰트 사이즈 변경

                this.gDitance.GetComponent<Text>().color = Color.red; //색상 변경 color는 unityengine
                                                                      //네임스페이스에 포함
                this.gDitance.GetComponent<Text>().text = "ㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋ";

                fDelta += Time.deltaTime; // 한 프레임에 걸리는 시간을 담는다.
                if (fDelta >= 1.0f) //만약 fDelta가 1초 이상이 되면
                {
                    fDelta = 0.0f; //초기화
                    ReposCar(); //차 위치 초기화
                }

            }

        }

    }

}


/*
     컴포넌트 : 오브젝트가 가지고 있는 설정자료로 보인다. 오브젝트의 요소?
                종류로는 Text, Transform, AudioSource, Ragidbody(물리적으로 움직임)등이 있다.
       
    형식 :    Game오브젝트라는 빈 상자에 컴포넌트를 추가하고 GetComponent 메소드를 사용하여
              <>꺽쇠 안에 원하는 컴포넌트를 넣어 사용한다.
                
                *꺽쇠 안에들어가는 컴포넌트는 클래스 형식으로 되어 있는거 같아 보여 꺽쇠 뒤에
                 원하는 메소드를 호출하여 사용할 수 있는 것 처럼 보인다.
                 GetComponent<AudioSource>().Play();

                ps. GetComponent메소드는 
                    UnityEngin 의 NameSpace -> GameObject class 의 메소드이다.
                
                    namespace는 함수나 구조체 혹은 변수 이름 등의 소속 (구조체 또는 함수의 
                        이름이 같아 충돌하는 것을 방지)

 */