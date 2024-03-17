using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    
    public GameObject arrowPrefab = null; // �������� ���� �� ����
    GameObject go = null; // �������� �ν��Ͻ��� ���� ������Ʈ ����
    GameObject gREbtn = null;
    
    int inPx = 0;

    [SerializeField]
    float fSpan = 1.0f; // ���� 1��
    [SerializeField]
    float delta = 0.0f; // �̰��� �������� �ð����� ����
    // Start is called before the first frame update
    void Start()
    {
        this.gREbtn = GameObject.Find("ReSetButton");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gREbtn.activeSelf == false) // ���ʿ� ��ư�� active�� true��� �������� ���� �ȵȴ�.
        {                                    // ��ư�� Ȱ��ȭ ��Ű�°� SetActive, ���� �������°� ActiveSelf
            this.delta += Time.deltaTime; //�������� �ð����� ���մ�������

            //1�ʸ��� ������ ����
            if (this.delta > this.fSpan)
            { // ������ �ð����� 1 �̻�(�� 1���̻�)�Ͻ� 
                this.delta = 0.0f; // delta�� �ٽ� �ʱ�ȭ
                go = Instantiate(arrowPrefab); // instantiate�� �Ű��� �������� �޾� �ν��Ͻ��� ���� 
                inPx = Random.Range(-9, 10); // ����Ŭ������ range(����)�޼ҵ�� -9 ���� ũ�ų� �۰� 10 �̸� 
                go.transform.position = new Vector3(inPx, 7, 0); //transform Ŭ������ position�� Vector3 ����
                                                                 // Ŭ���� �ȿ� ����ü�� �׷��� new Vector3(inPx, 7, 0);
                                                                 //ó�� ���� �ν��Ͻ��� �� �� �ִ�. ���� ��ǥ
                                                                 // x��ǥ�� �������� �ְڴٴ� �ǹ�
            }
          
        }
        
       
    }

    public void DesArrow() {
       
            Destroy(go); // �������� �����.
    }
}
