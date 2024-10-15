﻿using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Presentation.Models
{
    public class LoginViewModel
    {
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
