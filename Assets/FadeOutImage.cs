using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutImage : MonoBehaviour
{
    public void fade()
    {
        UImanager._instance.LoadScene("GoodLevel");
    }
}
