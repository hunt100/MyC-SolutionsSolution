using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebApplication1.Migrations.MyWebApplication1IdentityDb
{
    public partial class addrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be7b0e27-a1d3-4cfa-9343-e9f967e94b8e", "6c331c88-96f2-46fc-9188-98622ac729b9", "ADMIN", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fe405f88-e15b-4613-bd35-989de6fe9921", "a8ef52e8-0278-4165-a961-d2af94ef9926", "USER", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f4506baa-d5c2-4f8f-9076-37946e75f6aa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be7b0e27-a1d3-4cfa-9343-e9f967e94b8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe405f88-e15b-4613-bd35-989de6fe9921");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "ed87e74d-a728-4ddd-b7b5-e4868e9107fd");
        }
    }
}
