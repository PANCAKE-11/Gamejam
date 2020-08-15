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
   public bool canMove;
   public AudioSource audioWalk;
    [SerializeField] private bool _pressedJump;
    [SerializeField] private Vector2 _jumpForce;
   [SerializeField] LayerMask ground;
    [SerializeField] Transform checkPosition;
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
         Jump();
        }
        Filp();
        SwitchAnim();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _pressedJump = true;
        }
    }
    void Jump()
    {
            RaycastHit2D hit = Raycast(checkPosition.position, Vector2.down, 0.2f, ground);

            if (_pressedJump && hit)
            {
                rb.AddForce(_jumpForce, ForceMode2D.Impulse);
                _pressedJump = false;
            }
        
    }
    void Move()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        if (horizontalMove!=0&&!audioWalk.isPlaying)
        {

        }
        
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
            UImanager._instance.GameEnd();
        }
        anim.SetBool("Move", horizontalMove != 0);
    }

      public void playWalkAudio()
    {
        audioWalk.Play();
    }

    private RaycastHit2D Raycast(Vector3 origin, Vector3 dir, float distance, LayerMask layerMask)
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(origin, dir, distance, layerMask);
        Color color = (hit) ? Color.red : Color.white;

        Debug.DrawRay(checkPosition.position, Vector2.down * distance, color);
        return hit;
    }
}
