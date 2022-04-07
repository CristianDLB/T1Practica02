using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animar;
    private SpriteRenderer render;

    private const int correr = 0;

    public float volocidad = -4;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animar = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        body.velocity = new Vector2(volocidad, body.velocity.y);
        Animaciones(correr);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mato"))
        {
            Debug.Log("Muere Dino");
            Destroy(this.gameObject);
        }
    }

    private void Animaciones(int animation)
    {
        animar.SetInteger("EstEne", animation);
    }



}
