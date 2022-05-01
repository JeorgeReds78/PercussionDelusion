using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaPiso : MonoBehaviour
{
    public static bool estaEnPiso = false;

    [SerializeField]
    private AudioSource music;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        estaEnPiso = true;
        print(estaEnPiso);
        music.Play();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        estaEnPiso = false;
        print(estaEnPiso);
    }
    
}
