using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomM.API.Migrations
{
    public partial class SeekData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Property Types
            migrationBuilder.Sql("INSERT INTO PropertyTypes (Name, Deleted) VALUES ('House', 0)");
            migrationBuilder.Sql("INSERT INTO PropertyTypes (Name, Deleted) VALUES ('Apartment', 0)");
            migrationBuilder.Sql("INSERT INTO PropertyTypes (Name, Deleted) VALUES ('Studio', 0)");

            // Property Rules
            migrationBuilder.Sql("INSERT INTO PropertyRules (Name, Deleted) VALUES ('Listed Residence Restrictions 1', 0)");
            migrationBuilder.Sql("INSERT INTO PropertyRules (Name, Deleted) VALUES ('Listed Residence Restrictions 2', 0)");
            migrationBuilder.Sql("INSERT INTO PropertyRules (Name, Deleted) VALUES ('Listed Residence Restrictions 3', 0)");
            migrationBuilder.Sql("INSERT INTO PropertyRules (Name, Deleted) VALUES ('Listed Residence Restrictions 4', 0)");

            // Property Features
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name, Deleted) VALUES ('Air Conditions', 0)");
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name, Deleted) VALUES ('Parking', 0)");
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name, Deleted) VALUES ('Fitness Center', 0)");
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name, Deleted) VALUES ('Loundry Facility', 0)");
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name, Deleted) VALUES ('Pool', 0)");
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name, Deleted) VALUES ('Alarm System', 0)");
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name, Deleted) VALUES ('Cable/Satellite', 0)");
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name, Deleted) VALUES ('Elevator', 0)");
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name, Deleted) VALUES ('Garage', 0)");
            migrationBuilder.Sql("INSERT INTO PropertyFeatures (Name, Deleted) VALUES ('Yard', 0)");

            // Room Features
            migrationBuilder.Sql("INSERT INTO RoomFeatures (Name, Deleted) VALUES('Balcony/Patio', 0)");
            migrationBuilder.Sql("INSERT INTO RoomFeatures (Name, Deleted) VALUES ('Furnished', 0)");
            migrationBuilder.Sql("INSERT INTO RoomFeatures (Name, Deleted) VALUES ('View', 0)");
            migrationBuilder.Sql("INSERT INTO RoomFeatures (Name, Deleted) VALUES ('Closet', 0)");
            migrationBuilder.Sql("INSERT INTO RoomFeatures (Name, Deleted) VALUES ('Private entrance', 0)");
            migrationBuilder.Sql("INSERT INTO RoomFeatures (Name, Deleted) VALUES ('Telephone jack', 0)");
            migrationBuilder.Sql("INSERT INTO RoomFeatures (Name, Deleted) VALUES ('Master bedroom', 0)");

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
