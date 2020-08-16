using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left*Time.deltaTime*2.2f;
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
