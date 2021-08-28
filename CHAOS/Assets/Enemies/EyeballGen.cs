using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballGen : MonoBehaviour
{
    [SerializeField] private Transform eyeballPos;
    [SerializeField] private GameObject prefEyeball = null;
    [SerializeField] private float maxeyeballTime = 8.0f;
    [SerializeField] private float mineyeballTime = 5.0f;
    [SerializeField] private float xRange = 12.0f;
    [SerializeField] private float yRange = 3.0f;
    private float timer = 0.0f;

    private void OnEnable()
    {
        timer = Random.Range(mineyeballTime, maxeyeballTime); ;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            SpawnEyeball();
            timer = Random.Range(mineyeballTime, maxeyeballTime);
        }
    }

    void SpawnEyeball()
    {
        GameObject go = Instantiate(prefEyeball, eyeballPos.transform);
        Vector2 newPos = eyeballPos.position;
        newPos.x = Random.Range(0, xRange);
        newPos.y += Random.Range(-yRange, yRange);
        eyeballPos.transform.position = newPos;
    }
}
