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
    
    public partial class tblFoDetail
    {
        public long Id { get; set; }
        public long IdFo { get; set; }
        public Nullable<int> Row { get; set; }
        public Nullable<int> Col { get; set; }
        public string RowName { get; set; }
        public string ColName { get; set; }
        public Nullable<int> Value { get; set; }
        public string UserUpdate { get; set; }
        public string ComputerUpdate { get; set; }
        public Nullable<System.DateTime> DateUpdate { get; set; }
    
        public virtual tblFo tblFo { get; set; }
    }
}
