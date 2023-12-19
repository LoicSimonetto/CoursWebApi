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
    public class WookieEntityTypeConfiguration : IEntityTypeConfiguration<Wookie>
    {
        #region Méthodes publiques
        public void Configure(EntityTypeBuilder<Wookie> builder)
        {
            builder.ToTable("Wookie");
        }
        #endregion
    }
}
