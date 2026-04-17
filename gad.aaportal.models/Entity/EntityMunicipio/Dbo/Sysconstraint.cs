using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Sysconstraint
    {
        public int? Constid { get; set; }
        public int? Id { get; set; }
        public short? Colid { get; set; }
        public byte? Spare1 { get; set; }
        public int? Status { get; set; }
        public int? Actions { get; set; }
        public int? Error { get; set; }
    }
}
