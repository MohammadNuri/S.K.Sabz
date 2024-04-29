using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S.K.Sabz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class category2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.CreateTable(
				name: "Categories",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					CategoryPicUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ParentCategoryId = table.Column<long>(type: "bigint", nullable: true),
					InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
					UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
					IsRemoved = table.Column<bool>(type: "bit", nullable: false),
					RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Categories", x => x.Id);
					table.ForeignKey(
						name: "FK_Categories_Categories_ParentCategoryId",
						column: x => x.ParentCategoryId,
						principalTable: "Categories",
						principalColumn: "Id");
				});
			migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2024, 4, 29, 16, 29, 51, 27, DateTimeKind.Local).AddTicks(4208));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2024, 4, 29, 16, 29, 51, 27, DateTimeKind.Local).AddTicks(4268));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2024, 4, 29, 16, 29, 51, 27, DateTimeKind.Local).AddTicks(4287));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2024, 4, 29, 16, 14, 46, 102, DateTimeKind.Local).AddTicks(642));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2024, 4, 29, 16, 14, 46, 102, DateTimeKind.Local).AddTicks(685));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2024, 4, 29, 16, 14, 46, 102, DateTimeKind.Local).AddTicks(697));
        }
    }
}
