using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public  static float fSpeed;
    Vector2 vStartPos = new Vector2(0.0f, 0.0f); // ���콺�� Ŭ���ҽ� ���콺�� ��ǥ
    Vector2 vEndPos = new Vector2(0.0f, 0.0f); // ���콺���� ���� �� ���� ���콺 ��ǥ
    
    public static Vector2 vRePos = Vector2.zero;
    float fSwipeLenth = 0.0f; // ���콺�� ���������� �� ����  
    public static int nCount = 0; //���� Ƚ��
    
   

    GameObject gBtnRE; // ����� ��ư
    // Start is called before the first frame update
    void Start()
    {
        this.gBtnRE = GameObject.Find("BtnRe"); //�� ���� ��ư�� ã�´�.
        vRePos = transform.position; // �ڵ����� ���� ��ġ�� ����
        fSpeed = 0.0f; //GameScene�� ��� �ʱ갪
        
        nCount = 10; // start���� �ʱ�ȭ�� �� ��� sceneLoad�� ������ ���� �ʱ�ȭ �ȴ�.
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gBtnRE.activeSelf == false) // ��ư�� ��Ȱ��ȭ �����϶��� �Ⱦ��� ��ư ������ ��� �Ʒ� �ڵ尡 ����ȴ�.
        {
            if (Input.GetMouseButtonDown(0))
            { //���콺�� Ŭ���ϸ�

                //this.fSpeed = 0.2f; // �ڵ����� ����� �� �ӵ� �ʱⰪ ���� ���� ���1�� ����
                this.vStartPos = Input.mousePosition; //���콺�� ��ǥ�� startpos�� ����
            }
            else if (Input.GetMouseButtonUp(0))
            { // ���콺���� �հ����� �� ��
                this.vEndPos = Input.mousePosition; // ���콺�� ��ǥ�� endPos�� �����Ѵ�.


                this.fSwipeLenth = this.vEndPos.x - this.vStartPos.x; // ���� - �������� ���������� �Ÿ��� ���Ѵ�.
                fSpeed = this.fSwipeLenth / 500; // ���������� x��ǥ�� ���̰� �ʹ�Ŀ�� �ӵ��� �����⿡ 500�� ���� �ӵ���
                                                       // �ִ��� �����.
                GetComponent<AudioSource>().Play(); // ������ҽ� ������Ʈ�� ���ϰ� play�޼ҵ� ȣ���Ѵ�.
        
                nCount--; // Ƚ�� ����
            }
        }

     
            transform.Translate(fSpeed, 0, 0); // translate�� ���� �������� �׸�ŭ �ش���ǥ�� �̵���Ų��. 
                                                    // ��ǥ�� �����ϴ� ���� �ƴ�
            fSpeed *= 0.98f;  // ���� ���� ��Ų��.


    }
}
