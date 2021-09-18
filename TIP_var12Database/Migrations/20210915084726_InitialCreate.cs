using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TIP_var12Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accountcharts",
                columns: table => new
                {
                    accountchartid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    subconto1 = table.Column<string>(maxLength: 255, nullable: true),
                    subconto2 = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("accountcharts_pkey", x => x.accountchartid);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customerid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fio = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("customers_pkey", x => x.customerid);
                });

            migrationBuilder.CreateTable(
                name: "providers",
                columns: table => new
                {
                    providerid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("providers_pkey", x => x.providerid);
                });

            migrationBuilder.CreateTable(
                name: "series",
                columns: table => new
                {
                    seriesid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_series", x => x.seriesid);
                });

            migrationBuilder.CreateTable(
                name: "subdivision",
                columns: table => new
                {
                    subdivisionid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    accountchartid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subdivision", x => x.subdivisionid);
                    table.ForeignKey(
                        name: "accountchartidfk",
                        column: x => x.accountchartid,
                        principalTable: "accountcharts",
                        principalColumn: "accountchartid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    carid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    purchaseprice = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    retailprice = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    seriesid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cars_pkey", x => x.carid);
                    table.ForeignKey(
                        name: "seriesidfk",
                        column: x => x.seriesid,
                        principalTable: "series",
                        principalColumn: "seriesid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    servicesid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    price = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    subdivisionid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.servicesid);
                    table.ForeignKey(
                        name: "subdivisionidfk",
                        column: x => x.subdivisionid,
                        principalTable: "subdivision",
                        principalColumn: "subdivisionid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchasedocs",
                columns: table => new
                {
                    purchasedocid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    carid = table.Column<int>(nullable: false),
                    providerid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("purchasedocs_pkey", x => x.purchasedocid);
                    table.ForeignKey(
                        name: "caridfk",
                        column: x => x.carid,
                        principalTable: "cars",
                        principalColumn: "carid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "provideridfk",
                        column: x => x.providerid,
                        principalTable: "providers",
                        principalColumn: "providerid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "requests",
                columns: table => new
                {
                    requestsid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    carid = table.Column<int>(nullable: false),
                    customerid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requests", x => x.requestsid);
                    table.ForeignKey(
                        name: "caridfk",
                        column: x => x.carid,
                        principalTable: "cars",
                        principalColumn: "carid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "customeridfk",
                        column: x => x.customerid,
                        principalTable: "customers",
                        principalColumn: "customerid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "saledocs",
                columns: table => new
                {
                    saledocsid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employee = table.Column<string>(maxLength: 255, nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    total = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    requestsid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saledocs", x => x.saledocsid);
                    table.ForeignKey(
                        name: "requestsidfk",
                        column: x => x.requestsid,
                        principalTable: "requests",
                        principalColumn: "requestsid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "postingjournal",
                columns: table => new
                {
                    postingjournalid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    debitaccount = table.Column<int>(nullable: false),
                    subcontodebit1 = table.Column<string>(maxLength: 255, nullable: true),
                    subcontodebit2 = table.Column<string>(maxLength: 255, nullable: true),
                    creditaccount = table.Column<int>(nullable: false),
                    subcontocredit1 = table.Column<string>(maxLength: 255, nullable: true),
                    subcontocredit2 = table.Column<string>(maxLength: 255, nullable: true),
                    total = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    saledocsid = table.Column<int>(nullable: true),
                    purchasedocid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postingjournal", x => x.postingjournalid);
                    table.ForeignKey(
                        name: "creditaccountidfk",
                        column: x => x.creditaccount,
                        principalTable: "accountcharts",
                        principalColumn: "accountchartid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "debitaccountfk",
                        column: x => x.debitaccount,
                        principalTable: "accountcharts",
                        principalColumn: "accountchartid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "purchasedocidfk",
                        column: x => x.purchasedocid,
                        principalTable: "purchasedocs",
                        principalColumn: "purchasedocid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "saledocsidfk",
                        column: x => x.saledocsid,
                        principalTable: "saledocs",
                        principalColumn: "saledocsid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "saleservices",
                columns: table => new
                {
                    saleservicesid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    servicesid = table.Column<int>(nullable: false),
                    saledocsid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saleservices", x => x.saleservicesid);
                    table.ForeignKey(
                        name: "saledocsidfk",
                        column: x => x.saledocsid,
                        principalTable: "saledocs",
                        principalColumn: "saledocsid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "servicesidfk",
                        column: x => x.servicesid,
                        principalTable: "services",
                        principalColumn: "servicesid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_seriesid",
                table: "cars",
                column: "seriesid");

            migrationBuilder.CreateIndex(
                name: "IX_postingjournal_creditaccount",
                table: "postingjournal",
                column: "creditaccount");

            migrationBuilder.CreateIndex(
                name: "IX_postingjournal_debitaccount",
                table: "postingjournal",
                column: "debitaccount");

            migrationBuilder.CreateIndex(
                name: "IX_postingjournal_purchasedocid",
                table: "postingjournal",
                column: "purchasedocid");

            migrationBuilder.CreateIndex(
                name: "IX_postingjournal_saledocsid",
                table: "postingjournal",
                column: "saledocsid");

            migrationBuilder.CreateIndex(
                name: "IX_purchasedocs_carid",
                table: "purchasedocs",
                column: "carid");

            migrationBuilder.CreateIndex(
                name: "IX_purchasedocs_providerid",
                table: "purchasedocs",
                column: "providerid");

            migrationBuilder.CreateIndex(
                name: "IX_requests_carid",
                table: "requests",
                column: "carid");

            migrationBuilder.CreateIndex(
                name: "IX_requests_customerid",
                table: "requests",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_saledocs_requestsid",
                table: "saledocs",
                column: "requestsid");

            migrationBuilder.CreateIndex(
                name: "IX_saleservices_saledocsid",
                table: "saleservices",
                column: "saledocsid");

            migrationBuilder.CreateIndex(
                name: "IX_saleservices_servicesid",
                table: "saleservices",
                column: "servicesid");

            migrationBuilder.CreateIndex(
                name: "IX_services_subdivisionid",
                table: "services",
                column: "subdivisionid");

            migrationBuilder.CreateIndex(
                name: "IX_subdivision_accountchartid",
                table: "subdivision",
                column: "accountchartid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "postingjournal");

            migrationBuilder.DropTable(
                name: "saleservices");

            migrationBuilder.DropTable(
                name: "purchasedocs");

            migrationBuilder.DropTable(
                name: "saledocs");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "providers");

            migrationBuilder.DropTable(
                name: "requests");

            migrationBuilder.DropTable(
                name: "subdivision");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "accountcharts");

            migrationBuilder.DropTable(
                name: "series");
        }
    }
}
