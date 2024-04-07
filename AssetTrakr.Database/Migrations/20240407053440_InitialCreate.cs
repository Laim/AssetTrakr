using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssetTrakr.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionLogEntries",
                columns: table => new
                {
                    ActionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActionName = table.Column<string>(type: "TEXT", nullable: false),
                    ActionCategory = table.Column<int>(type: "INTEGER", nullable: false),
                    ActionType = table.Column<int>(type: "INTEGER", nullable: false),
                    ActionTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", nullable: false),
                    ActionBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLogEntries", x => x.ActionId);
                });

            migrationBuilder.CreateTable(
                name: "AssetHardware",
                columns: table => new
                {
                    AssetHardwareId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Processor = table.Column<string>(type: "TEXT", nullable: true),
                    RamSizeInGB = table.Column<int>(type: "INTEGER", nullable: false),
                    RamSticks = table.Column<int>(type: "INTEGER", nullable: false),
                    BiosSerialNumber = table.Column<string>(type: "TEXT", nullable: true),
                    AssetType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetHardware", x => x.AssetHardwareId);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    AttachmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<byte[]>(type: "BLOB", nullable: true),
                    DataType = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    IsUrl = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.AttachmentId);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    OrderRef = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaymentFrequency = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    SupportUrl = table.Column<string>(type: "TEXT", nullable: true),
                    SupportEmail = table.Column<string>(type: "TEXT", nullable: true),
                    SupportPhone = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    PeriodId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.PeriodId);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShortCode = table.Column<string>(type: "TEXT", nullable: false, comment: "ShortCode used at run time for getting reports since ReportId is never guranteed to be the same"),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    HasCriteria = table.Column<bool>(type: "INTEGER", nullable: false, comment: "Whether or not the report has criteria that can be used during run time"),
                    ParentType = table.Column<string>(type: "TEXT", nullable: false, comment: "The type of report, i.e Asset, License etc.  Uses ParentType enum in c#.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                });

            migrationBuilder.CreateTable(
                name: "SystemInfo",
                columns: table => new
                {
                    SysId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    ProductVersion = table.Column<string>(type: "TEXT", nullable: false),
                    DatabaseCreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RunDirectory = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemInfo", x => x.SysId);
                });

            migrationBuilder.CreateTable(
                name: "SystemSettings",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    SettingParentType = table.Column<string>(type: "TEXT", nullable: false),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    DefaultEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    SettingValue = table.Column<string>(type: "TEXT", nullable: true),
                    DefaultSettingValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettings", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "AssetNetworkAdapters",
                columns: table => new
                {
                    NetworkAdapterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssetHardwareId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IpAddress = table.Column<string>(type: "TEXT", nullable: false),
                    MacAddress = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetNetworkAdapters", x => x.NetworkAdapterId);
                    table.ForeignKey(
                        name: "FK_AssetNetworkAdapters_AssetHardware_AssetHardwareId",
                        column: x => x.AssetHardwareId,
                        principalTable: "AssetHardware",
                        principalColumn: "AssetHardwareId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractAttachments",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttachmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractAttachments", x => new { x.ContractId, x.AttachmentId });
                    table.ForeignKey(
                        name: "FK_ContractAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "AttachmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractAttachments_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetHardDrives",
                columns: table => new
                {
                    HardDriveId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssetHardwareId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    SerialNumber = table.Column<string>(type: "TEXT", nullable: true),
                    SizeInGB = table.Column<int>(type: "INTEGER", nullable: false),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetHardDrives", x => x.HardDriveId);
                    table.ForeignKey(
                        name: "FK_AssetHardDrives_AssetHardware_AssetHardwareId",
                        column: x => x.AssetHardwareId,
                        principalTable: "AssetHardware",
                        principalColumn: "AssetHardwareId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetHardDrives_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId");
                });

            migrationBuilder.CreateTable(
                name: "AssetOperatingSystems",
                columns: table => new
                {
                    OperatingSystemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetOperatingSystems", x => x.OperatingSystemId);
                    table.ForeignKey(
                        name: "FK_AssetOperatingSystems_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    PlatformId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.PlatformId);
                    table.ForeignKey(
                        name: "FK_Platforms_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractPeriods",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "INTEGER", nullable: false),
                    PeriodId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractPeriods", x => new { x.ContractId, x.PeriodId });
                    table.ForeignKey(
                        name: "FK_ContractPeriods_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractPeriods_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "PeriodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    LicenseKey = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    PurchaseDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    RegisteredUser = table.Column<string>(type: "TEXT", nullable: true),
                    RegisteredEmail = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    OrderReference = table.Column<string>(type: "TEXT", nullable: true),
                    IsUnderWarranty = table.Column<bool>(type: "INTEGER", nullable: false),
                    OperatingSystemId = table.Column<int>(type: "INTEGER", nullable: true),
                    HardwareId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContractId = table.Column<int>(type: "INTEGER", nullable: true),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: true),
                    PlatformId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_Assets_AssetHardware_HardwareId",
                        column: x => x.HardwareId,
                        principalTable: "AssetHardware",
                        principalColumn: "AssetHardwareId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_AssetOperatingSystems_OperatingSystemId",
                        column: x => x.OperatingSystemId,
                        principalTable: "AssetOperatingSystems",
                        principalColumn: "OperatingSystemId");
                    table.ForeignKey(
                        name: "FK_Assets_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId");
                    table.ForeignKey(
                        name: "FK_Assets_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId");
                    table.ForeignKey(
                        name: "FK_Assets_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "PlatformId");
                });

            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    PurchaseDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    IsSubscription = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsSubscriptionContract = table.Column<bool>(type: "INTEGER", nullable: false),
                    PaymentFrequency = table.Column<string>(type: "TEXT", nullable: false),
                    ContractId = table.Column<int>(type: "INTEGER", nullable: true),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    OrderReference = table.Column<string>(type: "TEXT", nullable: true),
                    Vendor = table.Column<string>(type: "TEXT", nullable: true),
                    Version = table.Column<string>(type: "TEXT", nullable: true),
                    PlatformId = table.Column<int>(type: "INTEGER", nullable: false),
                    RegisteredUser = table.Column<string>(type: "TEXT", nullable: true),
                    RegisteredEmail = table.Column<string>(type: "TEXT", nullable: true),
                    LicenseKey = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licenses_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId");
                    table.ForeignKey(
                        name: "FK_Licenses_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Licenses_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "PlatformId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetAttachments",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttachmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetAttachments", x => new { x.AssetId, x.AttachmentId });
                    table.ForeignKey(
                        name: "FK_AssetAttachments_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "AttachmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetPeriods",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "INTEGER", nullable: false),
                    PeriodId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetPeriods", x => new { x.AssetId, x.PeriodId });
                    table.ForeignKey(
                        name: "FK_AssetPeriods_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetPeriods_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "PeriodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LicenseAttachments",
                columns: table => new
                {
                    LicenseId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttachmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseAttachments", x => new { x.LicenseId, x.AttachmentId });
                    table.ForeignKey(
                        name: "FK_LicenseAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "AttachmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenseAttachments_Licenses_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "Licenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LicensePeriods",
                columns: table => new
                {
                    LicenseId = table.Column<int>(type: "INTEGER", nullable: false),
                    PeriodId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicensePeriods", x => new { x.LicenseId, x.PeriodId });
                    table.ForeignKey(
                        name: "FK_LicensePeriods_Licenses_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "Licenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicensePeriods_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "PeriodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "CreatedBy", "CreatedDate", "Name", "Notes", "SupportEmail", "SupportPhone", "SupportUrl", "UpdatedBy", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6895), new TimeSpan(0, 1, 0, 0, 0)), "Microsoft", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6959), new TimeSpan(0, 1, 0, 0, 0)), "https://microsoft.com" },
                    { 2, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6966), new TimeSpan(0, 1, 0, 0, 0)), "Adobe, Inc", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6967), new TimeSpan(0, 1, 0, 0, 0)), "https://adobe.com" },
                    { 3, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6969), new TimeSpan(0, 1, 0, 0, 0)), "1Password", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6970), new TimeSpan(0, 1, 0, 0, 0)), "https://1password.com" },
                    { 4, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6972), new TimeSpan(0, 1, 0, 0, 0)), "Valve", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6973), new TimeSpan(0, 1, 0, 0, 0)), "https://valvesoftware.com" },
                    { 5, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6975), new TimeSpan(0, 1, 0, 0, 0)), "Apple", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6976), new TimeSpan(0, 1, 0, 0, 0)), "https://apple.com" },
                    { 6, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6978), new TimeSpan(0, 1, 0, 0, 0)), "Citrix", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6979), new TimeSpan(0, 1, 0, 0, 0)), "https://www.citrix.com/" },
                    { 7, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6981), new TimeSpan(0, 1, 0, 0, 0)), "Splunk", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6982), new TimeSpan(0, 1, 0, 0, 0)), "https://www.splunk.com/" },
                    { 8, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6983), new TimeSpan(0, 1, 0, 0, 0)), "Amazon", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6984), new TimeSpan(0, 1, 0, 0, 0)), "https://amazon.com/" },
                    { 9, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6986), new TimeSpan(0, 1, 0, 0, 0)), "Google", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6987), new TimeSpan(0, 1, 0, 0, 0)), "https://google.com/" },
                    { 10, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6988), new TimeSpan(0, 1, 0, 0, 0)), "Linux Foundation", null, null, null, null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(6989), new TimeSpan(0, 1, 0, 0, 0)), "https://linuxfoundation.org/" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "Description", "HasCriteria", "Name", "ParentType", "ShortCode" },
                values: new object[,]
                {
                    { 1, "All assets without warranty assigned, does not include expired warranty.", false, "Assets without Warranty", "Asset", "awow" },
                    { 2, "Shows all assets in the system of the chosen criteria type.", true, "Assets of Type", "Asset", "aot" },
                    { 3, "Shows assets in the system with storage lower than the chosen threshold criteria.", true, "Assets With Low Storage", "Asset", "awls" },
                    { 4, "Shows all assets in the system with warranty whether active or expired.", false, "Assets with Warranty", "Asset", "aww" },
                    { 5, "Shows all assets in the system with all available fields.", false, "All Assets with All Fields", "Asset", "aawaf" },
                    { 6, "Shows all licenses in the system with all available fields.", false, "All Licenses with All Fields", "License", "alwaf" },
                    { 7, "Shows Cost of all Entities in the System", false, "Cost Analysis", "Other", "costAnal" }
                });

            migrationBuilder.InsertData(
                table: "SystemSettings",
                columns: new[] { "Name", "Category", "DefaultEnabled", "DefaultSettingValue", "Description", "Enabled", "SettingParentType", "SettingValue" },
                values: new object[,]
                {
                    { "AlertThreshold", 1, true, "30", "How many days before something expires to notify the user. (0 if disabled)", true, "Alerts", "30" },
                    { "AssetsWithExpiredWarranty", 0, true, null, "Alert", true, "Assets", null },
                    { "AssetsWithoutAttachments", 0, true, null, "Alert", true, "Assets", null },
                    { "AssetsWithoutWarranty", 0, true, null, "Alert", true, "Assets", null },
                    { "AssetsWithWarrantyExpiringSoon", 0, true, null, "Alert", true, "Assets", null },
                    { "AutomaticBackups", 1, true, "3", "Backup the database on application start.  Value dictacts amount of backups to keep.", true, "Database", "3" },
                    { "ContractsExpiringSoon", 0, true, null, "Alert", true, "Contracts", null },
                    { "ContractsWithoutAttachments", 0, true, null, "Alert", true, "Contracts", null },
                    { "LicensesWithExpiredSubscriptions", 0, true, null, "Alert", true, "Licenses", null },
                    { "LicensesWithoutAttachments", 0, true, null, "Alert", true, "Licenses", null },
                    { "LicensesWithSubscriptionsExpiringSoon", 0, true, null, "Alert", true, "Licenses", null },
                    { "NoAssetsAdded", 0, true, null, "Alert", true, "Assets", null },
                    { "NoContractsAdded", 0, true, null, "Alert", true, "Contracts", null },
                    { "NoLicensesAdded", 0, true, null, "Alert", true, "Licenses", null }
                });

            migrationBuilder.InsertData(
                table: "AssetOperatingSystems",
                columns: new[] { "OperatingSystemId", "ManufacturerId", "Name", "Notes" },
                values: new object[] { 1, 1, "Windows 11", null });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "PlatformId", "CreatedBy", "CreatedDate", "ManufacturerId", "Name", "Notes", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7034), new TimeSpan(0, 1, 0, 0, 0)), 1, "Windows", null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7036), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 2, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7043), new TimeSpan(0, 1, 0, 0, 0)), 5, "macOS", null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7044), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 3, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7045), new TimeSpan(0, 1, 0, 0, 0)), 10, "Linux", null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7046), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 4, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7047), new TimeSpan(0, 1, 0, 0, 0)), 9, "Chrome OS", null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7049), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 5, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7050), new TimeSpan(0, 1, 0, 0, 0)), 5, "iOS", null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7051), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 6, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7053), new TimeSpan(0, 1, 0, 0, 0)), 9, "Android", null, "SYSTEM", new DateTimeOffset(new DateTime(2024, 4, 7, 6, 34, 40, 468, DateTimeKind.Unspecified).AddTicks(7054), new TimeSpan(0, 1, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetAttachments_AttachmentId",
                table: "AssetAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetHardDrives_AssetHardwareId",
                table: "AssetHardDrives",
                column: "AssetHardwareId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetHardDrives_ManufacturerId",
                table: "AssetHardDrives",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetNetworkAdapters_AssetHardwareId",
                table: "AssetNetworkAdapters",
                column: "AssetHardwareId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetOperatingSystems_ManufacturerId",
                table: "AssetOperatingSystems",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetPeriods_PeriodId",
                table: "AssetPeriods",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ContractId",
                table: "Assets",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_HardwareId",
                table: "Assets",
                column: "HardwareId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ManufacturerId",
                table: "Assets",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Name",
                table: "Assets",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_OperatingSystemId",
                table: "Assets",
                column: "OperatingSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_PlatformId",
                table: "Assets",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractAttachments_AttachmentId",
                table: "ContractAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractPeriods_PeriodId",
                table: "ContractPeriods",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_Name",
                table: "Contracts",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_OrderRef",
                table: "Contracts",
                column: "OrderRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LicenseAttachments_AttachmentId",
                table: "LicenseAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LicensePeriods_PeriodId",
                table: "LicensePeriods",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_ContractId",
                table: "Licenses",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_ManufacturerId",
                table: "Licenses",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_PlatformId",
                table: "Licenses",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_Name",
                table: "Manufacturers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_ManufacturerId",
                table: "Platforms",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_Name",
                table: "Platforms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemSettings_Name",
                table: "SystemSettings",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionLogEntries");

            migrationBuilder.DropTable(
                name: "AssetAttachments");

            migrationBuilder.DropTable(
                name: "AssetHardDrives");

            migrationBuilder.DropTable(
                name: "AssetNetworkAdapters");

            migrationBuilder.DropTable(
                name: "AssetPeriods");

            migrationBuilder.DropTable(
                name: "ContractAttachments");

            migrationBuilder.DropTable(
                name: "ContractPeriods");

            migrationBuilder.DropTable(
                name: "LicenseAttachments");

            migrationBuilder.DropTable(
                name: "LicensePeriods");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "SystemInfo");

            migrationBuilder.DropTable(
                name: "SystemSettings");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "AssetHardware");

            migrationBuilder.DropTable(
                name: "AssetOperatingSystems");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
