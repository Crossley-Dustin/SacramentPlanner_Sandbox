using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SacramentPlanner_Sandbox.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hymn",
                columns: table => new
                {
                    HymnID = table.Column<Guid>(nullable: false),
                    HymnName = table.Column<string>(nullable: true),
                    HymnNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hymn", x => x.HymnID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: true),
                    FirstMidName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    MeetingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClosingHymnHymnID = table.Column<Guid>(nullable: true),
                    ClosingPrayerPersonID = table.Column<int>(nullable: true),
                    ConductingPersonID = table.Column<int>(nullable: true),
                    IntermediateSong = table.Column<string>(nullable: true),
                    MeetingDate = table.Column<DateTime>(nullable: false),
                    OpeningHymnHymnID = table.Column<Guid>(nullable: true),
                    OpeningPrayerPersonID = table.Column<int>(nullable: true),
                    SacramentHymnHymnID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.MeetingID);
                    table.ForeignKey(
                        name: "FK_Meeting_Hymn_ClosingHymnHymnID",
                        column: x => x.ClosingHymnHymnID,
                        principalTable: "Hymn",
                        principalColumn: "HymnID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Person_ClosingPrayerPersonID",
                        column: x => x.ClosingPrayerPersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Person_ConductingPersonID",
                        column: x => x.ConductingPersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Hymn_OpeningHymnHymnID",
                        column: x => x.OpeningHymnHymnID,
                        principalTable: "Hymn",
                        principalColumn: "HymnID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Person_OpeningPrayerPersonID",
                        column: x => x.OpeningPrayerPersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Hymn_SacramentHymnHymnID",
                        column: x => x.SacramentHymnHymnID,
                        principalTable: "Hymn",
                        principalColumn: "HymnID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    SpeakerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssignedTopic = table.Column<string>(nullable: true),
                    MeetingID1 = table.Column<int>(nullable: true),
                    PersonID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerID);
                    table.ForeignKey(
                        name: "FK_Speaker_Meeting_MeetingID1",
                        column: x => x.MeetingID1,
                        principalTable: "Meeting",
                        principalColumn: "MeetingID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Speaker_Person_PersonID1",
                        column: x => x.PersonID1,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_ClosingHymnHymnID",
                table: "Meeting",
                column: "ClosingHymnHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_ClosingPrayerPersonID",
                table: "Meeting",
                column: "ClosingPrayerPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_ConductingPersonID",
                table: "Meeting",
                column: "ConductingPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_OpeningHymnHymnID",
                table: "Meeting",
                column: "OpeningHymnHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_OpeningPrayerPersonID",
                table: "Meeting",
                column: "OpeningPrayerPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_SacramentHymnHymnID",
                table: "Meeting",
                column: "SacramentHymnHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_MeetingID1",
                table: "Speaker",
                column: "MeetingID1");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_PersonID1",
                table: "Speaker",
                column: "PersonID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "Hymn");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
