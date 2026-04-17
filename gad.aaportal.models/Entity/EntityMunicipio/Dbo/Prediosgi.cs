using System;
using System.Collections.Generic;

namespace gad.aaportal.models.Entity.Dbo
{
    public partial class Prediosgi
    {
        public double? Objectid { get; set; }
        public string? Clavecat { get; set; }
        public string? ManzPred { get; set; }
        public string? Cedula { get; set; }
        public string? Apellidos { get; set; }
        public string? Nombres { get; set; }
        public string? Observaciones { get; set; }
        public double? Areapredio { get; set; }
        public string? Claveacometida { get; set; }
        public double? ShapeArea { get; set; }
        public double? ShapeLen { get; set; }
    }
}
