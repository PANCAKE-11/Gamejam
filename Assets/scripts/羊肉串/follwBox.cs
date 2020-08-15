using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class follwBox : MonoBehaviour
{
    [SerializeField] GameObject UI;

    private void Start()
    {
        Destroy(gameObject, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            UI.SetActive(true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            UI.SetActive(false);

        }
    }
}
