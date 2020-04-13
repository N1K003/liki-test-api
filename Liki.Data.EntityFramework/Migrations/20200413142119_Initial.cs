using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Liki.Data.EntityFramework.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "DeliveryWindows",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Start = table.Column<TimeSpan>("time"),
                    End = table.Column<TimeSpan>("time"),
                    Price = table.Column<decimal>("money"),
                    WindowType = table.Column<int>(),
                    AvailableByHoursBefore = table.Column<TimeSpan>("time"),
                    IsAvailable = table.Column<bool>()
                },
                constraints: table => { table.PrimaryKey("PK_DeliveryWindows", x => x.Id); });

            migrationBuilder.InsertData(
                "DeliveryWindows",
                new[] {"Id", "AvailableByHoursBefore", "Description", "End", "IsAvailable", "Name", "Price", "Start", "WindowType"},
                new object[,]
                {
                    {
                        1, new TimeSpan(0, 12, 0, 0, 0), "Доставка с 10:00 до 13:00", new TimeSpan(0, 13, 0, 0, 0), true, "10:00 - 13:00",
                        50m, new TimeSpan(0, 10, 0, 0, 0), 0
                    },
                    {
                        2, new TimeSpan(0, 3, 0, 0, 0), "Доставка с 14:00 до 17:00", new TimeSpan(0, 17, 0, 0, 0), true, "14:00 - 17:00",
                        50m, new TimeSpan(0, 14, 0, 0, 0), 0
                    },
                    {
                        3, new TimeSpan(0, 3, 0, 0, 0), "Доставка с 18:00 до 21:00", new TimeSpan(0, 21, 0, 0, 0), true, "18:00 - 21:00",
                        50m, new TimeSpan(0, 18, 0, 0, 0), 0
                    },
                    {
                        4, new TimeSpan(0, 1, 0, 0, 0), "Срочная доставка с 10:00 до 21:00", new TimeSpan(0, 21, 0, 0, 0), true,
                        "10:00 - 21:00 (срочная)", 100m, new TimeSpan(0, 10, 0, 0, 0), 1
                    }
                });

            migrationBuilder.CreateIndex(
                "IX_DeliveryWindows_AvailableByHoursBefore",
                "DeliveryWindows",
                "AvailableByHoursBefore");

            migrationBuilder.CreateIndex(
                "IX_DeliveryWindows_Start_End",
                "DeliveryWindows",
                new[] {"Start", "End"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "DeliveryWindows");
        }
    }
}