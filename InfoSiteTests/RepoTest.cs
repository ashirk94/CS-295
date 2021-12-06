using System;
using System.Collections.Generic;
using System.Text;
using AlanShirkInformationalSite.Models;
using Xunit;
using AlanShirkInformationalSite.Controllers;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace InfoSiteTests
{
    public class FakeUserRepo : IPostRepository
    {
        public ForumPostModel GetPostById(int Id) => new ForumPostModel();
        private ForumPostContext context;

        public IEnumerable<UserModel> GetUsers()
        {
            return context.Users;
        }
        public IEnumerable<ForumPostModel> GetPosts()
        {
            return context.ForumPosts;
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
        //[Fact]
        //public void ReturnsView()
        //{
        //    var rep = new FakeUserRepo();
        //    var controller = new HomeController(rep);

        //    var result = controller.Index();

        //    Assert.IsType<ForumPostModel>(result);
        //}
    }


}
