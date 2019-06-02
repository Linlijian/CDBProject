
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.ACTION
{
    [Serializable]
    public class ACTIONModel : StandardModel
    {
        [Required]
        [Display(Name = "Id")]
        public int ID { get; set; } //W
        [Display(Name = "Data")]
        public string DATA { get; set; } //H

    }
    
}