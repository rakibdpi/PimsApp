using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Pims.Service.Manager.OperationModules;
using Pims.Service.Manager;
using Pims.Core.ViewModel.OperationModules;


namespace PimsApp.Controllers.Api
{
    public class EmergencyContactController : ApiController
    {
        EmergencyContactManager _manager = new EmergencyContactManager();

        // GET: api/EmergencyContact
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

        // GET: api/EmergencyContact/5
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

        [Route("api/EmergencyContact/GetInfoById")]
        [HttpGet]
        public IHttpActionResult GetInfoById(int id)
        {
            try
            {
                var entities = _manager.GetAll().Where(c => c.GeneralInformationId == id).ToList();
                return Ok(entities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/EmergencyContact
        public IHttpActionResult Post([FromBody]EmergencyContactViewModel vm)
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

        // PUT: api/EmergencyContact/5
        public IHttpActionResult Put(int id, [FromBody]EmergencyContactViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(_manager.Update(id, vm));
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


        // DELETE: api/EmergencyContact/5
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
