using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player1 : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    InputAction moveAction;
    Rigidbody2D rb;
    InputAction lookAction;
    InputAction jumpAction;
    Animator anim;
    SpriteRenderer sr;
    LayerMask groundLayerMask;
    bool result;
    bool isGrounded;


    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
        jumpAction = InputSystem.actions.FindAction("Jump");

        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        bool isGrounded = true;
        groundLayerMask = LayerMask.GetMask("Ground");

    }

   
    void Update()
    {

        isGrounded = RayCollisionCheck(0, (float)-0.5);

        print("move=" + moveAction.ReadValue<Vector2>());

       
        print("look=" + lookAction.ReadValue<Vector2>());

       
        print("look x=" + lookAction.ReadValue<Vector2>().x);
 

        if (jumpAction.triggered)
        {
            
        }

        if (jumpAction.IsPressed())
        {
            
        }

        Vector2 moveVel = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(moveVel.x * 5, rb.linearVelocity.y);

        if ( isGrounded == true )
        {
            Jump();
        }

        if (rb.linearVelocityX != 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }

        Flipsprite();

        void Flipsprite()
        {
            if ( rb.linearVelocityX < -0.1f )
            {
                sr.flipX = true;
            }
            if (rb.linearVelocityX > 0.1f)
            {
                sr.flipX = false;
            }
            
        }

    }


    void Jump()
    {
        if (jumpAction.WasPressedThisFrame())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 5);
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
            print("Player has collided with Ground layer");
            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray's position
        // You need to enable gizmos in th e editor to see these
        Debug.DrawRay(transform.position + offset, Vector2.down * rayLength, hitColor);
        return hitSomething;
    }
}
