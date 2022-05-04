using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using UnityEngine.UI;



public class DBPuntos : MonoBehaviour
{
    public static DBPuntos instance;

    // after the sql query is executed we will have a filled users array
    // Use this for initialization
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
                string sql = "execute actualizaP " + PlayerPrefs.GetString("usuario") + ", " + PlayerPrefs.GetInt("score");
                // execute sql command
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // read
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // each line in the output
                        while (reader.Read())
                        {
                        
                            
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
    private void Awake() => instance = this;
}

// init class for skill to create an array list of skills for a user


// init class for User (that is shown on the cube

