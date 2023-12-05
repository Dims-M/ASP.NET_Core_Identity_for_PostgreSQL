using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cofee.Migrations
{
    /// <inheritdoc />
    public partial class addPrioDev : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Сomments",
                table: "News",
                type: "text",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Сomments",
                table: "News",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "");
        }
    }
}
