using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    int value = 6;
    [SerializeField] float speed;
    private Rigidbody2D rigid;
    [SerializeField] int hp;
    [SerializeField] Slider hpSlider;
    [SerializeField] GameObject talkPanel;
    [SerializeField] Text npcScript;
    bool isNpc = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        hpSlider.value = hp;

        if (isNpc)
        {
            if (Input.GetKeyUp(KeyCode.Z))
            {
                Debug.Log("대화창이 활성화 됩니다.");
                talkPanel.SetActive(!talkPanel.activeInHierarchy);
            }
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            Damage(10);
        }
    }

    public void Damage(int value)
    {
        hp -= value;

        if (hp <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        // 어떻게 할것인가?
        Debug.Log("Dead");
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            value = 4;
            animator.SetInteger("direction", value);
            rigid.velocity += Vector2.up * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(1, 1, 1);
            value = 5;
            animator.SetInteger("direction", value);
            rigid.velocity += Vector2.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            value = 6;
            animator.SetInteger("direction", value);
            rigid.velocity += Vector2.down * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            value = 5;
            animator.SetInteger("direction", value);
            rigid.velocity += Vector2.right * speed * Time.deltaTime;
        }
        else
        {
            animator.SetInteger("direction", value - 3);
            rigid.velocity += Vector2.zero * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        if (collision.gameObject.CompareTag("NPC"))
        {
            NPCController npc = collision.gameObject.GetComponent<NPCController>();
            npc.ActiveTalk(true);
            npcScript.text = npc.talkScript;
            isNpc = true;
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log($"{collision.gameObject.name}");
    //    if (collision.gameObject.CompareTag("NPC"))
    //    {
    //        if (Input.GetKeyUp(KeyCode.Z))
    //        {
    //            Debug.Log("대화창이 활성화 됩니다.");
    //            talkPanel.SetActive(!talkPanel.activeInHierarchy);
    //        }
    //    }
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        if (collision.gameObject.CompareTag("NPC"))
        {
            NPCController npc = collision.gameObject.GetComponent<NPCController>();
            npc.ActiveTalk(false);
            talkPanel.SetActive(false);
            isNpc = false;
        }
    }
}
