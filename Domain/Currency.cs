using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Currency : Base
    {
        [Required]
        public string Name { get; set; }
        [StringLength(3)]
        [Required]
        public string Sgin { get; set; }
        [Required]
        public bool IsActive { get;  set ; }
    }
}
