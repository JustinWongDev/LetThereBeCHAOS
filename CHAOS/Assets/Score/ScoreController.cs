using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [Header("Vars")]
    [SerializeField] private int ptsPerOrb = 50;

    [Header("Refs")]
    [SerializeField] private TextMeshProUGUI textScore = null;
    [SerializeField] private TextMeshProUGUI textFinalScore = null;

    private PlayerController player = null;
    private float maxYReached = 0;
    private int numOrbsCollected = 0;

    private float score;


    private void Start()
    {
        player = FindObjectOfType<PlayerController>();

        GameManager.Instance.Newgame.AddListener(NewGame);
        GameManager.Instance.Gameover.AddListener(GameOver);
    }

    void Update()
    {
        score = maxYReached + numOrbsCollected * ptsPerOrb;

        if (player.gameObject.transform.position.y > maxYReached)
        {
            maxYReached = player.gameObject.transform.position.y;
        }

        textScore.text = score.ToString("f0");
    }

    void GameOver()
    {
        textFinalScore.text = "Final Score: " + score.ToString("f0");
    }
    public void AddOrb()
    {
        numOrbsCollected++;
    }

    private void NewGame()
    {
        numOrbsCollected = 0;
        maxYReached = 0;
    }
}
