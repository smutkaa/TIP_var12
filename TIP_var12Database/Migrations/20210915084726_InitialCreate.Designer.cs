// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TIP_var12Database;

namespace TIP_var12Database.Migrations
{
    [DbContext(typeof(mydbContext))]
    [Migration("20210915084726_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TIP_var12Database.Accountcharts", b =>
                {
                    b.Property<int>("Accountchartid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("accountchartid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Number")
                        .HasColumnName("number")
                        .HasColumnType("integer");

                    b.Property<string>("Subconto1")
                        .HasColumnName("subconto1")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Subconto2")
                        .HasColumnName("subconto2")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Accountchartid")
                        .HasName("accountcharts_pkey");

                    b.ToTable("accountcharts");
                });

            modelBuilder.Entity("TIP_var12Database.Cars", b =>
                {
                    b.Property<int>("Carid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("carid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<decimal>("Purchaseprice")
                        .HasColumnName("purchaseprice")
                        .HasColumnType("numeric(15,2)");

                    b.Property<decimal>("Retailprice")
                        .HasColumnName("retailprice")
                        .HasColumnType("numeric(15,2)");

                    b.Property<int>("Seriesid")
                        .HasColumnName("seriesid")
                        .HasColumnType("integer");

                    b.HasKey("Carid")
                        .HasName("cars_pkey");

                    b.HasIndex("Seriesid");

                    b.ToTable("cars");
                });

            modelBuilder.Entity("TIP_var12Database.Customers", b =>
                {
                    b.Property<int>("Customerid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("customerid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Fio")
                        .IsRequired()
                        .HasColumnName("fio")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Customerid")
                        .HasName("customers_pkey");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("TIP_var12Database.Postingjournal", b =>
                {
                    b.Property<int>("Postingjournalid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("postingjournalid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Creditaccount")
                        .HasColumnName("creditaccount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.Property<int>("Debitaccount")
                        .HasColumnName("debitaccount")
                        .HasColumnType("integer");

                    b.Property<int?>("Purchasedocid")
                        .HasColumnName("purchasedocid")
                        .HasColumnType("integer");

                    b.Property<int?>("Saledocsid")
                        .HasColumnName("saledocsid")
                        .HasColumnType("integer");

                    b.Property<string>("Subcontocredit1")
                        .HasColumnName("subcontocredit1")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Subcontocredit2")
                        .HasColumnName("subcontocredit2")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Subcontodebit1")
                        .HasColumnName("subcontodebit1")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Subcontodebit2")
                        .HasColumnName("subcontodebit2")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<decimal>("Total")
                        .HasColumnName("total")
                        .HasColumnType("numeric(15,2)");

                    b.HasKey("Postingjournalid");

                    b.HasIndex("Creditaccount");

                    b.HasIndex("Debitaccount");

                    b.HasIndex("Purchasedocid");

                    b.HasIndex("Saledocsid");

                    b.ToTable("postingjournal");
                });

            modelBuilder.Entity("TIP_var12Database.Providers", b =>
                {
                    b.Property<int>("Providerid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("providerid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Providerid")
                        .HasName("providers_pkey");

                    b.ToTable("providers");
                });

            modelBuilder.Entity("TIP_var12Database.Purchasedocs", b =>
                {
                    b.Property<int>("Purchasedocid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("purchasedocid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Carid")
                        .HasColumnName("carid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.Property<int>("Providerid")
                        .HasColumnName("providerid")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("integer");

                    b.HasKey("Purchasedocid")
                        .HasName("purchasedocs_pkey");

                    b.HasIndex("Carid");

                    b.HasIndex("Providerid");

                    b.ToTable("purchasedocs");
                });

            modelBuilder.Entity("TIP_var12Database.Requests", b =>
                {
                    b.Property<int>("Requestsid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("requestsid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Carid")
                        .HasColumnName("carid")
                        .HasColumnType("integer");

                    b.Property<int>("Customerid")
                        .HasColumnName("customerid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("integer");

                    b.HasKey("Requestsid");

                    b.HasIndex("Carid");

                    b.HasIndex("Customerid");

                    b.ToTable("requests");
                });

            modelBuilder.Entity("TIP_var12Database.Saledocs", b =>
                {
                    b.Property<int>("Saledocsid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("saledocsid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.Property<string>("Employee")
                        .IsRequired()
                        .HasColumnName("employee")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Requestsid")
                        .HasColumnName("requestsid")
                        .HasColumnType("integer");

                    b.Property<decimal>("Total")
                        .HasColumnName("total")
                        .HasColumnType("numeric(15,2)");

                    b.HasKey("Saledocsid");

                    b.HasIndex("Requestsid");

                    b.ToTable("saledocs");
                });

            modelBuilder.Entity("TIP_var12Database.Saleservices", b =>
                {
                    b.Property<int>("Saleservicesid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("saleservicesid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Number")
                        .HasColumnName("number")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnName("price")
                        .HasColumnType("numeric(15,2)");

                    b.Property<int>("Saledocsid")
                        .HasColumnName("saledocsid")
                        .HasColumnType("integer");

                    b.Property<int>("Servicesid")
                        .HasColumnName("servicesid")
                        .HasColumnType("integer");

                    b.HasKey("Saleservicesid");

                    b.HasIndex("Saledocsid");

                    b.HasIndex("Servicesid");

                    b.ToTable("saleservices");
                });

            modelBuilder.Entity("TIP_var12Database.Series", b =>
                {
                    b.Property<int>("Seriesid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("seriesid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Seriesid");

                    b.ToTable("series");
                });

            modelBuilder.Entity("TIP_var12Database.Services", b =>
                {
                    b.Property<int>("Servicesid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("servicesid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<decimal>("Price")
                        .HasColumnName("price")
                        .HasColumnType("numeric(15,2)");

                    b.Property<int>("Subdivisionid")
                        .HasColumnName("subdivisionid")
                        .HasColumnType("integer");

                    b.HasKey("Servicesid");

                    b.HasIndex("Subdivisionid");

                    b.ToTable("services");
                });

            modelBuilder.Entity("TIP_var12Database.Subdivision", b =>
                {
                    b.Property<int>("Subdivisionid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("subdivisionid")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Accountchartid")
                        .HasColumnName("accountchartid")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Subdivisionid");

                    b.HasIndex("Accountchartid");

                    b.ToTable("subdivision");
                });

            modelBuilder.Entity("TIP_var12Database.Cars", b =>
                {
                    b.HasOne("TIP_var12Database.Series", "Series")
                        .WithMany("Cars")
                        .HasForeignKey("Seriesid")
                        .HasConstraintName("seriesidfk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TIP_var12Database.Postingjournal", b =>
                {
                    b.HasOne("TIP_var12Database.Accountcharts", "CreditaccountNavigation")
                        .WithMany("PostingjournalCreditaccountNavigation")
                        .HasForeignKey("Creditaccount")
                        .HasConstraintName("creditaccountidfk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TIP_var12Database.Accountcharts", "DebitaccountNavigation")
                        .WithMany("PostingjournalDebitaccountNavigation")
                        .HasForeignKey("Debitaccount")
                        .HasConstraintName("debitaccountfk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TIP_var12Database.Purchasedocs", "Purchasedoc")
                        .WithMany("Postingjournal")
                        .HasForeignKey("Purchasedocid")
                        .HasConstraintName("purchasedocidfk")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TIP_var12Database.Saledocs", "Saledocs")
                        .WithMany("Postingjournal")
                        .HasForeignKey("Saledocsid")
                        .HasConstraintName("saledocsidfk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TIP_var12Database.Purchasedocs", b =>
                {
                    b.HasOne("TIP_var12Database.Cars", "Car")
                        .WithMany("Purchasedocs")
                        .HasForeignKey("Carid")
                        .HasConstraintName("caridfk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TIP_var12Database.Providers", "Provider")
                        .WithMany("Purchasedocs")
                        .HasForeignKey("Providerid")
                        .HasConstraintName("provideridfk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TIP_var12Database.Requests", b =>
                {
                    b.HasOne("TIP_var12Database.Cars", "Car")
                        .WithMany("Requests")
                        .HasForeignKey("Carid")
                        .HasConstraintName("caridfk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TIP_var12Database.Customers", "Customer")
                        .WithMany("Requests")
                        .HasForeignKey("Customerid")
                        .HasConstraintName("customeridfk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TIP_var12Database.Saledocs", b =>
                {
                    b.HasOne("TIP_var12Database.Requests", "Requests")
                        .WithMany("Saledocs")
                        .HasForeignKey("Requestsid")
                        .HasConstraintName("requestsidfk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TIP_var12Database.Saleservices", b =>
                {
                    b.HasOne("TIP_var12Database.Saledocs", "Saledocs")
                        .WithMany("Saleservices")
                        .HasForeignKey("Saledocsid")
                        .HasConstraintName("saledocsidfk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TIP_var12Database.Services", "Services")
                        .WithMany("Saleservices")
                        .HasForeignKey("Servicesid")
                        .HasConstraintName("servicesidfk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TIP_var12Database.Services", b =>
                {
                    b.HasOne("TIP_var12Database.Subdivision", "Subdivision")
                        .WithMany("Services")
                        .HasForeignKey("Subdivisionid")
                        .HasConstraintName("subdivisionidfk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TIP_var12Database.Subdivision", b =>
                {
                    b.HasOne("TIP_var12Database.Accountcharts", "Accountchart")
                        .WithMany("Subdivision")
                        .HasForeignKey("Accountchartid")
                        .HasConstraintName("accountchartidfk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
