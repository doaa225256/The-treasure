using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : Enemies
{
    private PlayerMovement player;
    private bool isFacingRight = true; // Added variable to track the facing direction
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check the player's position and flip the enemy accordingly
        if (player.transform.position.x > transform.position.x && !isFacingRight)
        {
            Flip();
        }
        else if (player.transform.position.x < transform.position.x && isFacingRight)
        {
            Flip();
        }

        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, maxSpeed * Time.deltaTime);
    }
    void FixedUpdate()
    {
        // Move the enemy horizontally
        float horizontalMovement = isFacingRight ? maxSpeed : -maxSpeed;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalMovement, this.GetComponent<Rigidbody2D>().velocity.y);
    }

    // Function to flip the enemy
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}