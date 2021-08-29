using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public UnityEvent Gameover;
    public UnityEvent Newgame;
    public UnityEvent Mainmenu;

    public enum gameState {
        MainMenu,
        Ingame,
        Gameover}

    private gameState currentState = gameState.MainMenu;

    private void Start()
    {
        Mainmenu.AddListener(SetStateToMain);
        Newgame.AddListener(SetStateToIngame);
        Gameover.AddListener(SetStateToGameover);
    }

    public gameState CurrentState()
    {
        return currentState;
    }

    void SetStateToMain()
    {
        currentState = gameState.MainMenu;
    }

    void SetStateToIngame()
    {
        currentState = gameState.Ingame;
    }

    void SetStateToGameover()
    {
        currentState = gameState.Gameover;
    }

}
