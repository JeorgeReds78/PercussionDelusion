using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;   
using UnityEngine.UI;



public class Connectivity : MonoBehaviour
{
    public static Connectivity instance;

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
                string usuario = PlayerPrefs.GetString("usuario");
                string nombre = PlayerPrefs.GetString("nombre");
                string password = PlayerPrefs.GetString("password");
                string entrytime= PlayerPrefs.GetString("edad");
                string edad = PlayerPrefs.GetString("edad");
                string nacionalidad = PlayerPrefs.GetString("nacionalidad");
                string genero = PlayerPrefs.GetString("genero");
                string stage = PlayerPrefs.GetString("stage", "0");
                string sql = "insert into Usuarios (gamerTag, password, name, gender, age, nacionalidad, currentStage_id)" +
                    "values ('" + usuario + "', '" + password + "', '" + nombre + "', '" + genero + "', '" + edad + "', '" + nacionalidad + "','" + stage + "')";
                // execute sql command
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // read
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // each line in the output
                        while (reader.Read())
                        {
                            // to avoid SqlNullValueException
                            if (!reader.IsDBNull(0)
                                & !reader.IsDBNull(1)
                                & !reader.IsDBNull(3))
                            {
                                // Skills list to be attached to each user object

                                // get output parameters
                                string username = reader.GetString(0);
                                string aboutString = reader.GetString(1);

                                // initialize User object
                                User user = new User(username.Trim(), aboutString.Trim());
                            }
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


// init class for User (that is shown on the cube)
public class User
{
    public string Name { get; set; }
    public string About { get; set; }

    public User(string Name, string About)
    {
        this.Name = Name;
        this.About = About;
    }

    public override string ToString()
    {
        return "Person: " + this.Name + " About me: " + this.About;
    }

}

