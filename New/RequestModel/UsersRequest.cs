using New.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace New.RequestModel
{
    public class UsersRequest
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
