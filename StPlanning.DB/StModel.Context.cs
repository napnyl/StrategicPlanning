﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StLiteDBEntities : DbContext
    {
        public StLiteDBEntities()
            : base("name=StLiteDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblDa> tblDa { get; set; }
        public virtual DbSet<tblDaDetail> tblDaDetail { get; set; }
        public virtual DbSet<tblDiagram> tblDiagram { get; set; }
        public virtual DbSet<tblDo> tblDo { get; set; }
        public virtual DbSet<tblDoDetail> tblDoDetail { get; set; }
        public virtual DbSet<tblFa> tblFa { get; set; }
        public virtual DbSet<tblFaDetail> tblFaDetail { get; set; }
        public virtual DbSet<tblFo> tblFo { get; set; }
        public virtual DbSet<tblFoda> tblFoda { get; set; }
        public virtual DbSet<tblFodaDetail> tblFodaDetail { get; set; }
        public virtual DbSet<tblFoDetail> tblFoDetail { get; set; }
        public virtual DbSet<tblManagerSt> tblManagerSt { get; set; }
        public virtual DbSet<tblStrategiesBasic> tblStrategiesBasic { get; set; }
        public virtual DbSet<tblBsc> tblBsc { get; set; }
        public virtual DbSet<tblProject> tblProject { get; set; }
    }
}