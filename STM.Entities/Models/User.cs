namespace STM.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;
    using STM.Common.Enums;

    [Table("Users")]
    public class User : IdentityUser<Guid>
    {
        public DateTime? LastLogin { get; set; }

        public StatusEnum? Status { get; set; }

        public bool IsAdmin { get; set; }

        public UserTypeEnum? UserType { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<UserClaim> UserClaims { get; set; }

        public virtual ICollection<UserLogin> UserLogins { get; set; }

        public virtual ICollection<UserToken> UserTokens { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
