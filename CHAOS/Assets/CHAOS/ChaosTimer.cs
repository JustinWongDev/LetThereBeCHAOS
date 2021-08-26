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

    [Header("Refs")]
    [SerializeField] private TextMeshProUGUI textTimer = null;
    [SerializeField] private GameObject prefWave = null;
    [SerializeField] private GameObject wavePos = null;

    private float timer = 0.0f;

    private PlayerInput input = null;
    private PostProcessController postProcCtrl = null;

    private void Start()
    {
        input = FindObjectOfType<PlayerInput>();
        postProcCtrl = FindObjectOfType<PostProcessController>();
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

        StartCoroutine(SlowTime());
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

    IEnumerator SlowTime()
    {
        Time.timeScale = waveTimeScale;
        StartCoroutine(LerpChromaticAberration(1.0f, 0.0f));

        yield return new WaitForSeconds(timeScaleDuration);

        StartCoroutine(LerpTimeScale(waveTimeScale, 1.0f));
        StartCoroutine(LerpChromaticAberration(0.0f, 1.0f));
    }

    IEnumerator LerpChromaticAberration(float valTo, float valFrom)
    {
        float elapsedTime = 0;
        float waitTime = timeScaleDuration / 2;

        while (elapsedTime < waitTime)
        {
            //transform.position = Vector3.Lerp(currentPos, Gotoposition, (elapsedTime / waitTime));

            valFrom = Mathf.Lerp(valFrom, valTo, (elapsedTime / waitTime));
            postProcCtrl.SetChromaticAb(valFrom);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator LerpTimeScale(float valTo, float valFrom)
    {
        float elapsedTime = 0;
        float waitTime = timeScaleDuration;

        while (elapsedTime < waitTime)
        {
            valFrom = Mathf.Lerp(valFrom, valTo, (elapsedTime / waitTime));
            Time.timeScale = valFrom;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
