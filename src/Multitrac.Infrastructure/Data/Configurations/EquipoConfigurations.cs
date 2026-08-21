using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Multitrac.Domain.Entities;

namespace Multitrac.Infrastructure.Data.Configurations;

public class EquipoConfiguration : IEntityTypeConfiguration<Equipo>
{
    public void Configure(EntityTypeBuilder<Equipo> builder)
    {
        builder.HasKey(e => new { e.TipoEquipo, e.CodEquipo });
        builder.ToTable("EQUIPOS");
        builder.Property(e => e.TipoEquipo).HasColumnName("Tipo_Equipo").HasMaxLength(1).IsUnicode(false);
        builder.Property(e => e.CodEquipo).HasColumnName("Cod_Equipo").HasMaxLength(12).IsUnicode(false);
        builder.Property(e => e.CodEllipse).HasColumnName("Cod_Ellipse").HasMaxLength(12).IsUnicode(false);
        builder.Property(e => e.NoPlaca).HasColumnName("No_Placa").HasMaxLength(12).IsUnicode(false);
        builder.Property(e => e.NoPlacaAnt).HasColumnName("No_Placa_Ant").HasMaxLength(12).IsUnicode(false);
        builder.Property(e => e.Flota).HasColumnName("Flota");
        builder.Property(e => e.DescEquipo).HasColumnName("Desc_Equipo").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.DescAlternativa).HasColumnName("Desc_Alternativa").HasMaxLength(80).IsUnicode(false);
        builder.Property(e => e.AreaEspecifica).HasColumnName("Area_Especifica").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.IdAreaEspec).HasColumnName("Id_Area_Espec");
        builder.Property(e => e.AreGnral).HasColumnName("Are_Gnral").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.IdAreaGral).HasColumnName("Id_Area_Gral");
        builder.Property(e => e.EquipoReemplazar).HasColumnName("Equipo_Reemplazar").HasMaxLength(2).IsUnicode(false);
        builder.Property(e => e.Modelo).HasColumnName("Modelo").HasMaxLength(35).IsUnicode(false);
        builder.Property(e => e.AnoFabricacion).HasColumnName("Año_Fabricacion").HasMaxLength(4).IsUnicode(false);
        builder.Property(e => e.NoSerMotor).HasColumnName("No_Ser_Motor").HasMaxLength(25).IsUnicode(false);
        builder.Property(e => e.NoSerChasis).HasColumnName("No_Ser_Chasis").HasMaxLength(25).IsUnicode(false);
        builder.Property(e => e.RevisionEquipo).HasColumnName("Revision_Equipo").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.EstatusEquipo).HasColumnName("Estatus_Equipo").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.NoTarjetaPropiedad).HasColumnName("No_Tarjeta_Propiedad").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Soat).HasColumnName("Soat").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.FechaExpedSoat).HasColumnName("Fecha_Exped_Soat").HasColumnType("datetime");
        builder.Property(e => e.FechaCaducidadSoat).HasColumnName("Fecha_Caducidad_Soat").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Observaciones).HasColumnName("Observaciones").HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.Horometro).HasColumnName("Horometro");
        builder.Property(e => e.Sticker).HasColumnName("Sticker").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.Marca).HasColumnName("Marca").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.ColorCamioneta).HasColumnName("ColorCamioneta").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.Tipo).HasColumnName("Tipo").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.Egi).HasColumnName("Egi").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.Combustible).HasColumnName("Combustible").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.EstatusOp).HasColumnName("EstatusOP");
        builder.Property(e => e.GPS).HasColumnName("GPS");
        builder.Property(e => e.Largo).HasColumnName("Largo");
        builder.Property(e => e.Ancho).HasColumnName("Ancho");
        builder.Property(e => e.Alto).HasColumnName("Alto");
        builder.Property(e => e.CargaUtil).HasColumnName("CargaUtil");
        builder.Property(e => e.KilometrajeMantto).HasColumnName("KilometrajeMantto");
    }
}

public class EquipoDocumentoTractoConfiguration : IEntityTypeConfiguration<EquipoDocumentoTracto>
{
    public void Configure(EntityTypeBuilder<EquipoDocumentoTracto> builder)
    {
        builder.HasKey(e => e.IdEquipoDocumentoTracto);
        builder.ToTable("EQUIPO_DOCUMENTO_TRACTO");
        builder.Property(e => e.IdEquipoDocumentoTracto).ValueGeneratedNever();
    }
}

public class EquipoDocumentoCarretaConfiguration : IEntityTypeConfiguration<EquipoDocumentoCarreta>
{
    public void Configure(EntityTypeBuilder<EquipoDocumentoCarreta> builder)
    {
        builder.HasKey(e => e.IdEquipoDocumentoCarreta);
        builder.ToTable("EQUIPO_DOCUMENTO_CARRETA");
        builder.Property(e => e.IdEquipoDocumentoCarreta).ValueGeneratedNever();
    }
}

public class EquipoCombustibleConfiguration : IEntityTypeConfiguration<EquipoCombustible>
{
    public void Configure(EntityTypeBuilder<EquipoCombustible> builder)
    {
        builder.HasKey(e => e.IdCombustibleEquipo);
        builder.ToTable("EQUIPO_COMBUSTIBLE");
        builder.Property(e => e.IdCombustibleEquipo).ValueGeneratedNever();
    }
}

public class EquipoKilometrajeConfiguration : IEntityTypeConfiguration<EquipoKilometraje>
{
    public void Configure(EntityTypeBuilder<EquipoKilometraje> builder)
    {
        builder.HasKey(e => e.IdEquipoKilometraje);
        builder.ToTable("EQUIPO_KILOMETRAJE");
        builder.Property(e => e.IdEquipoKilometraje).ValueGeneratedNever();
    }
}

public class EquipoMantenimientoConfiguration : IEntityTypeConfiguration<EquipoMantenimiento>
{
    public void Configure(EntityTypeBuilder<EquipoMantenimiento> builder)
    {
        builder.HasKey(e => e.IdEquipoMantenimiento);
        builder.ToTable("EQUIPO_MANTENIMIENTO");
        builder.Property(e => e.IdEquipoMantenimiento).ValueGeneratedNever();
    }
}

public class EquipoMantenimientoDetalleConfiguration : IEntityTypeConfiguration<EquipoMantenimientoDetalle>
{
    public void Configure(EntityTypeBuilder<EquipoMantenimientoDetalle> builder)
    {
        builder.HasKey(e => e.IdEquipoMantenimientoDetalle);
        builder.ToTable("EQUIPO_MANTENIMIENTO_DETALLE");
        builder.Property(e => e.IdEquipoMantenimientoDetalle).ValueGeneratedNever();
    }
}
