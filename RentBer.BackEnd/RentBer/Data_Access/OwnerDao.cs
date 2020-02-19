using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentBer.Models;

namespace RentBer.Data_Access
{
    public class OwnerDao: DaoBase
    {
        public Owner[] GetAllOwners()
        {
            var ownerCol = db.GetCollection<Owner>("Owners");
            return ownerCol.FindAll().ToArray();
        }
        public Owner GetOwnerById(Guid id)
        {
            var ownerCol = db.GetCollection<Owner>("Owners");
            return ownerCol.FindById(id);
        }

        public Owner AddNewOwner(EditableOwner editableOwner)
        {
            var ownerCol = db.GetCollection<Owner>("Owners");
            var newOwner = new Owner()
            {
                Id = Guid.NewGuid(),
                FirstName = editableOwner.FirstName,
                LastName = editableOwner.LastName
            };

            ownerCol.Insert(newOwner);

            return newOwner;
        }

        public Owner UpdateUser(Guid ownerId, EditableOwner editableOwner)
        {
            var ownerCol = db.GetCollection<Owner>("Owners");
            var foundOwner = ownerCol.FindById(ownerId);
            if (foundOwner == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(editableOwner.FirstName))
            {
                foundOwner.FirstName = editableOwner.FirstName;
            }

            if (!string.IsNullOrEmpty(editableOwner.LastName))
            {
                foundOwner.LastName = editableOwner.LastName;
            }

            ownerCol.Update(foundOwner);
            return foundOwner;
        }


        public bool DeleteOwner(Guid ownerId)
        {
            var ownerCol = db.GetCollection<Owner>("Owners");
            return ownerCol.Delete(ownerId);
        }
    }
}