using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class Login : MonoBehaviour
{
    public TextMeshProUGUI resultado;

    //Referencias a las entradas de texto
    public TMP_InputField textoNombre;
    public TMP_InputField textoPassword;

    string contrasena;
    // after the sql query is executed we will have a filled users array
    // Use this for initialization

    public void gametime()
    {
        Conectar();
        if (contrasena == textoPassword.text)
        {
            SceneManager.LoadScene("Demo");
        }
        else
        {
            resultado.text = "Incorrect password or username";
        }
    }

    public void registro()
    {
        SceneManager.LoadScene("Register");
    }

    public void Adios()
    {
        Application.Quit();
    }

    public void Conectar()
    {
        // initialize global users array
        ConnectToDB();
    }


    // function to connect to the db and the users list
    void ConnectToDB()
    {
        // Build connection string
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = "pasx.database.windows.net";
        builder.UserID = "pasx";
        builder.Password = "8918Part";
        builder.InitialCatalog = "PAS";
        try
        {
            // connect to the databases
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                // if open then the connection is established
                connection.Open();
                Debug.Log("connection established");
                // sql command
                string sql = "SELECT password FROM Usuarios WHERE gamerTag = '" + textoNombre.text + "'";
                // execute sql command
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // read
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // each line in the output
                        while (reader.Read())
                        {
                            // get output parameters
                            contrasena = reader["password"].ToString();
                        }
                    }
                }
            }
        }
        catch (SqlException e)
        {
            Debug.Log(e.ToString());
        }
    }

}

// init class for skill to create an array list of skills for a user


// init class for User (that is shown on the cube
