using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SacramentPlanner_Sandbox.Migrations
{
    public partial class SpeakerIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Hymn_ClosingHymnHymnID",
                table: "Meeting");

            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Person_ClosingPrayerPersonID",
                table: "Meeting");

            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Person_ConductingPersonID",
                table: "Meeting");

            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Hymn_OpeningHymnHymnID",
                table: "Meeting");

            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Person_OpeningPrayerPersonID",
                table: "Meeting");

            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Hymn_SacramentHymnHymnID",
                table: "Meeting");

            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_Meeting_MeetingID1",
                table: "Speaker");

            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_Person_PersonID1",
                table: "Speaker");

            migrationBuilder.DropIndex(
                name: "IX_Speaker_MeetingID1",
                table: "Speaker");

            migrationBuilder.DropIndex(
                name: "IX_Speaker_PersonID1",
                table: "Speaker");

            migrationBuilder.DropIndex(
                name: "IX_Meeting_ClosingHymnHymnID",
                table: "Meeting");

            migrationBuilder.DropIndex(
                name: "IX_Meeting_ClosingPrayerPersonID",
                table: "Meeting");

            migrationBuilder.DropIndex(
                name: "IX_Meeting_ConductingPersonID",
                table: "Meeting");

            migrationBuilder.DropIndex(
                name: "IX_Meeting_OpeningHymnHymnID",
                table: "Meeting");

            migrationBuilder.DropIndex(
                name: "IX_Meeting_OpeningPrayerPersonID",
                table: "Meeting");

            migrationBuilder.DropIndex(
                name: "IX_Meeting_SacramentHymnHymnID",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "MeetingID1",
                table: "Speaker");

            migrationBuilder.DropColumn(
                name: "PersonID1",
                table: "Speaker");

            migrationBuilder.DropColumn(
                name: "ClosingHymnHymnID",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "ClosingPrayerPersonID",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "ConductingPersonID",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "OpeningHymnHymnID",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "OpeningPrayerPersonID",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "SacramentHymnHymnID",
                table: "Meeting");

            migrationBuilder.AddColumn<int>(
                name: "MeetingID",
                table: "Speaker",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "Speaker",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ClosingHymn",
                table: "Meeting",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "ClosingPrayer",
                table: "Meeting",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Conducting",
                table: "Meeting",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "OpeningHymn",
                table: "Meeting",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "OpeningPrayer",
                table: "Meeting",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "SacramentHymn",
                table: "Meeting",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_MeetingID",
                table: "Speaker",
                column: "MeetingID");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_SpeakerID_MeetingID_PersonID",
                table: "Speaker",
                columns: new[] { "SpeakerID", "MeetingID", "PersonID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_Meeting_MeetingID",
                table: "Speaker",
                column: "MeetingID",
                principalTable: "Meeting",
                principalColumn: "MeetingID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_Meeting_MeetingID",
                table: "Speaker");

            migrationBuilder.DropIndex(
                name: "IX_Speaker_MeetingID",
                table: "Speaker");

            migrationBuilder.DropIndex(
                name: "IX_Speaker_SpeakerID_MeetingID_PersonID",
                table: "Speaker");

            migrationBuilder.DropColumn(
                name: "MeetingID",
                table: "Speaker");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "Speaker");

            migrationBuilder.DropColumn(
                name: "ClosingHymn",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "ClosingPrayer",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "Conducting",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "OpeningHymn",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "OpeningPrayer",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "SacramentHymn",
                table: "Meeting");

            migrationBuilder.AddColumn<int>(
                name: "MeetingID1",
                table: "Speaker",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonID1",
                table: "Speaker",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClosingHymnHymnID",
                table: "Meeting",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClosingPrayerPersonID",
                table: "Meeting",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConductingPersonID",
                table: "Meeting",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OpeningHymnHymnID",
                table: "Meeting",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OpeningPrayerPersonID",
                table: "Meeting",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SacramentHymnHymnID",
                table: "Meeting",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_MeetingID1",
                table: "Speaker",
                column: "MeetingID1");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_PersonID1",
                table: "Speaker",
                column: "PersonID1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Hymn_ClosingHymnHymnID",
                table: "Meeting",
                column: "ClosingHymnHymnID",
                principalTable: "Hymn",
                principalColumn: "HymnID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Person_ClosingPrayerPersonID",
                table: "Meeting",
                column: "ClosingPrayerPersonID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Person_ConductingPersonID",
                table: "Meeting",
                column: "ConductingPersonID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Hymn_OpeningHymnHymnID",
                table: "Meeting",
                column: "OpeningHymnHymnID",
                principalTable: "Hymn",
                principalColumn: "HymnID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Person_OpeningPrayerPersonID",
                table: "Meeting",
                column: "OpeningPrayerPersonID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Hymn_SacramentHymnHymnID",
                table: "Meeting",
                column: "SacramentHymnHymnID",
                principalTable: "Hymn",
                principalColumn: "HymnID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_Meeting_MeetingID1",
                table: "Speaker",
                column: "MeetingID1",
                principalTable: "Meeting",
                principalColumn: "MeetingID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_Person_PersonID1",
                table: "Speaker",
                column: "PersonID1",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
