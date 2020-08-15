using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            MoveMent moveMent = collision.GetComponent<MoveMent>();
            moveMent.canMove = false;
            UImanager._instance.Playpolt2();
        }
    }
}
