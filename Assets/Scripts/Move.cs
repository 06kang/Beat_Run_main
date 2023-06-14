using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Move : MonoBehaviour
{
    public float speed, jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer mySprite;
    Animator anim;
    Teleport tp;
    Dash dash;
    bool isGround, isDash;  //���� ��Ҵ°�.
    public int playerLife = 1;
    [SerializeField] private GameObject player = null;

    enum ObjectKind { None, TP, Dash };
    ObjectKind objKind;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.pause) return;

        if (!isDash)
        {
            move();
            jump();
        }


        int layerMask = 1 << LayerMask.NameToLayer("Obj");
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 1f, Vector2.zero, 0, layerMask);
        if (hit)
        {
            if (hit.collider.CompareTag("Teleport"))
            {
                tp = hit.collider.GetComponent<Teleport>();
                objKind = ObjectKind.TP;    //���� ������Ʈ�� �浹��

            }
            if (hit.collider.CompareTag("Dash"))
            {
                dash = hit.collider.GetComponent<Dash>();
                objKind = ObjectKind.Dash;    //���� ������Ʈ�� �浹��

            }
        }
        else
        {
            objKind = ObjectKind.None;
        }

        if (Input.GetKeyDown(KeyCode.F))    //����
        {
            if (objKind == ObjectKind.TP)
            {
                if (tp.isTrigger) return;
                tp.teleport(transform);
            }
            if(objKind == ObjectKind.Dash)
            {
                rigid.gravityScale = 0;
                rigid.velocity = Vector2.zero;
                dash.OnDash();
                isDash = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            if (isDash)
            {
                rigid.gravityScale = 4;
                dash.OffDash();
                objKind = ObjectKind.None;
                isDash = false;
            }
        }
    }

    void move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 dir = new Vector2(h * speed, rigid.velocity.y);
        rigid.velocity = dir;   //�÷��̾� �¿� �̵� 
        if (Mathf.Abs(h) >= 0.1f)
        {
            if (h < -0.1f) mySprite.flipX = true;
            else if(h>0.1f)mySprite.flipX = false;
            anim.SetBool("isMove", true);
        }
        else anim.SetBool("isMove", false);
    }
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);    //����
        }
        else if (Input.GetKeyUp(KeyCode.Space) && rigid.velocity.y > 0)
        {
            //rigid.velocity =rigid.velocity * 0.2f;
            
            float y = rigid.velocity.y*0.5f;
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.AddForce(Vector2.up * y, ForceMode2D.Impulse);
            
        }

    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.CompareTag("Ground"))
        {
            isGround = true;    //���� ����
        }
        
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Ground"))
        {
            isGround = false;   //������ ����
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")     //���ÿ��� �浹
        {
            playerTakeDamage(1);
            Debug.Log("���ÿ� ��ҽ��ϴ�.");
        }
    }
    private void playerrRebirth()
    {
        transform.position = new Vector2(-3.89f, -1.24f);
        RestartScenesButton();
    }
    void playerTakeDamage(int damage)
    {
        playerLife -= damage;
        if(playerLife <= 0)
        {
            gameObject.SetActive(false);
            Invoke("playerrRebirth", 3);
        }
    }
    public void RestartScenesButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
