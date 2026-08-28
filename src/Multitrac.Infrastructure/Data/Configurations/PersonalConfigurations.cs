using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Multitrac.Domain.Entities;

namespace Multitrac.Infrastructure.Data.Configurations;

public class PersonalConfiguration : IEntityTypeConfiguration<Personal>
{
    public void Configure(EntityTypeBuilder<Personal> builder)
    {
        builder.HasKey(e => e.IdPersonal);
        builder.ToTable("PERSONAL", t => t.UseSqlOutputClause(false));
        builder.Property(e => e.IdPersonal).HasColumnName("Id_Personal").ValueGeneratedOnAdd();
        builder.Property(e => e.EmpCod).HasColumnName("EMP_COD");
        builder.Property(e => e.IdContratista).HasColumnName("Id_Contratista");
        builder.Property(e => e.IdNivelEducativo).HasColumnName("Id_NivelEducativo");
        builder.Property(e => e.FotPersonal).HasColumnName("Fot_Personal").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.DniPersonal).HasColumnName("DNI_Personal").HasMaxLength(8).IsUnicode(false);
        builder.Property(e => e.ApPersonal).HasColumnName("AP_Personal").HasMaxLength(200).IsUnicode(false);
        builder.Property(e => e.AmPersonal).HasColumnName("AM_Personal").HasMaxLength(200).IsUnicode(false);
        builder.Property(e => e.NomPersonal).HasColumnName("Nom_Personal").HasMaxLength(200).IsUnicode(false);
        builder.Property(e => e.LicPersonal).HasColumnName("Lic_Personal").HasMaxLength(10).IsUnicode(false);
        builder.Property(e => e.IdLicPersonal).HasColumnName("Id_Lic_Personal");
        builder.Property(e => e.TlfPesronal).HasColumnName("Tlf_Pesronal").HasMaxLength(10).IsUnicode(false);
        builder.Property(e => e.RpcPersonal).HasColumnName("RPC_Personal").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.RpmPersonal).HasColumnName("RPM_Personal").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.CelPersonal).HasColumnName("Cel_Personal").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.FechNacPersonal).HasColumnName("FechNac_Personal").HasColumnType("datetime");
        builder.Property(e => e.SexoPersonal).HasColumnName("Sexo_Personal").HasMaxLength(1).IsUnicode(false);
        builder.Property(e => e.EmailPersonal).HasColumnName("Email_Personal").HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.FotoPersonal).HasColumnName("Foto_Personal").IsUnicode(false);
        builder.Property(e => e.EstadoCivilPersonal).HasColumnName("EstadoCivil_Personal").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.PasaportePersonal).HasColumnName("Pasaporte_Personal").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.FechaAdmitidoPersonal).HasColumnName("FechaAdmitido_Personal").HasColumnType("datetime");
        builder.Property(e => e.FechaBajaPersonal).HasColumnName("FechaBaja_Personal").HasColumnType("datetime");
        builder.Property(e => e.SueldoBrutoPersonal).HasColumnName("SueldoBruto_Personal").HasColumnType("decimal(9, 2)");
        builder.Property(e => e.Sctr).HasColumnName("SCTR").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.UsuarioPersonal).HasColumnName("Usuario_Personal").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Cussp).HasColumnName("CUSSP").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.AfpPersonal).HasColumnName("AFP_Personal");
        builder.Property(e => e.FechaIngresoAfp).HasColumnName("FechaIngresoAFP").HasColumnType("datetime");
        builder.Property(e => e.EsaludAutoGenerado).HasColumnName("ESALUD_AutoGenerado").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.LugarResidenciaPersonal).HasColumnName("LugarResidencia_Personal").HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.LugarNacimientoPersonal).HasColumnName("LugarNacimiento_Personal").HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.DireccionPersonal).HasColumnName("Direccion_Personal").HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.StatusOp).HasColumnName("StatusOP");
        builder.Property(e => e.Firma).HasColumnName("Firma").HasMaxLength(500).IsUnicode(false);
    }
}

public class PersonalDocumentoConfiguration : IEntityTypeConfiguration<PersonalDocumento>
{
    public void Configure(EntityTypeBuilder<PersonalDocumento> builder)
    {
        builder.HasKey(e => e.IdPersonalDocumento);
        builder.ToTable("PERSONAL_DOCUMENTO");
        builder.Property(e => e.IdPersonalDocumento).ValueGeneratedNever();
        builder.Property(e => e.NroDocumento).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Observaciones).HasMaxLength(250).IsUnicode(false);
    }
}

public class PersonalCargoConfiguration : IEntityTypeConfiguration<PersonalCargo>
{
    public void Configure(EntityTypeBuilder<PersonalCargo> builder)
    {
        builder.HasKey(e => e.IdPersonalCargo);
        builder.ToTable("PERSONAL_CARGO", t => t.UseSqlOutputClause(false));
        builder.Property(e => e.IdPersonalCargo).HasColumnName("Id_PersonalCargo").ValueGeneratedOnAdd();
        builder.Property(e => e.IdPersonal).HasColumnName("Id_Personal");
        builder.Property(e => e.IdCargo).HasColumnName("Id_Cargo");
        builder.Property(e => e.FechaInicioCargo).HasColumnName("FechaIncio_Cargo").HasColumnType("datetime");
        builder.Property(e => e.FechaFinCargo).HasColumnName("FechaFin_Cargo").HasColumnType("datetime");
        builder.Property(e => e.Estado).HasColumnName("Estado").HasMaxLength(1).IsUnicode(false);
    }
}

public class PersonalEquipoConfiguration : IEntityTypeConfiguration<PersonalEquipo>
{
    public void Configure(EntityTypeBuilder<PersonalEquipo> builder)
    {
        builder.HasKey(e => e.IdPersonalEquipo);
        builder.ToTable("PERSONAL_EQUIPO");
        builder.Property(e => e.IdPersonalEquipo).ValueGeneratedOnAdd();
        builder.Property(e => e.CodEquipo).HasMaxLength(12).IsUnicode(false);
        builder.Property(e => e.FechIni).HasColumnName("Fech_Ini").HasColumnType("datetime");
        builder.Property(e => e.FechFin).HasColumnName("Fech_Fin").HasColumnType("datetime");
        builder.Property(e => e.IdRemplazo).HasColumnName("Id_Remplazo");
        builder.Property(e => e.Estado).HasMaxLength(1).IsUnicode(false);
    }
}

public class PersonalEppConfiguration : IEntityTypeConfiguration<PersonalEpp>
{
    public void Configure(EntityTypeBuilder<PersonalEpp> builder)
    {
        builder.HasKey(e => e.IdPersonalEpp);
        builder.ToTable("PERSONAL_EPP");
        builder.Property(e => e.IdPersonalEpp).HasColumnName("Id_Pesonal_EPP").ValueGeneratedOnAdd();
        builder.Property(e => e.Talla).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Observacion).HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.Estado).HasMaxLength(1).IsUnicode(false);
    }
}

public class PersonalEppKardexConfiguration : IEntityTypeConfiguration<PersonalEppKardex>
{
    public void Configure(EntityTypeBuilder<PersonalEppKardex> builder)
    {
        builder.HasKey(e => e.IdPersonalEppKardex);
        builder.ToTable("PERSONAL_EPP_KARDEX");
        builder.Property(e => e.IdPersonalEppKardex).HasColumnName("Id_PeronalEPP_Kardex").ValueGeneratedOnAdd();
        builder.Property(e => e.IdPersonalEpp).HasColumnName("Id_Pesonal_EPP");
        builder.Property(e => e.Estado).HasMaxLength(1).IsUnicode(false);
    }
}

public class PersonalRecordConfiguration : IEntityTypeConfiguration<PersonalRecord>
{
    public void Configure(EntityTypeBuilder<PersonalRecord> builder)
    {
        builder.HasKey(e => e.IdPersonalRecord);
        builder.ToTable("PERSONAL_RECORD");
        builder.Property(e => e.IdPersonalRecord).ValueGeneratedOnAdd();
        builder.Property(e => e.DescripcionOcurrencia).IsUnicode(false);
        builder.Property(e => e.MedidasAImplementar).IsUnicode(false);
    }
}

public class PersonalVacacionesConfiguration : IEntityTypeConfiguration<PersonalVacaciones>
{
    public void Configure(EntityTypeBuilder<PersonalVacaciones> builder)
    {
        builder.HasKey(e => e.IdPersonalVacaciones);
        builder.ToTable("PERSONAL_VACACIONES");
        builder.Property(e => e.IdPersonalVacaciones).ValueGeneratedNever();
        builder.Property(e => e.Observaciones).HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.Estado).HasMaxLength(1).IsUnicode(false);
    }
}

public class PersonalVacacionesRegistroConfiguration : IEntityTypeConfiguration<PersonalVacacionesRegistro>
{
    public void Configure(EntityTypeBuilder<PersonalVacacionesRegistro> builder)
    {
        builder.HasKey(e => e.IdPersonalVacacionesReg);
        builder.ToTable("PERSONAL_VACACIONES_REGISTRO");
        builder.Property(e => e.IdPersonalVacacionesReg).ValueGeneratedNever();
        builder.Property(e => e.Memo).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Observaciones).HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.Archivo).HasMaxLength(500).IsUnicode(false);
    }
}

public class PersonalLicenciaConducirConfiguration : IEntityTypeConfiguration<PersonalLicenciaConducir>
{
    public void Configure(EntityTypeBuilder<PersonalLicenciaConducir> builder)
    {
        builder.HasKey(e => e.IdLicPersonal);
        builder.ToTable("PERSONAL_LICENCIA_CONDUCIR");
        builder.Property(e => e.IdLicPersonal).ValueGeneratedNever();
        builder.Property(e => e.NombreLicPersonal).HasMaxLength(250).IsUnicode(false);
        builder.Property(e => e.Observaciones).HasMaxLength(250).IsUnicode(false);
    }
}

public class PersonalSuenoConfiguration : IEntityTypeConfiguration<PersonalSueno>
{
    public void Configure(EntityTypeBuilder<PersonalSueno> builder)
    {
        builder.HasKey(e => e.IdSueno);
        builder.ToTable("PERSONAL_SUEÑO");
        builder.Property(e => e.IdSueno).ValueGeneratedNever();
        builder.Property(e => e.Sueno).HasColumnName("Sueñoo").HasMaxLength(5).IsUnicode(false);
        builder.Property(e => e.Foto).HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.Observaciones).HasMaxLength(500).IsUnicode(false);
    }
}
