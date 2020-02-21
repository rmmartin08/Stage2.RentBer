﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentBer.Models
{
    public class EditableRentalPayment
    {
        public Guid? RentalAgreementId { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public bool? IsPaid { get; set; }
    }
}