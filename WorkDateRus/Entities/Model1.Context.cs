//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkDateRus.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WorkDaysEntities : DbContext
    {
        public WorkDaysEntities()
            : base("name=WorkDaysEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Sehedule> Sehedule { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Worker> Worker { get; set; }
    }
}
