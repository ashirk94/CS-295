using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AlanShirkInformationalSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AlanShirkInformationalSite.Models
{
    public class QueryOptions<T>
    {
        public Expression<Func<T, Object>> OrderBy { get; set; }
        public Expression<Func<T, bool>> Where { get; set; }

        private string[] includes;
        public string Includes
        {
            set => includes = value.Replace(" ", "").Split(',');
        }
    }
    public interface IPostRepository : IDisposable
    {
        IEnumerable<ForumPostModel> GetPosts();
        IEnumerable<UserModel> GetUsers();
        ForumPostModel GetPostById(int id);
        void Insert(ForumPostModel post);
        void Update(ForumPostModel post);
        void Delete(int id);
        void Save();
    }
}
