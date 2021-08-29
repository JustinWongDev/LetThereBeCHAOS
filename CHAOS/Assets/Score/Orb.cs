using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    private ScoreController scoreCtrl = null;

    private void OnEnable()
    {
        scoreCtrl = FindObjectOfType<ScoreController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            scoreCtrl.AddOrb();
            SoundManager.PlayOrb();
            Destroy(this.gameObject);
        }

    }
}
