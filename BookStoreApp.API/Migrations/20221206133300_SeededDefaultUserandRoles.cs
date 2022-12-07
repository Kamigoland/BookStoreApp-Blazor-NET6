using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUserandRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ccb6af3-b1a7-4db0-998e-ead1bb409f78", "141ca949-6eee-4169-91fc-21c57f36ae48", "User", "USER" },
                    { "98db3b50-114b-4a9a-99fd-ea57611b4b7f", "83da09e0-dcbf-491f-8837-bd8909b8451f", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "393a8204-b670-4dc9-a1c0-5fadcfbb4159", 0, "e28b3430-9996-4aa1-8eb8-7bc20062f220", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEFGot1UN+tmulFs+qHTjvAp17rb4vz7rcfp1dAZDpd4inpo+O9YU+MjQYr8blhaujw==", null, false, "96e2eab4-227d-422d-b267-a36a1f530ffa", false, "admin@bookstore.com" },
                    { "5bc0a116-c932-4b95-924f-ab6c4a1f6324", 0, "fe0cd500-494e-4c2f-aac4-a30c5a8e47e5", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEC2O25K47V5l7W6hlXtmo+kEb121DxEJmmo9b1EfjRhyQ4oo/SVRuoCCSvHn1v+gsQ==", null, false, "5d859847-3856-4ba7-8446-2fd46ccf24ed", false, "user@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "98db3b50-114b-4a9a-99fd-ea57611b4b7f", "393a8204-b670-4dc9-a1c0-5fadcfbb4159" },
                    { "5ccb6af3-b1a7-4db0-998e-ead1bb409f78", "5bc0a116-c932-4b95-924f-ab6c4a1f6324" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "98db3b50-114b-4a9a-99fd-ea57611b4b7f", "393a8204-b670-4dc9-a1c0-5fadcfbb4159" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5ccb6af3-b1a7-4db0-998e-ead1bb409f78", "5bc0a116-c932-4b95-924f-ab6c4a1f6324" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ccb6af3-b1a7-4db0-998e-ead1bb409f78");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98db3b50-114b-4a9a-99fd-ea57611b4b7f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "393a8204-b670-4dc9-a1c0-5fadcfbb4159");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bc0a116-c932-4b95-924f-ab6c4a1f6324");
        }
    }
}
