using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerOnYAxis : MonoBehaviour
{
    private PlayerController player = null;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        Vector3 newPos = transform.position;
        newPos.y = player.transform.position.y;

        transform.position = newPos;
    }
}
