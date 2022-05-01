using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody Jugador;
    [SerializeField]
    float Gravedad, Velocidad, Salto;
    bool Ganaste;

    // Movimiento del jugador
    void Start()
    {
        Ganaste = false;
        Jugador = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!Ganaste)
        {
            if (!Input.GetKey(KeyCode.Escape))
            {
                Physics.gravity = new Vector3(0, -Gravedad, 0);
                if (IsGrounded())
                { 
                    if (Input.GetButton("Fire1"))
                    {
                        Jugador.velocity = new Vector3(0, Salto, 0);
                    }
                }
                transform.position = new Vector3(transform.position.x * Velocidad, transform.position.y, transform.position.z);
                transform.rotation = new Quaternion();
            }
        }
        
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.51f);
    }
    //cuando llegue a la meta se pare
    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Meta")
        {
            Ganaste = true;
        }
        if (obj.tag == "Trampa")
        {
            Application.LoadLevel("SEBAS");
        }
    }
}
