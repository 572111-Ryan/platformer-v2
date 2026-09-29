using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy1 : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject Player;
    public GameObject Enemy;
    LayerMask groundLayerMask;
    bool result;
    bool isGrounded;
    bool isNearedgeRight;
    bool isNearedgeLeft;
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = RayCollisionCheck(0, -0.5f);
        Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, Player.transform.position, speed);
        Flipsprite();

        void Flipsprite()
        {
            if (rb.linearVelocityX < -0.1f)
            {
                sr.flipX = true;
            }
            if (rb.linearVelocityX > 0.1f)
            {
                sr.flipX = false;
            }

        }
        if (rb.linearVelocityX != 0)
        {
            anim.SetBool("enemy walk", true);
        }
        else
        {
            anim.SetBool("enemy walk", false);
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
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, Vector2.down * rayLength, hitColor);
        return hitSomething;
    }
}
