using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public  static float fSpeed;
    Vector2 vStartPos = new Vector2(0.0f, 0.0f); // 마우스를 클릭할시 마우스의 좌표
    Vector2 vEndPos = new Vector2(0.0f, 0.0f); // 마우스에서 손을 뗄 때의 마우스 좌표
    
    public static Vector2 vRePos = Vector2.zero;
    float fSwipeLenth = 0.0f; // 마우스로 스와이프를 한 길이  
    public static int nCount = 0; //남은 횟수
    
   

    GameObject gBtnRE; // 재시작 버튼
    // Start is called before the first frame update
    void Start()
    {
        this.gBtnRE = GameObject.Find("BtnRe"); //재 시작 버튼을 찾는다.
        vRePos = transform.position; // 자동차의 시작 위치를 저장
        fSpeed = 0.0f; //GameScene에 담길 초깃값
        
        nCount = 10; // start에서 초기화를 해 줘야 sceneLoad를 했을때 값이 초기화 된다.
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gBtnRE.activeSelf == false) // 버튼이 비활성화 상태일때만 안쓰면 버튼 누르는 즉시 아래 코드가 실행된다.
        {
            if (Input.GetMouseButtonDown(0))
            { //마우스를 클릭하면

                //this.fSpeed = 0.2f; // 자동차가 출발할 때 속도 초기값 쉽게 말해 기어1단 느낌
                this.vStartPos = Input.mousePosition; //마우스의 좌표를 startpos에 대입
            }
            else if (Input.GetMouseButtonUp(0))
            { // 마우스에서 손가락을 뗄 시
                this.vEndPos = Input.mousePosition; // 마우스의 좌표를 endPos에 대입한다.


                this.fSwipeLenth = this.vEndPos.x - this.vStartPos.x; // 종점 - 시점으로 스와이프한 거리를 구한다.
                fSpeed = this.fSwipeLenth / 500; // 스와이프한 x좌표의 길이가 너무커서 속도가 빠르기에 500을 나눠 속도를
                                                       // 최대한 낮춘다.
                GetComponent<AudioSource>().Play(); // 오디오소스 컴포넌트를 구하고 play메소드 호출한다.
        
                nCount--; // 횟수 감소
            }
        }

     
            transform.Translate(fSpeed, 0, 0); // translate는 현재 지점에서 그만큼 해당좌표로 이동시킨다. 
                                                    // 좌표를 변경하는 것이 아님
            fSpeed *= 0.98f;  // 점점 감속 시킨다.


    }
}
