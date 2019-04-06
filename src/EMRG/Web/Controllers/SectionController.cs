using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.Core;
using Domain;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public SectionController(IUnitOfWork db)
        {
            _db = db;
        }

        // GET: api/Section
        [HttpGet]
        public async Task<JsonResult> GetAsync()
        {
            IList<Section> secton = (await _db.Sections.GetAll())
                                    .ToList();

            return new JsonResult(secton);
        }

        // GET: api/Section/5
        [HttpGet("{id}", Name = "GetSection")]
        public async Task<JsonResult> GetAsync(int id)
        {
            Section secton = (await _db.Sections.GetById((int)id));

            return new JsonResult(secton);
        }

        // POST: api/Section
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Section/5
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
