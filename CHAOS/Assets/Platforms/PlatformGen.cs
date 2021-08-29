using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGen : MonoBehaviour
{
    [Header("Var")]
    [SerializeField] private float yDistBetweenMax = 2.0f;
    [SerializeField] private float yDistBetweenMin = 1.0f;
    [SerializeField] private float maxXDisplacement = 12.0f;
    [SerializeField] private float xDistBetweenMax = 10.0f;
    [SerializeField] private float xDistBetweenMin = 4.0f;
    [SerializeField] private int initNumPlatforms = 5;
    [SerializeField] private float spawnMoreThreshold = 10.0f;
    [SerializeField] private int numPlatformsBatched = 10;
    [SerializeField] private float rateOfLateralPlatforms = 75f;
    [SerializeField] private float xLatDistBetweenMax = 10.0f;
    [SerializeField] private float xLatDistBetweenMin = 8.0f;
    [SerializeField] private float yLatDisplacement = 1.0f;

    [Header("Refs")]
    [SerializeField] private GameObject prefPlatform = null;

    private Vector2 spawnPt = Vector2.zero;
    private PlayerController player = null;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();

        GameManager.Instance.Newgame.AddListener(Initialise);
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentState() != GameManager.gameState.Ingame)
            return;

        CheckNewPlatforms();
    }

    void Initialise()
    {
        spawnPt = Vector2.zero;
        SpawnMorePlatforms(initNumPlatforms);
    }

    void SpawnMorePlatforms(int numOfPlatforms)
    {
        for (int i = 0; i < numOfPlatforms; i++)
        {
            if (spawnPt.x >= 12)
            {
                spawnPt.x = 12;
                spawnPt.x += Random.Range(Random.Range(-xDistBetweenMin, -xDistBetweenMax), 0);
            }
            else if (spawnPt.x <= -12)
            {
                spawnPt.x = -12;
                spawnPt.x += Random.Range(0, Random.Range(xDistBetweenMin, xDistBetweenMax));
            }
            else
            {
                spawnPt.x += Random.Range(Random.Range(-xDistBetweenMin, -xDistBetweenMax), Random.Range(xDistBetweenMin, xDistBetweenMax));
            }

            spawnPt.y += Random.Range(yDistBetweenMin, yDistBetweenMax);

            GameObject go = Instantiate(prefPlatform);
            go.transform.position = spawnPt;

            SpawnLateralPlatforms();
        }
    }

    void SpawnLateralPlatforms()
    {
        if (Random.Range(0, 100) >= (100 - rateOfLateralPlatforms))
        {
            Vector2 newPos = spawnPt;
            newPos.x += Random.Range(Random.Range(-xLatDistBetweenMin, -xLatDistBetweenMax), 0);
            newPos.y += Random.Range(-yLatDisplacement, yLatDisplacement);

            GameObject go = Instantiate(prefPlatform);
            go.transform.position = newPos;
        }

        if (Random.Range(0, 100) >= (100 - rateOfLateralPlatforms))
        {
            Vector2 newPos = spawnPt;
            newPos.x += Random.Range(0, Random.Range(xLatDistBetweenMin, xLatDistBetweenMax));
            newPos.y += Random.Range(-yLatDisplacement, yLatDisplacement);

            GameObject go = Instantiate(prefPlatform);
            go.transform.position = newPos;
        }
    }

    void CheckNewPlatforms()
    {
        if (Vector2.Distance(spawnPt, player.transform.position) <= spawnMoreThreshold)
        {
            SpawnMorePlatforms(numPlatformsBatched);
        }
    }
}
