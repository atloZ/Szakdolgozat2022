using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UPDF.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Auth");

            migrationBuilder.EnsureSchema(
                name: "Nevezes");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "Auth");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "Auth");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "Auth");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "Auth");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "Auth");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "Auth");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "Auth");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                schema: "Auth",
                table: "AspNetUsers",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Auth",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Auth",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Auth",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                schema: "Auth",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsernameChangeLimit",
                schema: "Auth",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Csapat",
                schema: "Nevezes",
                columns: table => new
                {
                    Azon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Csapat", x => x.Azon);
                });

            migrationBuilder.CreateTable(
                name: "Egyesulet",
                schema: "Nevezes",
                columns: table => new
                {
                    Azon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nev = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rovidites = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egyesulet", x => x.Azon);
                });

            migrationBuilder.CreateTable(
                name: "Kategora",
                schema: "Nevezes",
                columns: table => new
                {
                    Azon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Megnevezes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategora", x => x.Azon);
                });

            migrationBuilder.CreateTable(
                name: "Korcsoport",
                schema: "Nevezes",
                columns: table => new
                {
                    Azon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Megnevezes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Minimum = table.Column<int>(type: "int", nullable: false),
                    Maximum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korcsoport", x => x.Azon);
                });

            migrationBuilder.CreateTable(
                name: "VersenySzam",
                schema: "Nevezes",
                columns: table => new
                {
                    Azon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Megnevezes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Letszam = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersenySzam", x => x.Azon);
                });

            migrationBuilder.CreateTable(
                name: "Versenyzo",
                schema: "Nevezes",
                columns: table => new
                {
                    Sir_Azon = table.Column<int>(type: "int", nullable: false),
                    Egyesulet_Azon = table.Column<int>(type: "int", nullable: false),
                    Nev = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SzulHely = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SzulDatum = table.Column<DateTime>(type: "date", nullable: false),
                    EngedelySzam = table.Column<int>(type: "int", nullable: false),
                    EngedelyErv = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versenyzo", x => x.Sir_Azon);
                    table.ForeignKey(
                        name: "FK_Versenyzo_Egyesulet",
                        column: x => x.Egyesulet_Azon,
                        principalSchema: "Nevezes",
                        principalTable: "Egyesulet",
                        principalColumn: "Azon");
                });

            migrationBuilder.CreateTable(
                name: "Nevezes",
                schema: "Nevezes",
                columns: table => new
                {
                    Azon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KoreoCim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Versenyzo_Azon = table.Column<int>(type: "int", nullable: false),
                    Korcsoport_Azon = table.Column<int>(type: "int", nullable: false),
                    Kategoria_Azon = table.Column<int>(type: "int", nullable: false),
                    VersenySzam_Azon = table.Column<int>(type: "int", nullable: false),
                    Csapat_Azon = table.Column<int>(type: "int", nullable: false),
                    ZenePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rogzito_Azon = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nevezes", x => x.Azon);
                    table.ForeignKey(
                        name: "FK_Nevezes_Csapat",
                        column: x => x.Csapat_Azon,
                        principalSchema: "Nevezes",
                        principalTable: "Csapat",
                        principalColumn: "Azon");
                    table.ForeignKey(
                        name: "FK_Nevezes_Felhasznalo",
                        column: x => x.Rogzito_Azon,
                        principalSchema: "Auth",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nevezes_Kategoria",
                        column: x => x.Kategoria_Azon,
                        principalSchema: "Nevezes",
                        principalTable: "Kategora",
                        principalColumn: "Azon");
                    table.ForeignKey(
                        name: "FK_Nevezes_Korcsoport",
                        column: x => x.Korcsoport_Azon,
                        principalSchema: "Nevezes",
                        principalTable: "Korcsoport",
                        principalColumn: "Azon");
                    table.ForeignKey(
                        name: "FK_Nevezes_VersenySzam",
                        column: x => x.VersenySzam_Azon,
                        principalSchema: "Nevezes",
                        principalTable: "VersenySzam",
                        principalColumn: "Azon");
                    table.ForeignKey(
                        name: "FK_Nevezes_Versenyzo",
                        column: x => x.Versenyzo_Azon,
                        principalSchema: "Nevezes",
                        principalTable: "Versenyzo",
                        principalColumn: "Sir_Azon");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nevezes_Csapat_Azon",
                schema: "Nevezes",
                table: "Nevezes",
                column: "Csapat_Azon");

            migrationBuilder.CreateIndex(
                name: "IX_Nevezes_Kategoria_Azon",
                schema: "Nevezes",
                table: "Nevezes",
                column: "Kategoria_Azon");

            migrationBuilder.CreateIndex(
                name: "IX_Nevezes_Korcsoport_Azon",
                schema: "Nevezes",
                table: "Nevezes",
                column: "Korcsoport_Azon");

            migrationBuilder.CreateIndex(
                name: "IX_Nevezes_Rogzito_Azon",
                schema: "Nevezes",
                table: "Nevezes",
                column: "Rogzito_Azon");

            migrationBuilder.CreateIndex(
                name: "IX_Nevezes_VersenySzam_Azon",
                schema: "Nevezes",
                table: "Nevezes",
                column: "VersenySzam_Azon");

            migrationBuilder.CreateIndex(
                name: "IX_Nevezes_Versenyzo_Azon",
                schema: "Nevezes",
                table: "Nevezes",
                column: "Versenyzo_Azon");

            migrationBuilder.CreateIndex(
                name: "IX_Versenyzo",
                schema: "Nevezes",
                table: "Versenyzo",
                column: "Sir_Azon");

            migrationBuilder.CreateIndex(
                name: "IX_Versenyzo_Egyesulet_Azon",
                schema: "Nevezes",
                table: "Versenyzo",
                column: "Egyesulet_Azon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nevezes",
                schema: "Nevezes");

            migrationBuilder.DropTable(
                name: "Csapat",
                schema: "Nevezes");

            migrationBuilder.DropTable(
                name: "Kategora",
                schema: "Nevezes");

            migrationBuilder.DropTable(
                name: "Korcsoport",
                schema: "Nevezes");

            migrationBuilder.DropTable(
                name: "VersenySzam",
                schema: "Nevezes");

            migrationBuilder.DropTable(
                name: "Versenyzo",
                schema: "Nevezes");

            migrationBuilder.DropTable(
                name: "Egyesulet",
                schema: "Nevezes");

            migrationBuilder.DropColumn(
                name: "Birthday",
                schema: "Auth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Auth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Auth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Auth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                schema: "Auth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UsernameChangeLimit",
                schema: "Auth",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "Auth",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "Auth",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "Auth",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "Auth",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "Auth",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "Auth",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "Auth",
                newName: "AspNetRoleClaims");
        }
    }
}