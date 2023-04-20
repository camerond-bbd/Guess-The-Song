using Microsoft.Data.SqlClient;

namespace BlazorToDB.Pages
{
    public partial class Index
    {
        public Index()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";



                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();

                    String sql = "SELECT * FROM [dbo].[User]";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetInt32(0), reader.GetString(1));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
