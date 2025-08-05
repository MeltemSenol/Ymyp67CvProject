using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ymyp67CvProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class conctactConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("22bd5103-eb1e-4430-80c0-1626ab944570"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("90f88d87-1b36-4a91-86e7-37fa5b65c64a"));

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Contacts",
                newName: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Contacts",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(12)",
                oldFixedLength: true,
                oldMaxLength: 12);

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CreateAt", "IsActive", "IsDeleted", "Level", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("cd964287-1c33-41e3-a2a3-fdc6882ad7ae"), new DateTime(2025, 8, 3, 23, 21, 2, 187, DateTimeKind.Local).AddTicks(3794), true, false, (byte)80, "İngilizce", null },
                    { new Guid("e81b0414-8896-472b-9be8-5accb8863392"), new DateTime(2025, 8, 3, 23, 21, 2, 187, DateTimeKind.Local).AddTicks(3870), true, false, (byte)30, "Almanca", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("cd964287-1c33-41e3-a2a3-fdc6882ad7ae"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("e81b0414-8896-472b-9be8-5accb8863392"));

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Contacts",
                newName: "Adress");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Contacts",
                type: "nchar(12)",
                fixedLength: true,
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CreateAt", "IsActive", "IsDeleted", "Level", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("22bd5103-eb1e-4430-80c0-1626ab944570"), new DateTime(2025, 7, 24, 21, 53, 47, 113, DateTimeKind.Local).AddTicks(2355), true, false, (byte)30, "Almanca", null },
                    { new Guid("90f88d87-1b36-4a91-86e7-37fa5b65c64a"), new DateTime(2025, 7, 24, 21, 53, 47, 113, DateTimeKind.Local).AddTicks(2308), true, false, (byte)80, "İngilizce", null }
                });
        }
    }
}
