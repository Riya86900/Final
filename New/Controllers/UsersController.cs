using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using New.Models;
using New.RequestModel;

namespace New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DriveContext _driveContext;
        public UsersController(DriveContext User)
        {
            _driveContext = User;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            var getUser = _driveContext.Users.ToList();
            return getUser;
        }

        // GET: api/Users/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Users
        [HttpPost]
        public void Post([FromBody] UsersRequest value)
        {
            Users obj = new Users();
            obj.Username = value.Username;
            obj.UserPassword = value.UserPassword;
            obj.CreatedAt = value.CreatedAt;
            _driveContext.Users.Add(obj);
            _driveContext.SaveChanges();

        }

        // PUT: api/Users/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
