using Pims.Service.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PimsApp.Controllers.Api
{
    public class UniversityController : ApiController
    {
        UniversityManager _manager = new UniversityManager();
        // GET: api/University

        public IHttpActionResult Get()
        {
            try
            {
                var entities = _manager.GetAll();
                return Ok(entities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/University/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/University
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/University/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/University/5
        public void Delete(int id)
        {
        }
    }
}
