using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moving_App_Web_API.Models
{
    public partial class UserBox
    {
        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [Key]
        [Column("BoxID")]
        public int BoxId { get; set; }
    }
}
