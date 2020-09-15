using Pims.Core.ViewModel.OperationModules;
using Pims.Service.Manager.OperationModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PimsApp.Controllers.Api
{
    public class GeneralInformationsController : ApiController
    {
        GeneralInformationManager _manager = new GeneralInformationManager();

        [Route("api/GeneralInformations/GenerateEmployeId")]
        [HttpGet]
        public IHttpActionResult GenerateEmployeId()
        {
            try
            {
                var entities = _manager.GenerateEmployeId();
                return Ok(entities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // GET: api/GeneralInformations
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

        // GET: api/GeneralInformations/5
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

        // POST: api/GeneralInformations
        public IHttpActionResult Post([FromBody]GeneralInformationViewModel vm)
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

        // PUT: api/GeneralInformations/5
        public IHttpActionResult Put(int id, [FromBody]GeneralInformationViewModel vm)
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

        // DELETE: api/GeneralInformations/5
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
