    namespace DagusBlog.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    //using BlogSystem.Data.Migrations;
    using DagusBlog.Models;

    public class BlogSystemDbContext : IdentityDbContext
    {
        public BlogSystemDbContext()
            : base("BlogSystemConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<TrackingSystemDbContext, Configuration>());
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<ApplicationUser> Users
        {
            get;
            set;
        }

        public IDbSet<Post> Posts
        {
            get;
            set;
        }

        public static BlogSystemDbContext Create()
        {
            return new BlogSystemDbContext();
        }

    }
}
