using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S.K.Sabz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class category : Migration
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
				value: new DateTime(2023, 9, 30, 2, 20, 12, 952, DateTimeKind.Local).AddTicks(8346));

			migrationBuilder.UpdateData(
				table: "Roles",
				keyColumn: "Id",
				keyValue: 2L,
				column: "InsertTime",
				value: new DateTime(2023, 9, 30, 2, 20, 12, 952, DateTimeKind.Local).AddTicks(8384));

			migrationBuilder.UpdateData(
				table: "Roles",
				keyColumn: "Id",
				keyValue: 3L,
				column: "InsertTime",
				value: new DateTime(2023, 9, 30, 2, 20, 12, 952, DateTimeKind.Local).AddTicks(8394));

			migrationBuilder.CreateIndex(
				name: "IX_Categories_ParentCategoryId",
				table: "Categories",
				column: "ParentCategoryId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Categories");

			migrationBuilder.UpdateData(
				table: "Roles",
				keyColumn: "Id",
				keyValue: 1L,
				column: "InsertTime",
				value: new DateTime(2023, 9, 28, 21, 26, 30, 532, DateTimeKind.Local).AddTicks(9116));

			migrationBuilder.UpdateData(
				table: "Roles",
				keyColumn: "Id",
				keyValue: 2L,
				column: "InsertTime",
				value: new DateTime(2023, 9, 28, 21, 26, 30, 532, DateTimeKind.Local).AddTicks(9161));

			migrationBuilder.UpdateData(
				table: "Roles",
				keyColumn: "Id",
				keyValue: 3L,
				column: "InsertTime",
				value: new DateTime(2023, 9, 28, 21, 26, 30, 532, DateTimeKind.Local).AddTicks(9170));
		}
	}
}
