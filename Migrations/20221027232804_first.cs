using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vee_Tailoring.Migrations;

public partial class first : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Addresses",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                NumberLine = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Street = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                City = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Region = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                State = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Country = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                PostalCode = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Addresses", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "ArmTypes",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                ArmLength = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ArmTypes", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Categories",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                CategoryName = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CategoryDescription = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Categories", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "ClothCategories",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                ClothName = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClothCategories", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "ClothGender",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Gender = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClothGender", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Colors",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                ColorName = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ColorCode = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Colors", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Complaints",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Email = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Description = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                IsSolved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Complaints", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "DefaultPrices",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                PriceName = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DefaultPrices", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Materials",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                MaterialName = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                MaterialUrl = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                MaterialPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Materials", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Measurements",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Measurements", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "OrderAddresses",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                NumberLine = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Street = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                City = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Region = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                State = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Country = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                PostalCode = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OrderAddresses", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Roles",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Name = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Description = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Roles", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                UserName = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Email = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Password = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "UserDetails",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                FirstName = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                LastName = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Gender = table.Column<int>(type: "int", nullable: false),
                ImageUrl = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                AddressId = table.Column<int>(type: "int", nullable: false),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserDetails", x => x.Id);
                table.ForeignKey(
                    name: "FK_UserDetails_Addresses_AddressId",
                    column: x => x.AddressId,
                    principalTable: "Addresses",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Patterns",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                PatternName = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                PatternUrl = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ClothCategoryId = table.Column<int>(type: "int", nullable: false),
                ClothGenderId = table.Column<int>(type: "int", nullable: false),
                PatternPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Patterns", x => x.Id);
                table.ForeignKey(
                    name: "FK_Patterns_ClothCategories_ClothCategoryId",
                    column: x => x.ClothCategoryId,
                    principalTable: "ClothCategories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Patterns_ClothGender_ClothGenderId",
                    column: x => x.ClothGenderId,
                    principalTable: "ClothGender",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Styles",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                StyleId = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                StyleName = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                StyleUrl = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ClothCategoryId = table.Column<int>(type: "int", nullable: false),
                ClothGenderId = table.Column<int>(type: "int", nullable: false),
                StylePrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                IsApproved = table.Column<bool>(type: "tinyint(1)", nullable: true),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Styles", x => x.Id);
                table.ForeignKey(
                    name: "FK_Styles_ClothCategories_ClothCategoryId",
                    column: x => x.ClothCategoryId,
                    principalTable: "ClothCategories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Styles_ClothGender_ClothGenderId",
                    column: x => x.ClothGenderId,
                    principalTable: "ClothGender",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "OrderMeasurements",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                DefaultPriceId = table.Column<int>(type: "int", nullable: false),
                OrderId = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OrderMeasurements", x => x.Id);
                table.ForeignKey(
                    name: "FK_OrderMeasurements_DefaultPrices_DefaultPriceId",
                    column: x => x.DefaultPriceId,
                    principalTable: "DefaultPrices",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "UserRoles",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                UserId = table.Column<int>(type: "int", nullable: false),
                RoleId = table.Column<int>(type: "int", nullable: false),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserRoles", x => x.Id);
                table.ForeignKey(
                    name: "FK_UserRoles_Roles_RoleId",
                    column: x => x.RoleId,
                    principalTable: "Roles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_UserRoles_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Customers",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                UserId = table.Column<int>(type: "int", nullable: false),
                UserDetailsId = table.Column<int>(type: "int", nullable: false),
                CustomerNo = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                MeasurementsId = table.Column<int>(type: "int", nullable: false),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Customers", x => x.Id);
                table.ForeignKey(
                    name: "FK_Customers_Measurements_MeasurementsId",
                    column: x => x.MeasurementsId,
                    principalTable: "Measurements",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Customers_UserDetails_UserDetailsId",
                    column: x => x.UserDetailsId,
                    principalTable: "UserDetails",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Customers_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Staffs",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                UserDetailsId = table.Column<int>(type: "int", nullable: false),
                UserId = table.Column<int>(type: "int", nullable: false),
                StaffNo = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Staffs", x => x.Id);
                table.ForeignKey(
                    name: "FK_Staffs_UserDetails_UserDetailsId",
                    column: x => x.UserDetailsId,
                    principalTable: "UserDetails",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Staffs_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Templates",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                TemplateId = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TemplateName = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ClothGenderId = table.Column<int>(type: "int", nullable: false),
                ClothCategoryId = table.Column<int>(type: "int", nullable: false),
                StyleId = table.Column<int>(type: "int", nullable: false),
                PatternId = table.Column<int>(type: "int", nullable: false),
                ColorId = table.Column<int>(type: "int", nullable: false),
                MaterialId = table.Column<int>(type: "int", nullable: false),
                ArmTypeId = table.Column<int>(type: "int", nullable: false),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Templates", x => x.Id);
                table.ForeignKey(
                    name: "FK_Templates_ArmTypes_ArmTypeId",
                    column: x => x.ArmTypeId,
                    principalTable: "ArmTypes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Templates_ClothCategories_ClothCategoryId",
                    column: x => x.ClothCategoryId,
                    principalTable: "ClothCategories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Templates_ClothGender_ClothGenderId",
                    column: x => x.ClothGenderId,
                    principalTable: "ClothGender",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Templates_Colors_ColorId",
                    column: x => x.ColorId,
                    principalTable: "Colors",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Templates_Materials_MaterialId",
                    column: x => x.MaterialId,
                    principalTable: "Materials",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Templates_Patterns_PatternId",
                    column: x => x.PatternId,
                    principalTable: "Patterns",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Templates_Styles_StyleId",
                    column: x => x.StyleId,
                    principalTable: "Styles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Orders",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                OrderId = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ClothGenderId = table.Column<int>(type: "int", nullable: false),
                ClothCategoryId = table.Column<int>(type: "int", nullable: false),
                OrderPerson = table.Column<int>(type: "int", nullable: false),
                Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                Pieces = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                CustomerId = table.Column<int>(type: "int", nullable: false),
                OrderAddressId = table.Column<int>(type: "int", nullable: false),
                StyleId = table.Column<int>(type: "int", nullable: false),
                OrderMeasurementId = table.Column<int>(type: "int", nullable: false),
                PatternId = table.Column<int>(type: "int", nullable: false),
                ColorId = table.Column<int>(type: "int", nullable: false),
                MaterialId = table.Column<int>(type: "int", nullable: false),
                ArmTypeId = table.Column<int>(type: "int", nullable: false),
                StaffId = table.Column<int>(type: "int", nullable: false),
                CompletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                IsCompleted = table.Column<int>(type: "int", nullable: false),
                IsPaid = table.Column<int>(type: "int", nullable: false),
                AddToCart = table.Column<bool>(type: "tinyint(1)", nullable: false),
                IsAssigned = table.Column<bool>(type: "tinyint(1)", nullable: false),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Orders", x => x.Id);
                table.ForeignKey(
                    name: "FK_Orders_ArmTypes_ArmTypeId",
                    column: x => x.ArmTypeId,
                    principalTable: "ArmTypes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Orders_ClothCategories_ClothCategoryId",
                    column: x => x.ClothCategoryId,
                    principalTable: "ClothCategories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Orders_ClothGender_ClothGenderId",
                    column: x => x.ClothGenderId,
                    principalTable: "ClothGender",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Orders_Colors_ColorId",
                    column: x => x.ColorId,
                    principalTable: "Colors",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Orders_Customers_CustomerId",
                    column: x => x.CustomerId,
                    principalTable: "Customers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Orders_Materials_MaterialId",
                    column: x => x.MaterialId,
                    principalTable: "Materials",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Orders_OrderAddresses_OrderAddressId",
                    column: x => x.OrderAddressId,
                    principalTable: "OrderAddresses",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Orders_OrderMeasurements_OrderMeasurementId",
                    column: x => x.OrderMeasurementId,
                    principalTable: "OrderMeasurements",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Orders_Patterns_PatternId",
                    column: x => x.PatternId,
                    principalTable: "Patterns",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Orders_Staffs_StaffId",
                    column: x => x.StaffId,
                    principalTable: "Staffs",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Orders_Styles_StyleId",
                    column: x => x.StyleId,
                    principalTable: "Styles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Posts",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                CategoryId = table.Column<int>(type: "int", nullable: false),
                PostTitle = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                PostImage = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                PostDescription = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                PublishDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                ReadTime = table.Column<int>(type: "int", nullable: false),
                Likes = table.Column<int>(type: "int", nullable: false),
                StaffId = table.Column<int>(type: "int", nullable: false),
                IsApproved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Posts", x => x.Id);
                table.ForeignKey(
                    name: "FK_Posts_Categories_CategoryId",
                    column: x => x.CategoryId,
                    principalTable: "Categories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Posts_Staffs_StaffId",
                    column: x => x.StaffId,
                    principalTable: "Staffs",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Comments",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                PostId = table.Column<int>(type: "int", nullable: false),
                CustomerId = table.Column<int>(type: "int", nullable: false),
                Comments = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Likes = table.Column<int>(type: "int", nullable: false),
                CommentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                CreatedBy = table.Column<int>(type: "int", nullable: false),
                CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                LastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                DeletedBy = table.Column<int>(type: "int", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Comments", x => x.Id);
                table.ForeignKey(
                    name: "FK_Comments_Customers_CustomerId",
                    column: x => x.CustomerId,
                    principalTable: "Customers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Comments_Posts_PostId",
                    column: x => x.PostId,
                    principalTable: "Posts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateIndex(
            name: "IX_Comments_CustomerId",
            table: "Comments",
            column: "CustomerId");

        migrationBuilder.CreateIndex(
            name: "IX_Comments_PostId",
            table: "Comments",
            column: "PostId");

        migrationBuilder.CreateIndex(
            name: "IX_Customers_MeasurementsId",
            table: "Customers",
            column: "MeasurementsId");

        migrationBuilder.CreateIndex(
            name: "IX_Customers_UserDetailsId",
            table: "Customers",
            column: "UserDetailsId");

        migrationBuilder.CreateIndex(
            name: "IX_Customers_UserId",
            table: "Customers",
            column: "UserId",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_OrderMeasurements_DefaultPriceId",
            table: "OrderMeasurements",
            column: "DefaultPriceId");

        migrationBuilder.CreateIndex(
            name: "IX_Orders_ArmTypeId",
            table: "Orders",
            column: "ArmTypeId");

        migrationBuilder.CreateIndex(
            name: "IX_Orders_ClothCategoryId",
            table: "Orders",
            column: "ClothCategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_Orders_ClothGenderId",
            table: "Orders",
            column: "ClothGenderId");

        migrationBuilder.CreateIndex(
            name: "IX_Orders_ColorId",
            table: "Orders",
            column: "ColorId");

        migrationBuilder.CreateIndex(
            name: "IX_Orders_CustomerId",
            table: "Orders",
            column: "CustomerId");

        migrationBuilder.CreateIndex(
            name: "IX_Orders_MaterialId",
            table: "Orders",
            column: "MaterialId");

        migrationBuilder.CreateIndex(
            name: "IX_Orders_OrderAddressId",
            table: "Orders",
            column: "OrderAddressId");

        migrationBuilder.CreateIndex(
            name: "IX_Orders_OrderMeasurementId",
            table: "Orders",
            column: "OrderMeasurementId");

        migrationBuilder.CreateIndex(
            name: "IX_Orders_PatternId",
            table: "Orders",
            column: "PatternId");

        migrationBuilder.CreateIndex(
            name: "IX_Orders_StaffId",
            table: "Orders",
            column: "StaffId");

        migrationBuilder.CreateIndex(
            name: "IX_Orders_StyleId",
            table: "Orders",
            column: "StyleId");

        migrationBuilder.CreateIndex(
            name: "IX_Patterns_ClothCategoryId",
            table: "Patterns",
            column: "ClothCategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_Patterns_ClothGenderId",
            table: "Patterns",
            column: "ClothGenderId");

        migrationBuilder.CreateIndex(
            name: "IX_Posts_CategoryId",
            table: "Posts",
            column: "CategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_Posts_StaffId",
            table: "Posts",
            column: "StaffId");

        migrationBuilder.CreateIndex(
            name: "IX_Staffs_UserDetailsId",
            table: "Staffs",
            column: "UserDetailsId");

        migrationBuilder.CreateIndex(
            name: "IX_Staffs_UserId",
            table: "Staffs",
            column: "UserId",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Styles_ClothCategoryId",
            table: "Styles",
            column: "ClothCategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_Styles_ClothGenderId",
            table: "Styles",
            column: "ClothGenderId");

        migrationBuilder.CreateIndex(
            name: "IX_Templates_ArmTypeId",
            table: "Templates",
            column: "ArmTypeId");

        migrationBuilder.CreateIndex(
            name: "IX_Templates_ClothCategoryId",
            table: "Templates",
            column: "ClothCategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_Templates_ClothGenderId",
            table: "Templates",
            column: "ClothGenderId");

        migrationBuilder.CreateIndex(
            name: "IX_Templates_ColorId",
            table: "Templates",
            column: "ColorId");

        migrationBuilder.CreateIndex(
            name: "IX_Templates_MaterialId",
            table: "Templates",
            column: "MaterialId");

        migrationBuilder.CreateIndex(
            name: "IX_Templates_PatternId",
            table: "Templates",
            column: "PatternId");

        migrationBuilder.CreateIndex(
            name: "IX_Templates_StyleId",
            table: "Templates",
            column: "StyleId");

        migrationBuilder.CreateIndex(
            name: "IX_UserDetails_AddressId",
            table: "UserDetails",
            column: "AddressId");

        migrationBuilder.CreateIndex(
            name: "IX_UserRoles_RoleId",
            table: "UserRoles",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            name: "IX_UserRoles_UserId",
            table: "UserRoles",
            column: "UserId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Comments");

        migrationBuilder.DropTable(
            name: "Complaints");

        migrationBuilder.DropTable(
            name: "Orders");

        migrationBuilder.DropTable(
            name: "Templates");

        migrationBuilder.DropTable(
            name: "UserRoles");

        migrationBuilder.DropTable(
            name: "Posts");

        migrationBuilder.DropTable(
            name: "Customers");

        migrationBuilder.DropTable(
            name: "OrderAddresses");

        migrationBuilder.DropTable(
            name: "OrderMeasurements");

        migrationBuilder.DropTable(
            name: "ArmTypes");

        migrationBuilder.DropTable(
            name: "Colors");

        migrationBuilder.DropTable(
            name: "Materials");

        migrationBuilder.DropTable(
            name: "Patterns");

        migrationBuilder.DropTable(
            name: "Styles");

        migrationBuilder.DropTable(
            name: "Roles");

        migrationBuilder.DropTable(
            name: "Categories");

        migrationBuilder.DropTable(
            name: "Staffs");

        migrationBuilder.DropTable(
            name: "Measurements");

        migrationBuilder.DropTable(
            name: "DefaultPrices");

        migrationBuilder.DropTable(
            name: "ClothCategories");

        migrationBuilder.DropTable(
            name: "ClothGender");

        migrationBuilder.DropTable(
            name: "UserDetails");

        migrationBuilder.DropTable(
            name: "Users");

        migrationBuilder.DropTable(
            name: "Addresses");
    }
}
