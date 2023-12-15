using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject distenation;

    public bool moving = true;

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Player")
        {
            if (moving)
            {
                if (this.transform.position.y >= distenation.transform.position.y)
                    moving = false;
                else
                    this.transform.position -= (transform.up) * Time.deltaTime * 2f;
            }

        }
    }
}
