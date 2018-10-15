using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAPI.DomainModel.Migrations
{
    public partial class PermissionsSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_permission",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    num_type = table.Column<int>(nullable: false),
                    cd_level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_permission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_permission_group",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    txt_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_permission_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_user",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    txt_name = table.Column<string>(nullable: true),
                    txt_access_key = table.Column<string>(nullable: true),
                    txt_username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_link_perm_group",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_permission_group = table.Column<long>(nullable: false),
                    id_permission = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_link_perm_group", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_link_perm_group_t_permission_group_id_permission_group",
                        column: x => x.id_permission_group,
                        principalTable: "t_permission_group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_link_perm_group_t_permission_id_permission_group",
                        column: x => x.id_permission_group,
                        principalTable: "t_permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_link_group_user",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_permission_group = table.Column<long>(nullable: false),
                    id_user = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_link_group_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_link_group_user_t_permission_group_id_permission_group",
                        column: x => x.id_permission_group,
                        principalTable: "t_permission_group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_link_group_user_t_user_id_user",
                        column: x => x.id_user,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_link_group_user_id_permission_group",
                table: "t_link_group_user",
                column: "id_permission_group");

            migrationBuilder.CreateIndex(
                name: "IX_t_link_group_user_id_user",
                table: "t_link_group_user",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_t_link_perm_group_id_permission_group",
                table: "t_link_perm_group",
                column: "id_permission_group");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_link_group_user");

            migrationBuilder.DropTable(
                name: "t_link_perm_group");

            migrationBuilder.DropTable(
                name: "t_user");

            migrationBuilder.DropTable(
                name: "t_permission_group");

            migrationBuilder.DropTable(
                name: "t_permission");
        }
    }
}
