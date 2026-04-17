using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class GenLog
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public string? MessageTemplate { get; set; }
        public string? Level { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string? Exception { get; set; }
        public string? Properties { get; set; }
        public string? Response { get; set; }
        public string? UserName { get; set; }
        public string? Module { get; set; }
    }
}
