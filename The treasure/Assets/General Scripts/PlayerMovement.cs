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
    private Animator anim;
    public KeyCode X;
    public Transform KnifePoint;
    public GameObject knife;


    // Start is called before the first frame update
    void Start()
    {
        isfacinright = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(X)/*&&hit*/)
        {
            anim.SetBool("hit", true);
            shoot();
        }
        else
        {
            anim.SetBool("hit", false);
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

}
