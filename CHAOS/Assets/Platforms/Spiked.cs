using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiked : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage();
            this.gameObject.SetActive(false);
        }
    }
}
