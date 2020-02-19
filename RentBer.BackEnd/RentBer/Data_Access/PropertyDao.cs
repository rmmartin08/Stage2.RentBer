using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentBer.Models;

namespace RentBer.Data_Access
{
    public class PropertyDao: DaoBase
    {
        public Property[] GetAllProperties()
        {
            var propertyCol = db.GetCollection<Property>("Properties");
            return propertyCol.FindAll().ToArray();
        }

        public Property GetPropertyById(Guid propertyId)
        {
            var propertyCol = db.GetCollection<Property>("Properties");
            return propertyCol.FindById(propertyId);
        }

        public Property AddNewProperty(EditableProperty editableProperty)
        {
            var propertyCol = db.GetCollection<Property>("Properties");
            var newProperty = new Property()
            {
                Id = Guid.NewGuid(),
                StreetAddress = editableProperty.StreetAddress,
                City = editableProperty.City,
                State = editableProperty.State,
                Zip = editableProperty.Zip ?? 99999
            };

            propertyCol.Insert(newProperty);
            return newProperty;
        }

        public Property UpdateProperty(Guid propertyId, EditableProperty editableProperty)
        {
            var propertyCol = db.GetCollection<Property>("Properties");
            var foundProperty = propertyCol.FindById(propertyId);

            if (foundProperty == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(editableProperty.StreetAddress))
            {
                foundProperty.StreetAddress = editableProperty.StreetAddress;
            }
            if (!string.IsNullOrEmpty(editableProperty.City))
            {
                foundProperty.City = editableProperty.City;
            }
            if (!string.IsNullOrEmpty(editableProperty.State))
            {
                foundProperty.State = editableProperty.State;
            }
            if (editableProperty.Zip.HasValue)
            {
                foundProperty.Zip = editableProperty.Zip.Value;
            }

            propertyCol.Update(foundProperty);
            return foundProperty;
        }

        public bool DeleteProperty(Guid propertyId)
        {
            var propertyCol = db.GetCollection<Property>("Properties");
            return propertyCol.Delete(propertyId);
        }
    }
}