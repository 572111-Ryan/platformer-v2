using System;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    public LayerMask groundLayerMask;
    bool result;
    bool isGroundedleft;
    bool isGroundedright;
    float dir = 2;
    public GameObject Patrol_Enemy;
    bool dropleft = false;
    bool dropright = false;
    Animator anim;
    bool randJump = true;
    int number;
    float thrust = 1f;
    int jumpStart = 0;
    int jumpEnd = 0;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        isGroundedleft = RayCollisionCheck(-0.5f, -1);
        isGroundedright = RayCollisionCheck(0.5f, -1);


        if ( dir<0 && isGroundedleft == false)
        {
            dir = 2;
            dropleft = false;
        }
        if (dir > 0 && isGroundedright == false)
        {
            dir = -2;
            dropright = false;
        }

        


        if (dir != 0)
        {
            anim.SetBool("patrolling", true);
        }
        else
        {
            anim.SetBool("patrolling", false);
        }

        Flipsprite();

        rb.linearVelocityX = dir;
/*
        void ShowRandomNumber()
        {
            System.Random rnd = new System.Random();
            number = rnd.Next(0, 10);  // make a random number between 0 and 4
        }


        if (randJump == true)
        {
            Task.Delay(200);
            ShowRandomNumber();
            if (number > 7)
            {
                Jump();
            }
        }

    }
    void Jump()
    {
        if ( jumpStart == jumpEnd )
        {
            Task.Delay(900);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 5);
            Task.Delay(100);
            jumpEnd = jumpEnd + 1;
        }
        jumpEnd = jumpEnd - 1;
*/
    }
    void Flipsprite()
    {
        if (dir < -0.1f)
        {
            sr.flipX = false;
        }
        if (dir > 0.1f)
        {
            sr.flipX = true;
        }

    }



    public bool RayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.5f; // length of raycast
        bool hitSomething = false;


        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward starting at the sprite's position
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + offset, Vector2.down, rayLength, groundLayerMask);

        Color hitColor = Color.red;


        if (hit.collider != null)
        {
            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray's position
        // You need to enable gizmos in th e editor to see these
        Debug.DrawRay(transform.position + offset, Vector2.down * rayLength, hitColor);
        return hitSomething;
    }
}
