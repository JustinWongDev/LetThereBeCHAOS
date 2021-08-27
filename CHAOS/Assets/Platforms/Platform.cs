using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlatformTypes
{ 
    Basic,
    Spiked,
    Phasing,
    Bouncy
}

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject[] objs = null;
    [SerializeField] private Sprite[] sprites = null;
    [SerializeField] private int[] rates = null;

    private PlatformTypes nextType = PlatformTypes.Basic;
    private PlatformTypes currentType = PlatformTypes.Basic;

    [SerializeField] private SpriteRenderer rend = null;
    [SerializeField] private ChaosShader shad = null;
    private ChaosShader[] shads = null;

    public void SwapToRandomPlatform()
    {
        int totalRates = 0;
        foreach (int rate in rates)
        {
            totalRates += rate;
        }

        int randVal = Random.Range(0, totalRates);

        if (randVal > 0 && randVal <= rates[0])
        {
            nextType = (PlatformTypes)0;
        }
        else if (randVal > rates[0] && randVal <= rates[0] + rates[1])
        {
            nextType = (PlatformTypes)1;
        }
        else if (randVal > rates[0] + rates[1] && randVal <= rates[0] + rates[1] + rates[2])
        {
            nextType = (PlatformTypes)2;
        }
        else if (randVal > rates[0] + rates[1] + rates[2] && randVal <= rates[0] + rates[1] + rates[2] + rates[3])
        {
            nextType = (PlatformTypes)3;
        }
        else
        {
            nextType = (PlatformTypes)0;
        }

        UpdateObj();
    }

    private void UpdateObj()
    {
        for (int i = 0; i < objs.Length; i++)
        {
            if ((int)nextType == i)
            {
                objs[i].SetActive(true);
            }
            else
            {
                objs[i].SetActive(false);
            }
        }

        rend.sprite = sprites[(int)nextType];
        if (Random.Range(0, 100) > 50)
        {
            rend.flipX = true;
        }

        if (nextType != currentType)
        {
            //StartCoroutine(shad.Shift());
            shads = GetComponentsInChildren<ChaosShader>();
            foreach (ChaosShader shad in shads)
            {
                StartCoroutine(shad.Shift());
            }
        }

        currentType = nextType;
    }
}


