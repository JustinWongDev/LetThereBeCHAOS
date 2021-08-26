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

    private PlatformTypes type = PlatformTypes.Basic;

    private SpriteRenderer rend = null;

    private void Start()
    {
        rend = GetComponentInChildren<SpriteRenderer>();
    }

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
            type = (PlatformTypes)0;
        }
        else if (randVal > rates[0] && randVal <= rates[0] + rates[1])
        {
            type = (PlatformTypes)1;
        }
        else if (randVal > rates[0] + rates[1] && randVal <= rates[0] + rates[1] + rates[2])
        {
            type = (PlatformTypes)2;
        }
        else if (randVal > rates[0] + rates[1] + rates[2] && randVal <= rates[0] + rates[1] + rates[2] + rates[3])
        {
            type = (PlatformTypes)3;
        }
        else
        {
            type = (PlatformTypes)0;
        }

        //type = (PlatformTypes)Random.Range(0, System.Enum.GetValues(typeof(PlatformTypes)).Length);

        UpdateObj();
    }

    private void UpdateObj()
    {
        for (int i = 0; i < objs.Length; i++)
        {
            if ((int)type == i)
            {
                objs[i].SetActive(true);
            }
            else
            {
                objs[i].SetActive(false);
            }
        }

        rend.sprite = sprites[(int)type];
        if (Random.Range(0, 100) > 50)
        {
            rend.flipX = true;
        }
    }
}


