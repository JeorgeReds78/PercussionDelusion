using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuevePersonaje : MonoBehaviour
{
    // Variable de instancia
    private Rigidbody2D rb;


    //Velocidad
    public float velocidadX = 0;
    public float velocidadY = 0;

    public static MuevePersonaje instance;

    // Start is called before the first frame update
    void Start()
    {
        instance.rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float movVertical = Input.GetAxis("Jump");
        float movHorizontal = Input.GetAxis("Horizontal");
        instance.rb.velocity = new Vector2(movHorizontal * instance.velocidadX, instance.rb.velocity.y);
        if (movVertical > 0 & PruebaPiso.estaEnPiso == true)
        {
            instance.rb.velocity = new Vector2(instance.rb.velocity.x, movVertical * velocidadY * 6);

        }
       
    }

    private void Awake() => instance = this;

}