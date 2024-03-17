
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float fRotSpeed = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        
        if (Input.GetMouseButtonDown(0)) { //클릭된 순간에 한번만 true값 반환 인수가 0 왼쪽클릭 1이면 오른쪽 2는 휠
            this.fRotSpeed = 40; // 사실 스피드가 아니라 각도로 생각되지만 update메소드 이기에 한 프레임에 40도씩 
                                 // 움직이는 느낌
                                 // 즉 한번 마우스 좌클릭을 할 시 초기값을 다시 40으로 만든다.
        }

        transform.Rotate(0, 0, this.fRotSpeed); // z축 방향으로 회전 10도씩 한 프레임에 움직인다.

        this.fRotSpeed *= 0.99f; // 매프레임 마다 감쇠계수를 곱하여 조금씩 멈추게 한다.
                                 // 정수로 빼는 것은 선형적으로 감소하기에 물리적으로 부자연스럽다.
                                 // 예상으론 감소를 하다가 소수점의 float이 담을수 없은 자리수
                                 //EX) 0.00000000000645243242....같은경우 0이 되어 멈추는 것 같다. 질문!
   
      
    }
}
