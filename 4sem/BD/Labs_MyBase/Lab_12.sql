USE Lab_03;

---- 1. Режим неявной транзакции
SET NOCOUNT ON;
DECLARE @flag CHAR = 'c';

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.НОВЫЙ_СКЛАД') AND type IN (N'U'))
    DROP TABLE НОВЫЙ_СКЛАД;

DECLARE @count INT;
SET IMPLICIT_TRANSACTIONS ON;

CREATE TABLE НОВЫЙ_СКЛАД (
    ID_Места INT PRIMARY KEY IDENTITY,
    ID_Товара INT NOT NULL,
    Объем_хранения INT CHECK (Объем_хранения > 0),
    FOREIGN KEY (ID_Товара) REFERENCES Товары(ID_Товара)
);

INSERT INTO НОВЫЙ_СКЛАД (ID_Товара, Объем_хранения) VALUES 
(1, 500), (2, 300);
SET @count = (SELECT COUNT(*) FROM НОВЫЙ_СКЛАД);
PRINT 'Количество записей: ' + CAST(@count AS VARCHAR);

IF @flag = 'c'
    COMMIT;
ELSE
    ROLLBACK;

SET IMPLICIT_TRANSACTIONS OFF;

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.НОВЫЙ_СКЛАД') AND type IN (N'U'))
    PRINT 'Таблица НОВЫЙ_СКЛАД существует';
ELSE
    PRINT 'Таблица НОВЫЙ_СКЛАД не существует';


---- 2. Явная транзакция с обработкой ошибок
BEGIN TRY
    BEGIN TRANSACTION;
        UPDATE Сделки
        SET Количество = 5
        WHERE ID_Сделки = 1;
        
        DELETE FROM Сделки
        WHERE ID_Сделки = 2;
        
        COMMIT TRANSACTION;
        PRINT 'Транзакция успешно завершена';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'Ошибка: ' + ERROR_MESSAGE();
END CATCH;


---- 3. Контрольные точки (SAVE TRANSACTION)
BEGIN TRANSACTION;
BEGIN TRY
    INSERT INTO Покупатели (ФИО, Телефон, Адрес) 
    VALUES ('Еще один Покупатель', '3751111111', 'Тестовый адрес 2');
    
    SAVE TRANSACTION SavePoint1;
    
    INSERT INTO Склад (ID_Товара, Количество_товара, Место_хранения, Количество_ячеек)
    VALUES (1, 50, 'Секция A2', 20);
    
    COMMIT TRANSACTION;
    PRINT 'Обе операции успешно выполнены';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION SavePoint1;
    COMMIT TRANSACTION;
    PRINT 'Ошибка: ' + ERROR_MESSAGE();
END CATCH;



---- 4. Проблемы параллельных транзакций
---- Сценарий A
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN TRANSACTION;
    SELECT * FROM Сделки WHERE ID_Покупателя = 1;
    -- Пауза для тестирования
COMMIT;

---- Сценарий B
BEGIN TRANSACTION;
    UPDATE Сделки SET Количество = 10 WHERE ID_Сделки = 1;
    -- Пауза для тестирования
ROLLBACK;


---- 5. Уровень изоляции READ COMMITTED
---- Сценарий A
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
BEGIN TRANSACTION;
    SELECT SUM(Количество) FROM Сделки 
    WHERE ID_Товара = 1;
    -- Пауза для тестирования
COMMIT;

---- Сценарий B
BEGIN TRANSACTION;
    UPDATE Товары SET Цена = Цена * 1.1 
    WHERE ID_Товара = 1;
COMMIT;


---- 6. Уровень изоляции REPEATABLE READ
---- Сценарий A
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
BEGIN TRANSACTION;
    SELECT * FROM Склад 
    WHERE ID_Товара = 1;
    -- Пауза для тестирования
COMMIT;

---- Сценарий B
BEGIN TRANSACTION;
    INSERT INTO Сделки (ID_Покупателя, ID_Товара, Дата_сделки, Количество)
    VALUES (1, 1, GETDATE(), 2);
COMMIT;


---- 7. Уровень изоляции SERIALIZABLE
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRANSACTION;
    DELETE FROM Сделки 
    WHERE ID_Сделки BETWEEN 10 AND 20;
    
    INSERT INTO Сделки (ID_Покупателя, ID_Товара, Дата_сделки, Количество)
    VALUES (2, 2, GETDATE(), 3);
COMMIT;

---- Сценарий B
BEGIN TRANSACTION;
    DELETE FROM Сделки 
    WHERE ID_Сделки = 15;
COMMIT;


---- 8. Вложенные транзакции
BEGIN TRANSACTION ВнешняяТранзакция;
    PRINT 'Уровень вложенности: ' + CAST(@@TRANCOUNT AS VARCHAR);
    
    BEGIN TRANSACTION ВнутренняяТранзакция;
        PRINT 'Уровень вложенности: ' + CAST(@@TRANCOUNT AS VARCHAR);
        INSERT INTO Товары (Наименование, Цена) 
        VALUES ('Тестовый товар', 99.99);
        COMMIT TRANSACTION ВнутренняяТранзакция;
    
    PRINT 'Уровень вложенности: ' + CAST(@@TRANCOUNT AS VARCHAR);
    
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION ВнешняяТранзакция;


