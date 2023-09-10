using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA_Repository.Auth.Validation
{
    public class LoginRequest
    {
            [Required(ErrorMessage = "User Name is required")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Password is required")]
            public string Password { get; set; }
        
    }
}
