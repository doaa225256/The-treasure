using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Flying_Enemy : Enemy_Controller
{
    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float Amplitude;

    private Vector3 tempPosition;

    void Start()
    {
        tempPosition = transform.position;
    }

    void FixedUpdate()
    {
        // Move the enemy in a sine wave pattern
        tempPosition.x += HorizontalSpeed * Time.deltaTime;
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * Amplitude;

        // Move the enemy
        transform.position = tempPosition;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Wall")
        {
            Flip();
        }
        if (collider.tag == "Enemy")
        {
            Flip();
        }
        if (collider.tag == "Player")
        {
            FindObjectOfType<Player_Stats>().TakeDamage(damage);
            Flip();
        }
    }
}