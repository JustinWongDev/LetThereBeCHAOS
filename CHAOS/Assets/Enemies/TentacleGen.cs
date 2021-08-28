using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleGen : MonoBehaviour
{
    [Header("Tentacle")]
    [SerializeField] private Transform tentaclePos;
    [SerializeField] private GameObject prefTentacle = null;
    [SerializeField] private float maxtentacleTime = 10.0f;
    [SerializeField] private float mintentacleTime = 8.0f;
    [SerializeField] private float xRange = 12.0f;
    private float timer = 0.0f;

    private void OnEnable()
    {
        timer = Random.Range(mintentacleTime, maxtentacleTime);
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            SpawnTentacle();
            timer = Random.Range(mintentacleTime, maxtentacleTime); ;
        }
    }

    void SpawnTentacle()
    {
        GameObject go = Instantiate(prefTentacle, tentaclePos.transform);
        Vector2 newPos = tentaclePos.position;
        newPos.x += Random.Range(-xRange, xRange);
        tentaclePos.transform.position = newPos;
    }
}
