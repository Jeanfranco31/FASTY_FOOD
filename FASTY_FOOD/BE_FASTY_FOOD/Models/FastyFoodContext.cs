using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BE_FASTY_FOOD.Models;

public partial class FastyFoodContext : DbContext
{
    public FastyFoodContext()
    {
    }

    public FastyFoodContext(DbContextOptions<FastyFoodContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<LogOrderCustomer> LogOrderCustomers { get; set; }

    public virtual DbSet<LoginLog> LoginLogs { get; set; }

    public virtual DbSet<MenuOption> MenuOptions { get; set; }

    public virtual DbSet<OrderCustomer> OrderCustomers { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<SubMenu> SubMenus { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3213E83F071FCABB");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateRegister)
                .HasColumnType("datetime")
                .HasColumnName("date_Register");
            entity.Property(e => e.NameCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nameCategory");
            entity.Property(e => e.StatusCategory).HasColumnName("status_Category");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Company__3213E83F0F271575");

            entity.ToTable("Company");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateRegister)
                .HasColumnType("datetime")
                .HasColumnName("dateRegister");
            entity.Property(e => e.FullName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("fullName");
            entity.Property(e => e.Ruc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("ruc");
            entity.Property(e => e.StatusCompany).HasColumnName("statusCompany");
        });

        modelBuilder.Entity<LogOrderCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LogOrder__3213E83F93C6CFF3");

            entity.ToTable("LogOrderCustomer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdOrderCustomer).HasColumnName("idOrderCustomer");
            entity.Property(e => e.IdUser).HasColumnName("id_User");

            entity.HasOne(d => d.IdOrderCustomerNavigation).WithMany(p => p.LogOrderCustomers)
                .HasForeignKey(d => d.IdOrderCustomer)
                .HasConstraintName("FK__LogOrderC__idOrd__4D94879B");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.LogOrderCustomers)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__LogOrderC__id_Us__4E88ABD4");
        });

        modelBuilder.Entity<LoginLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LoginLog__3213E83F1A567986");

            entity.ToTable("LoginLog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attemp).HasColumnName("attemp");
            entity.Property(e => e.DateLogged)
                .HasColumnType("datetime")
                .HasColumnName("date_Logged");
            entity.Property(e => e.IdUser).HasColumnName("id_User");
            entity.Property(e => e.StatusAccount).HasColumnName("status_Account");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("userName");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.LoginLogs)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__LoginLog__id_Use__403A8C7D");
        });

        modelBuilder.Entity<MenuOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MenuOpti__3213E83F1DB834B6");

            entity.ToTable("MenuOption");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateRegister)
                .HasColumnType("datetime")
                .HasColumnName("date_Register");
            entity.Property(e => e.IconName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("icon_Name");
            entity.Property(e => e.NameOption)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name_Option");
            entity.Property(e => e.StatusOption).HasColumnName("statusOption");
        });

        modelBuilder.Entity<OrderCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderCus__3213E83F9FDD233A");

            entity.ToTable("OrderCustomer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateRegister)
                .HasColumnType("datetime")
                .HasColumnName("date_Register");
            entity.Property(e => e.IdCategory).HasColumnName("id_Category");
            entity.Property(e => e.IdUser).HasColumnName("id_User");
            entity.Property(e => e.ImageName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("image_Name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("price");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.OrderCustomers)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK__OrderCust__id_Ca__49C3F6B7");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.OrderCustomers)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__OrderCust__id_Us__4AB81AF0");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rol__3213E83FF660E4A2");

            entity.ToTable("Rol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateRegister)
                .HasColumnType("datetime")
                .HasColumnName("dateRegister");
            entity.Property(e => e.Rolname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rolname");
            entity.Property(e => e.StatusRol).HasColumnName("statusRol");
        });

        modelBuilder.Entity<SubMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubMenu__3213E83F17DFEB14");

            entity.ToTable("SubMenu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateRegister)
                .HasColumnType("datetime")
                .HasColumnName("date_Register");
            entity.Property(e => e.IdOption).HasColumnName("idOption");
            entity.Property(e => e.NameSubOption)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nameSubOption");

            entity.HasOne(d => d.IdOptionNavigation).WithMany(p => p.SubMenus)
                .HasForeignKey(d => d.IdOption)
                .HasConstraintName("FK__SubMenu__idOptio__44FF419A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F95AE8E22");

            entity.HasIndex(e => e.IdNumber, "UQ__Users__D58CDE119EC133D6").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateRegister)
                .HasColumnType("datetime")
                .HasColumnName("date_Register");
            entity.Property(e => e.FullName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.IdCompany).HasColumnName("id_Company");
            entity.Property(e => e.IdNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("id_number");
            entity.Property(e => e.IdRol).HasColumnName("id_Rol");
            entity.Property(e => e.StatusUser).HasColumnName("status_User");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdCompany)
                .HasConstraintName("FK__Users__id_Compan__3D5E1FD2");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Users__id_Rol__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
