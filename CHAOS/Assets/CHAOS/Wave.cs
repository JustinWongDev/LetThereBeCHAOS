using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;

    void Update()
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
    }
}
