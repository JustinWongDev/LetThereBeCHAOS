using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Brick { basic, cracked, weathered, broken, hole };

public class BrickLayer : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private int bricksPerRow = 12;
    [SerializeField] private int initNumRows = 10;
    [SerializeField] private float distBetweenBricks = 2.0f;
    [SerializeField] private float distBetweenRows = 0.5f;
    [SerializeField] private float spawnMoreThreshold = 10.0f;
    [SerializeField] private float torchRate = 25.0f;


    [Header("Prefabs")]
    [SerializeField] private GameObject prefBrickBasic = null;
    [SerializeField] private GameObject prefTorch = null;

    Row row = new Row();
    List<Row> tower = new List<Row>();

    Vector2 spawnPt = Vector2.zero;
    private PlayerController player = null;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();

        Initialise();
    }

    private void Update()
    {
        CheckNewRow();
    }

    private void Initialise()
    {
        for (int j = 0; j < initNumRows; j++)
        {
            row = new Row();

            for (int i = 0; i < bricksPerRow; i++)
            {
                row.AddBrick(Brick.basic);
            }

            tower.Add(row);
        }

        for (int j = 0; j < initNumRows; j++)
        {
            for (int i = 0; i < bricksPerRow; i++)
            {
                switch (tower[j].GetBrickAtIndex(i))
                {
                    case Brick.basic:
                        GameObject go = Instantiate(prefBrickBasic, this.transform);
                        go.GetComponent<BrickObj>().SwapToRandomBrick();
                        Vector3 newPos = transform.position;
                        newPos.x += distBetweenBricks * i;

                        if (j % 2 == 0)
                            newPos.x += distBetweenBricks / 2;

                        newPos.y += distBetweenRows * j;
                        go.transform.position = newPos;
                        spawnPt = newPos;
                        break;
                }
            }
        }
    }

    private void CheckNewRow()
    {
        if (Mathf.Abs(spawnPt.y - player.transform.position.y) <= spawnMoreThreshold)
        {
            SpawnMoreBricks(10);
            SpawnMoreTorches();
        }
    }

    private void SpawnMoreBricks(int numOfRows)
    {
        spawnPt.x = transform.position.x - 2;

        for (int j = 0; j < numOfRows; j++)
        {
            if (j % 2 == 0)
                spawnPt.x += distBetweenBricks / 2;

            for (int i = 0; i < bricksPerRow; i++)
            {
                GameObject go = Instantiate(prefBrickBasic, this.transform);
                go.GetComponent<BrickObj>().SwapToRandomBrick();
                spawnPt.x += distBetweenBricks;

                go.transform.position = spawnPt;
            }

            spawnPt.x = transform.position.x - 2;
            spawnPt.y += distBetweenRows;
        }
    }

    private void SpawnMoreTorches()
    {
        Vector2 leftTorchPos = spawnPt;
        leftTorchPos.x = -11.0f;
        Vector2 rightTorchPos = spawnPt;
        rightTorchPos.x = 11.0f;


        if (Random.Range(0, 100) <= torchRate)
        {
            GameObject left = Instantiate(prefTorch);
            left.transform.position = leftTorchPos;

            if (Random.Range(0, 100) >= 50)
                left.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }

        if (Random.Range(0, 100) <= torchRate)
        {
            GameObject right = Instantiate(prefTorch);
            right.transform.position = rightTorchPos;

            if (Random.Range(0, 100) >= 50)
                right.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }

    }
}
