using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemController : MonoBehaviour
{

    public enum E_ITEM_WITH_SCORE // 열거형 상수로 변수에 의미있는 스코어(상수)를 지정
    {
        Bronze = 50,    //코인들의 점수(상수)값 지정
        Silver = 100,
        Gold = 300
    }

    [SerializeField] // inspector창에서 아이템을 바꾸어 주기위하여 선언
    public E_ITEM_WITH_SCORE ITEM = E_ITEM_WITH_SCORE.Bronze; // 초기 값으로 가장많은 bronze로 enum 변수 선언

    //SpriteRenderer mySprite = GetComponent<SpriteRenderer>(); 이런식으로 변수저장 가능

    // Start is called before the first frame update
    void Start()
    {
        
       
        

        if (ITEM == E_ITEM_WITH_SCORE.Bronze)
        { //ITEM에 저장된 값이 Bronze라면
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Item/Bronze");
            //GetComponent<SpriteRenderer>()는 인스펙터창에서 spriterenderer로 접근한다는 뜻
            //.sprite로 SpriteRenderer의 sprite이미지에 접근
            //Resources.Load는 Resources폴더로 접근하여 폴더 안의 에셋에 접근할 수 있다.
            // 따로 project창에 Resources라는 폴더를 만들어 주어야 한다.
            // <에셋타입>("파일경로")

        }
        else if (ITEM == E_ITEM_WITH_SCORE.Silver)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Item/Silver");
        }
        else if (ITEM == E_ITEM_WITH_SCORE.Gold)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Item/Gold");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(0,2, 0); // 코인을 y축 방향으로 회전 시킨다.
    }
}
