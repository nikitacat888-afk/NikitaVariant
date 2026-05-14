using System.ComponentModel.DataAnnotations.Schema;

namespace efCrud.Models
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("age")]
        public int Age { get; set; }

        public Profile Profile { get; set; }
    }
}
