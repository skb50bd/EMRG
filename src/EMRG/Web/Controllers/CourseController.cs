using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Data.Core;

namespace Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public CourseController(IUnitOfWork db)
        {
            _db = db;
        }

        // GET: api/Course
        [HttpGet]
        public async Task<JsonResult> GetAsync()
        {
            IList<Course> course = (await _db.Courses.GetAll())
                                    .ToList();

            return new JsonResult(course);
        }

        // GET: api/Course/5
        [HttpGet("{id}", Name = "GetCourse")]
        public async Task<JsonResult> GetAsync(int id)
        {
            Course course = (await _db.Courses.GetById((int)id));

            return new JsonResult(course);
        }

        // POST: api/Course
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Course/5
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
