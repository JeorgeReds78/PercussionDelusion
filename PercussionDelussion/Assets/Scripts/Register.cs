using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Register : MonoBehaviour
{

    //Referencias a las entradas de texto
    public TMP_InputField textoNombre;
    public TMP_InputField textoPassword;
    public TMP_InputField textoUsuario;
    public TMP_InputField textoEdad;
    public TMP_InputField textoNacionalidad;
    public TMP_InputField textoGenero;

    //Estructura para convertir a JSON
    public struct DatosUsuario
    {
        public string usuario;
        public string nombre;
        public string password;
        public string entrytime;
        public string edad;
        public string nacionalidad;
        public string genero;
        public string exittime;
    }

    public DatosUsuario datos;
    
    public void registrar()
    {
        string entrytime = System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString();
    
        PlayerPrefs.SetString("nombre", textoNombre.text);
        PlayerPrefs.SetString("password", textoPassword.text);
        PlayerPrefs.SetString("usuario", textoUsuario.text);
        PlayerPrefs.SetString("entrytime", entrytime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void regresar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
