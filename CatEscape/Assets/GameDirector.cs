using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject gHpGuage = null; // hp������
    GameObject gGameOver = null; // ���ӿ����ؽ�Ʈ
    GameObject gREbtn = null; // ���¹�ư
    GameObject gPlayer = null; // �÷��̾�
    GameObject ArrowGenerator = null; // ���ʷ�����
   
    void Start()
    {
        this.gHpGuage = GameObject.Find("hpGauge");
        this.gGameOver = GameObject.Find("GameOver");
        this.gREbtn = GameObject.Find("ReSetButton");
        this.gPlayer = GameObject.Find("player");
        this.ArrowGenerator = GameObject.Find("ArrowGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        // �ؽ�Ʈ�� ��ư�� ��Ȱ��ȭ�� ��� ����� �Ѵ�.
        gGameOver.SetActive(false);
        gREbtn.SetActive(false);

        if (gHpGuage.GetComponent<Image>().fillAmount == 0) {
            this.gREbtn.SetActive(true); // ���� hp�� ���� �޾����� ��ư�� Ȱ��ȭ
            this.gGameOver.SetActive(true); // ���ӿ��� �ؽ�Ʈ�� Ȱ��ȭ 
        }
    }

    public void DecreseHp() {
        this.gHpGuage.GetComponent<Image>().fillAmount -= 0.1f;
    }

    public void Reset() // ��ư�� ���� �� ȣ���� �Լ�
    {
        this.gHpGuage.GetComponent<Image>().fillAmount = 1; // ü���� �ʱ�ȭ
        this.gPlayer.GetComponent<PlayerController>().RePos(); // �÷��̾��� ��ġ �ʱ�ȭ
        this.ArrowGenerator.GetComponent<ArrowGenerator>().DesArrow(); // ���ʷ����Ϳ� ȭ�� ������ ����� �Լ� ȣ��
    }
}
