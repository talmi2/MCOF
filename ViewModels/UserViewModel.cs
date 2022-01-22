using System;
using System.Collections.Generic;
using MyCupOverflows.Models;
using MyCupOverflows.Dal;
using System.Linq;
using System.Web;

namespace MyCupOverflows.ViewModel
{
    public class UserViewModel
    {
        public User User { get; set; }
        public List<User> Users { get; set; }
    }
}