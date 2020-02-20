using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentBer.Models
{
    public class EditableRentalAgreement
    {
        public Guid? OwnerId { get; set; }
        public Guid? RenterId { get; set; }
        public Guid? PropertyId { get; set; }
        public int? MonthlyRate { get; set; }
    }
}