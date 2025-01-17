using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Login.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alumni_group",
                columns: table => new
                {
                    G_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__alumni_group__3213E83F46A0C516", x => x.G_id);
                });

            migrationBuilder.CreateTable(
                name: "user_tbl",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    gender = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    year_of_graduation = table.Column<int>(type: "int", nullable: false),
                    batch_number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    linkedin_id = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    roll_num = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_tbl__3213E83F46A0C516", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_group",
                columns: table => new
                {
                    user_group_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    G_id = table.Column<int>(type: "int", nullable: false),
                    AlumniGroupG_id = table.Column<int>(type: "int", nullable: true),
                    UserTblId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_group__3213E83F46A0C516", x => x.user_group_id);
                    table.ForeignKey(
                        name: "FK_user_group_alumni_group_AlumniGroupG_id",
                        column: x => x.AlumniGroupG_id,
                        principalTable: "alumni_group",
                        principalColumn: "G_id");
                    table.ForeignKey(
                        name: "FK_user_group_alumni_group_G_id",
                        column: x => x.G_id,
                        principalTable: "alumni_group",
                        principalColumn: "G_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_group_user_tbl_UserTblId",
                        column: x => x.UserTblId,
                        principalTable: "user_tbl",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_group_user_tbl_id",
                        column: x => x.id,
                        principalTable: "user_tbl",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_group_AlumniGroupG_id",
                table: "user_group",
                column: "AlumniGroupG_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_group_G_id",
                table: "user_group",
                column: "G_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_group_id",
                table: "user_group",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_user_group_UserTblId",
                table: "user_group",
                column: "UserTblId");

            migrationBuilder.CreateIndex(
                name: "UQ__user_tbl__AB6E6164EB168A93",
                table: "user_tbl",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_group");

            migrationBuilder.DropTable(
                name: "alumni_group");

            migrationBuilder.DropTable(
                name: "user_tbl");
        }
    }
}
