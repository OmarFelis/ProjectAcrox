using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace notienendqver.Models;

public partial class AcroxOgContext : DbContext
{
    public AcroxOgContext()
    {
    }

    public AcroxOgContext(DbContextOptions<AcroxOgContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Almacen> Almacens { get; set; }

    public virtual DbSet<Beneficiario> Beneficiarios { get; set; }

    public virtual DbSet<Boletum> Boleta { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<DetallePagoBoletum> DetallePagoBoleta { get; set; }

    public virtual DbSet<DetallePagoKardex> DetallePagoKardices { get; set; }

    public virtual DbSet<Kardex> Kardices { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<PagoBoletum> PagoBoleta { get; set; }

    public virtual DbSet<PagoKardex> PagoKardices { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Registro> Registros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Visitum> Visita { get; set; }

    public virtual DbSet<Viviendum> Vivienda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
=> optionsBuilder.UseSqlServer("server=DESKTOP-6UPJBIN;database=ACROX_OG2;user id=PryAcrox2;password=123456789;trustservercertificate=true;Trusted_Connection=True;Encrypt=True;"
//=> optionsBuilder.UseSqlServer("server=ULELAB312;database=ACROX_OG2;user id=PryAcrox2;password=123456789;trustservercertificate=true;Trusted_Connection=True;Encrypt=True;"

);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Almacen>(entity =>
        {
            entity.HasKey(e => e.CodAlmacen).HasName("PK__Almacen__611D730DA0201C65");

            entity.ToTable("Almacen");

            entity.HasIndex(e => e.LugarAlmacen, "UQ__Almacen__126E1A3E71FA2558").IsUnique();

            entity.Property(e => e.CodAlmacen).HasColumnName("Cod_Almacen");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.LugarAlmacen)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Lugar_Almacen");
            entity.Property(e => e.NombreAlmacen)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Nombre_Almacen");
        });

        modelBuilder.Entity<Beneficiario>(entity =>
        {
            entity.HasKey(e => e.CodBeneficiario).HasName("PK__Benefici__8777E7D68AC55A1E");

            entity.ToTable("Beneficiario");

            entity.HasIndex(e => e.DniBeneficiario, "UQ__Benefici__85ADABB274CD7AFC").IsUnique();

            entity.Property(e => e.CodBeneficiario).HasColumnName("Cod_Beneficiario");
            entity.Property(e => e.DniBeneficiario)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("DNI_Beneficiario");
            entity.Property(e => e.EstadoBeneficiario)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Estado_Beneficiario");
            entity.Property(e => e.FechBeneficiario).HasColumnName("Fech__Beneficiario");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.NombreCBeneficiario)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("NombreC_Beneficiario");
        });

        modelBuilder.Entity<Boletum>(entity =>
        {
            entity.HasKey(e => e.CodBoleta).HasName("PK__Boleta__D7F91012F77A4520");

            entity.Property(e => e.CodBoleta).HasColumnName("Cod_Boleta");
            entity.Property(e => e.CodMaterial).HasColumnName("Cod_Material");
            entity.Property(e => e.CodVivienda).HasColumnName("Cod_Vivienda");
            entity.Property(e => e.EstadoBoleta)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Estado_Boleta");
            entity.Property(e => e.FechaBoleta).HasColumnName("Fecha_Boleta");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.TotalBoleta).HasColumnName("Total_Boleta");

            entity.HasOne(d => d.CodMaterialNavigation).WithMany(p => p.Boleta)
                .HasForeignKey(d => d.CodMaterial)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Boleta__Cod_Mate__4D94879B");

            entity.HasOne(d => d.CodViviendaNavigation).WithMany(p => p.Boleta)
                .HasForeignKey(d => d.CodVivienda)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Boleta__Cod_Vivi__4E88ABD4");
        });

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.CodContrato).HasName("PK__Contrato__39540FF14B739B19");

            entity.ToTable("Contrato");

            entity.Property(e => e.CodContrato).HasColumnName("Cod_Contrato");
            entity.Property(e => e.CodVivienda).HasColumnName("Cod_Vivienda");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.TipoContrato)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Tipo_Contrato");

            entity.HasOne(d => d.CodViviendaNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.CodVivienda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contrato__Cod_Vi__66603565");
        });

        modelBuilder.Entity<DetallePagoBoletum>(entity =>
        {
            entity.HasKey(e => e.CodDetalle).HasName("PK__Detalle___548DF142061463FD");

            entity.ToTable("Detalle_Pago_Boleta");

            entity.Property(e => e.CodDetalle).HasColumnName("Cod_Detalle");
            entity.Property(e => e.CodBoleta).HasColumnName("Cod_Boleta");
            entity.Property(e => e.CodPagoB).HasColumnName("Cod_PagoB");
            entity.Property(e => e.Descrp)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");

            entity.HasOne(d => d.CodBoletaNavigation).WithMany(p => p.DetallePagoBoleta)
                .HasForeignKey(d => d.CodBoleta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_P__Cod_B__5629CD9C");

            entity.HasOne(d => d.CodPagoBNavigation).WithMany(p => p.DetallePagoBoleta)
                .HasForeignKey(d => d.CodPagoB)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_P__Cod_P__571DF1D5");
        });

        modelBuilder.Entity<DetallePagoKardex>(entity =>
        {
            entity.HasKey(e => e.CodDetalle).HasName("PK__Detalle___548DF1429F972A3A");

            entity.ToTable("Detalle_Pago_Kardex");

            entity.Property(e => e.CodDetalle).HasColumnName("Cod_Detalle");
            entity.Property(e => e.CodKardex).HasColumnName("Cod_Kardex");
            entity.Property(e => e.CodPagoK).HasColumnName("Cod_PagoK");
            entity.Property(e => e.Descp)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");

            entity.HasOne(d => d.CodKardexNavigation).WithMany(p => p.DetallePagoKardices)
                .HasForeignKey(d => d.CodKardex)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_P__Cod_K__73BA3083");

            entity.HasOne(d => d.CodPagoKNavigation).WithMany(p => p.DetallePagoKardices)
                .HasForeignKey(d => d.CodPagoK)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_P__Cod_P__74AE54BC");
        });

        modelBuilder.Entity<Kardex>(entity =>
        {
            entity.HasKey(e => e.CodKardex).HasName("PK__Kardex__D8B7A4D5B60BB00A");

            entity.ToTable("Kardex");

            entity.Property(e => e.CodKardex).HasColumnName("Cod_Kardex");
            entity.Property(e => e.CodMaterial).HasColumnName("Cod_Material");
            entity.Property(e => e.CodProveedor).HasColumnName("Cod_Proveedor");
            entity.Property(e => e.CodVivienda).HasColumnName("Cod_Vivienda");
            entity.Property(e => e.DescrpKardex)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Descrp_Kardex");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");

            entity.HasOne(d => d.CodMaterialNavigation).WithMany(p => p.Kardices)
                .HasForeignKey(d => d.CodMaterial)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Kardex__Cod_Mate__6B24EA82");

            entity.HasOne(d => d.CodProveedorNavigation).WithMany(p => p.Kardices)
                .HasForeignKey(d => d.CodProveedor)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Kardex__Cod_Prov__6A30C649");

            entity.HasOne(d => d.CodViviendaNavigation).WithMany(p => p.Kardices)
                .HasForeignKey(d => d.CodVivienda)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Kardex__Cod_Vivi__6C190EBB");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.CodMaterial).HasName("PK__Material__5C328A4632CC7562");

            entity.ToTable("Material");

            entity.Property(e => e.CodMaterial).HasColumnName("Cod_Material");
            entity.Property(e => e.CodAlmacen).HasColumnName("Cod_Almacen");
            entity.Property(e => e.CodProveedor).HasColumnName("Cod_Proveedor");
            entity.Property(e => e.CodVivienda).HasColumnName("Cod_Vivienda");
            entity.Property(e => e.DescrpMaterial)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Descrp_Material");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.NombMaterial)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Nomb_Material");
            entity.Property(e => e.PrecioMaterial).HasColumnName("Precio_Material");

            entity.HasOne(d => d.CodAlmacenNavigation).WithMany(p => p.Materials)
                .HasForeignKey(d => d.CodAlmacen)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Material__Cod_Al__48CFD27E");

            entity.HasOne(d => d.CodProveedorNavigation).WithMany(p => p.Materials)
                .HasForeignKey(d => d.CodProveedor)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Material__Cod_Pr__47DBAE45");

            entity.HasOne(d => d.CodViviendaNavigation).WithMany(p => p.Materials)
                .HasForeignKey(d => d.CodVivienda)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Material__Cod_Vi__49C3F6B7");
        });

        modelBuilder.Entity<PagoBoletum>(entity =>
        {
            entity.HasKey(e => e.CodPagoB).HasName("PK__Pago_Bol__BC62E0F86CB0B1CC");

            entity.ToTable("Pago_Boleta");

            entity.Property(e => e.CodPagoB).HasColumnName("Cod_PagoB");
            entity.Property(e => e.CodBoleta).HasColumnName("Cod_Boleta");
            entity.Property(e => e.EstadoPago)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Estado_Pago");
            entity.Property(e => e.FechPago).HasColumnName("Fech_Pago");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.MontoPago).HasColumnName("Monto_Pago");

            entity.HasOne(d => d.CodBoletaNavigation).WithMany(p => p.PagoBoleta)
                .HasForeignKey(d => d.CodBoleta)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Pago_Bole__Cod_B__52593CB8");
        });

        modelBuilder.Entity<PagoKardex>(entity =>
        {
            entity.HasKey(e => e.CodPagoK).HasName("PK__Pago_Kar__BC62E0C1E2C0C579");

            entity.ToTable("Pago_Kardex");

            entity.Property(e => e.CodPagoK).HasColumnName("Cod_PagoK");
            entity.Property(e => e.CodKardex).HasColumnName("Cod_Kardex");
            entity.Property(e => e.EstadoPago)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Estado_Pago");
            entity.Property(e => e.FechPago).HasColumnName("Fech_Pago");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.MontoPago).HasColumnName("Monto_Pago");

            entity.HasOne(d => d.CodKardexNavigation).WithMany(p => p.PagoKardices)
                .HasForeignKey(d => d.CodKardex)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Pago_Kard__Cod_K__6FE99F9F");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.CodProveedor).HasName("PK__Proveedo__F7D7424E4DCE10CB");

            entity.ToTable("Proveedor");

            entity.Property(e => e.CodProveedor).HasColumnName("Cod_Proveedor");
            entity.Property(e => e.DirProveedor)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Dir_Proveedor");
            entity.Property(e => e.EstadoProveedor)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Estado_Proveedor");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.NombProveedor)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Nomb_Proveedor");
            entity.Property(e => e.TelfProveedor)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Telf_Proveedor");
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.HasKey(e => e.CodRegistro).HasName("PK__Registro__83039D6523C4E99C");

            entity.ToTable("Registro");

            entity.Property(e => e.CodRegistro).HasColumnName("Cod_Registro");
            entity.Property(e => e.CodVivienda).HasColumnName("Cod_Vivienda");
            entity.Property(e => e.DescrpRegistro)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Descrp_Registro");
            entity.Property(e => e.FechRegistro).HasColumnName("Fech_Registro");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.TipoRegistro)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Tipo_Registro");

            entity.HasOne(d => d.CodViviendaNavigation).WithMany(p => p.Registros)
                .HasForeignKey(d => d.CodVivienda)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Registro__Cod_Vi__628FA481");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.CodUsuario).HasName("PK__Usuario__D16E26A69CEA03A9");

            entity.ToTable("Usuario");

            entity.Property(e => e.CodUsuario).HasColumnName("Cod_Usuario");
            entity.Property(e => e.ClaveUsuario)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Clave_Usuario");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Nombre_Usuario");
        });

        modelBuilder.Entity<Visitum>(entity =>
        {
            entity.HasKey(e => e.CodVisita).HasName("PK__Visita__3C9BB4DE8E71BC14");

            entity.Property(e => e.CodVisita).HasColumnName("Cod_Visita");
            entity.Property(e => e.CodBeneficiario).HasColumnName("Cod_Beneficiario");
            entity.Property(e => e.CodVivienda).HasColumnName("Cod_Vivienda");
            entity.Property(e => e.DespVisita)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Desp_Visita");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaVisita)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Fecha_Visita");

            entity.HasOne(d => d.CodBeneficiarioNavigation).WithMany(p => p.Visita)
                .HasForeignKey(d => d.CodBeneficiario)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Visita__Cod_Bene__5DCAEF64");

            entity.HasOne(d => d.CodViviendaNavigation).WithMany(p => p.Visita)
                .HasForeignKey(d => d.CodVivienda)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Visita__Cod_Vivi__5EBF139D");
        });

        modelBuilder.Entity<Viviendum>(entity =>
        {
            entity.HasKey(e => e.CodVivienda).HasName("PK__Vivienda__E58322EDCB75D98C");

            entity.HasIndex(e => e.DirVivienda, "UQ__Vivienda__9A298BBF6BD5A175").IsUnique();

            entity.Property(e => e.CodVivienda).HasColumnName("Cod_Vivienda");
            entity.Property(e => e.AreaVivienda)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Area_Vivienda");
            entity.Property(e => e.CodBeneficiario).HasColumnName("Cod_Beneficiario");
            entity.Property(e => e.DirVivienda)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Dir_Vivienda");
            entity.Property(e => e.EstadoVivienda)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Estado_Vivienda");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.TipoVivienda)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("Tipo_Vivienda");

            entity.HasOne(d => d.CodBeneficiarioNavigation).WithMany(p => p.Vivienda)
                .HasForeignKey(d => d.CodBeneficiario)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Vivienda__Cod_Be__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
