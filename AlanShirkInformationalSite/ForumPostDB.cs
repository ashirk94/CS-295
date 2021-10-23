using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using AlanShirkInformationalSite.Models;


namespace AlanShirkInformationalSite
{
    public static class ForumPostDB
    {
        //loading users from file
        public static string filename = "posts.txt";
        private static bool loaded = false;
        private static List<ForumPostModel> posts = new List<ForumPostModel>();

        public static List<ForumPostModel> GetPosts()
        {
            if (loaded == false)
            {
                LoadPosts();
            }
            return posts;
        }
        public static void LoadPosts()
        {
            try
            {
                StreamReader reader = new StreamReader(filename);
                string line = reader.ReadLine();
                while (line != null)
                {
                    List<string> parts = line.Split(',').ToList();
                    string post = parts[0];
                    string user = parts[1];
                    DateTime date = DateTime.Parse(parts[2]);
                    string page = parts[3];
                    int rating = Int32.Parse(parts[4]);
                    posts.Add(new ForumPostModel
                    {
                        Text = post,
                        User = user,
                        PostDate = date,
                        Page = page,
                        Rating = rating
                    });
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
        public static void SavePosts()
        {
            if (loaded == false)
            {
                LoadPosts();
            }
            try
            {
                StreamWriter writer = new StreamWriter(filename);
                foreach (ForumPostModel post in posts)
                {
                    string line = post.Text + ',' + post.User + ','
                        + post.PostDate + ',' + post.Page + ',' + post.Rating;
                    writer.WriteLine(line);
                }
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void AddPost(ForumPostModel post)
        {
            if (loaded == false)
            {
                LoadPosts();
            }
            posts.Add(post);
        }
    }
}

