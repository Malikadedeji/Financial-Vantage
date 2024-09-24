﻿using Microsoft.AspNetCore.Identity;

namespace FinancialVantage.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

    }
}
