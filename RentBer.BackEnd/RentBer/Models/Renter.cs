using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentBer.Models
{
    public class Renter
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}