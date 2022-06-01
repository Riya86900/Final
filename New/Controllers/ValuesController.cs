using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using New.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using New.RequestModel;

namespace  New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        private readonly DriveContext _drivecontext;
        public ValuesController(DriveContext project)
        {
            _drivecontext = project;
        }

        // GET: api/PlayersInfo
        [HttpGet]
        public IActionResult Get()
        {
            var getInfo = _drivecontext.Folders.ToList();
            return Ok(getInfo);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _drivecontext.Folders.First(obj => obj.FolderId == id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        // POST: api/PlayersInfo
        [HttpPost]
        public void Post([FromBody] FoldersRequest value)
        {
            Folders obj = new Folders();
            obj.FolderName = value.FolderName;
            obj.CreatedAt = value.CreatedAt;
            obj.CreatedBy = value.CreatedBy;
            obj.IsDeleted = value.IsDeleted;
            _drivecontext.Folders.Add(obj);
            _drivecontext.SaveChanges();


        }
        [HttpGet("{value}")]
        public IActionResult Get(string value)
        {

            var result = _drivecontext.Folders.Where(obj => obj.FolderName.Contains(value));
            return Ok(result);



        }
    }
}
