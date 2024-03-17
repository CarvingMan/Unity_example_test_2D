using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject gScore = null;
   
    
    public static int nScore; //점수 클리어 씬에서 불러오기 
    // Start is called before the first frame update
    void Start()
    {
        nScore = 0;
        this.gScore = GameObject.Find("Score"); //Score ui를 가져옴
     
    }

    // Update is called once per frame
    void Update()
    {
       
        this.gScore.GetComponent<Text>().text = "Score : " + nScore; // 점수 표시
    }

    public void UpScore(int score) {
        nScore += score; // 점수를 올린다.
    }
}
