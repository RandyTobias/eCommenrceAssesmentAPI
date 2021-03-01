using Microsoft.EntityFrameworkCore.Migrations;

namespace ecommerceassessment.Migrations
{
    public partial class UserType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "typeid",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accessLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_typeid",
                table: "Users",
                column: "typeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_typeid",
                table: "Users",
                column: "typeid",
                principalTable: "UserTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_typeid",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropIndex(
                name: "IX_Users_typeid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "typeid",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
