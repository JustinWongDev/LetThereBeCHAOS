using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unparent : MonoBehaviour
{
    public void UnparentMe()
    {
        Vector2 currentPos = transform.position;

        this.transform.SetParent(null);

        //this.transform.localScale = new Vector3(1, 1, 1);
        //transform.position = currentPos;
    }
}
