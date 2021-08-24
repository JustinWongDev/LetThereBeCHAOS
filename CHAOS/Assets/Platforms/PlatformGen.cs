using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGen : MonoBehaviour
{
    [Header("Var")]
    [SerializeField] private float yDistBetweenMax = 2.0f;
    [SerializeField] private float yDistBetweenMin = 1.0f;
    [SerializeField] private float xDistBetweenMax = 10.0f;
    [SerializeField] private float xDistBetweenMin = 4.0f;
    [SerializeField] private int initNumPlatforms = 5;
    [SerializeField] private float spawnMoreThreshold = 10.0f;
    [SerializeField] private int numPlatformsBatched = 10;

    [Header("Refs")]
    [SerializeField] private GameObject prefPlatform = null;

    private Vector2 spawnPt = Vector2.zero;
    private PlayerController player = null;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();

        Initialise();
    }

    private void Update()
    {
        CheckNewPlatforms();
    }

    void Initialise()
    {
        SpawnMorePlatforms(initNumPlatforms);
    }

    void SpawnMorePlatforms(int numOfPlatforms)
    {
        for (int i = 0; i < numOfPlatforms; i++)
        {
            spawnPt.x += Random.Range(Random.Range(-xDistBetweenMin, -xDistBetweenMax), Random.Range(xDistBetweenMin, xDistBetweenMax));
            spawnPt.y += Random.Range(yDistBetweenMin, yDistBetweenMax);

            GameObject go = Instantiate(prefPlatform);
            go.transform.position = spawnPt;
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
