using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player = null;
   

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("cat");  // �÷��̾� ������Ʈ�� ã�´�.
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position; //�÷��̾��� ��ġ�� ���� ������ ��� �����Ӹ��� ��Ƶд�.

        transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
        // ������ �������� x��� z���� �״��, y�ุ payer�� �߽� ��ǥ��� �̵��Ѵ�.
    }

}
