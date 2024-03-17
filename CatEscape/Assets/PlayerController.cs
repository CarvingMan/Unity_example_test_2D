using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    GameObject gREbtn = null; 

   private bool RBtnOn = false; //��ư�� ���� �ִ���
   private bool LBtnOn = false;

    private Vector3 vStartPos = Vector3.zero; // ó����ġ
    void Start()
    {
        this.gREbtn = GameObject.Find("ReSetButton");
        vStartPos = transform.position; //������� ���� ���� �ʹ� ��ġ�� Start����  vStartPos�� ��Ƶд�.
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gREbtn.activeSelf == false) // ���ʿ� ��ư�� active�� true��� translate�� �Ұ�
        {                                    // ��ư�� Ȱ��ȭ ��Ű�°� SetActive, ���� �������°� ActiveSelf
            //���� ȭ��ǥ�� ������ �ִ� ����
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -9) //ī�޶��� ��ġ�� ������� �ȵǱ⿡ -9�̻��϶� �̴�.
            { //KeyCode�� enum(������ ���)���� �ƽ�Ű �ڵ尪�� ������ ���� ������ ���δ�.
                transform.Translate(-0.3f, 0, 0); // �������� '3' �����δ�.
            }



            //������ ȭ��ǥ�� ������ �ִ� ����
            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 9)
            {
                transform.Translate(0.3f, 0, 0); // ���������� '0.5' �����δ�.
            }

            if (RBtnOn == true)
            {
                transform.Translate(0.3f, 0, 0); // ���������� '0.5' �����δ�.
            }


            if (LBtnOn == true)
            {
                transform.Translate(-0.3f, 0, 0); // �������� '0.5' �����δ�.
            }


            float fClampPos = Mathf.Clamp(transform.position.x, -9.0f, 9.0f);


            // Mathf�� Clamp �޼ҵ� () �ȿ� ������� ������, �ּҰ�, �ִ밪 ���̿����� ���� ������ �� �ְ� �����Ѵ�.
            //���� ��� �ش� ������ ���� �ִ밪�� �ѱ�� ���� �ڵ����� �ִ밪���� �ٽ� ��ȯ�Ѵ�. �ݴ뵵 ��������
            // transform.position�� x���� -9 ���� 9�� �����Ͽ� ����ī�޶� ������ ������ �ʵ��� �ϴ� ��

            transform.position = new Vector3(fClampPos, transform.position.y, transform.position.z);
            // �׸��� ������ ��ġ�� ���ο� ���ͷ� x���� ���� fClampPos�� �����Ͽ� ������Ʈ �� �ش�.
            // �⺻������ fClampPos�� ���� transform.position.x�� ���� ������ ���� 
            // ĳ���Ͱ� -9���� 9�̻����� x���� Translate�ȴٸ� fClampPos���� Clamp �޼ҵ�� ������ �ִ밪, �ּҰ�����
            // �ǵ�����.        �������� transform.position.y, transform.position.z �״�� ������Ʈ �� �ش�.
        }
    }


    public void RePos() // �÷��̾��� ��ġ�� �ʱ�ȭ
    {
        transform.position = vStartPos; // start�޼ҵ忡�� ������ �� ��Ƴ��� ���������� �ʱ�ȭ
    }
    public void RBtnUp() 
    {
        this.RBtnOn = false;  // PointerUp�Ͻ� false�� ��ȯ
    }

    public void RBtnDown()
    {
        this.RBtnOn = true;  // PointerDown�Ͻ� true�� ��ȯ
    }

    public void LBtnDown() {
        this.LBtnOn = true;
    }

    public void LBtnUp()
    {
        this.LBtnOn = false;
    }

    /*  public void LButtonDown() {
          transform.Translate(-3, 0, 0);
      }

      public void RButtonDown()
      {
          transform.Translate(3, 0, 0);
      }
    */
}
