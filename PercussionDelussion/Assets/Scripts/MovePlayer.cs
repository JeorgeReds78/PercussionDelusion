using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    public float jump = 5;
    public float speed = 5f;
    public Rigidbody2D rb;
    public int life;
    public int damage;
    public Text TXTlife;
    public Text TXTscore;
    public int score;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        life = 100;
        damage = 20;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TXTscore.text = "Score: " + score;
        TXTlife.text = "LIFE: " + life;
        transform.Translate(Vector2.right * (Time.deltaTime * speed));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DAÑO")
        {
            life = life - damage;
        }
        if (collision.gameObject.tag == "EAGLE")
        {
            life = life - damage*2;
        }
        if (collision.gameObject.tag == "HEART")
        {
            life = life + damage;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "COIN")
        {
            score = score + 30;
            Destroy(collision.gameObject);
        }
    }

}
