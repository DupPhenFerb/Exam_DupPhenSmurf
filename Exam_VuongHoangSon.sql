CREATE DATABASE NTB_DB;
GO;
USE NTB_DB;
GO;

CREATE TABLE location(
	LocationID char(6) PRIMARY KEY,
	Name nvarchar(50) not null,
	Description nvarchar(100)
);
CREATE TABLE Land (
    LandID int PRIMARY KEY IDENTITY,
    Title nvarchar(100) not null,
    LocationID char(6) foreign key references Location(LocationID),
    Detail nvarchar(1000),
    StartDate datetime not null,
    EndDate datetime not null
);
CREATE TABLE Building (
    BuildingID int primary key identity,
    LandID int foreign key references Land(LandID),
    BuildingType nvarchar(50),
    Area int default 50,
    Floors int default 1,
    Rooms int default 1,
    Cost money
);
INSERT INTO Location (LocationID, Name, Description)
VALUES
    ('100001', 'Urban', 'Urban Region'),
    ('100002', 'Suburban', 'Suburban Region'),
    ('100003', 'Rural', 'Rural Region');

INSERT INTO Land (Title, LocationID, Detail, StartDate, EndDate)
VALUES
    ('My Dinh', '100001', 'My Dinh in Urban Region', '2010-01-01', '2012-12-31'),
    ('Hoai Duc', '100002', 'Hoai Duc in Suburban Region', '2013-02-01', '2023-11-30'),
    ('An Thuong', '100003', 'An Thuong in Rural Region', '2000-03-01', '2010-10-31');

INSERT INTO Building (LandID, BuildingType, Area, Floors, Rooms, Cost)
VALUES
    (1, 'Villa', 200, 2, 4, 1000),
    (2, 'Apartment', 150, 3, 6, 800),
    (3, 'Supermarket', 300, 1, 1, 1500);
SELECT * FROM Building
	WHERE Area >= 100;

SELECT * FROM Land
	WHERE EndDate < '2013-01-01';

SELECT Building.* FROM Building
	JOIN Land ON Building.LandID = Land.LandID
	WHERE Land.Title = 'My Dinh';


CREATE VIEW v_Buildings AS
	SELECT Building.BuildingID, Land.Title, Location.Name, Building.BuildingType, Building.Area, Building.Floors
	FROM Building
	JOIN Land ON Building.LandID = Land.LandID
	JOIN Location ON Land.LocationID = Location.LocationID;


CREATE VIEW v_TopBuildings AS
	SELECT TOP 5 BuildingID, BuildingType, Area, Cost/Area AS PricePerM2
	FROM Building
	ORDER BY PricePerM2 DESC;


CREATE PROCEDURE sp_SearchLandByLocation @AreaCode char(6)
AS
BEGIN
    SELECT Land.* FROM Land
    JOIN Location ON Land.LocationID = Location.LocationID
    WHERE Location.LocationID = @AreaCode;
END;


CREATE PROCEDURE sp_SearchBuildingByLand @LandCode int
AS
BEGIN
    SELECT * FROM Building
    WHERE LandID = @LandCode;
END;
