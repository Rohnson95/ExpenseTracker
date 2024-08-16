using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpenseTracker.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsRecurrent = table.Column<bool>(type: "bit", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 17, 1, 53, 3, 563, DateTimeKind.Local).AddTicks(5843), "johndoe@example.com", "hashedpassword1", new DateTime(2024, 8, 17, 1, 53, 3, 563, DateTimeKind.Local).AddTicks(5898), "johndoe" },
                    { 2, new DateTime(2024, 8, 17, 1, 53, 3, 563, DateTimeKind.Local).AddTicks(5901), "janedoe@example.com", "hashedpassword2", new DateTime(2024, 8, 17, 1, 53, 3, 563, DateTimeKind.Local).AddTicks(5902), "janedoe" },
                    { 3, new DateTime(2024, 8, 17, 1, 53, 3, 563, DateTimeKind.Local).AddTicks(5904), "bobsmith@example.com", "hashedpassword3", new DateTime(2024, 8, 17, 1, 53, 3, 563, DateTimeKind.Local).AddTicks(5906), "bobsmith" }
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "Category", "Currency", "Date", "IsRecurrent", "Name", "Notes", "UserId" },
                values: new object[,]
                {
                    { 1, 150.75m, "Food", "SEK", new DateTime(2024, 8, 7, 1, 53, 3, 563, DateTimeKind.Local).AddTicks(5992), false, "Groceries", null, 1 },
                    { 2, 80.50m, "Utilities", "SEK", new DateTime(2024, 8, 12, 1, 53, 3, 563, DateTimeKind.Local).AddTicks(5997), false, "Electricity Bill", null, 1 },
                    { 3, 45.00m, "Health", "SEK", new DateTime(2024, 7, 17, 1, 53, 3, 563, DateTimeKind.Local).AddTicks(6001), false, "Gym Membership", null, 2 },
                    { 4, 60.00m, "Utilities", "SEK", new DateTime(2024, 8, 14, 1, 53, 3, 563, DateTimeKind.Local).AddTicks(6007), false, "Internet Bill", null, 2 },
                    { 5, 5.50m, "Food", "SEK", new DateTime(2024, 8, 16, 1, 53, 3, 563, DateTimeKind.Local).AddTicks(6011), false, "Coffee", null, 3 },
                    { 6, 12.00m, "Entertainment", "SEK", new DateTime(2024, 8, 15, 1, 53, 3, 563, DateTimeKind.Local).AddTicks(6015), false, "Movie Ticket", null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UserId",
                table: "Expenses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
