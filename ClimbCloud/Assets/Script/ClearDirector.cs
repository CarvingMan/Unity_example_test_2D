using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //�ʿ�
using UnityEngine.SceneManagement; // LoadScene�� ����ϴµ� �ʿ��ϴ�.
 

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
            // ���� ���� �ҷ��´�.
            //public static�̱⿡ Ŭ������.�޼ҵ������ ȣ�� �԰����̴�.
        }

        this.gScore.GetComponent<Text>().text = "���� ���� : " + GameDirector.nScore;
       // Debug.Log(GameDirector.nScore);
    }
}
