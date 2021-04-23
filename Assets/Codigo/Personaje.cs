using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personaje : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    public Puntaje puntaje;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        animator.SetInteger("Estado", 0);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(10, rb.velocity.y);
            animator.SetInteger("Estado", 1);
            sr.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-10, rb.velocity.y);
            animator.SetInteger("Estado", 1);
            sr.flipX = true;

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector2(rb.velocity.x, 0.08f), ForceMode2D.Impulse);
            animator.SetInteger("Estado", 2);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(new Vector2(rb.velocity.x, rb.velocity.y), ForceMode2D.Impulse);
            animator.SetInteger("Estado", 3);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 3) // bronce
        {
            Destroy(collision.gameObject);
            puntaje.AddPoints(10);
        }
        if (collision.gameObject.layer == 6) // plata
        {
            Destroy(collision.gameObject);
            puntaje.AddPoints(20);
        }
    }
}
