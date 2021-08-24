﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChaosTimer : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float timeTilWave = 5.0f;
    [SerializeField] private bool isRandomising = false;

    [Header("Refs")]
    [SerializeField] private TextMeshProUGUI textTimer = null;
    [SerializeField] private GameObject prefWave = null;
    [SerializeField] private GameObject wavePos = null;

    private float timer = 0.0f;

    private PlayerInput input = null;

    private void Start()
    {
        input = FindObjectOfType<PlayerInput>();
    }

    void Update()
    {
        RandomiseInputsOnTimer();
        UpdateUI();
    }

    public void SpawnWave()
    {
        GameObject go = Instantiate(prefWave);
        go.transform.position = wavePos.transform.position;
    }

    public void RandomiseInputsOnTimer()
    {
        if (!isRandomising)
            return;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            //input.RandomiseKeys();
            GameObject go = Instantiate(prefWave);
            go.transform.position = wavePos.transform.position;

            timer = timeTilWave;
        }
    }

    void UpdateUI()
    {
        textTimer.text = timer.ToString("f0");
    }
}
