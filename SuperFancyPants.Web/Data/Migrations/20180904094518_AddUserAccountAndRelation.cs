using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperFancyPants.Web.Data.Migrations
{
    public partial class AddUserAccountAndRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Todos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserAccountId",
                table: "Todos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Todos_UserAccountId",
                table: "Todos",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_AspNetUsers_UserAccountId",
                table: "Todos",
                column: "UserAccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_AspNetUsers_UserAccountId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_UserAccountId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");
        }
    }
}
