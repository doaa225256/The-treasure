using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;
    public float jumpHeight;
    public bool isfacinright;
    public KeyCode spacebar;
    public KeyCode L;
    public KeyCode R;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private bool hit;
    private bool hit2;
    private Animator anim;
    public KeyCode uparrow;
    public Transform KnifePoint;
    public GameObject knife;
    public KeyCode downarrow;
    //public Transform KnifePoint;
    //public GameObject knife;
    public Transform attackPoint; // Set the attack point (usually an empty GameObject on the player representing attack position)
    public LayerMask enemyLayer; // Set the layer for enemies

    public float attackRange = 0.5f; // Define the attack range
    public int attackDamage = 10; // Define the attack d

    // Start is called before the first frame update
    void Start()
    {
        isfacinright = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(uparrow))
        {
            anim.SetBool("hit", true);
            shoot();
        }
        else
        {
            anim.SetBool("hit", false);
        }
        if (Input.GetKeyDown(downarrow))
        {
            anim.SetBool("slide", true);
         
        }
        else
        {
            anim.SetBool("slide", false);
        }
        if (Input.GetKeyDown(spacebar) && grounded)
        {
            Jump();
        }
        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-movespeed, GetComponent<Rigidbody2D>().velocity.y);
            if (isfacinright)
            {
                flip();
                isfacinright = false;
            }
        }
        else if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(movespeed, GetComponent<Rigidbody2D>().velocity.y);
            if (!isfacinright)
            {
                flip();
                isfacinright = true;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);

        }
        anim.SetFloat("speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("jump", grounded);
        //anim.SetBool("hit", hit);
    }

    void flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
    public void shoot()
    {
        Instantiate(knife, KnifePoint.position, KnifePoint.rotation);
    }
    void Attack()
    {


        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        // Damage all detected enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            // Deal damage to the enemy (consider having an Enemy script with a TakeDamage method)
            enemy.GetComponent<Enemies>().TakeDamage(attackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
