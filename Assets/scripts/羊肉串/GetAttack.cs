using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetAttack : MonoBehaviour
{
    [SerializeField] Text san;
    Collider2D collider2;
    int san2 = 0;
    bool IsTaugh = false;
    private void Update()
    {
        if(IsTaugh)
        {
            if(Input.GetKeyDown(KeyCode.J))
            {
                Destroy(collider2.gameObject);
                IsTaugh = false;
            }
        }
    }
    // Start is called before the first frame update
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
        }
    }
}
