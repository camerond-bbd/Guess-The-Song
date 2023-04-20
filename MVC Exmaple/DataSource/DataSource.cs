using MVC_Exmaple.Models;
using System.Text.Json;

namespace MVC_Exmaple.DataSource
{
    public class DataSource
    {

        private static DataSourceCore mainDataSource;

        private class DataSourceCore
        {
            public bool PopulateUserModel(out UserModel? User, int ID)
            {
                string text = File.ReadAllText(@"./UserInfo.json");
                var Users = JsonSerializer.Deserialize<UserModel[]>(text);
                if (Users == null)
                {
                    User = null;
                    return false;
                }
                for (int i = 0; i < Users.Length; i++)
                {
                    if (Users[i].ID == ID)
                    {
                        User = Users[i];
                        return true;
                    }
                }
                User = null;
                return false;
            }
        }

        static DataSource()
        {
            mainDataSource = new DataSourceCore();
        }

        public static void HydrateUserModel(out UserModel? user, int id)
        {
            DataSource.mainDataSource.PopulateUserModel(out user, id);
        }
    }
}
