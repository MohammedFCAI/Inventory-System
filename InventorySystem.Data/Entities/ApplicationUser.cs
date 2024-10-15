﻿using Microsoft.AspNetCore.Identity;

namespace InventorySystem.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }
    }
}
