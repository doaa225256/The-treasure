using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyy : Enemies
{
    private Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the enemy is attacking and stop moving during the attack animation
        if (isAttacking)
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else
        {
            // Move the enemy based on the facing direction
            if (this.isFacingRight)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Wall" || collider.tag == "Enemy")
        {
            // If the enemy collides with a wall or another enemy, flip direction
            Flip();
        }
        else if (collider.tag == "Player")
        {
            // Start the attack animation and apply damage to the player
            Attack();
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }
    }

    // Function to handle the attack animation
    void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("Attack"); // Assuming you have a trigger named "Attack" in your Animator
            // Add any other attack logic here
        }
    }

    // Function to be called from the Animator when the attack animation is complete
    void FinishAttack()
    {
        isAttacking = false;
    }
}
