using DagusBlog.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DagusBlog.Models;
using DagusBlog.Data;


namespace DagusBlog.Services
{
    public class PostService : BaseService<Post>, IPostService
    {
        public PostService(IBlogSystemData data)
            : base(data)
        {
        }

        public override void Add(Post entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
            base.SaveChanges();
        }
    }
}
