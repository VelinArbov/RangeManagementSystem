﻿using Microsoft.AspNetCore.Identity;
using RangeManagementSystem.Data.Common.Models;

namespace RangeManagementSystem.Data.Models
{
    public class ApplicationRole : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public ApplicationRole() : this(null)
        {

        }

        public ApplicationRole(string name)
          : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
