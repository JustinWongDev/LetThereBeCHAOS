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

    private PlatformTypes type = PlatformTypes.Basic;

    private SpriteRenderer rend = null;

    private void Start()
    {
        rend = GetComponentInChildren<SpriteRenderer>();
    }

    public void SwapToRandomPlatform()
    { 
        type = (PlatformTypes)Random.Range(0, System.Enum.GetValues(typeof(PlatformTypes)).Length);

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


