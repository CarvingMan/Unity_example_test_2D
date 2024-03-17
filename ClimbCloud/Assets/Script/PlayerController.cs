using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Load���� ����ϴµ� �ʿ��ϴ�.

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D; // rigidbody������Ʈ�� ����ϱ� ���� �ڽ�
    [SerializeField]
    float fJumpForce = 680f; // ������ �ϴ� ��
    float fWalkForce = 30.0f;
    float fMaxSpeed = 2.0f;
    float threshold = 0.2f; //���ӵ� ������
    float fClamp = 0.0f; //ȭ�� ������ 
    Animator animator;

    GameObject gDirector = null;

    
   
    // Start is called before the first frame update
    void Start()
    {
        //this.rigid2D = GetComponent<Rigidbody2D>().AddForce(transform.up * fJumpForce); // �ȵ�
        this.rigid2D = GetComponent<Rigidbody2D>(); // rigidbody ������Ʈ�� �ν��Ͻ�
        this.animator = GetComponent<Animator>(); //animator ������Ʈ�� ������
        this.gDirector = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        fClamp = Mathf.Clamp(transform.position.x, -2.8f, 2.8f); // x�� ��ǥ�� �����Ͽ� ��ȯ
        transform.position = new Vector3(fClamp, transform.position.y, transform.position.z);
        
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            if (this.rigid2D.velocity.y == 0)
            {
                //y���� �ӵ��� 0�϶��� �����Ѵ�.
                this.animator.SetTrigger("JumpTrigger"); // ���� Ʈ���� �ߵ�
                this.rigid2D.AddForce(Vector2.up * this.fJumpForce);
                //addforce�� vector2.up = (0,1,0)���⿡ ���� ����
            }
        }
      
            if (this.rigid2D.velocity.y < -2)// �����Ҷ�
            {
                this.animator.SetBool("BasePos", true);
            }
            else
            {
                this.animator.SetBool("BasePos", false);
            }
        

        //�¿��̵�
        int iKey = 0; // �������� ��ȭ �ϵ��� �̿ܿ��� 0���� �ʱ�ȭ �Ͽ� �������� �ʰ� �Ѵ�.

        if (Input.GetKey(KeyCode.RightArrow)) {
            iKey = 1; // ������ ����Ű�� ������ �������ȸ� ikey�� ���� 1
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            iKey = -1; // ���� ����Ű�� ������ �������ȸ� ikey�� ���� -1
        }


        //���ӵ������� �̿��� ������
        if (Input.acceleration.x > this.threshold) { //���ӵ� ������ �������� ũ�ٸ� ������ �����(����) 
            iKey = 1;
        }
        else if (Input.acceleration.x < -this.threshold)
        { //���ӵ� ������ -(����)���� �۴ٸ� ���� �����(����) 
            iKey = -1;
        }
        //�÷��̾��� �ӵ�
        float fSpeedx = Mathf.Abs(this.rigid2D.velocity.x);
        //velocity.x�� ���� �ӵ��ε� �����϶� -�� �̹Ƿ� abs�� ���밪 ��ȯ

        if (fSpeedx == 0)
        {
            this.animator.SetBool("isWalking", false);
        }
        else {
            this.animator.SetBool("isWalking", true);
        }

        // ���ǵ� ����
        if (fSpeedx < fMaxSpeed) { // addforce�� ������ ������ ����ȭ �Ǿ� ��� ���ִ� ��
            this.rigid2D.AddForce(transform.right * iKey * fWalkForce);
            // AddForce�� �Ű� ������ ������ Ÿ���� ���� // rigid2d �̸� ����2 
            // transform.right �� ���� 3�� (1,0,0)�� ������ �ְ� �ű⿡ key�� ���� ������ �����ְ� force�� ���� ���� �����ش�.
            //deltaTime�� �÷����ϴ� �ܸ��� ������ �ӵ��� �������  �ӵ��� ���߾� �ֱ�����
            // * �����Ӵ� �ɸ��� �ð�;
            // update�� ������ ���� ȣ�� �ǹǷ� �ӵ��� �ұ�Ģ �ϱ� �����ε� ������ �ð����� ȣ��Ǵ� fixedupdate
            // �� ����ϸ� delta�� �ʿ���� �ٸ�, fixedupdate�� ������ ���ٰ� �ƴϹǷ� �Է��� update �������ΰ���
            // fixedUpdate���� ���Ǿ�� �Ѵ�.
        }

        if (iKey != 0) // 0���� �ϸ� �������.
        { 
            transform.localScale = new Vector3(iKey, 1, 1); // �������� -�̸� �����ȴ�.
        }

        //�÷��̾� �ӵ��� ���缭 �ִϸ��̼� �ӵ��� �ٲ۴�.
        if (this.rigid2D.velocity.y == 0)
        { //������ ���� �ʴ´ٸ� �ӵ� �״��
            this.animator.speed = fSpeedx / 2.0f;
        }
        else {
            this.animator.speed = 1.0f; // ������ �ϸ� �ִϸ��̼��� 1�ʷ� ����
        }

        if (transform.position.y < -10) {
            SceneManager.LoadScene("GameScene"); 
            // -10���Ϸ� �������� GameScene(���� ó��)�� �ٽ� �ҷ��´�.
        }
    }

    //�� ����
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "flag")
        {
            Debug.Log("��");
            SceneManager.LoadScene("ClearScene");
            // ���� ���� �ҷ��´�.
            //public static�̱⿡ Ŭ������.�޼ҵ������ ȣ�� �԰����̴�.
        }

        if (other.gameObject.tag == "Coin") //�浹�� ������Ʈ�� �±װ� coin�̶��
        {
            int nScore = 0;
            Destroy(other.gameObject); // ���� ����
            nScore = ((int)other.gameObject.GetComponent<ItemController>().ITEM); //�浹 �������� enum�� int�� ����ȯ
            Debug.Log(nScore);
            this.gDirector.GetComponent<GameDirector>().UpScore(nScore);
            // GameDirector�� UpScoere()�� ȣ��
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
