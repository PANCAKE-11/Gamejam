using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPack : MonoBehaviour
{
   public  List<Transform> spawn_Points;
    GameObject[] spawned = new GameObject[7];
    public GameObject packPrefabs;

    private void Start()
    {
        StartCoroutine(Spwan());
    }

    IEnumerator Spwan()
    {
        while (true)
        {
                int num = UnityEngine.Random.Range(0, spawn_Points.Count);
              GameObject temp=   Instantiate(packPrefabs, spawn_Points[num].position, Quaternion.identity);
           // temp.transform.localScale = temp.transform.localScale * UnityEngine.Random.Range(1, 2f);
            if (spawned[num]==null)
            {
              spawned[num] = temp;
            }
            else
            {
                Destroy(spawned[num]);
                spawned[num] = temp;

            }


            yield return new WaitForSeconds(1);
        }
    }
}
