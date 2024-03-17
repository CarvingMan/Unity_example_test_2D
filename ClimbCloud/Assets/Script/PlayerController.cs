using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Load씬을 사용하는데 필요하다.

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D; // rigidbody컴포넌트를 사용하기 위한 박스
    [SerializeField]
    float fJumpForce = 680f; // 점프를 하는 힘
    float fWalkForce = 30.0f;
    float fMaxSpeed = 2.0f;
    float threshold = 0.2f; //가속도 센서값
    float fClamp = 0.0f; //화면 고정값 
    Animator animator;

    GameObject gDirector = null;

    
   
    // Start is called before the first frame update
    void Start()
    {
        //this.rigid2D = GetComponent<Rigidbody2D>().AddForce(transform.up * fJumpForce); // 안됨
        this.rigid2D = GetComponent<Rigidbody2D>(); // rigidbody 컴포넌트를 인스턴스
        this.animator = GetComponent<Animator>(); //animator 컴포넌트를 가져옴
        this.gDirector = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        fClamp = Mathf.Clamp(transform.position.x, -2.8f, 2.8f); // x축 좌표를 고정하여 반환
        transform.position = new Vector3(fClamp, transform.position.y, transform.position.z);
        
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            if (this.rigid2D.velocity.y == 0)
            {
                //y축의 속도가 0일때만 점프한다.
                this.animator.SetTrigger("JumpTrigger"); // 점프 트리거 발동
                this.rigid2D.AddForce(Vector2.up * this.fJumpForce);
                //addforce에 vector2.up = (0,1,0)방향에 힘을 곱함
            }
        }
      
            if (this.rigid2D.velocity.y < -2)// 낙하할때
            {
                this.animator.SetBool("BasePos", true);
            }
            else
            {
                this.animator.SetBool("BasePos", false);
            }
        

        //좌우이동
        int iKey = 0; // 누를때만 변화 하도록 이외에는 0으로 초기화 하여 움직이지 않게 한다.

        if (Input.GetKey(KeyCode.RightArrow)) {
            iKey = 1; // 오른쪽 방향키를 누르고 있을동안만 ikey의 값이 1
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            iKey = -1; // 왼쪽 방향키를 누르고 있을동안만 ikey의 값이 -1
        }


        //가속도센서를 이용한 움직임
        if (Input.acceleration.x > this.threshold) { //가속도 변수가 변수보다 크다면 오른쪽 기울임(방향) 
            iKey = 1;
        }
        else if (Input.acceleration.x < -this.threshold)
        { //가속도 변수가 -(변수)보다 작다면 왼쪽 기울임(방향) 
            iKey = -1;
        }
        //플레이어의 속도
        float fSpeedx = Mathf.Abs(this.rigid2D.velocity.x);
        //velocity.x는 현재 속도인데 왼쪽일때 -값 이므로 abs로 절대값 반환

        if (fSpeedx == 0)
        {
            this.animator.SetBool("isWalking", false);
        }
        else {
            this.animator.SetBool("isWalking", true);
        }

        // 스피드 제한
        if (fSpeedx < fMaxSpeed) { // addforce는 누르고 있으면 가속화 되어 제어를 해주는 것
            this.rigid2D.AddForce(transform.right * iKey * fWalkForce);
            // AddForce의 매개 변수는 벡터의 타입을 가짐 // rigid2d 이면 벡터2 
            // transform.right 는 벡터 3의 (1,0,0)를 가지고 있고 거기에 key를 곱해 방향을 정해주고 force를 곱해 힘을 정해준다.
            //deltaTime은 플레이하는 단말의 프레임 속도에 관계없이  속도를 맞추어 주기위해
            // * 프레임당 걸리는 시간;
            // update는 프레임 마다 호출 되므로 속도가 불규칙 하기 때문인데 고정된 시간마다 호출되는 fixedupdate
            // 를 사용하면 delta는 필요없다 다만, fixedupdate는 프레임 마다가 아니므로 입력은 update 물리적인것은
            // fixedUpdate에서 사용되어야 한다.
        }

        if (iKey != 0) // 0으로 하면 사라진다.
        { 
            transform.localScale = new Vector3(iKey, 1, 1); // 스케일이 -이면 반전된다.
        }

        //플레이어 속도에 맞춰서 애니메이션 속도를 바꾼다.
        if (this.rigid2D.velocity.y == 0)
        { //점프를 뛰지 않는다면 속도 그대로
            this.animator.speed = fSpeedx / 2.0f;
        }
        else {
            this.animator.speed = 1.0f; // 점프를 하면 애니메이션을 1초로 지정
        }

        if (transform.position.y < -10) {
            SceneManager.LoadScene("GameScene"); 
            // -10이하로 떨어지면 GameScene(씬의 처음)을 다시 불러온다.
        }
    }

    //골 도착
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "flag")
        {
            Debug.Log("골");
            SceneManager.LoadScene("ClearScene");
            // 게임 씬을 불러온다.
            //public static이기에 클래스명.메소드명으로 호출 쌉가능이다.
        }

        if (other.gameObject.tag == "Coin") //충돌한 오브젝트의 태그가 coin이라면
        {
            int nScore = 0;
            Destroy(other.gameObject); // 코인 삭제
            nScore = ((int)other.gameObject.GetComponent<ItemController>().ITEM); //충돌 아이탬의 enum을 int로 형변환
            Debug.Log(nScore);
            this.gDirector.GetComponent<GameDirector>().UpScore(nScore);
            // GameDirector의 UpScoere()를 호출
        }

        if (other.gameObject.tag == "Cloud") 
        {
            GetComponent<PolygonCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<PolygonCollider2D>().isTrigger = false;
       
    }
    
    
}
