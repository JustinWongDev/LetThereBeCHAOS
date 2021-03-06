using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChaosTimer : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float timeTilWave = 5.0f;
    [SerializeField] private float distForNewWave = 30.0f;

    [Header("Refs")]
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

        GameManager.Instance.Newgame.AddListener(NewGame);
        GameManager.Instance.Gameover.AddListener(Gameover);
    }

    void Update()
    {
        ReplaceWave();
    }

    private void Gameover()
    {
        Destroyable[] destroyables = FindObjectsOfType<Destroyable>();
        foreach (Destroyable destroyable in destroyables)
        {
            destroyable.DestroyMe();
        }

        Destroy(currentWave.gameObject);
        Time.timeScale = 1;
    }

    private void NewGame()
    {
        SpawnWave();
    }

    private void ReplaceWave()
    {
        if (GameManager.Instance.CurrentState() != GameManager.gameState.Ingame)
            return;

        if (Vector2.Distance(input.transform.position, currentWave.transform.position) >= distForNewWave)
        {
            Destroy(currentWave.gameObject);
            SpawnWave();
        }
    }

    public void SpawnWave()
    {
        currentWave = Instantiate(prefWave, wavePos.transform);
        currentWave.transform.position = wavePos.transform.position;
        StartCoroutine(BuildUp());
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

            if (currentWave == null)
                break; 

            currentWave.GetComponentInChildren<SpriteRenderer>().material.SetFloat("TwirlStrength", twirlStrength);
            currentWave.GetComponentInChildren<SpriteRenderer>().material.SetFloat("Scale", scale);
            currentWave.GetComponentInChildren<SpriteRenderer>().material.SetFloat("Speed", speed);
            currentWave.GetComponentInChildren<SpriteRenderer>().material.SetFloat("DissolveAmount", dissolve);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        PushWave();
    }

    void PushWave()
    {
        if (currentWave == null)
            return;

        currentWave.GetComponent<Wave>().enabled = true;
    }
}
