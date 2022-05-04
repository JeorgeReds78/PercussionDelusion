using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class PreguntaMenu : MonoBehaviour
{
    public TMP_Text resultado;

    private void Start()
    {
        PlayerPrefs.SetString("P", "1");
    }
    // Se debería hacer un menú por nivel
    public void Respuesta1()
    {
        //Se tiene que guardar la respuesta 1 aquí:
        PlayerPrefs.SetString("R", "To look cool");
        PlayerPrefs.SetString("RB", "false");
        StartCoroutine(falso());
        DBPreguntas.instance.Conectar();
        
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
        PlayerPrefs.SetString("R", "To protect your ears from high freqencies");
        PlayerPrefs.SetString("RB", "true");
        StartCoroutine(verdadero());
        DBPreguntas.instance.Conectar();
    }

    public void Respuesta3()
    {
        PlayerPrefs.SetString("R", "To pretend having yellow airpods");
        PlayerPrefs.SetString("RB", "false");
        StartCoroutine(falso());
        DBPreguntas.instance.Conectar();
    }

    

}
