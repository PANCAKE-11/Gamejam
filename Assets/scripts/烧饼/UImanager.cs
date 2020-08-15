using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : Singleton<UImanager>
{
    [SerializeField] public GameObject panel;
    [SerializeField] private GameObject PlayerName;
    [SerializeField] private Text _InputName;
    [SerializeField] private Text _PlayerName;
    
    string _playerName;
    public void Name()
    {
        _PlayerName.text = _InputName.text;
        panel.SetActive(false);
        PlayerName.SetActive(true);
    }
    public  void  LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
