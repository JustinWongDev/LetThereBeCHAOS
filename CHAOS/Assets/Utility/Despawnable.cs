using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawnable : MonoBehaviour
{
    [SerializeField] private float despawnDist = 50.0f;

    private PlayerController player = null;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > despawnDist)
        {
            Destroy(this.gameObject);
        }
    }
}
