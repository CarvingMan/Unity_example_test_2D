using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject gHpGuage = null; // hp게이지
    GameObject gGameOver = null; // 게임오버텍스트
    GameObject gREbtn = null; // 리셋버튼
    GameObject gPlayer = null; // 플레이어
    GameObject ArrowGenerator = null; // 제너레이터
   
    void Start()
    {
        this.gHpGuage = GameObject.Find("hpGauge");
        this.gGameOver = GameObject.Find("GameOver");
        this.gREbtn = GameObject.Find("ReSetButton");
        this.gPlayer = GameObject.Find("player");
        this.ArrowGenerator = GameObject.Find("ArrowGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        // 텍스트와 버튼의 비활성화를 계속 해줘야 한다.
        gGameOver.SetActive(false);
        gREbtn.SetActive(false);

        if (gHpGuage.GetComponent<Image>().fillAmount == 0) {
            this.gREbtn.SetActive(true); // 만약 hp가 전부 달았으면 버튼을 활성화
            this.gGameOver.SetActive(true); // 게임오버 텍스트도 활성화 
        }
    }

    public void DecreseHp() {
        this.gHpGuage.GetComponent<Image>().fillAmount -= 0.1f;
    }

    public void Reset() // 버튼을 누를 시 호출할 함수
    {
        this.gHpGuage.GetComponent<Image>().fillAmount = 1; // 체력을 초기화
        this.gPlayer.GetComponent<PlayerController>().RePos(); // 플레이어의 위치 초기화
        this.ArrowGenerator.GetComponent<ArrowGenerator>().DesArrow(); // 제너레이터에 화살 프리팹 지우는 함수 호출
    }
}
