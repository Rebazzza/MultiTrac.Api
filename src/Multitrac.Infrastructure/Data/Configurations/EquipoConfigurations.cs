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
        builder.HasNoKey();
        builder.ToTable("EQUIPO_DOCUMENTO_TRACTO", t => t.ExcludeFromMigrations());
        builder.Property(e => e.SocioTercero).HasColumnName("SocioTercero").HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.CodEquipo).HasColumnName("CodEquipo").HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.IdDocumento).HasColumnName("IdDocumento");
        builder.Property(e => e.NombreDocumento).HasColumnName("NombreDocumento").HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.Documento).HasColumnName("Documento").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.FechaExpedida).HasColumnName("FechaExpedida");
        builder.Property(e => e.FechaCaducidad).HasColumnName("FechaCaducidad");
    }
}

public class EquipoDocumentoCarretaConfiguration : IEntityTypeConfiguration<EquipoDocumentoCarreta>
{
    public void Configure(EntityTypeBuilder<EquipoDocumentoCarreta> builder)
    {
        builder.HasNoKey();
        builder.ToTable("EQUIPO_DOCUMENTO_CARRETA", t => t.ExcludeFromMigrations());
        builder.Property(e => e.SocioTercero).HasColumnName("SocioTercero").HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.CodEquipo).HasColumnName("CodEquipo").HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.IdDocumento).HasColumnName("IdDocumento");
        builder.Property(e => e.NombreDocumento).HasColumnName("NombreDocumento").HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.Documento).HasColumnName("Documento").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.FechaExpedida).HasColumnName("FechaExpedida");
        builder.Property(e => e.FechaCaducidad).HasColumnName("FechaCaducidad");
    }
}

public class EquipoCombustibleConfiguration : IEntityTypeConfiguration<EquipoCombustible>
{
    public void Configure(EntityTypeBuilder<EquipoCombustible> builder)
    {
        builder.HasKey(e => e.IdCombustibleEquipo);
        builder.ToTable("EQUIPO_COMBUSTIBLE");
        builder.Property(e => e.IdCombustibleEquipo).HasColumnName("Id_CombustibleEquipo").ValueGeneratedOnAdd();
        builder.Property(e => e.IdOperacionGeneralEquipo).HasColumnName("Id_OperacionGeneralEquipo");
        builder.Property(e => e.IdOperacionGeneralPersonal).HasColumnName("Id_OperacionGeneralPersonal");
        builder.Property(e => e.IdPersonal).HasColumnName("Id_Personal");
        builder.Property(e => e.CodEquipo).HasColumnName("Cod_Equipo").HasMaxLength(12).IsUnicode(false);
        builder.Property(e => e.IdGrifo).HasColumnName("Id_Grifo");
        builder.Property(e => e.NumVale).HasColumnName("Num_Vale").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.NumValeGrifo).HasColumnName("Num_ValeGrifo").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.FechaVale).HasColumnName("Fecha_Vale");
        builder.Property(e => e.IdCombustible).HasColumnName("Id_Combustible");
        builder.Property(e => e.IdUnidad).HasColumnName("IdUnidad");
        builder.Property(e => e.IdContratista).HasColumnName("Id_Contratista");
        builder.Property(e => e.RUCContratista).HasColumnName("RUC_Contratista").HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.IdAutorizado).HasColumnName("Id_Autorizado");
        builder.Property(e => e.IdVB).HasColumnName("Id_VB");
        builder.Property(e => e.FechaDespacho).HasColumnName("Fecha_Despacho");
        builder.Property(e => e.HoraDespacho).HasColumnName("Hora_Despacho").HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.KilometrajeDespacho).HasColumnName("Kilometraje_Despacho");
        builder.Property(e => e.FechaRetorno).HasColumnName("Fecha_Retorno");
        builder.Property(e => e.IdLiquidacionContratistaDescuento).HasColumnName("Id_LiquidacionContratistaDescuento");
        builder.Property(e => e.IdCombustibleEquipoFactura).HasColumnName("Id_CombustibleEquipo_Factura");
        builder.Property(e => e.IdUsuarioRegistro).HasColumnName("Id_UsuarioRegistro");
    }
}

public class EquipoKilometrajeConfiguration : IEntityTypeConfiguration<EquipoKilometraje>
{
    public void Configure(EntityTypeBuilder<EquipoKilometraje> builder)
    {
        builder.HasKey(e => e.IdEquipoKilometraje);
        builder.ToTable("EQUIPO_KILOMETRAJE");
        builder.Property(e => e.IdEquipoKilometraje).ValueGeneratedNever();
        builder.Property(e => e.CodEquipo).HasColumnName("Cod_Equipo").HasMaxLength(12).IsUnicode(false);
        builder.Property(e => e.Acoplado).HasColumnName("Acoplado").HasMaxLength(12).IsUnicode(false);
        builder.Property(e => e.Fecha).HasColumnName("Fecha");
        builder.Property(e => e.Kilometraje).HasColumnName("Kilometraje");
        builder.Property(e => e.Observacion).HasColumnName("Observacion").HasMaxLength(255).IsUnicode(false);
    }
}

public class EquipoMantenimientoConfiguration : IEntityTypeConfiguration<EquipoMantenimiento>
{
    public void Configure(EntityTypeBuilder<EquipoMantenimiento> builder)
    {
        builder.HasKey(e => e.IdEquipoMantenimiento);
        builder.ToTable("EQUIPO_MANTENIMIENTO");
        builder.Property(e => e.IdEquipoMantenimiento).ValueGeneratedNever();
        builder.Property(e => e.CodEquipo).HasColumnName("Cod_Equipo").HasMaxLength(12).IsUnicode(false);
        builder.Property(e => e.Acoplado).HasColumnName("Acoplado").HasMaxLength(12).IsUnicode(false);
        builder.Property(e => e.FechaIngreso).HasColumnName("FechaIngreso");
        builder.Property(e => e.HoraIngreso).HasColumnName("HoraIngreso").HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.FechaEstimadaSalida).HasColumnName("FechaEstimadaSalida");
        builder.Property(e => e.HoraEstimadaSalida).HasColumnName("HoraEstimadaSaalida").HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.FechaSalida).HasColumnName("FechaSalida");
        builder.Property(e => e.HoraSalida).HasColumnName("HoraSalida").HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.KilometrajeIngreso).HasColumnName("KilometrajeIngreso");
        builder.Property(e => e.IdTipoMantto).HasColumnName("IdTipoMantto");
        builder.Property(e => e.IdManttoPM).HasColumnName("IdManttoPM");
        builder.Property(e => e.IdPersonaResponsable).HasColumnName("IdPersonaResponsable");
        builder.Property(e => e.CantidadTrabajos).HasColumnName("CantidadTrabajos");
        builder.Property(e => e.IdMarca).HasColumnName("IdMarca");
        builder.Property(e => e.IdEquipoEstadoGeneral).HasColumnName("IdEquipoEstadoGeneral");
        builder.Property(e => e.NroOrden).HasColumnName("Nro_Orden").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Url).HasColumnName("Url").HasMaxLength(500).IsUnicode(false);
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
