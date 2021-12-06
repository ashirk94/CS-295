using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AlanShirkInformationalSite.Models
{
    public class PostRepository : IPostRepository, IDisposable
    {
        private ForumPostContext context;

        public PostRepository(ForumPostContext context)
        {
            this.context = context;
        }

        public IEnumerable<ForumPostModel> GetPosts()
        {
            return context.ForumPosts;
        }
        public IEnumerable<UserModel> GetUsers()
        {
            return context.Users;
        }

        public ForumPostModel GetPostById(int id)
        {
            return context.ForumPosts.Find(id);
        }

        public void Insert(ForumPostModel post)
        {
            context.ForumPosts.Add(post);
        }

        public void Delete(int id)
        {
            ForumPostModel post = context.ForumPosts.Find(id);
            context.ForumPosts.Remove(post);
        }

        public void Update(ForumPostModel post)
        {
            context.Entry(post).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
