﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PropertyPortal
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class propertyportalEntities : DbContext
    {
        public propertyportalEntities()
            : base("name=propertyportalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tbladminlogin> tbladminlogins { get; set; }
        public DbSet<tblfurnishmaster> tblfurnishmasters { get; set; }
        public DbSet<tblmenu> tblmenus { get; set; }
        public DbSet<tblownershiptypemaster> tblownershiptypemasters { get; set; }
        public DbSet<tblpropertycategory> tblpropertycategories { get; set; }
        public DbSet<tblpropertytype> tblpropertytypes { get; set; }
        public DbSet<tbltrantypemaster> tbltrantypemasters { get; set; }
        public DbSet<tblportaluser> tblportalusers { get; set; }
        public DbSet<tblpropagent> tblpropagents { get; set; }
    }
}
