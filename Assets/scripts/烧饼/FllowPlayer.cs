using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FllowPlayer : MonoBehaviour
{
    [SerializeField] Transform Player;
  
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y+1.8f, Player.position.z);
    }
}
