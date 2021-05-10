using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moving_App_Web_API.Models
{
    public partial class Items
    {
        [Key]
        [Column("ItemID")]
        public int ItemId { get; set; }
        [Required]
        [StringLength(50)]
        public string ItemName { get; set; }
    }
}
