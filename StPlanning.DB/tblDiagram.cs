//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StPlanning.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblDiagram
    {
        public long Id { get; set; }
        public long IdProject { get; set; }
        public string Key { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<double> FromX { get; set; }
        public Nullable<double> FromY { get; set; }
        public Nullable<double> ToX { get; set; }
        public Nullable<double> ToY { get; set; }
        public Nullable<int> Color { get; set; }
    
        public virtual tblProject tblProject { get; set; }
    }
}
