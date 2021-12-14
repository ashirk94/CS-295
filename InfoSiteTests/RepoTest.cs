using System;
using System.Collections.Generic;
using System.Text;
using AlanShirkInformationalSite.Models;
using System.Linq;
using AlanShirkInformationalSite.Controllers;
using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace InfoSiteTests
{
    public class RepoTests
    {
        private ForumPostContext context;

        private Mock<PostRepository> postRepo;
        private Mock<UserRepository> userRepo;
        private HomeController controller;

        [Fact]
        public void TestGetIndex()
        {
            context = new ForumPostContext();
            postRepo = new Mock<PostRepository>(context);
            userRepo = new Mock<UserRepository>(context);
            controller = new HomeController(postRepo.Object, userRepo.Object);
            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void TestPostForum()
        {
            context = new ForumPostContext();
            postRepo = new Mock<PostRepository>(context);
            userRepo = new Mock<UserRepository>(context);

            var post = new ForumPostModel
            {
                Id = 1,
                User = "Alan",
                PostDate = DateTime.Now,
                Page = "Forum",
                Rating = 5,
                Text = "Test"
            };

            controller = new HomeController(postRepo.Object, userRepo.Object);
            var result = controller.Forum(post);

            Assert.IsType<ViewResult>(result); 
        }
    }
}
