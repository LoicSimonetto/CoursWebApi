using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SelfieAWookies.NET.Selfies.Domain;
using SelfieAWookies.NET.Selfies.Infrastructures.Data.TypeConfiguration;
using SelfiesAWookies.Core.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookies.NET.Selfies.Infrastructures.Data
{
    public class SelfiesContext : IdentityDbContext, IUnitOfWork
    {
        #region Propriétés
        public DbSet<Selfie> Selfies { get; set; }
        public DbSet<Wookie> Wookies { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        #endregion

        #region Constructeurs
        public SelfiesContext([NotNullAttribute] DbContextOptions<SelfiesContext> options) : base(options) { }
        public SelfiesContext() : base()
        {

        }
        #endregion

        #region Méthodes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SelfieEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new WookieEntityTypeConfiguration());
        }
        #endregion
    }
}
