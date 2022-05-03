using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform Jugador;
    void Update()
    {
        //Para que la cámara se mueva con el jugador
        transform.position = new Vector3(Jugador.position.x + 6, transform.position.y, transform.position.z);
    }
}
