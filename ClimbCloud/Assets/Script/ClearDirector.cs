using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //필요
using UnityEngine.SceneManagement; // LoadScene를 사용하는데 필요하다.
 

public class ClearDirector : MonoBehaviour
{
    GameObject gScore = null;
   // GameObject gDirector = null;
   
    // Start is called before the first frame update
    void Start()
    {
        gScore = GameObject.Find("Score");
        //gDirector = GameObject.Find("GameDirector");
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("GameScene");
            // 게임 씬을 불러온다.
            //public static이기에 클래스명.메소드명으로 호출 쌉가능이다.
        }

        this.gScore.GetComponent<Text>().text = "최종 점수 : " + GameDirector.nScore;
       // Debug.Log(GameDirector.nScore);
    }
}
