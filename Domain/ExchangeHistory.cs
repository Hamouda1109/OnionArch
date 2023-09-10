using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class ExchangeHistory:Base
    {
        [Required]
        public DateTime ExchangeTime { get; set; }
        [Required]
        public float Rate { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        public  Currency Currency { get; set; }
    }
}
