using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemController : MonoBehaviour
{

    public enum E_ITEM_WITH_SCORE // ������ ����� ������ �ǹ��ִ� ���ھ�(���)�� ����
    {
        Bronze = 50,    //���ε��� ����(���)�� ����
        Silver = 100,
        Gold = 300
    }

    [SerializeField] // inspectorâ���� �������� �ٲپ� �ֱ����Ͽ� ����
    public E_ITEM_WITH_SCORE ITEM = E_ITEM_WITH_SCORE.Bronze; // �ʱ� ������ ���帹�� bronze�� enum ���� ����

    //SpriteRenderer mySprite = GetComponent<SpriteRenderer>(); �̷������� �������� ����

    // Start is called before the first frame update
    void Start()
    {
        
       
        

        if (ITEM == E_ITEM_WITH_SCORE.Bronze)
        { //ITEM�� ����� ���� Bronze���
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Item/Bronze");
            //GetComponent<SpriteRenderer>()�� �ν�����â���� spriterenderer�� �����Ѵٴ� ��
            //.sprite�� SpriteRenderer�� sprite�̹����� ����
            //Resources.Load�� Resources������ �����Ͽ� ���� ���� ���¿� ������ �� �ִ�.
            // ���� projectâ�� Resources��� ������ ����� �־�� �Ѵ�.
            // <����Ÿ��>("���ϰ��")

        }
        else if (ITEM == E_ITEM_WITH_SCORE.Silver)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Item/Silver");
        }
        else if (ITEM == E_ITEM_WITH_SCORE.Gold)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Item/Gold");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(0,2, 0); // ������ y�� �������� ȸ�� ��Ų��.
    }
}
