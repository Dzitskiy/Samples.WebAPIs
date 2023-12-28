using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdataApp.Data.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("age")]
        public int Age { get; set; }

        //[Column("date_of_birth")]
        //public DateTime? DateOfBirth { get; set; }

        [Column("country_id")]
        public int? CountryId { get; set; }

        public Country Country { get; set; }

        public List<Comment>? Comments { get; set; }
    }


    [Table("countries")]
    public class Country
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("comments")]
    public class Comment
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
