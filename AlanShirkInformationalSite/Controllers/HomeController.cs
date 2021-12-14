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
        private PostRepository postData { get; set; }
        private UserRepository userData { get; set; }
        public HomeController(PostRepository postRep, UserRepository userRep)
        {
            postData = postRep;
            userData = userRep;
        }
        //using repos
        public IActionResult Index()
        {
            var users = from user in userData.GetAll()select user;
            ViewBag.Users = users;
            return View();
        }

        public IActionResult Overview()
        {
            return View();
        }
        //using repo
        [HttpGet]
        public IActionResult Forum()
        {
            //adding models for users and forum posts
            var users = from user in userData.GetAll() select user;
            var posts = from post in postData.GetAll() select post;

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
                    userData.Insert(user);
                else
                    userData.Update(user);
                userData.Save();
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
                    postData.Insert(post);
                else
                    postData.Update(post);
                postData.Save();
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
    }
}
