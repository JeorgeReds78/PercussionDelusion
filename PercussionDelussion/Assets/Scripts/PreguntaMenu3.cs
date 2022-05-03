using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PreguntaMenu3 : MonoBehaviour
{
    public TMP_Text resultado;
    // Se debería hacer un menú por nivel
    public void Respuesta1()
    {
        StartCoroutine(falso());
    }

    public void Respuesta2()
    {
        StartCoroutine(verdadero());
    }
    private IEnumerator falso()
    {
        resultado.text = "Incorrect, the answer is , Good try";
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
}
