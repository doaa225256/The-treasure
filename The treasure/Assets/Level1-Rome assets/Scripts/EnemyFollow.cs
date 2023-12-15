using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : Enemies
{
    private PlayerMovement player;
    private Animator animator;
    private bool isFacingRight = true; // Added variable to track the facing direction
    public float detectionRange = 5f; // Set the detection range in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is within the detection range
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToPlayer < detectionRange)
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
            // Set a parameter in the Animator to trigger the walking animation
            animator.SetBool("IsWalking", true);
        }
        else
        {
            // Player is not in range, play idle animation
            // Set a parameter in the Animator to trigger the idle animation
            animator.SetBool("IsWalking", false);
        }
    }

    void FixedUpdate()
    {
        // Move the enemy horizontally only if it is within the detection range
        if (Vector3.Distance(player.transform.position, transform.position) < detectionRange)
        {
            float horizontalMovement = isFacingRight ? maxSpeed : -maxSpeed;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalMovement, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            // Stop moving if the player is outside the detection range
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
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