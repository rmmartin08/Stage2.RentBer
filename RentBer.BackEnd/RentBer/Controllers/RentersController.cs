using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using RentBer.Data_Access;
using RentBer.Models;

namespace RentBer.Controllers
{
    public class RentersController : ApiController
    {
        // GET: api/Renter
        public IHttpActionResult Get()
        {
            var renterDao = new RenterDao();
            return Ok(renterDao.GetAllRenters());
        }

        // GET: api/Renter/5
        public IHttpActionResult Get(Guid id)
        {
            var renterDao = new RenterDao();
            var renter = renterDao.GetRenterById(id);
            if (renter == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(renter);
            }
        }

        // POST: api/Renter
        public IHttpActionResult Post(EditableRenter newRenter)
        {
            var renterDao = new RenterDao();
            return Ok(renterDao.AddNewRenter(newRenter.FirstName, newRenter.LastName));
        }

        // PUT: api/Renter/asfdfdf
        public IHttpActionResult Put(Guid id, [FromBody]EditableRenter renter)
        {
            var renterDao = new RenterDao();

            var foundAndUpdatedRenter = renterDao.UpdateRenter(id, renter);
            if (foundAndUpdatedRenter == null)
            {
                return NotFound();
            }
            return Ok(foundAndUpdatedRenter);
        }

        // DELETE: api/Renter/5
        public IHttpActionResult Delete(Guid id)
        {
            var renterDao = new RenterDao();
            var didDelete = renterDao.DeleteRenter(id);

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
