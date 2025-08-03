USE Planets;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PLANETS')
BEGIN
    CREATE TABLE PLANETS (
        Name nvarchar(50) NOT NULL PRIMARY KEY,
        Radius int NOT NULL,
        Core_Temperature decimal(8,2) NOT NULL,
        Have_Atmosphere bit NOT NULL,
        Have_Life bit NOT NULL,
        Image VARBINARY(MAX) NULL
    );
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'SATELLITES')
BEGIN
    CREATE TABLE SATELLITES (
        Name nvarchar(50) NOT NULL PRIMARY KEY,
        Planet_Name nvarchar(50) NOT NULL FOREIGN KEY REFERENCES PLANETS(Name),
        Radius int NOT NULL,
        Planetary_Distance int NOT NULL,
        Image nvarchar(50)
    );
END