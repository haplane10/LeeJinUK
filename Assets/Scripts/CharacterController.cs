using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    int value = 6;
    [SerializeField] float speed;
    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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

}
