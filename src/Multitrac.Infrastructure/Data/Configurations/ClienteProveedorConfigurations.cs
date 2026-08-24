using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Multitrac.Domain.Entities;

namespace Multitrac.Infrastructure.Data.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(e => e.IdCliente);
        builder.ToTable("CLIENTE");
        builder.Property(e => e.IdCliente).HasColumnName("Id_Cliente").ValueGeneratedNever();
        builder.Property(e => e.RazonSocialCliente).HasColumnName("RazonSocial_Cliente").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.ClienteNombre).HasColumnName("Cliente").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.RucCliente).HasColumnName("RUC_Cliente").HasMaxLength(11).IsUnicode(false);
        builder.Property(e => e.DomicilioFiscalCliente).HasColumnName("DomicilioFiscal_Cliente").HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.TlfCliente).HasColumnName("Tlf_Cliente").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.RpcCliente).HasColumnName("RPC_Cliente");
        builder.Property(e => e.RpmCliente).HasColumnName("RPM_Cliente").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.EmailCliente).HasColumnName("Email_Cliente").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.WebSiteCliente).HasColumnName("WebSite_Cliente").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.DiasDemoraPagoCliente).HasColumnName("DiasDemoraPago_Cliente");
        builder.Property(e => e.FacturacionMultiple).HasColumnName("FacturacionMultiple");
    }
}

public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.HasKey(e => e.PrvCod);
        builder.ToTable("PROVEEDOR");
        builder.Property(e => e.PrvCod).HasColumnName("PRV_COD").ValueGeneratedNever();
        builder.Property(e => e.PrvNom).HasColumnName("PRV_NOM").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.PrvRuc).HasColumnName("PRV_RUC").HasMaxLength(11).IsUnicode(false);
        builder.Property(e => e.CodUbi).HasColumnName("COD_UBI").HasMaxLength(6).IsUnicode(false);
        builder.Property(e => e.PrvDir).HasColumnName("PRV_DIR").HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.PrvRep).HasColumnName("PRV_REP").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.PrvTel).HasColumnName("PRV_TEL").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.PrvFax).HasColumnName("PRV_FAX").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.PrvCrr).HasColumnName("PRV_CRR").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.PrvWeb).HasColumnName("PRV_WEB").HasMaxLength(300).IsUnicode(false);
        builder.Property(e => e.PrvFecAlt).HasColumnName("PRV_FEC_ALT").HasColumnType("datetime");
        builder.Property(e => e.PrvFecBaj).HasColumnName("PRV_FEC_BAJ").HasColumnType("datetime");
        builder.Property(e => e.PrvObs).HasColumnName("PRV_OBS").HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.IdBanco).HasColumnName("IdBanco");
        builder.Property(e => e.NroCuenta).HasColumnName("NRO_CUENTA").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.IdBancoDolares).HasColumnName("IdBancoDolares");
        builder.Property(e => e.NroCuentaDolares).HasColumnName("NRO_CUENTA_DOLARES").HasMaxLength(50).IsUnicode(false);
    }
}

public class AreaConfiguration : IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        builder.HasKey(e => e.AreCod);
        builder.ToTable("AREA");
        builder.Property(e => e.AreCod).HasColumnName("ARE_COD").ValueGeneratedNever();
        builder.Property(e => e.AreNom).HasColumnName("ARE_NOM").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.SubareCod).HasColumnName("SUBARE_COD");
        builder.Property(e => e.DiaxMes).HasColumnName("DiaxMes");
        builder.Property(e => e.PagoxMes).HasColumnName("PagoxMes");
        builder.Property(e => e.Pertenece).HasColumnName("Pertenece");
    }
}

public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
{
    public void Configure(EntityTypeBuilder<TipoDocumento> builder)
    {
        builder.HasKey(e => e.TipCod);
        builder.ToTable("TIPO_DOCUMENTO");
        builder.Property(e => e.TipCod).HasColumnName("TIP_COD").ValueGeneratedNever();
        builder.Property(e => e.TipDoc).HasColumnName("TIP_DOC").HasMaxLength(255).IsUnicode(false);
    }
}

public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.HasKey(e => e.IdEmpresa);
        builder.ToTable("EMPRESA");
        builder.Property(e => e.IdEmpresa).HasColumnName("IdEmpresa").ValueGeneratedNever();
        builder.Property(e => e.NomEmpresa).HasColumnName("NomEmpresa").HasMaxLength(255).IsUnicode(false);
        builder.Property(e => e.RucEmpresa).HasColumnName("RucEmpresa");
        builder.Property(e => e.DescEmpresa).HasColumnName("DescEmpresa").HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.AreasTrabajo).HasColumnName("AreasTrabajo").HasMaxLength(500).IsUnicode(false);
        builder.Property(e => e.Usuario).HasColumnName("Usuario").HasMaxLength(255);
    }
}
