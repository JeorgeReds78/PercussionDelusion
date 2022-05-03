using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class PreguntaMenu : MonoBehaviour
{
    public TMP_Text resultado;

    // Se debería hacer un menú por nivel
    public void Respuesta1()
    {
        //Se tiene que guardar la respuesta 1 aquí:
        StartCoroutine(falso());
        
    }

    private IEnumerator falso()
    {
        resultado.text = "Incorrect, the answer is number 2, Good try";
        yield return new WaitForSeconds(5);
        //Cargar la siguiente escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator verdadero()
    {
        resultado.text = "Correct! Nice Job";
        yield return new WaitForSeconds(5);
        // Cargar la siguiente escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Respuesta2()
    {
        StartCoroutine(verdadero());
    }

    public void Respuesta3()
    {
        StartCoroutine(falso());
    }

    

}
