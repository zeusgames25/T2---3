using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaControlador : MonoBehaviour
{
    public float velocidadX = 5;
    public float jumpForce = 50;
    public int Limite = 0;
    public float velocidadY = 5;
 

    public GameObject bala;
    public GameObject balaIzq;

    public GameControl game;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource au;

    private const string Choque_Enemigo = "Enemigo";


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        au = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        animator.SetInteger("Estado", 0);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            rb.velocity = new Vector2(-velocidadX, rb.velocity.y);
            animator.SetInteger("Estado", 1);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            rb.velocity = new Vector2(velocidadX, rb.velocity.y);
            animator.SetInteger("Estado", 1);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 30, ForceMode2D.Impulse);
            animator.SetInteger("Estado", 2);


        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            sr.flipX = false;
            rb.velocity = new Vector2(velocidadX, rb.velocity.y);
            animator.SetInteger("Estado", 3);


        }
        if (Input.GetKeyUp(KeyCode.X))
        {

            animator.SetInteger("Estado", 4);
            var balas = sr.flipX ? balaIzq : bala;
            var position = new Vector2(transform.position.x, transform.position.y);
            var rotation = bala.transform.rotation;
            Instantiate(balas, position, rotation);

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {

            animator.SetInteger("Estado", 5);
            rb.velocity = new Vector2(rb.velocity.x,velocidadY);
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            sr.flipX = false;
            animator.SetInteger("Estado", 6);
        }
        if (Limite == 3)
        {
            animator.SetInteger("Estado", 7);
           
        }





    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Choque_Enemigo))
        {
            game.PierdeVida();
            Limite += 1;
        }

    }

}
