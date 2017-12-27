namespace DagusBlog.Data
{
    using DagusBlog.Data.Repositories;
    using DagusBlog.Models;

    public interface IBlogSystemData
    {
        IRepository<ApplicationUser> Users
        {
            get;
        }

        IRepository<Post> Posts
        {
            get;
        }

        IRepository<T> GetRepository<T>() where T:class;
    }
}
