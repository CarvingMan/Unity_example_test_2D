using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    GameObject gPlayler = null;
    
    GameObject gHP = null;
    Vector2 vArrow = Vector2.zero;  //벡터 초기화
    Vector2 vPlayer = Vector2.zero;
    Vector2 vDir = Vector2.zero;
    float fDir = 0.0f;
    float fR1 = 0.0f;
    float fR2 = 0.0f;
   


    // Start is called before the first frame update
    void Start()
    {
        this.gPlayler = GameObject.Find("player"); //플레이어 오브젝트를 연결
        
        this.gHP = GameObject.Find("hpGauge");
    }


    // Update is called once per frame
    void Update()
    {
        if (gHP.GetComponent<Image>().fillAmount > 0) // hp가 0보다 클시만 낙하 같거나 작을시 멈춘다.
        {
            transform.Translate(0, -0.1f, 0); // 프레임마다 등속으로 낙하시킨다.
        }
        
        //화면 밖으로 나오면 오브젝트를 소멸시킨다. 또는 버튼이 활성화 되면 소멸
        if (transform.position.y < -5.0f) {
            Destroy(gameObject); // 매개변수로 전달한 오브젝트를 삭제
        }
        

        //충돌판정
        this.vArrow = transform.position;       //화살의 중심좌표
        this.vPlayer = this.gPlayler.transform.position; //캐릭터의 중심좌표
        this.vDir = vArrow - vPlayer; // 종점 - 시점
        this.fDir = vDir.magnitude;  // 길이
        this.fR1 = 0.5f;    //화살의 반경
        this.fR2 = 1.0f;    // 플레이어의 반경

        if(fDir < fR1 + fR2) // 두 중점의 거리가 각 반지름의 합 보다 작을시 충돌이다.
        {   // 감독 스크립트에 플레이어와 화살이 충돌했다고 전달한다.
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreseHp();
            Destroy(gameObject); //충돌시 화살 삭제
        }
    }
}
