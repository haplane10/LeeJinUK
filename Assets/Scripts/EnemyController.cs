using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public new Rigidbody2D rigidbody;
    public Animator animator;
    public float hp;
    public Slider slider;
    public CircleCollider2D circleCollider;

    bool isAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isAttack == false && collision.gameObject.CompareTag("Player"))
        {
            Vector2 moveVector = collision.transform.position - transform.position;
            rigidbody.velocity = moveVector.normalized * speed * Time.deltaTime;
            animator.SetInteger("Anim", 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rigidbody.velocity = Vector2.zero;   // new Vector2(0, 0);
            animator.SetInteger("Anim", 0);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isAttack == false && collision.gameObject.CompareTag("Player"))
        {
            isAttack = true;
            rigidbody.velocity = Vector2.zero;
            animator.SetTrigger("Attack");
            circleCollider.enabled = false;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if (!animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("Attack"))
            {
                isAttack = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            circleCollider.enabled = true;
        }
    }
}
