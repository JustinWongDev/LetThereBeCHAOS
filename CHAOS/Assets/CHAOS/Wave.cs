using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float waveTimeScale = 0.25f;
    [SerializeField] private float timeScaleDuration = 1.5f;
    [SerializeField] private float moveSpeed = 15.0f;

    private PostProcessController postProcCtrl = null;

    private void OnEnable()
    {
        postProcCtrl = FindObjectOfType<PostProcessController>();

        GetComponent<BoxCollider2D>().enabled = true;
        StartCoroutine(SlowTime());

        //Disable tentacles
        GetComponent<TentacleGen>().enabled = false;
        GetComponent<OrbGen>().enabled = false;
        GetComponent<EyeballGen>().enabled = false;
        Destroyable[] destroyables = FindObjectsOfType<Destroyable>();
        foreach (Destroyable destroyable in destroyables)
        {
            destroyable.DestroyMe();
        }
    }

    void Update()
    {
        MoveDown();
    }

    void MoveDown()
    {
        Vector2 newPos = transform.position;
        newPos.y -= moveSpeed * Time.deltaTime;
        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerInput>())
            collision.GetComponent<PlayerInput>().RandomiseKeys();

        if (collision.GetComponent<BrickObj>())
            collision.GetComponent<BrickObj>().SwapToRandomBrick();

        if (collision.GetComponent<Platform>())
            collision.GetComponent<Platform>().SwapToRandomPlatform();
    }

    IEnumerator SlowTime()
    {
        StartCoroutine(LerpChromaticAberration(1.0f, 0.0f));

        yield return new WaitForSeconds(timeScaleDuration);

        StartCoroutine(LerpChromaticAberration(0.0f, 1.0f));
    }

    IEnumerator LerpChromaticAberration(float valTo, float valFrom)
    {
        float elapsedTime = 0;
        float waitTime = timeScaleDuration / 2;

        while (elapsedTime < waitTime)
        {
            valFrom = Mathf.Lerp(valFrom, valTo, (elapsedTime / waitTime));
            postProcCtrl.SetChromaticAb(valFrom);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
