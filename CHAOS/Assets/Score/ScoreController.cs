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

    private PlayerController player = null;
    private float maxYReached = 0;
    private int numOrbsCollected = 0;

    private float score;


    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
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

    public void AddOrb()
    {
        numOrbsCollected++;
    }
}
