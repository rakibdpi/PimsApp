using Pims.Core.ViewModel;
using Pims.Service.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PimsApp.Controllers.Api
{
    public class DepartmentsController : ApiController
    {
        //Manager's Object create from service One

        DepartmentManager _manager = new DepartmentManager();

        // GET: api/Departments
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

        // GET: api/Departments/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = _manager.Get(id);
                if (entity == null)
                    return NotFound();

                return Ok(entity);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Departments
        public IHttpActionResult Post([FromBody]DepartmentViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(_manager.Add(vm));
                }
                else
                {
                    return BadRequest("Input Value Not Valid");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Departments/5
        //[HttpPut]
        public IHttpActionResult Put(int id, [FromBody]DepartmentViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(_manager.Update(id,vm));
                }
                else
                {
                    return BadRequest("Input Value Not Valid");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Departments/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok(_manager.Remove(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
