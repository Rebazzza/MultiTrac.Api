using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Multitrac.Domain.Entities;

namespace Multitrac.Infrastructure.Data.Configurations;

public class MonedaConfiguration : IEntityTypeConfiguration<Moneda>
{
    public void Configure(EntityTypeBuilder<Moneda> builder)
    {
        builder.HasKey(e => e.IdMoneda);
        builder.ToTable("MONEDA");
        builder.Property(e => e.IdMoneda).HasColumnName("Id_Moneda").ValueGeneratedNever();
        builder.Property(e => e.NombreMoneda).HasColumnName("NombreMoneda").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.AbreviaturaMoneda).HasColumnName("Abreviatura_Moneda").HasMaxLength(50).IsUnicode(false);
    }
}

public class BancoConfiguration : IEntityTypeConfiguration<Banco>
{
    public void Configure(EntityTypeBuilder<Banco> builder)
    {
        builder.HasKey(e => e.IdBanco);
        builder.ToTable("BANCO");
        builder.Property(e => e.IdBanco).HasColumnName("Id_Banco").ValueGeneratedOnAdd();
        builder.Property(e => e.BancoNombre).HasColumnName("Banco").HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.Observaciones).HasColumnName("Observaciones").HasMaxLength(250).IsUnicode(false);
    }
}

public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
{
    public void Configure(EntityTypeBuilder<Cargo> builder)
    {
        builder.HasKey(e => e.IdCargo);
        builder.ToTable("CARGO");
        builder.Property(e => e.IdCargo).HasColumnName("IdCargo").ValueGeneratedOnAdd();
        builder.Property(e => e.TituloCargo).HasColumnName("Titulo_Cargo").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.DescripcionCargo).HasColumnName("Descripcion_Cargo").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.CrgCod).HasColumnName("CRG_COD");
        builder.Property(e => e.AreCod).HasColumnName("ARE_COD");
        builder.Property(e => e.CrgNom).HasColumnName("CRG_NOM").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.CrgCer).HasColumnName("CRG_CER").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.CrgAdc).HasColumnName("CRG_ADC").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.CrgExp).HasColumnName("CRG_EXP").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.CrgPer).HasColumnName("CRG_PER").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.CrgObs).HasColumnName("CRG_OBS").HasMaxLength(200).IsUnicode(false);
        builder.Property(e => e.CtrlAsist).HasColumnName("CTRL_ASIST").HasMaxLength(3).IsUnicode(false);
    }
}

public class NivelEducativoConfiguration : IEntityTypeConfiguration<NivelEducativo>
{
    public void Configure(EntityTypeBuilder<NivelEducativo> builder)
    {
        builder.HasKey(e => e.IdNivelEducativo);
        builder.ToTable("NIVEL_EDUCATIVO");
        builder.Property(e => e.IdNivelEducativo).HasColumnName("Id_NivelEducativo").ValueGeneratedNever();
        builder.Property(e => e.CodInterno).HasColumnName("codInterno");
        builder.Property(e => e.DescripcionNivelEducativo).HasColumnName("Descripcion_NivelEducativo").HasMaxLength(150).IsUnicode(false);
        builder.Property(e => e.IdGradoInstruccion).HasColumnName("Id_GradoInstruccion");
    }
}

public class AfpConfiguration : IEntityTypeConfiguration<Afp>
{
    public void Configure(EntityTypeBuilder<Afp> builder)
    {
        builder.HasKey(e => e.IdAfp);
        builder.ToTable("AFP");
        builder.Property(e => e.IdAfp).HasColumnName("Id_AFP").ValueGeneratedOnAdd();
        builder.Property(e => e.CodigoExcel).HasColumnName("CodigoExcel").HasMaxLength(5).IsUnicode(false);
        builder.Property(e => e.NomAfp).HasColumnName("Nom_AFP").HasMaxLength(200).IsUnicode(false);
        builder.Property(e => e.Estado).HasColumnName("Estado").HasMaxLength(1).IsUnicode(false);
        builder.Property(e => e.Observacion).HasColumnName("Observacion").HasMaxLength(10).IsFixedLength();
    }
}

public class FlotaConfiguration : IEntityTypeConfiguration<Flota>
{
    public void Configure(EntityTypeBuilder<Flota> builder)
    {
        builder.HasKey(e => e.IdFlota);
        builder.ToTable("FLOTA");
        builder.Property(e => e.IdFlota).HasColumnName("IdFlota").ValueGeneratedOnAdd();
        builder.Property(e => e.DescFlota).HasColumnName("DescFlota").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.Nivel).HasColumnName("Nivel").HasMaxLength(3).IsUnicode(false);
        builder.Property(e => e.Tipo).HasColumnName("Tipo").HasMaxLength(1).IsUnicode(false);
    }
}

public class ActividadConfiguration : IEntityTypeConfiguration<Actividad>
{
    public void Configure(EntityTypeBuilder<Actividad> builder)
    {
        builder.HasKey(e => e.IdActividad);
        builder.ToTable("ACTIVIDAD");
        builder.Property(e => e.IdActividad).HasColumnName("Id_Actividad").ValueGeneratedOnAdd();
        builder.Property(e => e.Descripcion).HasColumnName("Descripcion").HasMaxLength(255).IsUnicode(false);
    }
}

public class TurnoConfiguration : IEntityTypeConfiguration<Turno>
{
    public void Configure(EntityTypeBuilder<Turno> builder)
    {
        builder.HasKey(e => e.IdTurno);
        builder.ToTable("TURNO");
        builder.Property(e => e.IdTurno).HasColumnName("Id_Turno").ValueGeneratedOnAdd();
        builder.Property(e => e.IdContratista).HasColumnName("Id_Contratista");
        builder.Property(e => e.IdOperacion).HasColumnName("Id_Operacion");
        builder.Property(e => e.PosicionTurno).HasColumnName("Posicion_Turno");
        builder.Property(e => e.FechInicTurno).HasColumnName("Fech_Inic_Turno").HasColumnType("datetime");
        builder.Property(e => e.FechFinTurno).HasColumnName("Fech_Fin_Turno").HasColumnType("datetime");
        builder.Property(e => e.Estado).HasColumnName("Estado").HasMaxLength(1).IsUnicode(false);
    }
}

public class TipoPagoConfiguration : IEntityTypeConfiguration<TipoPago>
{
    public void Configure(EntityTypeBuilder<TipoPago> builder)
    {
        builder.HasKey(e => e.IdTipoPago);
        builder.ToTable("TIPO_PAGO");
        builder.Property(e => e.IdTipoPago).HasColumnName("Id_TipoPago").ValueGeneratedNever();
        builder.Property(e => e.DescTipoPago).HasColumnName("Desc_TipoPago").HasMaxLength(200).IsUnicode(false);
        builder.Property(e => e.Observaciones).HasColumnName("Observaciones").HasMaxLength(200).IsUnicode(false);
    }
}

public class TipoOcurrenciaConfiguration : IEntityTypeConfiguration<TipoOcurrencia>
{
    public void Configure(EntityTypeBuilder<TipoOcurrencia> builder)
    {
        builder.HasKey(e => e.IdTipoOcurrencia);
        builder.ToTable("TIPO_OCURRENCIA");
        builder.Property(e => e.IdTipoOcurrencia).HasColumnName("Id_TipoOcurrencia").ValueGeneratedOnAdd();
        builder.Property(e => e.TipoOcurrenciaNombre).HasColumnName("TipoOcurrencia").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Observaciones).HasColumnName("Observaciones").HasMaxLength(250).IsUnicode(false);
    }
}
