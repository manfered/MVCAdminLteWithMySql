using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAdminLteWithMySql.Models
{
    public class AdminHomeModel
    {
        public int UsersCount { get; set; }
        public int TopicsCount { get; set; }
        public int CommentsCount { get; set; }
    }
}