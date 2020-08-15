using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    float horizontalMove;
    [SerializeField] float speed = 3;
    public GameObject InputPanel;
    Animator anim;
    Rigidbody2D rb;
    bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove&&InputPanel.activeSelf==false)
        {
        Move();

        }
        Filp();
        SwitchAnim();
    }

    void Move()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
    }
   void Filp()
    {
        if (horizontalMove>0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }else if (horizontalMove < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void SwitchAnim()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("Die");
            canMove = false;
        }
        anim.SetBool("Move", horizontalMove != 0);
    }
}
