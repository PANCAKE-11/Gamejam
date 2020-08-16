using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDialog : MonoBehaviour
{
    [SerializeField] List<GameObject> dialogs;
    private void Start()
    {
        StartCoroutine(Spwan());
    }

    IEnumerator Spwan()
    {
        while (true)
        {
            int num = UnityEngine.Random.Range(0, dialogs.Count);
            GameObject temp = Instantiate(dialogs[num],new Vector3(transform.position.x+Random.Range(-1,1f), transform.position.y + Random.Range(-1, 1f)), Quaternion.identity);
           
            yield return new WaitForSeconds(4);
        }
    }
}
