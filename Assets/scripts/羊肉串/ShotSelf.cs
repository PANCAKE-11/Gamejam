using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ShotSelf : MonoBehaviour
{
    GameObject Player;
    SpriteRenderer sr;
    [SerializeField] float LauchForce = 2.0f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Shoot();
    }

    

    void Shoot()
    {
        Vector2 PlayerPosition = Player.transform.position;
        Vector2 selfPosition = transform.position;
        Vector2 Direction = PlayerPosition - selfPosition;
        print(Direction);
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
         rb.velocity = Direction * LauchForce;
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" )
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - Time.deltaTime * 0.8f);
            Destroy(gameObject, 3);
        }
    }
}
