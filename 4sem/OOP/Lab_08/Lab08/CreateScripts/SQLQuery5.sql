CREATE TRIGGER trg_Planets_BeforeInsert
ON PLANETS
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS(SELECT 1 FROM inserted WHERE Core_Temperature < 0)
    BEGIN
        RAISERROR('Температура ядра не может быть отрицательной', 16, 1)
        RETURN
    END
    
    INSERT INTO PLANETS (Name, Radius, Core_Temperature, Have_Atmosphere, Have_Life, Image)
    SELECT Name, Radius, Core_Temperature, Have_Atmosphere, Have_Life, Image
    FROM inserted
END