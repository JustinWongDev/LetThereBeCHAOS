using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private GameObject bgIntro = null;
    [SerializeField] private GameObject bgGame = null;

    public static AudioClip jump, damage, orb, bounce, wave, button;
    private static AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        jump = UnityEngine.Resources.Load<AudioClip>("jump");
        damage = UnityEngine.Resources.Load<AudioClip>("damage");
        orb = UnityEngine.Resources.Load<AudioClip>("orb");
        bounce = UnityEngine.Resources.Load<AudioClip>("bounce");
        wave = UnityEngine.Resources.Load<AudioClip>("wavePush");
        button = UnityEngine.Resources.Load<AudioClip>("button");

        PlayIntro();

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

    public static void PlayJump()
    {
        audioSrc.PlayOneShot(jump);
    }
    public static void PlayDamage()
    {
        audioSrc.PlayOneShot(damage);
    }

    public static void PlayOrb()
    {
        audioSrc.PlayOneShot(orb);
    }

    public static void PlayBounce()
    {
        audioSrc.PlayOneShot(bounce);
    }

    public static void PlayWave()
    {
        audioSrc.PlayOneShot(wave);
    }

    public void PlayButton()
    {
        audioSrc.PlayOneShot(button);
    }
}
