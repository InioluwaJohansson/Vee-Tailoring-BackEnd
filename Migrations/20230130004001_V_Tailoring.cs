using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vee_Tailoring.Migrations;

public partial class V_Tailoring : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Users",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Users",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Users",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "UserRoles",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "UserRoles",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "UserRoles",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "UserDetails",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "UserDetails",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "UserDetails",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Templates",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Templates",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Templates",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Styles",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Styles",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Styles",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Staffs",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Staffs",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Staffs",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Roles",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Roles",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Roles",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Posts",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Posts",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Posts",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Patterns",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Patterns",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Patterns",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Orders",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Orders",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Orders",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "OrderMeasurements",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "OrderMeasurements",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "OrderMeasurements",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AddColumn<string>(
            name: "AnkleSize",
            table: "OrderMeasurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "ArmLength",
            table: "OrderMeasurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "ArmSize",
            table: "OrderMeasurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "BackWaist",
            table: "OrderMeasurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "BodyHeight",
            table: "OrderMeasurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "BurstGirth",
            table: "OrderMeasurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "FrontWaist",
            table: "OrderMeasurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "Head",
            table: "OrderMeasurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "HighHips",
            table: "OrderMeasurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "HipSize",
            table: "OrderMeasurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "LegLength",
            table: "OrderMeasurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "NeckSize",
            table: "OrderMeasurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "ShoulderWidth",
            table: "OrderMeasurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "ThirdQuarterLegLength",
            table: "OrderMeasurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "WaistSize",
            table: "OrderMeasurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "WristCircumfrence",
            table: "OrderMeasurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "OrderAddresses",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "OrderAddresses",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "OrderAddresses",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Measurements",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Measurements",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Measurements",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AddColumn<string>(
            name: "AnkleSize",
            table: "Measurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "ArmLength",
            table: "Measurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "ArmSize",
            table: "Measurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "BackWaist",
            table: "Measurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "BodyHeight",
            table: "Measurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "BurstGirth",
            table: "Measurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "FrontWaist",
            table: "Measurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "Head",
            table: "Measurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "HighHips",
            table: "Measurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "HipSize",
            table: "Measurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "LegLength",
            table: "Measurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "NeckSize",
            table: "Measurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "ShoulderWidth",
            table: "Measurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "ThirdQuarterLegLength",
            table: "Measurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "WaistSize",
            table: "Measurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
            name: "WristCircumfrence",
            table: "Measurements",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Materials",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Materials",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Materials",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "DefaultPrices",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "DefaultPrices",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "DefaultPrices",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Customers",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Customers",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Customers",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Complaints",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Complaints",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Complaints",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Comments",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Comments",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Comments",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Colors",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Colors",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Colors",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "ClothGender",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "ClothGender",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "ClothGender",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "ClothCategories",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "ClothCategories",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "ClothCategories",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Categories",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Categories",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Categories",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "ArmTypes",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "ArmTypes",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "ArmTypes",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Addresses",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Addresses",
            type: "datetime(6)",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Addresses",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "AnkleSize",
            table: "OrderMeasurements");

        migrationBuilder.DropColumn(
            name: "ArmLength",
            table: "OrderMeasurements");

        migrationBuilder.DropColumn(
            name: "ArmSize",
            table: "OrderMeasurements");

        migrationBuilder.DropColumn(
            name: "BackWaist",
            table: "OrderMeasurements");

        migrationBuilder.DropColumn(
            name: "BodyHeight",
            table: "OrderMeasurements");

        migrationBuilder.DropColumn(
            name: "BurstGirth",
            table: "OrderMeasurements");

        migrationBuilder.DropColumn(
            name: "FrontWaist",
            table: "OrderMeasurements");

        migrationBuilder.DropColumn(
            name: "Head",
            table: "OrderMeasurements");

        migrationBuilder.DropColumn(
            name: "HighHips",
            table: "OrderMeasurements");

        migrationBuilder.DropColumn(
            name: "HipSize",
            table: "OrderMeasurements");

        migrationBuilder.DropColumn(
            name: "LegLength",
            table: "OrderMeasurements");

        migrationBuilder.DropColumn(
            name: "NeckSize",
            table: "OrderMeasurements");

        migrationBuilder.DropColumn(
            name: "ShoulderWidth",
            table: "OrderMeasurements");

        migrationBuilder.DropColumn(
            name: "ThirdQuarterLegLength",
            table: "OrderMeasurements");

        migrationBuilder.DropColumn(
            name: "WaistSize",
            table: "OrderMeasurements");

        migrationBuilder.DropColumn(
            name: "WristCircumfrence",
            table: "OrderMeasurements");

        migrationBuilder.DropColumn(
            name: "AnkleSize",
            table: "Measurements");

        migrationBuilder.DropColumn(
            name: "ArmLength",
            table: "Measurements");

        migrationBuilder.DropColumn(
            name: "ArmSize",
            table: "Measurements");

        migrationBuilder.DropColumn(
            name: "BackWaist",
            table: "Measurements");

        migrationBuilder.DropColumn(
            name: "BodyHeight",
            table: "Measurements");

        migrationBuilder.DropColumn(
            name: "BurstGirth",
            table: "Measurements");

        migrationBuilder.DropColumn(
            name: "FrontWaist",
            table: "Measurements");

        migrationBuilder.DropColumn(
            name: "Head",
            table: "Measurements");

        migrationBuilder.DropColumn(
            name: "HighHips",
            table: "Measurements");

        migrationBuilder.DropColumn(
            name: "HipSize",
            table: "Measurements");

        migrationBuilder.DropColumn(
            name: "LegLength",
            table: "Measurements");

        migrationBuilder.DropColumn(
            name: "NeckSize",
            table: "Measurements");

        migrationBuilder.DropColumn(
            name: "ShoulderWidth",
            table: "Measurements");

        migrationBuilder.DropColumn(
            name: "ThirdQuarterLegLength",
            table: "Measurements");

        migrationBuilder.DropColumn(
            name: "WaistSize",
            table: "Measurements");

        migrationBuilder.DropColumn(
            name: "WristCircumfrence",
            table: "Measurements");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Users",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Users",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Users",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "UserRoles",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "UserRoles",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "UserRoles",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "UserDetails",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "UserDetails",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "UserDetails",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Templates",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Templates",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Templates",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Styles",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Styles",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Styles",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Staffs",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Staffs",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Staffs",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Roles",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Roles",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Roles",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Posts",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Posts",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Posts",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Patterns",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Patterns",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Patterns",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Orders",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Orders",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Orders",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "OrderMeasurements",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "OrderMeasurements",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "OrderMeasurements",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "OrderAddresses",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "OrderAddresses",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "OrderAddresses",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Measurements",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Measurements",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Measurements",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Materials",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Materials",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Materials",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "DefaultPrices",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "DefaultPrices",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "DefaultPrices",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Customers",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Customers",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Customers",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Complaints",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Complaints",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Complaints",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Comments",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Comments",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Comments",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Colors",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Colors",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Colors",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "ClothGender",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "ClothGender",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "ClothGender",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "ClothCategories",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "ClothCategories",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "ClothCategories",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Categories",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Categories",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Categories",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "ArmTypes",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "ArmTypes",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "ArmTypes",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "LastModifiedOn",
            table: "Addresses",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DeletedOn",
            table: "Addresses",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<int>(
            name: "DeletedBy",
            table: "Addresses",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");
    }
}
