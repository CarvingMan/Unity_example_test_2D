using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player = null;
   

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("cat");  // 플레이어 오브젝트를 찾는다.
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position; //플레이어의 위치를 벡터 변수에 담아 프레임마다 담아둔다.

        transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
        // 현재의 포지션을 x축과 z축은 그대로, y축만 payer의 중심 좌표대로 이동한다.
    }

}
