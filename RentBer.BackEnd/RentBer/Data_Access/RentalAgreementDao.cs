using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RentBer.Models;

namespace RentBer.Data_Access
{
    public class RentalAgreementDao : DaoBase
    {
        public RentalAgreement[] GetAllRentalAgreements()
        {
            var rentalAgreementCol = db.GetCollection<RentalAgreement>("RentalAgreements");
            return rentalAgreementCol.FindAll().ToArray();
        }

        public RentalAgreement GetRentalAgreementById(Guid rentalAgreementId)
        {
            var rentalAgreementCol = db.GetCollection<RentalAgreement>("RentalAgreements");
            var foundRentalAgreement = rentalAgreementCol.FindById(rentalAgreementId);
            return foundRentalAgreement;
        }

        public RentalAgreement[] GetRentalAgreementsByOwner(Guid ownerId)
        {
            var rentalAgreementCol = db.GetCollection<RentalAgreement>("RentalAgreements");
            return rentalAgreementCol.Find(ra => ra.OwnerId == ownerId).ToArray();
        }

        public RentalAgreement[] GetRentalAgreementsByRenter(Guid renterId)
        {
            var rentalAgreementCol = db.GetCollection<RentalAgreement>("RentalAgreements");
            return rentalAgreementCol.Find(ra => ra.RenterId == renterId).ToArray();
        }

        public RentalAgreement AddNewRentalAgreement(EditableRentalAgreement editableRentalAgreement)
        {
            if (!editableRentalAgreement.OwnerId.HasValue || !editableRentalAgreement.RenterId.HasValue ||
                !editableRentalAgreement.MonthlyRate.HasValue || !editableRentalAgreement.PropertyId.HasValue)
            {
                throw new ValidationException("Rental Agreement requires a Renter Id, Owner Id, and a Monthly Rate");
            }

            var rentalAgreementCol = db.GetCollection<RentalAgreement>("RentalAgreements");
            var newRentalAgreement = new RentalAgreement()
            {
                Id = Guid.NewGuid(),
                OwnerId = editableRentalAgreement.OwnerId.Value,
                RenterId = editableRentalAgreement.RenterId.Value,
                PropertyId = editableRentalAgreement.PropertyId.Value,
                MonthlyRate = editableRentalAgreement.MonthlyRate.Value
            };

            rentalAgreementCol.Insert(newRentalAgreement);

            return newRentalAgreement;
        }

        public RentalAgreement UpdateRentalAgreement(Guid rentalAgreementId,
            EditableRentalAgreement editableRentalAgreement)
        {
            var rentalAgreementCol = db.GetCollection<RentalAgreement>("RentalAgreements");
            var foundRentalAgreement = rentalAgreementCol.FindById(rentalAgreementId);
            if (foundRentalAgreement == null)
            {
                return null;
            }

            if (editableRentalAgreement.MonthlyRate.HasValue)
            {
                foundRentalAgreement.MonthlyRate = editableRentalAgreement.MonthlyRate.Value;
            }

            if (editableRentalAgreement.PropertyId.HasValue)
            {
                foundRentalAgreement.PropertyId = editableRentalAgreement.PropertyId.Value;
            }

            rentalAgreementCol.Update(foundRentalAgreement);

            return foundRentalAgreement;
        }

        public bool DeleteRentalAgreement(Guid rentalAgreementId)
        {
            var rentalAgreementCol = db.GetCollection<RentalAgreement>("RentalAgreements");
            return rentalAgreementCol.Delete(rentalAgreementId);
        }

        public RentalAgreement[] GetRentalAgreementsByFilter(Guid? ownerId, Guid? renterId)
        {
            var rentalAgreementCol = db.GetCollection<RentalAgreement>("RentalAgreements");
            var returnAgreements = rentalAgreementCol.FindAll();
            if (ownerId.HasValue)
            {
                returnAgreements = returnAgreements.Where(ra => ra.OwnerId == ownerId);
            }

            if (renterId.HasValue)
            {
                returnAgreements = returnAgreements.Where(ra => ra.RenterId == renterId);
            }

            return returnAgreements.ToArray();
        }
    }
}