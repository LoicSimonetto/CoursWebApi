using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfieAWookies.NET.Selfies.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SelfieAWookies.NET.Selfies.Infrastructures.Data.TypeConfiguration
{
    public class SelfieEntityTypeConfiguration : IEntityTypeConfiguration<Selfie>
    {
        #region Méthodes publiques
        public void Configure(EntityTypeBuilder<Selfie> builder)
        {
            builder.ToTable("Selfie");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Wookie)
                   .WithMany(x => x.Selfies);
        }
        #endregion
    }
}
