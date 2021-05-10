using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moving_App_Web_API.Models
{
    public partial class BoxItem
    {
        [Key]
        [Column("BoxID")]
        public int BoxId { get; set; }
        [Key]
        [Column("ItemID")]
        public int ItemId { get; set; }
    }
}
