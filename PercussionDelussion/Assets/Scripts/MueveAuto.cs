using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MueveAuto : MonoBehaviour
{
    // Variable de instancia
    private Rigidbody2D rb;

    //Animator
    private Animator animator;

    //Velocidad
    public float velocidadX = 0;
    public float velocidadY = 0;

    //Box collider
    private BoxCollider2D BoxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float movVertical = Input.GetAxis("Jump");
        rb.velocity = new Vector2(velocidadX, rb.velocity.y);
        if (movVertical > 0 & PruebaPiso.estaEnPiso == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, movVertical * velocidadY * 6);

        }
        //Slide
        if (Input.GetButton("Fire1"))
        {
            animator.SetBool("slide", true);
            BoxCollider2D.size = new Vector3(1.5f, .5f, .5f);
            BoxCollider2D.offset = new Vector3(0, -.7f);
        }
        if (!Input.GetButton("Fire1"))
        {
            animator.SetBool("slide", false);
            BoxCollider2D.size = new Vector3(1f, 1.5f, .5f);
            BoxCollider2D.offset = new Vector3(0, -.3f);
        }
        // Animación
        float velocidad = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("velocidad", velocidad);

        //Animacion saltando
        animator.SetBool("saltando", !PruebaPiso.estaEnPiso);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("npc"))
        {
            velocidadX = 0;
            velocidadY = 0;
            StartCoroutine(MomDialogue.instance.momhit());
            velocidadX = 10;
            velocidadY = 1.1f;
        }
    }
}
