﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFTaken
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BankEntities : DbContext
    {
        public BankEntities()
            : base("name=BankEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Klant> Klanten { get; set; }
        public virtual DbSet<Rekening> Rekeningen { get; set; }
        public virtual DbSet<Personeelslid> Personeel { get; set; }
        public virtual DbSet<TotaleSaldoPerKlant> TotaleSaldosPerKlant { get; set; }
    
        public virtual int AdministratieveKost(Nullable<decimal> kost)
        {
            var kostParameter = kost.HasValue ?
                new ObjectParameter("Kost", kost) :
                new ObjectParameter("Kost", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AdministratieveKost", kostParameter);
        }
    }
}
