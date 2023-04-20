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

        public static Dictionary<string,object> doQuery(string[] Fields, string Query)
        {
            Dictionary<string, object> dictReturn = new Dictionary<string, object>();
            conn.Open();
            SqlCommand cmd = new SqlCommand(Query, conn);

            SqlDataReader reader = cmd.ExecuteReader();
                
            for (int i = 0; i < Fields.Length; i++)
            {
                dictReturn.Add(Fields[i], reader.GetValue(i));
            }
            conn.Close();
            return dictReturn;
        }

        public static int executeQuery(string Query)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(Query, conn);
            int totalEffected = cmd.ExecuteNonQuery();
            conn.Close();
            return totalEffected;
        }
    }
}
