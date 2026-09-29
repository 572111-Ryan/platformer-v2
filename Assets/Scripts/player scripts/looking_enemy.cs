using JetBrains.Annotations;
using System;
using UnityEngine;

public class looking_enemy : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Flipsprite();



        Console.WriteLine("player x position it" + player.transform.position.x);

        

    }

    void Flipsprite()
    {
        if (player.transform.position.x > transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

}
