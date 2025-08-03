USE Planets;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'PROC_COUNT_PLANETS')
BEGIN
    EXEC('
    CREATE PROCEDURE PROC_COUNT_PLANETS
    AS 
    BEGIN 
        DECLARE @k INT = (SELECT COUNT(*) FROM dbo.PLANETS);
        SELECT @k AS [NumOfPlanets];
        RETURN @k;
    END
    ');
END