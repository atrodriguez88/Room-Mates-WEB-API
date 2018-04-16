using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RoomM.API.Migrations
{
    public partial class SeekData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Property Types
            migrationBuilder.Sql("INSERT INTO PropertyTypes (Name) VALUES ('House')");
            migrationBuilder.Sql("INSERT INTO PropertyTypes (Name) VALUES ('Apartment')");
            migrationBuilder.Sql("INSERT INTO PropertyTypes (Name) VALUES ('Studio')");

            // Property Rules
            migrationBuilder.Sql("INSERT INTO PropertyRules (Name) VALUES ('Listed Residence Restrictions 1')");
            migrationBuilder.Sql("INSERT INTO PropertyRules (Name) VALUES ('Listed Residence Restrictions 2')");
            migrationBuilder.Sql("INSERT INTO PropertyRules (Name) VALUES ('Listed Residence Restrictions 3')");
            migrationBuilder.Sql("INSERT INTO PropertyRules (Name) VALUES ('Listed Residence Restrictions 4')");

            // Property Features
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name) VALUES ('Air Conditions')");
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name) VALUES ('Parking')");
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name) VALUES ('Fitness Center')");
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name) VALUES ('Loundry Facility')");
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name) VALUES ('Pool')");
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name) VALUES ('Alarm System')");
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name) VALUES ('Cable/Satellite')");
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name) VALUES ('Elevator')");
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name) VALUES ('Garage')");
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name) VALUES ('Yard')");

            // Room Features
            migrationBuilder.Sql("INSERT INTO RoomFeatures (Name) VALUES('Balcony/Patio')");
            migrationBuilder.Sql("INSERT INTO RoomFeatures (Name) VALUES ('Furnished')");
            migrationBuilder.Sql("INSERT INTO RoomFeatures (Name) VALUES ('View')");
            migrationBuilder.Sql("INSERT INTO RoomFeatures (Name) VALUES ('Closet')");
            migrationBuilder.Sql("INSERT INTO RoomFeatures (Name) VALUES ('Private entrance')");
            migrationBuilder.Sql("INSERT INTO RoomFeatures (Name) VALUES ('Telephone jack')");
            migrationBuilder.Sql("INSERT INTO RoomFeatures (Name) VALUES ('Master bedroom')");

            // Ocupations
            migrationBuilder.Sql("INSERT INTO Ocupations (Name) VALUES ('Student')");
            migrationBuilder.Sql("INSERT INTO Ocupations (Name) VALUES ('Profesional')");
            migrationBuilder.Sql("INSERT INTO Ocupations (Name) VALUES ('Military')");
            migrationBuilder.Sql("INSERT INTO Ocupations (Name) VALUES ('Unemployee')");
            migrationBuilder.Sql("INSERT INTO Ocupations (Name) VALUES ('Retired')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM PropertyTypes");
            migrationBuilder.Sql("DELETE FROM PropertyRules");
            migrationBuilder.Sql("DELETE FROM PropertyFeatures");
            migrationBuilder.Sql("DELETE FROM RoomFeatures");
            migrationBuilder.Sql("DELETE FROM Ocupations");
        }
    }
}
