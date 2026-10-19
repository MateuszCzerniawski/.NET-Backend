using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetbackend.Migrations
{
    /// <inheritdoc />
    public partial class weights : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "PK",
                keyValue: 1,
                column: "current_weight",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "PK",
                keyValue: 2,
                column: "current_weight",
                value: 24);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "PK",
                keyValue: 1,
                column: "current_weight",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "PK",
                keyValue: 2,
                column: "current_weight",
                value: 0);
        }
    }
}
