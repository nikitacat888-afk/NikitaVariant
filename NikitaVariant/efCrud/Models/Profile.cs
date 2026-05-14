using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace efCrud.Models
{
    [Table("profiles")]
    public class Profile
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("bio")]
        public string Bio { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        public User User { get; set; }

    }
}
