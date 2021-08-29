using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject uiMainmenu = null;
    [SerializeField] private GameObject uiIngame = null;
    [SerializeField] private GameObject uiGameover = null;

    void Start()
    {
        GameManager.Instance.Mainmenu.AddListener(MainMenu);
        GameManager.Instance.Newgame.AddListener(Ingame);
        GameManager.Instance.Gameover.AddListener(Gameover);

        GameManager.Instance.Mainmenu?.Invoke();
    }

    public void StartNewGame()
    {
        GameManager.Instance.Newgame?.Invoke();
    }

    public void BackToMain()
    {
        GameManager.Instance.Mainmenu?.Invoke();
    }

    void MainMenu()
    {
        ToggleUIMainmenu(true);
        ToggleUIGameover(false);
        ToggleUIIngame(false);
    }

    void Ingame()
    {
        ToggleUIMainmenu(false);
        ToggleUIGameover(false);
        ToggleUIIngame(true);
    }

    void Gameover()
    {
        ToggleUIMainmenu(false);
        ToggleUIGameover(true);
        ToggleUIIngame(false);
    }

    void ToggleUIIngame(bool val)
    {
        uiIngame.SetActive(val);
    }

    void ToggleUIGameover(bool val)
    {
        uiGameover.SetActive(val);
    }

    void ToggleUIMainmenu(bool val)
    {
        uiMainmenu.SetActive(val);
    }
}
