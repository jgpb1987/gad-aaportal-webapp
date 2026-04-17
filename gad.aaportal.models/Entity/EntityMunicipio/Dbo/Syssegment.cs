using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Syssegment
    {
        public int Segment { get; set; }
        public string Name { get; set; } = null!;
        public int Status { get; set; }
    }
}
