namespace STM.Entities.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;
    using STM.Common.Enums;

    [Table("Roles")]
    public class Role : IdentityRole<Guid>
    {
        public StatusEnum? Status { get; set; }

        public virtual ICollection<RoleClaim> RoleClaims { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
