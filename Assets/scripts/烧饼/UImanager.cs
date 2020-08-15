using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public static UImanager _instance;
   

    protected virtual void Awake()
    {
        if (_instance != null)
        {
            Debug.LogError("[Singleton] Tring t instantate a sceond instace of singleton class");
        }
        else
        {
            _instance = this;
        }
    }
    [SerializeField] public GameObject StartPanel;
    [SerializeField] public GameObject EndPanel;
    [SerializeField] private GameObject PlayerName;
    [SerializeField] private Text _InputName;
    [SerializeField] private Text _PlayerName;
    [SerializeField] private Animator fadeImage;
    [SerializeField] private GameObject plot1;
    
    string _playerName;
    public void Name()
    {
        _PlayerName.text = _InputName.text;
        StartPanel.SetActive(false);
        PlayerName.SetActive(true);
    }
    public  void  LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

   
   public void FadeIn()
    {
        fadeImage.SetTrigger("fade");
    }

    public void PlayPolt()
    {
        plot1.SetActive(true);
    }


    public void GameEnd()
    {
        EndPanel.SetActive(true);
    }

    public void End()
    {
        Application.Quit();
    }
}
