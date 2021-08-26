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
        //postProcCtrl.SetLensDistortion(1.0f);
        //postProcCtrl.SetChromaticAb(1.0f);
        StartCoroutine(LerpChromaticAberration(1.0f, 0.0f));

        yield return new WaitForSeconds(timeScaleDuration);

        //postProcCtrl.SetLensDistortion(0.0f);
        //postProcCtrl.SetChromaticAb(0.0f);
        StartCoroutine(LerpChromaticAberration(0.0f, 1.0f));
        Time.timeScale = 1.0f;
    }

    IEnumerator LerpChromaticAberration(float valTo, float valFrom)
    {
        float elapsedTime = 0;
        float waitTime = timeScaleDuration;

        float chromVal = valFrom;

        while (elapsedTime < waitTime)
        {
            //transform.position = Vector3.Lerp(currentPos, Gotoposition, (elapsedTime / waitTime));

            chromVal = Mathf.Lerp(chromVal, valTo, (elapsedTime / waitTime));
            postProcCtrl.SetChromaticAb(chromVal);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
