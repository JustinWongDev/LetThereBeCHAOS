using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaosShader : MonoBehaviour
{
    [SerializeField] private float duration = 0.25f;
    [SerializeField] private SpriteRenderer rend = null;
    [SerializeField] private Image img = null;
    [SerializeField] private bool isImage = false;

    public IEnumerator Shift()
    {
        float elapsedTime = 0;
        float waitTime = duration;
        float fade = 0;

        if (isImage)
        {
            while (elapsedTime < waitTime)
            {
                fade = Mathf.Lerp(0, 1, (elapsedTime / waitTime));
                img.material.SetFloat("_Fade", fade);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            img.material.SetFloat("_Fade", 1);
        }
        else
        {
            while (elapsedTime < waitTime)
            {
                fade = Mathf.Lerp(0, 1, (elapsedTime / waitTime));
                rend.material.SetFloat("_Fade", fade);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            rend.material.SetFloat("_Fade", 1);
        }

    }
}
