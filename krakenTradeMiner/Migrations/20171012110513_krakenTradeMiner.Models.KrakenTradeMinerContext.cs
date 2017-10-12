using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace krakenTradeMiner.Migrations
{
    public partial class krakenTradeMinerModelsKrakenTradeMinerContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastTradeId = table.Column<long>(type: "bigint", nullable: false),
                    Miscellaneous = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pair = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(30,5)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnixTime = table.Column<decimal>(type: "decimal(30,5)", nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(30,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trades", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trades");
        }
    }
}
