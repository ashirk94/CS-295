using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using AlanShirkInformationalSite.Models;

namespace AlanShirkInformationalSite
{
    public static class UserDB
    {
        //loading users from file
        public static string filename = "users.txt";
        private static bool loaded = false;
        private static List<UserModel> users = new List<UserModel>();

        public static List<UserModel> GetUsers()
        {
            if (loaded == false)
            {
                LoadUsers();
            }
            return users;
        }
        public static void LoadUsers()
        {
            try
            {
                StreamReader reader = new StreamReader(filename);
                string line = reader.ReadLine();
                while (line != null)
                {
                    string name = line;
                    users.Add(new UserModel { Name = name });
                    line = reader.ReadLine();
                }

                loaded = true;
                reader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        //saving to the file
        public static void SaveUsers()
        {
            if (loaded == false)
            {
                LoadUsers();
            }
            try
            {
                StreamWriter writer = new StreamWriter(filename);
                foreach(UserModel user in users)
                {
                    string line = user.Name;
                    writer.WriteLine(line);
                }
                writer.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void AddUser(UserModel user)
        {
            if (loaded == false)
            {
                LoadUsers();
            }
            users.Add(user);
        }
    }
}
