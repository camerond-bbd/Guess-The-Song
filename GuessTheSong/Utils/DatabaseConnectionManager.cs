using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace GuessTheSong.Utils
{
    public static class DatabaseConnectionManager
    {

        static SqlConnection conn;
        static DatabaseConnectionManager()
        {
            //create connection
            string connetionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=gameDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadOnly;MultiSubnetFailover=True";
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
            reader.Close();
            conn.Close();

            return output;
        }

        public static Dictionary<string, object>? doQuery(string[] Fields, string Query)
        {
            Dictionary<string, object> dictReturn = new Dictionary<string, object>();
            conn.Open();
            SqlCommand cmd = new SqlCommand(Query, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
                return null;
            reader.Read();
            for (int i = 0; (i < Fields.Length); i++)
            {
                string key = Fields[i];
                object value = reader.GetValue(i);
                dictReturn.Add(key, value);
            }
            reader.Close();
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

        public static Dictionary<string, object>[] getMulti(string[] Fields, string Query)
        {
            List<Dictionary<string, object>> lstDicts = new List<Dictionary<string, object>>();
            conn.Open();
            SqlCommand cmd = new SqlCommand(Query, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Dictionary<string, object> record = new Dictionary<string, object>();
                for (int i = 0; i < Fields.Length; i++)
                {
                    record.Add(Fields[i], reader.GetValue(i));
                }
                lstDicts.Add(record);
            }
            reader.Close();
            conn.Close();
            return lstDicts.ToArray();
        }

        public static int rowCount(string Query)
        {
            conn.Open();
            int rowCount = 0;
            SqlCommand cmd = new SqlCommand(Query, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                conn.Close();
                return 0;
            }


            while (reader.Read())
            {
                rowCount++;
            }
            reader.Close();
            conn.Close();

            return rowCount;
        }

        public static int[] getIDList(string Query)
        {
            List<int> list = new List<int>();
            conn.Open();
            int rowCount = 0;
            SqlCommand cmd = new SqlCommand(Query, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                conn.Close();
                return new int[] {};
            }


            while (reader.Read())
            {
                list.Add((int)reader.GetValue(0));
            }
            reader.Close();
            conn.Close();

            return list.ToArray();
        }
    }
}
