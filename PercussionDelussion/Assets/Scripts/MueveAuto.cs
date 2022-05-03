using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MueveAuto : MonoBehaviour
{
    //public Text TXTscore;
    private int score;
    public int damage = 50;
    // Variable de instancia
    private Rigidbody2D rb;

    //Animator
    private Animator animator;

    //Velocidad
    public float velocidadX = 0;
    public float velocidadY = 0;

    //Box collider
    private BoxCollider2D BoxCollider2D;
    private void Update()
    {
        //TXTscore.text = "Score: " + score;
     
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
        score = PlayerPrefs.GetInt("score", 3000);
        StartCoroutine(waitstart());
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
        if (collision.gameObject.tag == "HEART")
        {
            score = score + 30;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "COIN")
        {
            score = score + 15;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "DAÑO")
        {
            score = score - damage;
            animator.SetBool("hurt", true);
        }
        if(collision.gameObject.tag == "Finish")
        {
            Points.instance.actualizar(score);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DAÑO")
        {
            animator.SetBool("hurt", false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private IEnumerator waitstart()
    {
        velocidadX = 0;
        yield return new WaitForSeconds(3);
        velocidadX = 7;
    }
}

