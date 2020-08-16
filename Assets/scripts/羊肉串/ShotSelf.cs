using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ShotSelf : MonoBehaviour
{
    GameObject Player;
    SpriteRenderer sr;
    float LauchForce = 0.8f;
    Rigidbody2D rb;
    [SerializeField] float high;
    [SerializeField] int Damage;
    // Start is called before the first frame update
    void Start()
    {
       Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        high = Random.Range(5, 20);
        Shoot();
    }

    

    void Shoot()
    {
        Vector2 PlayerPosition = Player.transform.position;
        Vector2 selfPosition = transform.position;
        Vector2 Direction = new Vector2((PlayerPosition.x - selfPosition.x) / 2+PlayerPosition.x, high);

        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
         rb.velocity = Direction * LauchForce;
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" )
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - Time.deltaTime * 0.8f);
            gameObject.tag = "Untagged";
            Destroy(gameObject, 3);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"&&gameObject.CompareTag("bad"))
        {
            collision.gameObject.GetComponent<GetAttack>().GetDamage(Damage);
            
        }

    }
}
