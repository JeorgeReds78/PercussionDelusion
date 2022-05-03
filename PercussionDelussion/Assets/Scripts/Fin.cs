using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Fin : MonoBehaviour
{
    public TMP_Text resultado;

    private void Start()
    {
        resultado.text = "Puntos: " + PlayerPrefs.GetInt("score");
    }

    public void otravez()
    {
        PlayerPrefs.SetInt("score", 3000);
        SceneManager.LoadScene("Demo");
    }
    public void fin()
    {
        PlayerPrefs.SetInt("score", 3000);
        Application.Quit();
    }
}
