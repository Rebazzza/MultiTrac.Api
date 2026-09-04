using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Multitrac.Domain.Entities;

namespace Multitrac.Infrastructure.Data.Configurations;

public class BaucherCajaConfiguration : IEntityTypeConfiguration<BaucherCaja>
{
    public void Configure(EntityTypeBuilder<BaucherCaja> builder)
    {
        builder.ToTable("BAUCHER_CAJA");
        builder.HasKey(e => e.IdBaucherCaja);
        builder.Property(e => e.IdBaucherCaja).HasColumnName("IdBaucherCaja").ValueGeneratedNever();
        builder.Property(e => e.FechaDoc).HasColumnName("FechaDoc");
        builder.Property(e => e.Concepto).HasColumnName("Referencia").HasMaxLength(250); 
        builder.Property(e => e.Total).HasColumnName("Total").HasColumnType("decimal(18,2)");
        builder.Property(e => e.Estado).HasColumnName("Enviado").HasMaxLength(1);
    }
}

public class BaucherEgresoConfiguration : IEntityTypeConfiguration<BaucherEgreso>
{
    public void Configure(EntityTypeBuilder<BaucherEgreso> builder)
    {
        builder.ToTable("BAUCHER_EGRESOS");
        builder.HasKey(e => e.IdBaucherEgresos);
        builder.Property(e => e.IdBaucherEgresos).HasColumnName("IdBaucherEgresos").ValueGeneratedNever();
        builder.Property(e => e.NroBaucher).HasColumnName("NroBaucher").HasMaxLength(50);
        builder.Property(e => e.FechaBaucher).HasColumnName("FechaBaucher");
        builder.Property(e => e.ImporteTotal).HasColumnName("ImporteTotal").HasColumnType("decimal(18,2)");
        builder.Property(e => e.Referencia).HasColumnName("Referencia").HasMaxLength(250);
    }
}
