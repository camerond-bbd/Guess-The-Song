using System.Data.SqlClient;

namespace GuessTheSong.Utils
{
    public static class DatabaseConnectionManager
    {

        static SqlConnection conn;
        static DatabaseConnectionManager()
        {
            //create connection
            string connetionString = "Data Source=PALESAM\\SQLEXPRESS;Initial Catalog = gameDB;Integrated Security = true";
            conn = new SqlConnection(connetionString);
        }

        public static string getResult()
        {
            conn.Open();
            string output = "";
            SqlCommand cmd = new SqlCommand("SELECT artist_id,name FROM artists", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                output = output + reader.GetValue(0) + reader.GetValue(0);
            }
            conn.Close();

            return output;
        }



    }
}
