using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleGen : MonoBehaviour
{
    [Header("Tentacle")]
    [SerializeField] private Transform tentaclePos;
    [SerializeField] private GameObject prefTentacle = null;
    [SerializeField] private float tentacleTime = 5.0f;
    [SerializeField] private float xRange = 12.0f;
    private float timer = 0.0f;

    private void OnEnable()
    {
        timer = tentacleTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            SpawnTentacle();
            timer = tentacleTime;
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
