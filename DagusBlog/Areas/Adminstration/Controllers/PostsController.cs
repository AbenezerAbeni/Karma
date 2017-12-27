using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DagusBlog.Data;
using DagusBlog.Models;
using DagusBlog.Controllers;
using DagusBlog.Areas.Adminstration.ViewModels;
using DagusBlog.Services.Contracts;
using DagusBlog.Services;

namespace DagusBlog.Areas.Adminstration.Controllers
{
    public class PostsController : BaseController
    {
        //public BlogSystemDbContext db = new BlogSystemDbContext();


        private IPostService postsService;
        private IUsersService usersService;

        public PostsController(IPostService postService, IUsersService usersService)
        {
            this.postsService = postService;
            this.usersService = usersService;
        }

        [Authorize(Roles = "Publisher")]
        // GET: Adminstration/Posts
        public ActionResult Index()
        {
            var posts = Mapper.Map<List<Post>,
                List<PostViewModel>>(postsService.GetAll().ToList());
            return View(posts);
        }

        [Authorize(Roles = "Publisher")]
        // GET: Adminstration/Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = postsService.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [Authorize(Roles = "Publisher")]
        // GET: Adminstration/Posts/Create
        public ActionResult Create()
        {
            PostViewModel postVM = new PostViewModel();
            postVM.Users = new SelectList(this.usersService.GetAll(), "Id", "UserName");
           // createVM.Users = new SelectList(Data.Users.All(), "Id", "UserName");
            // createVM.Users.Users
            return View(postVM);
        }

        // POST: Adminstration/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Publisher")]
        public ActionResult Create(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                var dbpost = Mapper.Map<Post>(post);
               // dbpost.CreatedOn = DateTime.Now;
                this.postsService.Add(dbpost);
               // this.postsService.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(this.postsService.GetAll(), "Id", "Email", post.AuthorId);
            return View(post);
        }

        [Authorize(Roles = "Publisher")]
        // GET: Adminstration/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = this.postsService.Find(id);

           // PostViewModel post = Mapper.Map<PostViewModel>
           //     (this.postsService.Find(id));

            if (post == null)
            {
                return HttpNotFound();
            }

            PostViewModel postVM = Mapper.Map < PostViewModel >
                (post);
            postVM.Users = new SelectList(this.usersService.GetAll(), "Id", "Email", post.AuthorId);
           // ViewBag.AuthorId = new SelectList(this.usersService.GetAll(), "Id", "Email", post.AuthorId);
            return View(postVM);
        }

        // POST: Adminstration/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Publisher")]
        public ActionResult Edit(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                var dbpost = Mapper.Map<Post>(post);
                this.postsService.Update(dbpost);
                return RedirectToAction("Index");
            }
            post.Users = new SelectList(this.usersService.GetAll(), "Id", "Email", post.AuthorId);
            return View(post);
        }

        [Authorize(Roles = "Publisher")]
        // GET: Adminstration/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = this.postsService.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Adminstration/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Publisher")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.postsService.Delete(id);
            this.postsService.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        Data.Posts.Delete();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
