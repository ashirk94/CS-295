using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AlanShirkInformationalSite.Models
{
    public class ForumPostContext : DbContext
    {
        public ForumPostContext()
        { }
        public ForumPostContext(DbContextOptions<ForumPostContext> options) : base(options)
        { }
        public DbSet<ForumPostModel> ForumPosts { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
