using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase : MonoBehaviour
{
    [SerializeField] SpriteRenderer rend = null;
    [SerializeField] private float phaseOutTime = 1.0f;
    [SerializeField] private float delay = 3.0f;
    [SerializeField] private GameObject parent = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            StartCoroutine(DelayPhase());
        }
    }

    IEnumerator DelayPhase()
    {
        yield return new WaitForSeconds(delay);

        StartCoroutine(PhaseOut());
    }

    IEnumerator PhaseOut()
    {
        float elapsedTime = 0;
        float waitTime = phaseOutTime;

        Color tmp = rend.color;

        while (elapsedTime < waitTime)
        {
            tmp.a = Mathf.SmoothStep(tmp.a, 0, (elapsedTime / waitTime));
            tmp.g = Mathf.SmoothStep(tmp.g, 0, (elapsedTime / waitTime));
            rend.color = tmp;
            elapsedTime += Time.deltaTime;
            yield return null;

        }
        parent.SetActive(false);

    }
}
