using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using UnityEngine.UI;



public class DBPreguntas : MonoBehaviour
{
    public static DBPreguntas instance;
    string id;

    // after the sql query is executed we will have a filled users array
    // Use this for initialization
    public void Conectar()
    {
        // initialize global users array
        ConnectToDB();
        ConnectToDB1();
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
                string sql = "SELECT resultadosId FROM Resultados WHERE resultadosId=(SELECT max(resultadosId) FROM Resultados)";
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
                            id = reader["resultadosId"].ToString();
                            
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

    void ConnectToDB1()
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
                string sql = "INSERT INTO Resultados (resultadosId, pregunta_id, user_id, respuesta, eval)"+
                    "values('" + id+1 + "','" + PlayerPrefs.GetString("P") + "', '" + PlayerPrefs.GetString("usuario") + "', '" + PlayerPrefs.GetString("R") + "', '" + PlayerPrefs.GetString("RB") + "')";
                // execute sql command
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // read
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // each line in the output
                       
                    }
                }
            }
        }
        catch (SqlException e)
        {
            Debug.Log(e.ToString());
        }
    }
    private void Awake() => instance = this;
}

// init class for skill to create an array list of skills for a user


// init class for User (that is shown on the cube
