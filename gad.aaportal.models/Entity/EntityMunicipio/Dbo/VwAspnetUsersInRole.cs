using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VwAspnetUsersInRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
