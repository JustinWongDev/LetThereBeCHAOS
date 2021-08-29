using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInMenu : MonoBehaviour
{

    [SerializeField] private GameObject go = null;

    void Start()
    {
        GameManager.Instance.Mainmenu.AddListener(TurnOn);
        GameManager.Instance.Gameover.AddListener(TurnOff);
        GameManager.Instance.Newgame.AddListener(TurnOff);
    }

    void TurnOn()
    {
        go.SetActive(true);
    }
    
    void TurnOff()
    {
        go.SetActive(false);
    }
}
