using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PreguntaMenu3 : MonoBehaviour
{
    public TMP_Text resultado;
    // Se debería hacer un menú por nivel
    private void Start()
    {
        PlayerPrefs.SetString("P", "3");
    }
    public void Respuesta1()
    {
        PlayerPrefs.SetString("R", "1 to 2 hours");
        PlayerPrefs.SetString("RB", "false");
        StartCoroutine(falso());
        DBPreguntas.instance.Conectar();
    }

    public void Respuesta2()
    {
        PlayerPrefs.SetString("R", "Between 0 and 30 seconds");
        PlayerPrefs.SetString("RB", "false");
        StartCoroutine(verdadero());
        DBPreguntas.instance.Conectar();
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
