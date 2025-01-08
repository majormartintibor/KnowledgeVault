using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace meShop.Modules.HR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "hr");

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "hr",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    first_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    last_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    identity_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                schema: "hr",
                columns: table => new
                {
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "hr",
                columns: table => new
                {
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "employee_roles",
                schema: "hr",
                columns: table => new
                {
                    employee_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_name = table.Column<string>(type: "character varying(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employee_roles", x => new { x.employee_id, x.role_name });
                    table.ForeignKey(
                        name: "fk_employee_roles_employees_employee_id",
                        column: x => x.employee_id,
                        principalSchema: "hr",
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_employee_roles_roles_roles_name",
                        column: x => x.role_name,
                        principalSchema: "hr",
                        principalTable: "roles",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role_permissions",
                schema: "hr",
                columns: table => new
                {
                    permission_code = table.Column<string>(type: "character varying(100)", nullable: false),
                    role_name = table.Column<string>(type: "character varying(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_permissions", x => new { x.permission_code, x.role_name });
                    table.ForeignKey(
                        name: "fk_role_permissions_permissions_permission_code",
                        column: x => x.permission_code,
                        principalSchema: "hr",
                        principalTable: "permissions",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_role_permissions_roles_role_name",
                        column: x => x.role_name,
                        principalSchema: "hr",
                        principalTable: "roles",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "hr",
                table: "permissions",
                column: "code",
                value: "example:read");

            migrationBuilder.InsertData(
                schema: "hr",
                table: "roles",
                column: "name",
                value: "Example");

            migrationBuilder.InsertData(
                schema: "hr",
                table: "role_permissions",
                columns: new[] { "permission_code", "role_name" },
                values: new object[] { "example:read", "Example" });

            migrationBuilder.CreateIndex(
                name: "ix_employee_roles_roles_name",
                schema: "hr",
                table: "employee_roles",
                column: "role_name");

            migrationBuilder.CreateIndex(
                name: "ix_employees_email",
                schema: "hr",
                table: "Employees",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_employees_identity_id",
                schema: "hr",
                table: "Employees",
                column: "identity_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_role_permissions_role_name",
                schema: "hr",
                table: "role_permissions",
                column: "role_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee_roles",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "role_permissions",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "permissions",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "hr");
        }
    }
}
