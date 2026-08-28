using Microsoft.EntityFrameworkCore;
using Multitrac.Domain.Entities;

namespace Multitrac.Infrastructure.Data;

public class BdmultitracContext : DbContext
{
    public BdmultitracContext(DbContextOptions<BdmultitracContext> options)
        : base(options)
    {
    }

    // Catálogos simples
    public virtual DbSet<Moneda> Monedas { get; set; } = null!;
    public virtual DbSet<Banco> Bancos { get; set; } = null!;
    public virtual DbSet<Cargo> Cargos { get; set; } = null!;
    public virtual DbSet<NivelEducativo> NivelesEducativos { get; set; } = null!;
    public virtual DbSet<Afp> Afps { get; set; } = null!;
    public virtual DbSet<Flota> Flotas { get; set; } = null!;
    public virtual DbSet<Actividad> Actividades { get; set; } = null!;
    public virtual DbSet<Turno> Turnos { get; set; } = null!;
    public virtual DbSet<TipoPago> TipoPagos { get; set; } = null!;
    public virtual DbSet<TipoOcurrencia> TipoOcurrencias { get; set; } = null!;

    // Operaciones
    public virtual DbSet<Operacion> Operaciones { get; set; } = null!;
    public virtual DbSet<OperacionGeneral> OperacionesGenerales { get; set; } = null!;
    public virtual DbSet<OperacionGeneralEquipo> OperacionesGeneralesEquipos { get; set; } = null!;
    public virtual DbSet<OperacionFlete> OperacionesFletes { get; set; } = null!;
    public virtual DbSet<OperacionInforme> OperacionesInformes { get; set; } = null!;
    public virtual DbSet<OperacionHorario> OperacionesHorarios { get; set; } = null!;
    public virtual DbSet<OperacionTurno> OperacionesTurnos { get; set; } = null!;
    public virtual DbSet<OperacionCarga> OperacionesCargas { get; set; } = null!;
    public virtual DbSet<OperacionTipo> OperacionesTipos { get; set; } = null!;
    public virtual DbSet<TipoCarga> TiposCarga { get; set; } = null!;
    public virtual DbSet<Unidad> Unidades { get; set; } = null!;
    public virtual DbSet<Convoy> Convoys { get; set; } = null!;

    // Personal
    public virtual DbSet<Personal> Personals { get; set; } = null!;
    public virtual DbSet<PersonalDocumento> PersonalDocumentos { get; set; } = null!;
    public virtual DbSet<PersonalCargo> PersonalCargos { get; set; } = null!;
    public virtual DbSet<PersonalEquipo> PersonalEquipos { get; set; } = null!;
    public virtual DbSet<PersonalEpp> PersonalEpps { get; set; } = null!;
    public virtual DbSet<PersonalEppKardex> PersonalEppKardexes { get; set; } = null!;
    public virtual DbSet<PersonalRecord> PersonalRecords { get; set; } = null!;
    public virtual DbSet<PersonalVacaciones> PersonalVacaciones { get; set; } = null!;
    public virtual DbSet<PersonalVacacionesRegistro> PersonalVacacionesRegistros { get; set; } = null!;
    public virtual DbSet<PersonalLicenciaConducir> PersonalLicenciasConducir { get; set; } = null!;
    public virtual DbSet<PersonalSueno> PersonalSuenos { get; set; } = null!;

    // Equipos
    public virtual DbSet<Equipo> Equipos { get; set; } = null!;
    public virtual DbSet<EquipoDocumentoTracto> EquipoDocumentoTractos { get; set; } = null!;
    public virtual DbSet<EquipoDocumentoCarreta> EquipoDocumentoCarretas { get; set; } = null!;
    public virtual DbSet<EquipoCombustible> EquipoCombustibles { get; set; } = null!;
    public virtual DbSet<EquipoKilometraje> EquipoKilometrajes { get; set; } = null!;
    public virtual DbSet<EquipoMantenimiento> EquipoMantenimientos { get; set; } = null!;
    public virtual DbSet<EquipoMantenimientoDetalle> EquipoMantenimientoDetalles { get; set; } = null!;

    // Contratistas
    public virtual DbSet<Contratista> Contratistas { get; set; } = null!;

    // Cliente/Proveedor/Area/Empresa
    public virtual DbSet<Cliente> Clientes { get; set; } = null!;
    public virtual DbSet<Proveedor> Proveedores { get; set; } = null!;
    public virtual DbSet<Area> Areas { get; set; } = null!;
    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; } = null!;
    public virtual DbSet<Empresa> Empresas { get; set; } = null!;

    // Auth
    public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BdmultitracContext).Assembly);
    }
}
