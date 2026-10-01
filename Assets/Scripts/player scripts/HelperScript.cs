using UnityEngine;

public class HelperScrpit : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    

    public void Flipsprites()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb.linearVelocityX < -0.1f)
        {
            sr.flipX = true;
        }
        if (rb.linearVelocityX > 0.1f)
        {
            sr.flipX = false;
        }

    }
    public void FlipSprite(bool flip)
    {
        // Get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
