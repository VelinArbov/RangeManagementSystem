﻿using Microsoft.AspNetCore.Identity;
using RangeManagementSystem.Data.Common.Models;

namespace RangeManagementSystem.Data.Models
{
    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        // Deletable entity
        public bool IsDeleted { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime? DeletedOn { get; set; }
        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        public virtual List<Reservation> Reservations { get; set; } = new ();
        public virtual List<ShootingEvent> ShootingEvents { get; set; } = new ();
    }
}
