using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Fish : Enemy_Controller
{
    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float Amplitude;
    public float pos;
    private Vector3 temp_pos;

    void Start()
    {
        temp_pos = transform.position;
    }

    void FixedUpdate()
    {
        if (isFacingRight)
        {
            temp_pos.x += HorizontalSpeed * Time.deltaTime;
            temp_pos.y = (Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * Amplitude) - pos;
            transform.position = temp_pos;
        }
        else
        {
            temp_pos.x -= HorizontalSpeed * Time.deltaTime;
            temp_pos.y = (Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * Amplitude) - pos;
            transform.position = temp_pos;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Wall")
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