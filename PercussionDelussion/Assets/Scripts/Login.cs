using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;

public class Login : MonoBehaviour
{

    public void menutime()
    {
        SceneManager.LoadScene("Demo");
    }


    //mandar JSON
    /*public void EnviarJson()
    {
        StartCoroutine(SubirJson());
    }

    private IEnumerator SubirJson()
    {

        datos.exittime = System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString();
        print(JsonUtility.ToJson(datos));

        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datos));
        UnityWebRequest request = UnityWebRequest.Post("http://localhost/unity/recibeJSON.php", forma);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            string texto = request.downloadHandler.text;
            resultado.text = texto;
        }
        else
        {
            resultado.text = "Error";
        }
    }

    public void LeerJSON()
    {
        StartCoroutine(DescargarJSON());
        Application.Quit();
    }

    private IEnumerator DescargarJSON()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://localhost/unity/enviaJSON.php");
        yield return request.SendWebRequest(); //Ejecuta en segundo plano
        //...despues de cierto tiempo continua
        if (request.result == UnityWebRequest.Result.Success)
        {
            string texto = request.downloadHandler.text;
            resultado.text = texto;
            //Deserializar
            datos = JsonUtility.FromJson<DatosUsuario>(texto);
            resultado.text = resultado.text + "\nNombre: " + datos.nombre;
            resultado.text = resultado.text + "\nPassword: " + datos.password;
        }
        else
        {
            resultado.text = "Error";
        }
    }*/

    public void register()
    {
        SceneManager.LoadScene("Register");
    }

}
