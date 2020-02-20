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
    //[RoutePrefix("api/RentalAgreements")]
    public class RentalAgreementsController : ApiController
    {
        [HttpGet]
        // GET: api/RentalAgreements
        public IHttpActionResult Get(Guid? ownerId = null, Guid? renterId = null)
        {
            var rentalAgreementDao = new RentalAgreementDao();

            if (!ownerId.HasValue && !renterId.HasValue)
            {
                return Ok(rentalAgreementDao.GetAllRentalAgreements());
            }
            else
            {
                return Ok(rentalAgreementDao.GetRentalAgreementsByFilter(ownerId, renterId));
            }
        }

        // GET: api/RentalAgreements/5
        public IHttpActionResult Get(Guid id)
        {
            var rentalAgreementDao = new RentalAgreementDao();
            var foundRentalAgreement = rentalAgreementDao.GetRentalAgreementById(id);
            if (foundRentalAgreement == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundRentalAgreement);
            }
        }

        // POST: api/RentalAgreements
        public IHttpActionResult Post([FromBody] EditableRentalAgreement inputRentalAgreement)
        {
            var rentalAgreementDao = new RentalAgreementDao();
            return Ok(rentalAgreementDao.AddNewRentalAgreement(inputRentalAgreement));
        }

        // PUT: api/RentalAgreements/5
        public IHttpActionResult Put(Guid id, [FromBody] EditableRentalAgreement updatedRentalAgreement)
        {
            var rentalAgreementDao = new RentalAgreementDao();
            var foundRentalAgreement = rentalAgreementDao.UpdateRentalAgreement(id, updatedRentalAgreement);
            if (foundRentalAgreement == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundRentalAgreement);
            }
        }

        // DELETE: api/RentalAgreements/5
        public IHttpActionResult Delete(Guid id)
        {
            var rentalAgreementDao = new RentalAgreementDao();
            var didDelete = rentalAgreementDao.DeleteRentalAgreement(id);
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