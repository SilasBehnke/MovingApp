using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moving_App_Web_API.Models
{
    public partial class Boxes
    {
        [Key]
        [Column("BoxID")]
        public int BoxId { get; set; }
        [Required]
        [StringLength(15)]
        public string BoxName { get; set; }
    }
}
