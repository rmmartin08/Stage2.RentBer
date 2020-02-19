using System;
using System.Linq;
using RentBer.Models;

namespace RentBer.Data_Access
{
    public class RenterDao : DaoBase
    {
        public Renter[] GetAllRenters()
        {
            var renterCol = db.GetCollection<Renter>("Renters");
            return renterCol.FindAll().ToArray();
        }

        public Renter GetRenterById(Guid renterId)
        {
            var renterCol = db.GetCollection<Renter>("Renters");
            return renterCol.FindById(renterId);
        }

        public Renter AddNewRenter(string FirstName, string LastName)
        {
            var renterCol = db.GetCollection<Renter>("Renters");
            var newRenter = new Renter()
            {
                Id = Guid.NewGuid(),
                FirstName = FirstName,
                LastName = LastName
            };

            renterCol.Insert(newRenter);

            return newRenter;
        }

        public Renter UpdateRenter(Guid renterId, EditableRenter updatedRenter)
        {
            var renterCol = db.GetCollection<Renter>("Renters");
            var foundRenter = renterCol.FindById(renterId);

            if (foundRenter == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(updatedRenter.FirstName))
            {
                foundRenter.FirstName = updatedRenter.FirstName;
            }

            if (!string.IsNullOrEmpty(updatedRenter.LastName))
            {
                foundRenter.LastName = updatedRenter.LastName;
            }

            renterCol.Update(foundRenter);
            return foundRenter;
        }

        public bool DeleteRenter(Guid renterId)
        {
            var renterCol = db.GetCollection<Renter>("Renters");
            var foundRenter = renterCol.FindById(renterId);

            return renterCol.Delete(renterId);
        }
    }
}