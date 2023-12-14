using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Follow_Enemy : Enemy_Controller
{
    private PlayerMovement player;
    public float speedtowardsplayer;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the player's position
        Vector3 targetPosition = player.transform.position;

        // Set a fixed Y-coordinate for the enemy (adjust this value as needed)
        float fixedY = 0.0f;

        // Create a new position with the fixed Y-coordinate
        Vector3 newPosition = new Vector3(targetPosition.x, fixedY, targetPosition.z);

        // Move the enemy towards the new position
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedtowardsplayer * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<Player_Stats>().TakeDamage(damage);
        }

    }
}
