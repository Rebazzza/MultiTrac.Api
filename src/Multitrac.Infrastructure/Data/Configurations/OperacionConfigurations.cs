using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Multitrac.Domain.Entities;

namespace Multitrac.Infrastructure.Data.Configurations;

public class OperacionConfiguration : IEntityTypeConfiguration<Operacion>
{
    public void Configure(EntityTypeBuilder<Operacion> builder)
    {
        builder.HasKey(e => e.IdOperacion);
        builder.ToTable("OPERACION");
        builder.Property(e => e.IdOperacion).HasColumnName("Id_Operacion").ValueGeneratedOnAdd();
        builder.Property(e => e.DescOperacion).HasColumnName("Desc_Operacion").HasMaxLength(200).IsUnicode(false);
        builder.Property(e => e.HhTransporteProm).HasColumnName("HH_Transporte_Prom");
        builder.Property(e => e.HhTrabajoProm).HasColumnName("HH_Trabajo_Prom");
        builder.Property(e => e.OIdUbicacionOp).HasColumnName("O_Id_UbicacionOP");
        builder.Property(e => e.DIdUbicacionOp).HasColumnName("D_Id_UbicacionOP");
        builder.Property(e => e.IdTipoCarga).HasColumnName("Id_TipoCarga");
        builder.Property(e => e.IdUnidad).HasColumnName("Id_Unidad");
        builder.Property(e => e.FactPlacas).HasColumnName("Fact_Placas");
        builder.Property(e => e.FactCant).HasColumnName("Fact_Cant");
        builder.Property(e => e.FactUnid).HasColumnName("Fact_Unid");
        builder.Property(e => e.FactGTr).HasColumnName("Fact_GTr");
        builder.Property(e => e.FactPreUnt).HasColumnName("Fact_PreUnt");
        builder.Property(e => e.FactConf).HasColumnName("Fact_Conf");
        builder.Property(e => e.FactDestino).HasColumnName("Fact_Destino");
        builder.Property(e => e.LiqTipo).HasColumnName("Liq_Tipo");
        builder.Property(e => e.LatCentroGIda).HasColumnName("LatCentroG_Ida");
        builder.Property(e => e.LngCentroGIda).HasColumnName("LngCentroG_Ida");
        builder.Property(e => e.ZoomGIda).HasColumnName("ZoomG_Ida");
        builder.Property(e => e.LatCentroGVuelta).HasColumnName("LatCentroG_Vuelta");
        builder.Property(e => e.LngCentroGVuelta).HasColumnName("LngCentroG_Vuelta");
        builder.Property(e => e.ZoomGVuelta).HasColumnName("ZoomG_Vuelta");
        builder.Property(e => e.TipoProducto).HasColumnName("TipoProducto").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Origen).HasColumnName("Origen").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.Origen1).HasColumnName("Origen1").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.Origen2).HasColumnName("Origen2").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.Origen3).HasColumnName("Origen3").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.Destino).HasColumnName("Destino").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.Destino1).HasColumnName("Destino1").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.Destino2).HasColumnName("Destino2").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.Destino3).HasColumnName("Destino3").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.RutaPrincipal).HasColumnName("RutaPrincipal").IsUnicode(false);
        builder.Property(e => e.RutaAlterna).HasColumnName("RutaAlterna").IsUnicode(false);
        builder.Property(e => e.RutaNoAutorizada).HasColumnName("RutaNoAutorizada").IsUnicode(false);
        builder.Property(e => e.Camino).HasColumnName("Camino").IsUnicode(false);
    }
}

public class OperacionGeneralConfiguration : IEntityTypeConfiguration<OperacionGeneral>
{
    public void Configure(EntityTypeBuilder<OperacionGeneral> builder)
    {
        builder.HasKey(e => e.IdOperacionGeneral);
        builder.ToTable("OPERACION_GENERAL");
        builder.Property(e => e.IdOperacionGeneral).HasColumnName("Id_OperacionGeneral").ValueGeneratedOnAdd();
        builder.Property(e => e.IdOperacion).HasColumnName("Id_Operacion");
        builder.Property(e => e.IdTipoCarga).HasColumnName("Id_TipoCarga");
        builder.Property(e => e.IdTipoOperacion).HasColumnName("Id_TipoOperacion");
        builder.Property(e => e.FechaInicioPlanOp).HasColumnName("FechaInicio_Plan_OP").HasColumnType("datetime");
        builder.Property(e => e.HoraInicioPlanOp).HasColumnName("HoraInicio_Plan_OP").HasMaxLength(5).IsUnicode(false);
        builder.Property(e => e.NroConvoy).HasColumnName("NroConvoy");
        builder.Property(e => e.Observaciones).HasColumnName("Observaciones").IsUnicode(false);
        builder.Property(e => e.IdLiquidacionContratistaDescuento).HasColumnName("Id_LiquidacionContratistaDescuento");
        builder.Property(e => e.ValidadoGps).HasColumnName("ValidadoGPS");
        builder.Property(e => e.NoAtendido).HasColumnName("NoAtendido");
        builder.Property(e => e.TurnoRansa).HasColumnName("TurnoRansa");
        builder.Property(e => e.EnviarCorreo).HasColumnName("EnviarCorreo");
        builder.Property(e => e.Estado).HasColumnName("Estado").HasMaxLength(2).IsUnicode(false);
        builder.Property(e => e.Usuario).HasColumnName("Usuario").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.UserOrica).HasColumnName("User_Orica").HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.OCOrica).HasColumnName("OC_Orica").HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.Estatus).HasColumnName("Estatus").HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.Turno).HasColumnName("Turno").HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.TurnoVerif).HasColumnName("Turno_Verif").HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.FechaCarga).HasColumnName("FechaCarga").HasColumnType("datetime");
        builder.Property(e => e.FechaGr).HasColumnName("FechaGR").HasColumnType("datetime");
        builder.Property(e => e.HoraGr).HasColumnName("HoraGR").HasColumnType("datetime");
        builder.Property(e => e.DetalleMercaderia).HasColumnName("DetalleMercaderia").HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.Contenedor).HasColumnName("Contenedor").HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.Proveedor).HasColumnName("Proveedor").HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.PuntoCarga).HasColumnName("PuntoCarga").HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.IdPuntoCarga).HasColumnName("IdPuntoCarga");
        builder.Property(e => e.DemoraSobrestadia).HasColumnName("DemoraSobrestadia").HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.HoraCita).HasColumnName("HoraCita").HasMaxLength(5).IsUnicode(false);
        builder.Property(e => e.HoraLlegada).HasColumnName("HoraLlegada").HasMaxLength(5).IsUnicode(false);
        builder.Property(e => e.HoraInicioCarguio).HasColumnName("HoraInicioCarguio").HasMaxLength(5).IsUnicode(false);
        builder.Property(e => e.HoraFinCarguio).HasColumnName("HoraFinCarguio").HasMaxLength(5).IsUnicode(false);
        builder.Property(e => e.HoraAStandBy).HasColumnName("HoraAStandBy").HasMaxLength(5).IsUnicode(false);
        builder.Property(e => e.HorasStandBy).HasColumnName("HorasStandBy").HasMaxLength(5).IsUnicode(false);
        builder.Property(e => e.GRTransportista).HasColumnName("GR_Transportista").HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.FechaHoraSalida).HasColumnName("FechaHoraSalida").HasColumnType("datetime");
        builder.Property(e => e.GRRemitente).HasColumnName("GR_Remitente").HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.Peso).HasColumnName("Peso");
        builder.Property(e => e.IdUnidadPeso).HasColumnName("IdUnidadPeso");
        builder.Property(e => e.GRMultitrac).HasColumnName("GR_Multitrac").HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.Gestor).HasColumnName("Gestor").HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.PrimerPuntoPernocte).HasColumnName("PrimerPuntoPernocte").HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.IdPrimerPuntoPernocte).HasColumnName("IdPrimerPuntoPernocte");
        builder.Property(e => e.PuntoDescarga).HasColumnName("PuntoDescarga").HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.IdPuntoDescarga).HasColumnName("IdPuntoDescarga");
        builder.Property(e => e.UbActual).HasColumnName("UbActual").HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.IdUbActual).HasColumnName("IdUbActual");
        builder.Property(e => e.TipoUnidad).HasColumnName("TipoUnidad").HasMaxLength(250);
        builder.Property(e => e.IdTipoServicio).HasColumnName("IdTipoServicio");
        builder.Property(e => e.IdClientePrincipal).HasColumnName("IdClientePrincipal");
    }
}

public class OperacionGeneralEquipoConfiguration : IEntityTypeConfiguration<OperacionGeneralEquipo>
{
    public void Configure(EntityTypeBuilder<OperacionGeneralEquipo> builder)
    {
        builder.HasKey(e => e.IdOperacionGeneralEquipo);
        builder.ToTable("OPERACION_GENERAL_EQUIPO");
        builder.Property(e => e.IdOperacionGeneralEquipo).HasColumnName("Id_OperacionGeneralEquipo").ValueGeneratedOnAdd();
        builder.Property(e => e.IdOperacionGeneral).HasColumnName("Id_OperacionGeneral");
        builder.Property(e => e.CodEquipoTracto).HasColumnName("Cod_Equipo_Tracto").HasMaxLength(12).IsUnicode(false);
        builder.Property(e => e.CodEquipoCarreta).HasColumnName("Cod_Equipo_Carreta").HasMaxLength(12).IsUnicode(false);
        builder.Property(e => e.CarretaTercero).HasColumnName("Carreta_Tercero");
        builder.Property(e => e.IdPersonal).HasColumnName("Id_Personal");
        builder.Property(e => e.KmUltimo).HasColumnName("Km_Ultimo");
        builder.Property(e => e.KmSalida).HasColumnName("Km_Salida");
        builder.Property(e => e.KmFinal).HasColumnName("Km_Final");
        builder.Property(e => e.Carga).HasColumnName("Carga").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.Tipo).HasColumnName("Tipo").HasMaxLength(1).IsUnicode(false);
        builder.Property(e => e.Observaciones).HasColumnName("Observaciones").HasMaxLength(30).IsUnicode(false);
        builder.Property(e => e.HoraCheckListMantto).HasColumnName("HoraCheckListMantto").HasMaxLength(5).IsUnicode(false);
        builder.Property(e => e.ObsCheckListMantto).HasColumnName("ObsCheckListMantto").IsUnicode(false);
        builder.Property(e => e.HoraCheckListPdP).HasColumnName("HoraCheckListPdP").HasMaxLength(5).IsUnicode(false);
        builder.Property(e => e.ObsCheckListPdP).HasColumnName("ObsCheckListPdP").IsUnicode(false);
        builder.Property(e => e.IdOperacionGeneralEstado).HasColumnName("Id_OperacionGeneralEstado");
        builder.Property(e => e.OperacionInformeMantto).HasColumnName("OperacionInformeMantto").HasColumnType("text");
        builder.Property(e => e.OperacionInformePdP).HasColumnName("OperacionInformePdP").HasColumnType("text");
    }
}

public class OperacionFleteConfiguration : IEntityTypeConfiguration<OperacionFlete>
{
    public void Configure(EntityTypeBuilder<OperacionFlete> builder)
    {
        builder.HasKey(e => e.IdOperacionFlete);
        builder.ToTable("OPERACION_FLETE");
        builder.Property(e => e.IdOperacionFlete).HasColumnName("Id_Operacion_Flete").ValueGeneratedOnAdd();
        builder.Property(e => e.IdOperacion).HasColumnName("Id_Operacion");
        builder.Property(e => e.IdTipoCarga).HasColumnName("Id_TipoCarga");
        builder.Property(e => e.IdMoneda).HasColumnName("Id_Moneda");
        builder.Property(e => e.IdUnidad).HasColumnName("Id_Unidad");
        builder.Property(e => e.IdIgv).HasColumnName("Id_IGV");
        builder.Property(e => e.IdOperacionTipo).HasColumnName("Id_OperacionTipo");
        builder.Property(e => e.ConfVeTracto).HasColumnName("Conf_Ve_Tracto").HasMaxLength(5).IsUnicode(false);
        builder.Property(e => e.ConfVeCarreta).HasColumnName("Conf_Ve_Carreta").HasMaxLength(5).IsUnicode(false);
        builder.Property(e => e.PorcFlete).HasColumnName("Porc_Flete");
        builder.Property(e => e.ValorVentaFlete).HasColumnName("ValorVenta_Flete");
        builder.Property(e => e.ValorReferencial).HasColumnName("ValorReferencial");
        builder.Property(e => e.PesoPromedioTn).HasColumnName("PesoPromedioTN");
        builder.Property(e => e.ComisionMultitrac).HasColumnName("ComisionMultitrac");
        builder.Property(e => e.IdUnidadComisionMultitrac).HasColumnName("IdUnidadComisionMultitrac");
        builder.Property(e => e.ComisionTerceros).HasColumnName("ComisionTerceros");
        builder.Property(e => e.IdUnidadComisionTerceros).HasColumnName("IdUnidadComisionTerceros");
        builder.Property(e => e.CalculoComision).HasColumnName("CalculoComision");
        builder.Property(e => e.IdUnidadCalculoComsion).HasColumnName("IdUnidadCalculoComsion");
        builder.Property(e => e.CalculoComisionTerceros).HasColumnName("CalculoComisionTerceros");
        builder.Property(e => e.IdUnidadCalculoComisionTerceros).HasColumnName("IdUnidadCalculoComisionTerceros");
        builder.Property(e => e.CalculoLiquidez).HasColumnName("CalculoLiquidez");
        builder.Property(e => e.IdUnidadCalculoLiquidez).HasColumnName("IdUnidadCalculoLiquidez");
        builder.Property(e => e.FechaInicio).HasColumnName("Fecha_Inicio").HasColumnType("datetime");
        builder.Property(e => e.FechaFin).HasColumnName("Fecha_Fin").HasColumnType("datetime");
        builder.Property(e => e.Estado).HasColumnName("Estado").HasMaxLength(1).IsUnicode(false);
    }
}

public class OperacionInformeConfiguration : IEntityTypeConfiguration<OperacionInforme>
{
    public void Configure(EntityTypeBuilder<OperacionInforme> builder)
    {
        builder.HasKey(e => e.IdOperacionInforme);
        builder.ToTable("OPERACION_INFORME");
        builder.Property(e => e.IdOperacionInforme).HasColumnName("Id_OperacionInforme").ValueGeneratedOnAdd();
        builder.Property(e => e.IdOperacionGeneral).HasColumnName("Id_OperacionGeneral");
        builder.Property(e => e.Convoy).HasColumnName("Convoy");
        builder.Property(e => e.FechaInforme).HasColumnName("FechaInforme").HasColumnType("datetime");
        builder.Property(e => e.FechaSalida).HasColumnName("FechaSalida").HasColumnType("datetime");
        builder.Property(e => e.HoraSalida).HasColumnName("HoraSalida").HasMaxLength(5).IsUnicode(false);
        builder.Property(e => e.FechaLlegada).HasColumnName("FechaLlegada").HasColumnType("datetime");
        builder.Property(e => e.HoraLlegada).HasColumnName("HoraLlegada").HasMaxLength(5).IsUnicode(false);
        builder.Property(e => e.Informe).HasColumnName("Informe").HasColumnType("text");
        builder.Property(e => e.InformeMantto).HasColumnName("InformeMantto").HasColumnType("text");
        builder.Property(e => e.Evento).HasColumnName("Evento");
        builder.Property(e => e.IdClasificacionIncident).HasColumnName("IdClasificacionIncident");
        builder.Property(e => e.DescripcionIncident).HasColumnName("DescripcionIncident").HasColumnType("text");
        builder.Property(e => e.IdConsecuencia).HasColumnName("IdConsecuencia");
        builder.Property(e => e.RequiereInvestigacion).HasColumnName("RequiereInvestigacion");
        builder.Property(e => e.DescripcionReqInv).HasColumnName("DescripcionReqInv").HasColumnType("text");
    }
}

public class OperacionHorarioConfiguration : IEntityTypeConfiguration<OperacionHorario>
{
    public void Configure(EntityTypeBuilder<OperacionHorario> builder)
    {
        builder.HasKey(e => e.IdHorarioOperacion);
        builder.ToTable("OPERACION_HORARIO");
        builder.Property(e => e.IdHorarioOperacion).HasColumnName("Id_HorarioOperacion").ValueGeneratedOnAdd();
        builder.Property(e => e.IdOperacion).HasColumnName("Id_Operacion");
        builder.Property(e => e.HoraInicio).HasColumnName("Hora_Inicio").HasMaxLength(5).IsUnicode(false);
        builder.Property(e => e.HoraFin).HasColumnName("Hora_Fin").HasMaxLength(5).IsUnicode(false);
        builder.Property(e => e.FechaInicio).HasColumnName("Fecha_Inicio").HasColumnType("datetime");
        builder.Property(e => e.FechaFin).HasColumnName("Fecha_Fin").HasColumnType("datetime");
        builder.Property(e => e.Estado).HasColumnName("Estado").HasMaxLength(1).IsUnicode(false);
        builder.Property(e => e.IdUbicacionOp).HasColumnName("Id_UbicacionOP");
        builder.Property(e => e.Tipo).HasColumnName("Tipo");
    }
}

public class OperacionTurnoConfiguration : IEntityTypeConfiguration<OperacionTurno>
{
    public void Configure(EntityTypeBuilder<OperacionTurno> builder)
    {
        builder.HasKey(e => e.IdOperacionTurno);
        builder.ToTable("OPERACION_TURNO");
        builder.Property(e => e.IdOperacionTurno).HasColumnName("Id_OperacionTurno").ValueGeneratedOnAdd();
        builder.Property(e => e.IdPersonalRegistro).HasColumnName("Id_PersonalRegistro");
        builder.Property(e => e.IdTurno).HasColumnName("Id_Turno");
        builder.Property(e => e.IdOperacion).HasColumnName("Id_Operacion");
        builder.Property(e => e.Turno).HasColumnName("Turno").HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.FechaRegistro).HasColumnName("FechaRegistro").HasColumnType("datetime");
        builder.Property(e => e.Observacion).HasColumnName("Observacion").IsUnicode(false);
    }
}

public class OperacionCargaConfiguration : IEntityTypeConfiguration<OperacionCarga>
{
    public void Configure(EntityTypeBuilder<OperacionCarga> builder)
    {
        builder.HasKey(e => e.IdOperacionCarga);
        builder.ToTable("OPERACION_CARGA");
        builder.Property(e => e.IdOperacionCarga).HasColumnName("Id_Operacion_Carga").ValueGeneratedOnAdd();
        builder.Property(e => e.IdOperacion).HasColumnName("Id_Operacion");
        builder.Property(e => e.IdTipoCarga).HasColumnName("Id_TipoCarga");
        builder.Property(e => e.Estado).HasColumnName("Estado").HasMaxLength(1).IsUnicode(false);
    }
}

public class OperacionTipoConfiguration : IEntityTypeConfiguration<OperacionTipo>
{
    public void Configure(EntityTypeBuilder<OperacionTipo> builder)
    {
        builder.HasKey(e => e.IdOperacionTipo);
        builder.ToTable("OPERACION_TIPO");
        builder.Property(e => e.IdOperacionTipo).ValueGeneratedOnAdd();
        builder.Property(e => e.OperacionTipoNombre).HasColumnName("OperacionTipo").HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.ObservacionTipo).HasColumnName("ObservacionTipo").HasMaxLength(250).IsUnicode(false);
    }
}

public class TipoCargaConfiguration : IEntityTypeConfiguration<TipoCarga>
{
    public void Configure(EntityTypeBuilder<TipoCarga> builder)
    {
        builder.HasKey(e => e.IdTipoCarga);
        builder.ToTable("TIPO_CARGA");
        builder.Property(e => e.IdTipoCarga).HasColumnName("Id_TipoCarga").ValueGeneratedOnAdd();
        builder.Property(e => e.NombreTipoCarga).HasColumnName("Nombre_TipoCarga").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.DescripcionTipoCarga).HasColumnName("Descripcion_TipoCarga").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.NomInsumoQuimicoFiscalizado).HasColumnName("Nom_InsumoQuimicoFiscalizado").HasMaxLength(150).IsUnicode(false);
        builder.Property(e => e.NomInsumoComercial).HasColumnName("Nom_InsumoComercial").HasMaxLength(150).IsUnicode(false);
        builder.Property(e => e.ProveedorCertificado).HasColumnName("ProveedorCertificado").HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.ProveedorDireccionEmbarque).HasColumnName("ProveedorDireccionEmbarque").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.PropietarioCertificado).HasColumnName("PropietarioCertificado").HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.PropietarioDireccionEntrega).HasColumnName("PropietarioDireccionEntrega").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.IdTipoProducto).HasColumnName("Id_TipoProducto");
        builder.Property(e => e.CodigoSunat).HasColumnName("CodigoSunat").HasMaxLength(20).IsUnicode(false);
    }
}

public class UnidadConfiguration : IEntityTypeConfiguration<Unidad>
{
    public void Configure(EntityTypeBuilder<Unidad> builder)
    {
        builder.HasKey(e => e.IdUnidad);
        builder.ToTable("UNIDAD");
        builder.Property(e => e.IdUnidad).HasColumnName("Id_Unidad").ValueGeneratedNever();
        builder.Property(e => e.AbreviaturaUnidad).HasColumnName("Abreviatura_Unidad").HasMaxLength(10).IsUnicode(false);
        builder.Property(e => e.NombreUnidad).HasColumnName("Nombre_Unidad").HasMaxLength(250).IsUnicode(false);
    }
}

public class ConvoyConfiguration : IEntityTypeConfiguration<Convoy>
{
    public void Configure(EntityTypeBuilder<Convoy> builder)
    {
        builder.HasKey(e => e.IdConvoy);
        builder.ToTable("CONVOY");
        builder.Property(e => e.IdConvoy).ValueGeneratedOnAdd();
        builder.Property(e => e.IdOperacion).HasColumnName("Id_Operacion");
        builder.Property(e => e.IdCargo).HasColumnName("IdCargo");
        builder.Property(e => e.NroPersonal).HasColumnName("NroPersonal");
        builder.Property(e => e.NroUnidades).HasColumnName("NroUnidades");
        builder.Property(e => e.NroConvoys).HasColumnName("NroConvoys");
    }
}

public class ContratistaConfiguration : IEntityTypeConfiguration<Contratista>
{
    public void Configure(EntityTypeBuilder<Contratista> builder)
    {
        builder.HasKey(e => e.IdContratista);
        builder.ToTable("CONTRATISTA");
        builder.Property(e => e.IdContratista).HasColumnName("Id_Contratista").ValueGeneratedNever();
        builder.Property(e => e.NomContratista).HasColumnName("Nom_Contratista").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.APContratista).HasColumnName("AP_Contratista").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.AMContratista).HasColumnName("AM_Contratista").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.RazonSocialContratista).HasColumnName("RazonSocial_Contratista").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.Socio).HasColumnName("Socio").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.RUCContratista).HasColumnName("RUC_Contratista");
        builder.Property(e => e.NomRepLegalContratista).HasColumnName("Nom_RepLegal_Contartista").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.APRepLegalContratista).HasColumnName("AP_RepLegal_Contartista").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.AMRepLegalContratista).HasColumnName("AM_RepLegal_Contartista").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.TlfRepLegalContratista).HasColumnName("Tlf_RepLegal_Contartista");
        builder.Property(e => e.RPCRepLegalContratista).HasColumnName("RPC_RepLegal_Contartista");
        builder.Property(e => e.RPMRepLegalContratista).HasColumnName("RPM_RepLegal_Contartista").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.CelRepLegalContratista).HasColumnName("Cel_RepLegal_Contartista");
        builder.Property(e => e.FechNacRepLegalContratista).HasColumnName("FechNac_RepLegal_Contartista").HasColumnType("datetime");
        builder.Property(e => e.EmailRepLegalContratista).HasColumnName("Email_RepLegal_Contartista").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.DireccionRepLegalContratista).HasColumnName("Direccion_RepLegal_Contratista").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.Combustible).HasColumnName("Combustible");
        builder.Property(e => e.NombreProveedorDetraccion).HasColumnName("NombreProveedorDetraccion").HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.IdContratistaTipo).HasColumnName("Id_ContratistaTipo");
        builder.Property(e => e.AlertaDocumentos).HasColumnName("AlertaDocumentos");
        builder.Property(e => e.AlertaRendimiento).HasColumnName("AlertaRendimiento");
        builder.Property(e => e.OperacionObservacion).HasColumnName("OperacionObservaci\u00f3n");
        builder.Property(e => e.ReporteOperaciones).HasColumnName("ReporteOperaciones");
        builder.Property(e => e.DescuentoMantto).HasColumnName("DescuentoMantto");
        builder.Property(e => e.DescuentoManttoSup).HasColumnName("DescuentoManttoSup");
        builder.Property(e => e.PRDCod).HasColumnName("PRD_COD");
    }
}
