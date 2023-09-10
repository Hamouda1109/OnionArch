using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA_Repository.Validations.Currency
{
    public class CurrencyValidation
    {
        [Required]
        public string Name { get; set; }
        [StringLength(3)]
        public string Sgin { get; set; }
        [Required]
        public bool IsActive { get; set; }

    }
}
