
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float fRotSpeed = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        
        if (Input.GetMouseButtonDown(0)) { //Ŭ���� ������ �ѹ��� true�� ��ȯ �μ��� 0 ����Ŭ�� 1�̸� ������ 2�� ��
            this.fRotSpeed = 40; // ��� ���ǵ尡 �ƴ϶� ������ ���������� update�޼ҵ� �̱⿡ �� �����ӿ� 40���� 
                                 // �����̴� ����
                                 // �� �ѹ� ���콺 ��Ŭ���� �� �� �ʱⰪ�� �ٽ� 40���� �����.
        }

        transform.Rotate(0, 0, this.fRotSpeed); // z�� �������� ȸ�� 10���� �� �����ӿ� �����δ�.

        this.fRotSpeed *= 0.99f; // �������� ���� �������� ���Ͽ� ���ݾ� ���߰� �Ѵ�.
                                 // ������ ���� ���� ���������� �����ϱ⿡ ���������� ���ڿ�������.
                                 // �������� ���Ҹ� �ϴٰ� �Ҽ����� float�� ������ ���� �ڸ���
                                 //EX) 0.00000000000645243242....������� 0�� �Ǿ� ���ߴ� �� ����. ����!
   
      
    }
}
