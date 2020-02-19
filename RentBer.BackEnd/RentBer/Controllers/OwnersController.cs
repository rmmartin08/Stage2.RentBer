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
    public class OwnersController : ApiController
    {
        // GET: api/Owners
        public IHttpActionResult Get()
        {
            var ownerDao = new OwnerDao();
            return Ok(ownerDao.GetAllOwners());
        }

        // GET: api/Owners/5
        public IHttpActionResult Get(Guid id)
        {
            var ownerDao = new OwnerDao();
            var foundOwner = ownerDao.GetOwnerById(id);
            if (foundOwner == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundOwner);
            }
        }

        // POST: api/Owners
        public IHttpActionResult Post([FromBody] EditableOwner inputOwner)
        {
            var ownerDao = new OwnerDao();
            var newOwner = ownerDao.AddNewOwner(inputOwner);

            return Ok(newOwner);
        }

        // PUT: api/Ownerss/5
        public IHttpActionResult Put(Guid id, [FromBody] EditableOwner editableOwner)
        {
            var ownerDao = new OwnerDao();
            var foundOwner = ownerDao.UpdateUser(id, editableOwner);
            if (foundOwner == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundOwner);
            }
        }

        // DELETE: api/Owners/5
        public IHttpActionResult Delete(Guid id)
        {
            var ownerDao = new OwnerDao();
            var didDelete = ownerDao.DeleteOwner(id);
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