using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sheremetov_Authorization.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("UserID")]
        public int UserID { get; set; }

        [Column("Login")]
        public string UserLogin { get; set; }

        [Column("PasswordHash")]
        public string UserPassword { get; set; }

        [Column("RoleID")]
        public int RoleID { get; set; }

        [Column("ReaderID")]
        public int? ReaderID { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }
    }
}
