using Android.Content;
using Android.Widget;
using FluentNHibernate.Cfg.Db;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.Icu.Text.IDNA;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Conexion : ContentPage
    {
        public Conexion()
        {
            InitializeComponent();
        }
       

        public static MySqlConnection ObternerConexion()
        {
            MySqlConnection conexion = new MySqlConnection("server=atxsqldbserver.mysql.database.azure.com;database=wp_atxmx;Uid=atxmx@atxsqldbserver;pwd=Bzp9cTLyAH;");
            conexion.Open();
            return conexion;
        }
        public static void connect_mysql_tess()
         {
             // La siguiente linea es la que provee la conexión entre C# y MySQL.
             // Debes cambiar el nombre de usuario, contrasenia y nombre de base de datos
             // de acuerdo a tus datos
             // Puedes ignorar la opción de base de datos (database) si quieres acceder a todas
             // 127.0.0.1 es de localhost y el puerto predeterminado para conectar
             string connectionString = "datasource=atxsqldbserver.mysql.database.azure.com;port=3306;username=atxmx@atxsqldbserver;pwd=Bzp9cTLyAH;database=wp_atxmx;Convert Zero Datetime=True;";
             // Tu consulta en SQL
             string query = "SELECT * FROM wp_posts;";

             // Prepara la conexión
             MySqlConnection databaseConnection = new MySqlConnection(connectionString);
             MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
             commandDatabase.CommandTimeout = 60;
             MySqlDataReader reader;

             // A consultar !
             try
             {
                 // Abre la base de datos
                 databaseConnection.Open();

                 // Ejecuta la consultas
                 reader = commandDatabase.ExecuteReader();

                 // Hasta el momento todo bien, es decir datos obtenidos

                 // IMPORTANTE :#
                 // Si tu consulta retorna un resultado, usa el siguiente proceso para obtener datos

                 DataTable dt = new DataTable();
                 dt.Load(reader);
                 int numberOfResults = dt.Rows.Count;

                 foreach (DataRow dr in dt.Rows)
                 {
                     string value = dr["post_content"].ToString();

                     Console.WriteLine(value);
                 }
                 Console.WriteLine("Finaliza");
                 Console.ReadKey();

                 /* if (reader.HasRows)
                  {
                      while (reader.Read())
                      {
                          // En nuestra base de datos, el array contiene:  ID 0, FIRST_NAME 1,LAST_NAME 2, ADDRESS 3
                          // Hacer algo con cada fila obtenida
                          string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4) };
                          Console.WriteLine("OK");
                      }
                  }
                  else
                  {
                      Console.WriteLine("No se encontraron datos.");
                  }*/

                 // Cerrar la conexión
                 databaseConnection.Close();
             }
             catch (Exception ex)
             {
                 // Mostrar cualquier excepción
                 //MessageBox.Show(ex.Message);

             }

         }

       
            /// <summary>
            /// Prueba la conexión a la base de datos utilizando las credenciales correspondientes
            /// </summary>
            /// <param name="context"></param>
            /// <param name="Usuario"></param>
            /// <param name="Contrasenia"></param>
            /// <returns></returns>
            public bool TryConnec(Context context, string Usuario, string Contrasenia)
            {
            //datasource = ; port = 3306; username = ; password = Bzp9cTLyAH; database = ; Convert Zero Datetime = True;
            MySqlConnectionStringBuilder Builder = new MySqlConnectionStringBuilder();
                Builder.Port = 3306;
                //Al ser una BD Online debes usar la ip de tu servidor y no localhost
                Builder.Server = "atxsqldbserver.mysql.database.azure.com";
                Builder.Database = "wp_atxmx";
                Builder.UserID = Usuario; //Es el usuario de la base de datos
                Builder.Password = Contrasenia; //La contraseña del usuario
                try
                {
                    MySqlConnection ms = new MySqlConnection(Builder.ToString());
                    ms.Open(); //Debes agregar la referencia System.Data
                    return true;
                }
                catch (Exception ex)
                {
                    Toast.MakeText(context, ex.ToString(), ToastLength.Long).Show(); //Muestra un Toast con el error (Puede ser muy largo)
                    return false;
                }
            }
        }

    public static List<Post> mostrar()
    {
        List<Post> Lista = new List<Post>();
        MySqlCommand comando = new MySqlCommand(String.Format("SELECT post_title FROM wp_posts"), Conexion.ObternerConexion());
        MySqlDataReader reader = comando.ExecuteReader();
        Post p = new Post();
        while (reader.Read())
        {
            p.title = reader.GetString(0);
        }
        return Lista;
    }

}