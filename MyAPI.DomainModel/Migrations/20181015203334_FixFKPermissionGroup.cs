using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAPI.DomainModel.Migrations
{
    public partial class FixFKPermissionGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_link_perm_group_t_permission_id_permission_group",
                table: "t_link_perm_group");

            migrationBuilder.CreateIndex(
                name: "IX_t_link_perm_group_id_permission",
                table: "t_link_perm_group",
                column: "id_permission");

            migrationBuilder.AddForeignKey(
                name: "FK_t_link_perm_group_t_permission_id_permission",
                table: "t_link_perm_group",
                column: "id_permission",
                principalTable: "t_permission",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_link_perm_group_t_permission_id_permission",
                table: "t_link_perm_group");

            migrationBuilder.DropIndex(
                name: "IX_t_link_perm_group_id_permission",
                table: "t_link_perm_group");

            migrationBuilder.AddForeignKey(
                name: "FK_t_link_perm_group_t_permission_id_permission_group",
                table: "t_link_perm_group",
                column: "id_permission_group",
                principalTable: "t_permission",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
