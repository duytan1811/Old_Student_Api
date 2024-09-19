namespace STM.Entities.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    [Table("Roles")]
    public class Role : IdentityRole<Guid>
    {
        public int? Status { get; set; }

        public virtual ICollection<RoleClaim> RoleClaims { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
