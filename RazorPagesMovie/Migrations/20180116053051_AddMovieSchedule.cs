﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RazorPagesMovie.Migrations
{
    public partial class AddMovieSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Movie",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrivateSchedule = table.Column<string>(nullable: true),
                    PrivateScheduleSize = table.Column<long>(nullable: false),
                    PublicSchedule = table.Column<string>(nullable: true),
                    PublicScheduleSize = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UploadDT = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movie");
        }
    }
}
