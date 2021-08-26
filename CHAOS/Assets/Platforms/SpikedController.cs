using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedController : MonoBehaviour
{
    [SerializeField] private GameObject[] spikeLocations = null;

    private void OnEnable()
    {
        int rand = Random.Range(0, spikeLocations.Length);

        for (int i = 0; i < spikeLocations.Length; i++)
        {
            if (i == rand)
            {
                spikeLocations[i].SetActive(true);

                if (Random.Range(0, 100) > 50)
                {
                    spikeLocations[i].GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            else
            {
                spikeLocations[i].SetActive(false);
            }
        }
    }
}
