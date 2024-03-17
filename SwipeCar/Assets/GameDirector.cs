using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // �ݵ�� ����Ʈ�� �ؾ� �Ѵ�. UI����
using UnityEngine.SceneManagement; //����Ƽ scene�� �ҷ����� ���� ���

public class GameDirector : MonoBehaviour
{// ���� ��ũ��Ʈ 
    //UI�� ����
    GameObject gCar;  //GameObject�� ���� ����
    GameObject gFlag; // ������Ʈ�� ���� �� ���ڸ� ���� �Ͱ� ����.
    GameObject gDitance;
    GameObject gScoreUI;
    GameObject gChance;
    GameObject gBtnRE;



    float fLength = 0.0f;
    float fDelta = 0.0f; //�� �����ӿ� �ɸ��� �ð��� ���� ����
    int nScore = 0; // ����
   

    public void ReStart()
    { //��ư�� �������� ����Ǵ� �Լ�

        nScore = 0; //���� �ʱ�ȭ        

        SceneManager.LoadScene("GameScene"); // LoadScene �޼ҵ带 ����Ͽ� �ʱ⿡ �����
                                             // GameSene�� �ҷ��´� 

    }

    void ReposCar() //�� ��ġ �ʱ�ȭ �Լ�
    {
        
            this.gCar.transform.position = CarController.vRePos; //�������� ��ġ�� ó������ ������.   
            
            
        
    }

    //���� ����
    void UpScore() {

        
            nScore += 10; //10�� ����
        
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gCar = GameObject.Find("car"); // UnityEngine���� �����ϴ� Find�޼ҵ�
        this.gFlag = GameObject.Find("flag"); // ����Ƽ ���� ������Ʈ�� �μ������� ã�� 
        this.gDitance = GameObject.Find("Distance"); // GameObject�� ������ ������ �ִ� �����̴�.
        this.gScoreUI = GameObject.Find("ScoreUI");
        this.gChance = GameObject.Find("Chance");
        this.gBtnRE = GameObject.Find("BtnRe");
    }

    // Update is called once per frame
    void Update()
    {
        gBtnRE.SetActive(false);

        fLength = this.gFlag.transform.position.x - this.gCar.transform.position.x;
        //                     ����� ��ǥ              -      �ڵ����� ��ǥ 
        //                    = ��ǥ���������� ���� �Ÿ�


        //��Ʈ ������� ���� �ʱ�ȭ
        this.gDitance.GetComponent<Text>().color = Color.black; //���� ���� color�� unityengine
                                                                //���ӽ����̽��� ����
        this.gDitance.GetComponent<Text>().fontSize = 64;   //��Ʈ ������

        this.gDitance.GetComponent<Text>().text = "��ǥ��������" + fLength.ToString("F2") + "m";
        this.gChance.GetComponent<Text>().text = "���� ��ȸ: " + CarController.nCount.ToString("D2");
        this.gScoreUI.GetComponent<Text>().text = "���� : " + nScore.ToString();
        // text������Ʈ�� ����Ͽ� distance������Ʈ�� �ؽ�Ʈ ����
        // fLength(�����Ÿ�)
        //ToString() �޼ҵ�� ���� ���ڿ��� ��ȯ�� �ش�.
        //�μ� ������ F2�� F(���� �Ҽ�����).2(�ڸ���)   => �� �Ǽ��� ���� �Ҽ��� �� ° �ڸ�����
        //                                               ���ڿ��� ��ȯ (��������D�̴�.)

        if (CarController.fSpeed <= 0.001f) //���� �ӵ��� 0.001�� ���ų� �۴ٸ�
        {

            CarController.fSpeed = 0.0f; // �ӵ��� 0�̵��� �ʱ⿡ �ٽ� �ʱ�ȭ�ؾ� �����.


            if (CarController.nCount <= 0) //Ƚ���� 0�̸�
            {
                this.gDitance.GetComponent<Text>().text = "���� ��!";
                this.gScoreUI.GetComponent<Text>().text = "���� : " + ToString();
                this.gChance.GetComponent<Text>().text = "���� ��ȸ: " + CarController.nCount.ToString("D2");
                gBtnRE.SetActive(true); //�ʱ�ȭ ��ư�� Ȱ��ȭ
            }



            if (fLength > 1.5 && gCar.transform.position.x != CarController.vRePos.x) // ��߿� �������� ���Ͽ�����
            {
                this.gDitance.GetComponent<Text>().fontSize = 180;// ��Ʈ ������ ����
                this.gDitance.GetComponent<Text>().color = Color.red; //���� ���� color�� unityengine
                                                                      //���ӽ����̽��� ����
                this.gDitance.GetComponent<Text>().text = "��..";

                fDelta += Time.deltaTime; // �� �����ӿ� �ɸ��� �ð��� ��´�.
                if (fDelta >= 1.0f) //���� fDelta�� 1�� �̻��� �Ǹ�
                {
                    fDelta = 0.0f; //�ʱ�ȭ
              
                    ReposCar(); //�� ��ġ �ʱ�ȭ
                }
         
            }
            else if (fLength >= -1.5 && fLength <= 1.5)
            { //���� �Ÿ��� 1 ���� -1 �̻� �̶��



                this.gDitance.GetComponent<Text>().fontSize = 180;
                this.gDitance.GetComponent<Text>().color = Color.yellow; //���� ���� color�� unityengine
                                                                         //���ӽ����̽��� ����
                this.gDitance.GetComponent<Text>().text = "����!";
                fDelta += Time.deltaTime; // �� �����ӿ� �ɸ��� �ð��� ��´�.
                if (fDelta >= 1.0f) //���� fDelta�� 1�� �̻��� �Ǹ�
                {
                    fDelta = 0.0f; //�ʱ�ȭ
                    UpScore(); //���� ����
                    ReposCar(); //�� ��ġ �ʱ�ȭ
                }
            }
            else if (fLength < -1.5f)
            { // ����ġ��  

                this.gDitance.GetComponent<Text>().fontSize = 180;//��Ʈ ������ ����

                this.gDitance.GetComponent<Text>().color = Color.red; //���� ���� color�� unityengine
                                                                      //���ӽ����̽��� ����
                this.gDitance.GetComponent<Text>().text = "����������������������";

                fDelta += Time.deltaTime; // �� �����ӿ� �ɸ��� �ð��� ��´�.
                if (fDelta >= 1.0f) //���� fDelta�� 1�� �̻��� �Ǹ�
                {
                    fDelta = 0.0f; //�ʱ�ȭ
                    ReposCar(); //�� ��ġ �ʱ�ȭ
                }

            }

        }

    }

}


/*
     ������Ʈ : ������Ʈ�� ������ �ִ� �����ڷ�� ���δ�. ������Ʈ�� ���?
                �����δ� Text, Transform, AudioSource, Ragidbody(���������� ������)���� �ִ�.
       
    ���� :    Game������Ʈ��� �� ���ڿ� ������Ʈ�� �߰��ϰ� GetComponent �޼ҵ带 ����Ͽ�
              <>���� �ȿ� ���ϴ� ������Ʈ�� �־� ����Ѵ�.
                
                *���� �ȿ����� ������Ʈ�� Ŭ���� �������� �Ǿ� �ִ°� ���� ���� ���� �ڿ�
                 ���ϴ� �޼ҵ带 ȣ���Ͽ� ����� �� �ִ� �� ó�� ���δ�.
                 GetComponent<AudioSource>().Play();

                ps. GetComponent�޼ҵ�� 
                    UnityEngin �� NameSpace -> GameObject class �� �޼ҵ��̴�.
                
                    namespace�� �Լ��� ����ü Ȥ�� ���� �̸� ���� �Ҽ� (����ü �Ǵ� �Լ��� 
                        �̸��� ���� �浹�ϴ� ���� ����)

 */