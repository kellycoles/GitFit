using Microsoft.EntityFrameworkCore.Migrations;

namespace GitFit.Migrations
{
    public partial class deleteConstraintRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Activity",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d0e277f8-1d8e-42d6-bfd5-172916ae3fed", "AQAAAAEAACcQAAAAEMTvPNURF5L/PO8ORXo32d149Abf+Gcopsv+FVOHuhWf0WZa83g/OYY02GvkmOoqmQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Activity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9a4c6f9c-8203-4b99-b15c-10c49f0a72f5", "AQAAAAEAACcQAAAAEM2iJtw2S2uFSpAeuC18+SRDualLvtMJ9kYMBd09dVxJ8+mb+6KB9gxHk5pmE92oRg==" });
        }
    }
}
