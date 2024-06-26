﻿using System.Collections.Generic;

namespace Quiplogs.Core.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string TaxNumber { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }

        public int SubscriptionId { get; set; }

        public bool IsLocked { get; set; }

        public string LockedReason { get; set; }

        public List<AppUser> Users { get; set; } = new List<AppUser>();
    }
}
