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
    public class DocumentsController : ControllerBase
    {
        private readonly DriveContext _driveContext;
        public DocumentsController(DriveContext Document)
        {
         
        _driveContext = Document;
        }
        // GET: api/Documents
        [HttpGet]
        public IActionResult Get()
        {
            var getDocument = _driveContext.Documents.ToList();
            return Ok(getDocument);
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _driveContext.Documents.First(obj => obj.DocumentId == id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        // GET: api/Documents/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Documents
        [HttpPost]
        public void Post([FromBody] DocumentRequest value)
        {
            Documents obj = new Documents();            
            obj.DocumentName = value.DocumentName;
            obj.DocumentType = value.DocumentType;
            obj.Size = value.Size;
            obj.CreatedAt = value.CreatedAt;
            obj.CreatedBy = value.CreatedBy;
            obj.FolderId = value.FolderId;
            obj.IsDeleted = value.IsDeleted;
            _driveContext.Documents.Add(obj);
            _driveContext.SaveChanges();

        }
        [HttpGet("{value}")]
        public IActionResult Get(string value)
        {

            var result = _driveContext.Documents.Where(obj => obj.DocumentName.Contains(value));
            return Ok(result);

        }




        // PUT: api/Documents/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}
