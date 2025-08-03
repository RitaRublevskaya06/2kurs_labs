USE Planets;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'PROC_COUNT_SATELLITES')
BEGIN
    EXEC('
    CREATE PROCEDURE PROC_COUNT_SATELLITES
    AS 
    BEGIN 
        DECLARE @k INT = (SELECT COUNT(*) FROM dbo.SATELLITES);
        SELECT @k AS [NumOfSatellites];
        RETURN @k;
    END
    ');
END