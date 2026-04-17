using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class VwAspnetRole
    {
        public Guid ApplicationId { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public string LoweredRoleName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
