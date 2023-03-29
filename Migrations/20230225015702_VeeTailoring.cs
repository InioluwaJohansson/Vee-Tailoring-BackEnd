using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vee_Tailoring.Migrations;

public partial class VeeTailoring : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "CollectionId",
            table: "Templates",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.CreateTable(
            name: "Collections",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                CollectionId = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CollectionName = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ClothGenderId = table.Column<int>(type: "int", nullable: false),
                ClothCategoryId = table.Column<int>(type: "int", nullable: false),
                Pieces = table.Column<int>(type: "int", nullable: false),
                Price = table.Column<double>(type: "double", nullable: false),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                DeletedBy = table.Column<int>(type: "int", nullable: false),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Collections", x => x.Id);
                table.ForeignKey(
                    name: "FK_Collections_ClothCategories_ClothCategoryId",
                    column: x => x.ClothCategoryId,
                    principalTable: "ClothCategories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Collections_ClothGender_ClothGenderId",
                    column: x => x.ClothGenderId,
                    principalTable: "ClothGender",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateIndex(
            name: "IX_Templates_CollectionId",
            table: "Templates",
            column: "CollectionId",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Collections_ClothCategoryId",
            table: "Collections",
            column: "ClothCategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_Collections_ClothGenderId",
            table: "Collections",
            column: "ClothGenderId");

        migrationBuilder.AddForeignKey(
            name: "FK_Templates_Collections_CollectionId",
            table: "Templates",
            column: "CollectionId",
            principalTable: "Collections",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Templates_Collections_CollectionId",
            table: "Templates");

        migrationBuilder.DropTable(
            name: "Collections");

        migrationBuilder.DropIndex(
            name: "IX_Templates_CollectionId",
            table: "Templates");

        migrationBuilder.DropColumn(
            name: "CollectionId",
            table: "Templates");
    }
}
