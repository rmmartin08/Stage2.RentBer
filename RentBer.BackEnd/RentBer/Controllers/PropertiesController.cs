using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RentBer.Data_Access;
using RentBer.Models;

namespace RentBer.Controllers
{
    public class PropertiesController : ApiController
    {
        // GET: api/Owners
        public IHttpActionResult Get()
        {
            var propertyDao = new PropertyDao();
            return Ok(propertyDao.GetAllProperties());
        }

        // GET: api/Owners/5
        public IHttpActionResult Get(Guid id)
        {
            var propertyDao = new PropertyDao();
            var foundProperty = propertyDao.GetPropertyById(id);
            if (foundProperty == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundProperty);
            }
        }

        // POST: api/Owners
        public IHttpActionResult Post([FromBody] EditableProperty inputProperty)
        {
            var propertyDao = new PropertyDao();
            var newProperty = propertyDao.AddNewProperty(inputProperty);

            return Ok(newProperty);
        }

        // PUT: api/Ownerss/5
        public IHttpActionResult Put(Guid id, [FromBody] EditableProperty editableProperty)
        {
            var propertyDao = new PropertyDao();
            var foundProperty = propertyDao.UpdateProperty(id, editableProperty);
            if (foundProperty == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundProperty);
            }
        }

        // DELETE: api/Owners/5
        public IHttpActionResult Delete(Guid id)
        {
            var propertyDao = new PropertyDao();
            var didDelete = propertyDao.DeleteProperty(id);
            if (didDelete)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return NotFound();
            }
        }
    }
}