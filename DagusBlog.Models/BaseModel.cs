using System;

namespace DagusBlog.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}