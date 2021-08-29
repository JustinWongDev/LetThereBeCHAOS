using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbGen : MonoBehaviour
{
    [SerializeField] private Transform orbPos;
    [SerializeField] private GameObject prefOrb = null;
    [SerializeField] private float maxTime = 5.0f;
    [SerializeField] private float minTime = 3.0f;
    [SerializeField] private float xRange = 12.0f;
    private float timer = 0.0f;

    private void OnEnable()
    {
        timer = Random.Range(minTime, maxTime);
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            SpawnOrb();
            timer = Random.Range(minTime, maxTime);
        }
    }

    void SpawnOrb()
    {
        GameObject go = Instantiate(prefOrb, orbPos.transform);
        Vector2 newPos = transform.position;
        newPos.x = Random.Range(-xRange, xRange);
        orbPos.transform.position = newPos;
    }
}
