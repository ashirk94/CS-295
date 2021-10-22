using AlanShirkInformationalSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AlanShirkInformationalSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<UserModel> users = new List<UserModel>();
            ViewBag.users = users;
            return View();
        }

        public IActionResult Overview()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Forum()
        {
            //adding models for users and forum posts
            List<UserModel> users = new List<UserModel>();
            List<ForumPostModel> posts = new List<ForumPostModel>();

            ViewBag.users = users;
            ViewBag.posts = posts;
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserModel user)
        {
            if(ModelState.IsValid)
            {
                UserDB.AddUser(user);
                UserDB.SaveUsers();
            }

            List<UserModel> users = UserDB.GetUsers();
            ViewBag.users = users;
            return View(user);
        }
        [HttpPost]
        public IActionResult Forum(ForumPostModel post)
        {
            if (ModelState.IsValid)
            {
                ForumPostDB.AddPost(post);
                ForumPostDB.SavePosts();
            }

            List<ForumPostModel> posts = ForumPostDB.GetPosts();
            ViewBag.posts = posts;
            return View(post);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
