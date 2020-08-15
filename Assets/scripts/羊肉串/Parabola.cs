using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabola : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Left;
    [SerializeField] GameObject Right;
    SpriteRenderer sr;
    float LauchForce = 3.0f;
    Rigidbody2D rb;
    bool IsShoot = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per framelay
    void Update()
    {

        if (Player.transform.position.x > Left.transform.position.x&&Player.transform.position.x <Right.transform.position.x&& IsShoot == false) 
        {
            Shoot();
        }
    }
    void Shoot()
    {
        IsShoot = true;
        Vector2 PlayerPosition =Player.transform.position;
        Vector2 BoxPosition =transform.position;
        Vector2 Direction =  PlayerPosition-BoxPosition ;
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        GetComponent<Rigidbody2D>().velocity = Direction * LauchForce;
    }


  

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && IsShoot)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - Time.deltaTime * 0.8f);
            Destroy(gameObject,3);
        }
    }
}
