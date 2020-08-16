using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetAttack : MonoBehaviour
{
    [SerializeField] Text san;
    [SerializeField] GameObject player;
    Collider2D collider2;
  public  int san2 = 0;
    bool IsTaugh = false;
    int Frame = 0;

    Slider slider;



    private void FixedUpdate()
    {

        if (IsTaugh)
        {
            if (Input.GetKey(KeyCode.J))
            {
                Frame++;
                if (slider != null)
                {

                    UImanager._instance.HoldJ(Frame, slider);
                }
            }
            if (Frame > 100)
            {
                Frame = 0;
                if (collider2!=null)
                {

                Destroy(collider2.gameObject);
                }
                IsTaugh = false;
                san2 += 10;
                san.text = san2.ToString() ;
                if (player.transform.localScale.x<0)
                {
                player.transform.localScale += new Vector3(-0.1f, 0.1f, 0.1f);

                }else if(player.transform.localScale.x > 0)
                {
                    player.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                }
            }
            if (Input.GetKeyUp(KeyCode.J))
            {
                Frame = 0;
            }
        }

        if (san2>=100)
        {
            UImanager._instance.LoadScene("WIN");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag =="bad")
        {
            san2++;
            san.text = san2.ToString();
        }
        else if(collision.gameObject.tag=="good")
        {
            san2--;
            san.text = san2.ToString();
        }
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.gameObject.tag=="pack")
        {
            IsTaugh = true;
            collider2 = collision;
            slider = collision.transform.GetComponentInChildren<Slider>();
            slider.maxValue = 100;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pack")
        {
            slider.value = 0;
            IsTaugh = false;
            collider2 = collision;
        }
    }

    public void GetDamage(int damage)
    {
        san2 -= damage;
       san.text = san2.ToString() ;
        if (san2<=-10)
        {
            GetComponent<MoveMent>().Die();
        }

    }
}
