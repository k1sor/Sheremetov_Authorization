using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sheremetov_Authorization.Models
{
    [Table("Roles")]
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        [Key]
        [Column("RoleID")]
        public int RoleID { get; set; }

        [Column("Name")]
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
