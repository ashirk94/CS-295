using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AlanShirkInformationalSite.Models
{
    public class UserRepository : IRepository<UserModel>
    {
        private ForumPostContext context;

        public UserRepository(ForumPostContext context)
        {
            this.context = context;
        }

        public IEnumerable<UserModel> GetAll()
        {
            return context.Users;
        }

        public UserModel GetById(int id)
        {
            return context.Users.Find(id);
        }

        public void Insert(UserModel user)
        {
            context.Users.Add(user);
        }

        public void Delete(int id)
        {
            UserModel user = context.Users.Find(id);
            context.Users.Remove(user);
        }

        public void Update(UserModel user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
