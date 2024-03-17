using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    GameObject gREbtn = null; 

   private bool RBtnOn = false; //버튼이 눌려 있는지
   private bool LBtnOn = false;

    private Vector3 vStartPos = Vector3.zero; // 처음위치
    void Start()
    {
        this.gREbtn = GameObject.Find("ReSetButton");
        vStartPos = transform.position; //재시작할 때를 위한 초반 위치를 Start에서  vStartPos에 담아둔다.
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gREbtn.activeSelf == false) // 애초에 버튼의 active가 true라면 translate가 불가
        {                                    // 버튼을 활성화 시키는건 SetActive, 값을 가져오는건 ActiveSelf
            //왼쪽 화살표를 누르고 있는 동안
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -9) //카메라의 위치를 벗어나서는 안되기에 -9이상일때 이다.
            { //KeyCode는 enum(열거형 상수)에서 아스키 코드값을 지정해 놓은 것으로 보인다.
                transform.Translate(-0.3f, 0, 0); // 왼쪽으로 '3' 움직인다.
            }



            //오른쪽 화살표를 누르고 있는 동안
            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 9)
            {
                transform.Translate(0.3f, 0, 0); // 오른쪽으로 '0.5' 움직인다.
            }

            if (RBtnOn == true)
            {
                transform.Translate(0.3f, 0, 0); // 오른쪽으로 '0.5' 움직인다.
            }


            if (LBtnOn == true)
            {
                transform.Translate(-0.3f, 0, 0); // 왼쪽으로 '0.5' 움직인다.
            }


            float fClampPos = Mathf.Clamp(transform.position.x, -9.0f, 9.0f);


            // Mathf의 Clamp 메소드 () 안에 순서대로 변수가, 최소값, 최대값 사이에서만 값을 지정할 수 있게 제한한다.
            //예를 들어 해당 변수의 값이 최대값을 넘기는 순간 자동으로 최대값으로 다시 반환한다. 반대도 마찬가지
            // transform.position의 x값을 -9 에서 9로 고정하여 메인카메라 밖으로 나가지 않도록 하는 것

            transform.position = new Vector3(fClampPos, transform.position.y, transform.position.z);
            // 그리고 포지션 위치를 새로운 벡터로 x값을 위의 fClampPos로 대입하여 업데이트 해 준다.
            // 기본적으로 fClampPos와 위의 transform.position.x의 값은 같지만 만일 
            // 캐릭터가 -9이하 9이상으로 x값이 Translate된다면 fClampPos에서 Clamp 메소드로 고정한 최대값, 최소값으로
            // 되돌린다.        나머지는 transform.position.y, transform.position.z 그대로 업데이트 해 준다.
        }
    }


    public void RePos() // 플레이어의 위치를 초기화
    {
        transform.position = vStartPos; // start메소드에서 시작할 때 담아놓은 포지션으로 초기화
    }
    public void RBtnUp() 
    {
        this.RBtnOn = false;  // PointerUp일시 false를 반환
    }

    public void RBtnDown()
    {
        this.RBtnOn = true;  // PointerDown일시 true를 반환
    }

    public void LBtnDown() {
        this.LBtnOn = true;
    }

    public void LBtnUp()
    {
        this.LBtnOn = false;
    }

    /*  public void LButtonDown() {
          transform.Translate(-3, 0, 0);
      }

      public void RButtonDown()
      {
          transform.Translate(3, 0, 0);
      }
    */
}
