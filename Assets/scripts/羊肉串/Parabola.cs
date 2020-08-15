using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabola : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Left;
    [SerializeField] GameObject Right;
    bool IsShoot = false;
   [SerializeField] float instaTimer;
   [SerializeField] float instaCounter;


   public List<GameObject> casts;
    // Start is called before the first frame update

    private void Start()
    {
            instaCounter = instaTimer;

    }
    // Update is called once per framelay
    void Update()
    {
        if (instaCounter>0&& 
            Player.transform.position.x > Left.transform.position.x && Player.transform.position.x < Right.transform.position.x &&
            IsShoot == false)
        {
            instaCounter -= Time.deltaTime;
            if (instaCounter<=0)
            {
                InstantiateRubbish();
            }
        }
        else
        {
            instaCounter = instaTimer;
            IsShoot = false;

        }

    }


    void InstantiateRubbish()
    {
                    Instantiate(casts[Random.Range(0,casts.Count)], transform.position, Quaternion.identity);
                    IsShoot = true;
    }
}
