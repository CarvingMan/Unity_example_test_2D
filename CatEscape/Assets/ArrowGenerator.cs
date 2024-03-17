using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    
    public GameObject arrowPrefab = null; // 프리펫을 담을 빈 상자
    GameObject go = null; // 프리팹을 인스턴스로 받을 오브젝트 상자
    GameObject gREbtn = null;
    
    int inPx = 0;

    [SerializeField]
    float fSpan = 1.0f; // 고정 1초
    [SerializeField]
    float delta = 0.0f; // 이곳에 프레임의 시간차를 저장
    // Start is called before the first frame update
    void Start()
    {
        this.gREbtn = GameObject.Find("ReSetButton");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gREbtn.activeSelf == false) // 애초에 버튼의 active가 true라면 프리팹이 생성 안된다.
        {                                    // 버튼을 활성화 시키는건 SetActive, 값을 가져오는건 ActiveSelf
            this.delta += Time.deltaTime; //프레임의 시간차를 복합대입저장

            //1초마다 프리팹 생성
            if (this.delta > this.fSpan)
            { // 프레임 시간차가 1 이상(측 1초이상)일시 
                this.delta = 0.0f; // delta를 다시 초기화
                go = Instantiate(arrowPrefab); // instantiate는 매개로 프리팹을 받아 인스턴스를 리턴 
                inPx = Random.Range(-9, 10); // 랜덤클래스의 range(범위)메소드로 -9 보다 크거나 작고 10 미만 
                go.transform.position = new Vector3(inPx, 7, 0); //transform 클래스의 position은 Vector3 형임
                                                                 // 클래스 안에 구조체형 그래서 new Vector3(inPx, 7, 0);
                                                                 //처럼 벡터 인스턴스를 줄 수 있다. 월드 좌표
                                                                 // x좌표를 랜덤으로 주겠다는 의미
            }
          
        }
        
       
    }

    public void DesArrow() {
       
            Destroy(go); // 프리팹을 지운다.
    }
}
