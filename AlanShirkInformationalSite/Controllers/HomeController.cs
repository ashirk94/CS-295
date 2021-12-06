using AlanShirkInformationalSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace AlanShirkInformationalSite.Controllers
{
    public class HomeController : Controller
    {

        private ForumPostContext postContext { get; set; }
        private PostRepository data { get; set; }
        public HomeController(PostRepository rep) => data = rep;
        //using repo
        public ActionResult Index()
        {
            var users = from user in data.GetUsers()select user;
            ViewBag.Users = users;
            return View();
        }
        //public HomeController(ForumPostContext ctx)
        //{
        //    postContext = ctx;
        //}
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    var users = postContext.Users.OrderBy(p => p.Id);
        //    return View();
        //}

        public IActionResult Overview()
        {
            return View();
        }
        //using repo
        [HttpGet]
        public IActionResult Forum()
        {
            //adding models for users and forum posts
            var users = from user in data.GetUsers() select user;
            var posts = from post in data.GetPosts() select post;

            ViewBag.users = users;
            ViewBag.posts = posts;
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserModel user)
        {
            try
            {
                if (user.Id == 0)
                    postContext.Users.Add(user);
                else
                    postContext.Users.Update(user);
                postContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Forum(ForumPostModel post)
        {
            try
            {
                if (post.Id == 0)
                    postContext.ForumPosts.Add(post);
                else
                    postContext.ForumPosts.Update(post);
                postContext.SaveChanges();
                return RedirectToAction("Forum", "Home");
            }
            catch
            {
                return View();
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Quiz()
        {
            ViewBag.Score = 0;
            return View();
        }
        [HttpPost]
        public IActionResult Quiz(QuizState state)
        {
            //get score from function in model
            ViewBag.Score = state.NumCorrect();

            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
