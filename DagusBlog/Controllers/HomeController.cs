using DagusBlog.Models;
using DagusBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using DagusBlog.Services.Contracts;

namespace DagusBlog.Controllers
{
    public class HomeController : BaseController
    {

        private IPostService postsService;
        // private ICacheService cache;
        //ICacheService cache
        public HomeController(IPostService service)
        {
           // this.cache = cache;
            this.postsService = service;
        }

        public ActionResult Index()
        {
            //// var dbPosts = this.cache.Get<ICollection<Post>>("allPosts", () =>
            //  {
            //      return postsService.GetAll().ToList();
            //  }, 60);

            //  var posts = Mapper.Map<ICollection<Post>,
            //      ICollection<PostViewModel>>(dbPosts);

            //  return View(posts);
            var posts = Mapper.Map<List<Post>, 
                List<PostViewModel>>(this.postsService.GetAll().ToList());

            return View(posts);
        }

        public ActionResult Info(int id)
        {
            // var post = Mapper.Map<PostViewModel>(this.postsService.Find(id));
            //if (post.Content.Length > 30)
            //{
            //    post.SubHeader = post.Content.Substring(0, 30);
            //}
            //else
            //{
            //    post.SubHeader = post.Content;
            //}
            ViewBag.Message = "Your application Description Page.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}