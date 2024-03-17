using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    GameObject gPlayler = null;
    
    GameObject gHP = null;
    Vector2 vArrow = Vector2.zero;  //���� �ʱ�ȭ
    Vector2 vPlayer = Vector2.zero;
    Vector2 vDir = Vector2.zero;
    float fDir = 0.0f;
    float fR1 = 0.0f;
    float fR2 = 0.0f;
   


    // Start is called before the first frame update
    void Start()
    {
        this.gPlayler = GameObject.Find("player"); //�÷��̾� ������Ʈ�� ����
        
        this.gHP = GameObject.Find("hpGauge");
    }


    // Update is called once per frame
    void Update()
    {
        if (gHP.GetComponent<Image>().fillAmount > 0) // hp�� 0���� Ŭ�ø� ���� ���ų� ������ �����.
        {
            transform.Translate(0, -0.1f, 0); // �����Ӹ��� ������� ���Ͻ�Ų��.
        }
        
        //ȭ�� ������ ������ ������Ʈ�� �Ҹ��Ų��. �Ǵ� ��ư�� Ȱ��ȭ �Ǹ� �Ҹ�
        if (transform.position.y < -5.0f) {
            Destroy(gameObject); // �Ű������� ������ ������Ʈ�� ����
        }
        

        //�浹����
        this.vArrow = transform.position;       //ȭ���� �߽���ǥ
        this.vPlayer = this.gPlayler.transform.position; //ĳ������ �߽���ǥ
        this.vDir = vArrow - vPlayer; // ���� - ����
        this.fDir = vDir.magnitude;  // ����
        this.fR1 = 0.5f;    //ȭ���� �ݰ�
        this.fR2 = 1.0f;    // �÷��̾��� �ݰ�

        if(fDir < fR1 + fR2) // �� ������ �Ÿ��� �� �������� �� ���� ������ �浹�̴�.
        {   // ���� ��ũ��Ʈ�� �÷��̾�� ȭ���� �浹�ߴٰ� �����Ѵ�.
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreseHp();
            Destroy(gameObject); //�浹�� ȭ�� ����
        }
    }
}
