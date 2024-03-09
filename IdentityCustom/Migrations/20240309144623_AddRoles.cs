using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityCustom.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "47EF3A46-9883-466A-969F-0C00975435D3", "AA6452D8-71F6-4E0D-B4E2-ED95438B57DC", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "65440C38-984A-4145-BCE1-4142A3722487", "A9B1C55C-B3E0-4AF0-AB41-CD9018B327F4", "Klient", "KLIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "DFA9AFA8-B475-451E-A77A-ACC97C647820", "B4AC058E-CAE2-4BD4-A236-9D3AA7B9BA37", "Pracownik", "PRACOWNIK" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47EF3A46-9883-466A-969F-0C00975435D3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65440C38-984A-4145-BCE1-4142A3722487");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "DFA9AFA8-B475-451E-A77A-ACC97C647820");
        }
    }
}
