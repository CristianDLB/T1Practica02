using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{

    private Rigidbody2D body;
    private Animator animar;
    private SpriteRenderer render;

    private const int correr = 0;
    private const int salto = 1;
    private const int deslizo = 2;
    private const int muero = 3;

    public float volocidad = 8;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animar = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(volocidad, body.velocity.y);
        Animaciones(correr);

        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, 14);
            Animaciones(salto);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            Animaciones(deslizo);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigos"))
        {
            Debug.Log("Coco");
            body.velocity = new Vector2(volocidad*0, body.velocity.y);
            Animaciones(muero);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Muere") && Input.GetKey(KeyCode.Z))
        {
            Debug.Log("Mas Velocidad");
            body.velocity = new Vector2(volocidad + 1, body.velocity.y);
        }
        if (collision.gameObject.CompareTag("NoMuere"))
        {
            Debug.Log("Mas Velocidad");
            body.velocity = new Vector2(volocidad + 1, body.velocity.y);
        }
        if (collision.gameObject.CompareTag("fin"))
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }
    }


    private void Animaciones(int animation)
    {
        animar.SetInteger("Estado", animation);
    }

}
