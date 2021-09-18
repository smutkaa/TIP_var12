using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TIP_var12Database
{
    public partial class mydbContext : DbContext
    {
        public mydbContext()
        {
        }

        public mydbContext(DbContextOptions<mydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accountcharts> Accountcharts { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Postingjournal> Postingjournal { get; set; }
        public virtual DbSet<Providers> Providers { get; set; }
        public virtual DbSet<Purchasedocs> Purchasedocs { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<Saledocs> Saledocs { get; set; }
        public virtual DbSet<Saleservices> Saleservices { get; set; }
        public virtual DbSet<Series> Series { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Subdivision> Subdivision { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=mydb;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accountcharts>(entity =>
            {
                entity.HasKey(e => e.Accountchartid)
                    .HasName("accountcharts_pkey");

                entity.ToTable("accountcharts");

                entity.Property(e => e.Accountchartid).HasColumnName("accountchartid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Subconto1)
                    .HasColumnName("subconto1")
                    .HasMaxLength(255);

                entity.Property(e => e.Subconto2)
                    .HasColumnName("subconto2")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Cars>(entity =>
            {
                entity.HasKey(e => e.Carid) 
                    .HasName("cars_pkey");

                entity.ToTable("cars");

                entity.Property(e => e.Carid).HasColumnName("carid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Purchaseprice)
                    .HasColumnName("purchaseprice")
                    .HasColumnType("numeric(15,2)");

                entity.Property(e => e.Retailprice)
                    .HasColumnName("retailprice")
                    .HasColumnType("numeric(15,2)");

                entity.Property(e => e.Seriesid).HasColumnName("seriesid");

                entity.HasOne(d => d.Series)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.Seriesid)
                    .HasConstraintName("seriesidfk");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.Customerid)
                    .HasName("customers_pkey");

                entity.ToTable("customers");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Fio)
                    .IsRequired()
                    .HasColumnName("fio")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Postingjournal>(entity =>
            {
                entity.ToTable("postingjournal");

                entity.Property(e => e.Postingjournalid).HasColumnName("postingjournalid");

                entity.Property(e => e.Creditaccount).HasColumnName("creditaccount");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Debitaccount).HasColumnName("debitaccount");

                entity.Property(e => e.Purchasedocid).HasColumnName("purchasedocid");

                entity.Property(e => e.Saledocsid).HasColumnName("saledocsid");

                entity.Property(e => e.Subcontocredit1)
                    .HasColumnName("subcontocredit1")
                    .HasMaxLength(255);

                entity.Property(e => e.Subcontocredit2)
                    .HasColumnName("subcontocredit2")
                    .HasMaxLength(255);

                entity.Property(e => e.Subcontodebit1)
                    .HasColumnName("subcontodebit1")
                    .HasMaxLength(255);

                entity.Property(e => e.Subcontodebit2)
                    .HasColumnName("subcontodebit2")
                    .HasMaxLength(255);

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("numeric(15,2)");

                entity.HasOne(d => d.CreditaccountNavigation)
                    .WithMany(p => p.PostingjournalCreditaccountNavigation)
                    .HasForeignKey(d => d.Creditaccount)
                    .HasConstraintName("creditaccountidfk");

                entity.HasOne(d => d.DebitaccountNavigation)
                    .WithMany(p => p.PostingjournalDebitaccountNavigation)
                    .HasForeignKey(d => d.Debitaccount)
                    .HasConstraintName("debitaccountfk");

                entity.HasOne(d => d.Purchasedoc)
                    .WithMany(p => p.Postingjournal)
                    .HasForeignKey(d => d.Purchasedocid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("purchasedocidfk");

                entity.HasOne(d => d.Saledocs)
                    .WithMany(p => p.Postingjournal)
                    .HasForeignKey(d => d.Saledocsid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("saledocsidfk");
            });

            modelBuilder.Entity<Providers>(entity =>
            {
                entity.HasKey(e => e.Providerid)
                    .HasName("providers_pkey");

                entity.ToTable("providers");

                entity.Property(e => e.Providerid).HasColumnName("providerid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Purchasedocs>(entity =>
            {
                entity.HasKey(e => e.Purchasedocid)
                    .HasName("purchasedocs_pkey");

                entity.ToTable("purchasedocs");

                entity.Property(e => e.Purchasedocid).HasColumnName("purchasedocid");

                entity.Property(e => e.Carid).HasColumnName("carid");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Providerid).HasColumnName("providerid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Purchasedocs)
                    .HasForeignKey(d => d.Carid)
                    .HasConstraintName("caridfk");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Purchasedocs)
                    .HasForeignKey(d => d.Providerid)
                    .HasConstraintName("provideridfk");
            });

            modelBuilder.Entity<Requests>(entity =>
            {
                entity.ToTable("requests");

                entity.Property(e => e.Requestsid).HasColumnName("requestsid");

                entity.Property(e => e.Carid).HasColumnName("carid");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.Carid)
                    .HasConstraintName("caridfk");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("customeridfk");
            });

            modelBuilder.Entity<Saledocs>(entity =>
            {
                entity.ToTable("saledocs");

                entity.Property(e => e.Saledocsid).HasColumnName("saledocsid");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Employee)
                    .IsRequired()
                    .HasColumnName("employee")
                    .HasMaxLength(255);

                entity.Property(e => e.Requestsid).HasColumnName("requestsid");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("numeric(15,2)");

                entity.HasOne(d => d.Requests)
                    .WithMany(p => p.Saledocs)
                    .HasForeignKey(d => d.Requestsid)
                    .HasConstraintName("requestsidfk");
            });

            modelBuilder.Entity<Saleservices>(entity =>
            {
                entity.ToTable("saleservices");

                entity.Property(e => e.Saleservicesid).HasColumnName("saleservicesid");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(15,2)");

                entity.Property(e => e.Saledocsid).HasColumnName("saledocsid");

                entity.Property(e => e.Servicesid).HasColumnName("servicesid");

                entity.HasOne(d => d.Saledocs)
                    .WithMany(p => p.Saleservices)
                    .HasForeignKey(d => d.Saledocsid)
                    .HasConstraintName("saledocsidfk");

                entity.HasOne(d => d.Services)
                    .WithMany(p => p.Saleservices)
                    .HasForeignKey(d => d.Servicesid)
                    .HasConstraintName("servicesidfk");
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.ToTable("series");

                entity.Property(e => e.Seriesid).HasColumnName("seriesid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.ToTable("services");

                entity.Property(e => e.Servicesid).HasColumnName("servicesid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(15,2)");

                entity.Property(e => e.Subdivisionid).HasColumnName("subdivisionid");

                entity.HasOne(d => d.Subdivision)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.Subdivisionid)
                    .HasConstraintName("subdivisionidfk");
            });

            modelBuilder.Entity<Subdivision>(entity =>
            {
                entity.ToTable("subdivision");

                entity.Property(e => e.Subdivisionid).HasColumnName("subdivisionid");

                entity.Property(e => e.Accountchartid).HasColumnName("accountchartid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Accountchart)
                    .WithMany(p => p.Subdivision)
                    .HasForeignKey(d => d.Accountchartid)
                    .HasConstraintName("accountchartidfk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
