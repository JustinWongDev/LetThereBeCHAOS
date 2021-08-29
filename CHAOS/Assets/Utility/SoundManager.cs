using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private GameObject bgIntro = null;
    [SerializeField] private GameObject bgGame = null;

    //public static AudioClip Intro, Game;
    private static AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        //Intro = UnityEngine.Resources.Load<AudioClip>("Intro");
        //Game = UnityEngine.Resources.Load<AudioClip>("Game");

        GameManager.Instance.Mainmenu.AddListener(PlayIntro);
        GameManager.Instance.Newgame.AddListener(PlayGame);
        GameManager.Instance.Gameover.AddListener(PlayIntro);
    }

    public void PlayIntro()
    {
        bgIntro.SetActive(true);
        bgGame.SetActive(false);
    }
    public void PlayGame()
    {
        bgIntro.SetActive(false);
        bgGame.SetActive(true);
    }

}
