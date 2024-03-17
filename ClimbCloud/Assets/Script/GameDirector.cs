using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject gScore = null;
   
    
    public static int nScore; //���� Ŭ���� ������ �ҷ����� 
    // Start is called before the first frame update
    void Start()
    {
        nScore = 0;
        this.gScore = GameObject.Find("Score"); //Score ui�� ������
     
    }

    // Update is called once per frame
    void Update()
    {
       
        this.gScore.GetComponent<Text>().text = "Score : " + nScore; // ���� ǥ��
    }

    public void UpScore(int score) {
        nScore += score; // ������ �ø���.
    }
}
