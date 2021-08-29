using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camMain = null;
    [SerializeField] private CinemachineVirtualCamera camGame = null;

    void Start()
    {
        GameManager.Instance.Mainmenu.AddListener(Mainmenu);
        GameManager.Instance.Newgame.AddListener(Ingame);
        GameManager.Instance.Gameover.AddListener(Gameover);
    }

    void Mainmenu()
    {
        camMain.Priority = 10;
        camGame.Priority = 1;
    }

    void Ingame()
    {
        camMain.Priority = 1;
        camGame.Priority = 10;
    }

    void Gameover()
    {
        camMain.Priority = 1;
        camGame.Priority = 10;
    }

}
