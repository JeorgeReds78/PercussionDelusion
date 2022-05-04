using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PreguntaMenu2 : MonoBehaviour
{
    public TMP_Text resultado;
    private void Start()
    {
        PlayerPrefs.SetString("P", "2");
    }
    // Se debería hacer un menú por nivel
    public void Respuesta1()
    {
        PlayerPrefs.SetString("R", "True");
        PlayerPrefs.SetString("RB", "true");
        StartCoroutine(verdadero());
        DBPreguntas.instance.Conectar();
    }

    public void Respuesta2()
    {
        PlayerPrefs.SetString("R", "False");
        PlayerPrefs.SetString("RB", "false");
        StartCoroutine(falso());
        DBPreguntas.instance.Conectar();
    }
    private IEnumerator falso()
    {
        resultado.text = "Incorrect, the answer is true, Good try";
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
