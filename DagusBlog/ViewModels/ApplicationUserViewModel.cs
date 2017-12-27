using DagusBlog.Common.Mapping;
using DagusBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DagusBlog.ViewModels
{
    public class ApplicationUserViewModel : IMapFrom<ApplicationUser>
    {
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}