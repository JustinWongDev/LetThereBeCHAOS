using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChaosTimer : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float timeTilWave = 5.0f;
    [SerializeField] private bool isRandomising = false;
    [SerializeField] private float waveTimeScale = 0.25f;
    [SerializeField] private float timeScaleDuration = 1.5f;
    [SerializeField] private float distForNewWave = 30.0f;

    [Header("Refs")]
    [SerializeField] private TextMeshProUGUI textTimer = null;
    [SerializeField] private GameObject prefWave = null;
    [SerializeField] private GameObject wavePos = null;

    private float timer = 10.0f;

    private PlayerInput input = null;

    [Header("Build Up")]
    [SerializeField] private float twirlInit = 0.0f;
    [SerializeField] private float twirlFinal = 10.0f;    
    [SerializeField] private float scaleInit = 0.0f;
    [SerializeField] private float scaleFinal = 2.0f;
    [SerializeField] private float speedInit = 0.0f;
    [SerializeField] private float speedFinal = 2.0f;
    [SerializeField] private float dissolveInit = 5.0f;
    [SerializeField] private float dissolveFinal = 0.9f;
    [SerializeField] private GameObject buildUp = null;
    private GameObject currentWave = null;

    private void Start()
    {
        input = FindObjectOfType<PlayerInput>();

        SpawnWave();
    }

    void Update()
    {
        RandomiseInputsOnTimer();
        UpdateUI();

        ReplaceWave();
    }

    private void ReplaceWave()
    {
        if (Vector2.Distance(input.transform.position, currentWave.transform.position) >= distForNewWave)
        {
            SpawnWave();
        }
    }

    public void SpawnWave()
    {
        currentWave = Instantiate(prefWave, wavePos.transform);
        currentWave.transform.position = wavePos.transform.position;
        StartCoroutine(BuildUp());
    }

    public void RandomiseInputsOnTimer()
    {
        if (!isRandomising)
            return;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            GameObject go = Instantiate(prefWave);
            go.transform.position = wavePos.transform.position;

            timer = timeTilWave;
        }
    }

    void UpdateUI()
    {
        textTimer.text = timer.ToString("f0");
    }

    IEnumerator BuildUp()
    {
        float elapsedTime = 0;
        float waitTime = timeTilWave;

        float twirlStrength = twirlInit;
        float scale = scaleInit;
        float speed = speedInit;
        float dissolve = dissolveInit;

        while (elapsedTime < waitTime)
        {
            twirlStrength = Mathf.Lerp(twirlStrength, twirlFinal, (elapsedTime / waitTime));
            scale = Mathf.Lerp(scale, scaleFinal, (elapsedTime / waitTime));
            speed = Mathf.Lerp(speed, speedFinal, (elapsedTime / waitTime));
            dissolve = Mathf.Lerp(dissolve, dissolveFinal, (elapsedTime / waitTime));

            currentWave.GetComponent<SpriteRenderer>().material.SetFloat("TwirlStrength", twirlStrength);
            currentWave.GetComponent<SpriteRenderer>().material.SetFloat("Scale", scale);
            currentWave.GetComponent<SpriteRenderer>().material.SetFloat("Speed", speed);
            currentWave.GetComponent<SpriteRenderer>().material.SetFloat("DissolveAmount", dissolve);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        PushWave();
    }

    void PushWave()
    {
        currentWave.GetComponent<Wave>().enabled = true;
    }
}
