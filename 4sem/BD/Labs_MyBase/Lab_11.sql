USE Lab_03;

-------- 1. Список всех товаров через запятую
DECLARE @product_list NVARCHAR(MAX) = '';
DECLARE @product_name NVARCHAR(255);

DECLARE ProductCursor CURSOR FOR 
SELECT Наименование FROM Товары ORDER BY Наименование;

OPEN ProductCursor;
FETCH NEXT FROM ProductCursor INTO @product_name;

WHILE @@FETCH_STATUS = 0
BEGIN
    IF LEN(@product_list) > 0
        SET @product_list = @product_list + ', ' + @product_name;
    ELSE
        SET @product_list = @product_name;
    
    FETCH NEXT FROM ProductCursor INTO @product_name;
END

CLOSE ProductCursor;
DEALLOCATE ProductCursor;

PRINT 'Список всех товаров: ' + @product_list;


-------- 2. Демонстрация локального и глобального курсоров
------ 2.1 Локальный курсор
-- Пакет 1: Создание и использование локального курсора
DECLARE LocalCustomerCursor CURSOR LOCAL FOR
SELECT ФИО FROM Покупатели 
WHERE Адрес LIKE '%Минск%'
ORDER BY ФИО;

DECLARE @customer_name NVARCHAR(255);

OPEN LocalCustomerCursor;
FETCH NEXT FROM LocalCustomerCursor INTO @customer_name;

PRINT 'Локальный курсор - первый покупатель из Минска: ' + @customer_name;
GO

-- Пакет 2: Попытка использовать локальный курсор в другом пакете
DECLARE @customer_name NVARCHAR(255);

-- Эта строка вызовет ошибку, так как курсор LocalCustomerCursor был локальным и уничтожился после первого пакета
FETCH NEXT FROM LocalCustomerCursor INTO @customer_name;
PRINT 'Локальный курсор - второй покупатель из Минска: ' + @customer_name;
GO

------ 2.2 Глобальный курсор
-- Пакет 1: Создание и использование глобального курсора
DECLARE GlobalCustomerCursor CURSOR GLOBAL FOR
SELECT ФИО FROM Покупатели 
WHERE Адрес LIKE '%Москва%'
ORDER BY ФИО;

DECLARE @customer_name NVARCHAR(255);

OPEN GlobalCustomerCursor;
FETCH NEXT FROM GlobalCustomerCursor INTO @customer_name;

PRINT 'Глобальный курсор - первый покупатель из Москвы: ' + @customer_name;
GO

-- Пакет 2: Продолжение работы с глобальным курсором
DECLARE @customer_name NVARCHAR(255);

FETCH NEXT FROM GlobalCustomerCursor INTO @customer_name;
PRINT 'Глобальный курсор - второй покупатель из Москвы: ' + @customer_name;

-- Закрытие и освобождение курсора
CLOSE GlobalCustomerCursor;
DEALLOCATE GlobalCustomerCursor;
GO


-------- 3. Демонстрация статического и динамического курсоров
DECLARE @product_id INT, @product_name NVARCHAR(255), @price DECIMAL(10,2);

DECLARE StaticProductCursor CURSOR LOCAL STATIC FOR
SELECT ID_Товара, Наименование, Цена FROM Товары WHERE Цена > 300;

OPEN StaticProductCursor;
PRINT 'Количество дорогих товаров: ' + CAST(@@CURSOR_ROWS AS VARCHAR(10));

UPDATE Товары SET Цена = Цена * 0.9 WHERE Наименование = 'Ноутбук';
INSERT INTO Товары VALUES ('Игровая консоль', 450.00, 'Новая игровая консоль');

PRINT 'Данные из статического курсора:';
FETCH NEXT FROM StaticProductCursor INTO @product_id, @product_name, @price;
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT CAST(@product_id AS VARCHAR) + ' | ' + @product_name + ' | ' + CAST(@price AS VARCHAR);
    FETCH NEXT FROM StaticProductCursor INTO @product_id, @product_name, @price;
END

CLOSE StaticProductCursor;
DEALLOCATE StaticProductCursor;

-- Динамический курсор 
DECLARE DynamicProductCursor CURSOR LOCAL DYNAMIC FOR
SELECT ID_Товара, Наименование, Цена FROM Товары WHERE Цена > 300;

OPEN DynamicProductCursor;

UPDATE Товары SET Цена = 350.00 WHERE Наименование = 'Телевизор';
BEGIN TRY
    DELETE FROM Товары WHERE Наименование = 'Планшет';
END TRY
BEGIN CATCH
    PRINT 'Не удалось удалить товар: ' + ERROR_MESSAGE();
END CATCH

PRINT 'Данные из динамического курсора:';
FETCH NEXT FROM DynamicProductCursor INTO @product_id, @product_name, @price;
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT CAST(@product_id AS VARCHAR) + ' | ' + @product_name + ' | ' + CAST(@price AS VARCHAR);
    FETCH NEXT FROM DynamicProductCursor INTO @product_id, @product_name, @price;
END

CLOSE DynamicProductCursor;
DEALLOCATE DynamicProductCursor;


-------- 4. Курсор с навигацией (SCROLL)
DECLARE @row_num INT, @product_name4 NVARCHAR(255), @price4 DECIMAL(10,2);

DECLARE ScrollProductCursor CURSOR LOCAL SCROLL FOR
SELECT 
    ROW_NUMBER() OVER (ORDER BY Цена DESC) AS RowNum,
    Наименование,
    Цена
FROM Товары
ORDER BY Цена DESC;

OPEN ScrollProductCursor;
PRINT 'Навигация по товарам с помощью SCROLL-курсора:';

FETCH FIRST FROM ScrollProductCursor INTO @row_num, @product_name4, @price4;
PRINT 'FIRST:     Строка ' + CAST(@row_num AS VARCHAR) + ' - ' + @product_name4 + ' (' + CAST(@price4 AS VARCHAR) + ' руб.)';

FETCH NEXT FROM ScrollProductCursor INTO @row_num, @product_name4, @price4;
PRINT 'NEXT:      Строка ' + CAST(@row_num AS VARCHAR) + ' - ' + @product_name4 + ' (' + CAST(@price4 AS VARCHAR) + ' руб.)';

FETCH ABSOLUTE 3 FROM ScrollProductCursor INTO @row_num, @product_name4, @price4;
PRINT 'ABSOLUTE 3: Строка ' + CAST(@row_num AS VARCHAR) + ' - ' + @product_name4 + ' (' + CAST(@price4 AS VARCHAR) + ' руб.)';

FETCH RELATIVE 2 FROM ScrollProductCursor INTO @row_num, @product_name4, @price4;
PRINT 'RELATIVE 2: Строка ' + CAST(@row_num AS VARCHAR) + ' - ' + @product_name4 + ' (' + CAST(@price4 AS VARCHAR) + ' руб.)';

FETCH PRIOR FROM ScrollProductCursor INTO @row_num, @product_name4, @price4;
PRINT 'PRIOR:     Строка ' + CAST(@row_num AS VARCHAR) + ' - ' + @product_name4 + ' (' + CAST(@price4 AS VARCHAR) + ' руб.)';

FETCH LAST FROM ScrollProductCursor INTO @row_num, @product_name4, @price4;
PRINT 'LAST:      Строка ' + CAST(@row_num AS VARCHAR) + ' - ' + @product_name4 + ' (' + CAST(@price4 AS VARCHAR) + ' руб.)';

CLOSE ScrollProductCursor;
DEALLOCATE ScrollProductCursor;


-------- 5. Курсор с обновлением данных (CURRENT OF)
-- Создаем временную таблицу для демонстрации
SELECT ID_Товара, Наименование, Цена 
INTO #TempProducts
FROM Товары
WHERE Цена BETWEEN 200 AND 600;

DECLARE @product_id5 INT, @current_price DECIMAL(10,2);

DECLARE UpdatePriceCursor CURSOR FOR 
SELECT ID_Товара, Цена FROM #TempProducts
FOR UPDATE;

OPEN UpdatePriceCursor;
FETCH NEXT FROM UpdatePriceCursor INTO @product_id5, @current_price;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Повышаем цену на 10% для товаров дороже 300
    IF @current_price > 300
    BEGIN
        UPDATE #TempProducts 
        SET Цена = Цена * 1.1 
        WHERE CURRENT OF UpdatePriceCursor;
        
        PRINT 'Цена товара ID ' + CAST(@product_id5 AS VARCHAR) + 
              ' повышена с ' + CAST(@current_price AS VARCHAR) + 
              ' до ' + CAST(@current_price * 1.1 AS VARCHAR);
    END
    
    FETCH NEXT FROM UpdatePriceCursor INTO @product_id5, @current_price;
END

CLOSE UpdatePriceCursor;
DEALLOCATE UpdatePriceCursor;

SELECT * FROM #TempProducts;
DROP TABLE #TempProducts;



-------- 6.1 Удаление сделок с количеством товара меньше 2 (аналог удаления плохих оценок)
DECLARE @count INT = (SELECT COUNT(*) FROM Сделки WHERE Количество < 2);
PRINT 'Найдено ' + CAST(@count AS VARCHAR) + ' сделок с количеством товара меньше 2';

DECLARE @deal_id INT, @customer_id INT, @product_id6 INT, @quantity INT;
DECLARE SmallDealsCursor CURSOR FOR 
    SELECT s.ID_Сделки, s.ID_Покупателя, s.ID_Товара, s.Количество 
    FROM Сделки s
    JOIN Покупатели p ON s.ID_Покупателя = p.ID_Покупателя
    JOIN Товары t ON s.ID_Товара = t.ID_Товара
    WHERE s.Количество < 2
    FOR UPDATE;

OPEN SmallDealsCursor;
FETCH NEXT FROM SmallDealsCursor INTO @deal_id, @customer_id, @product_id6, @quantity;

IF @@FETCH_STATUS <> 0
    PRINT 'Нет сделок для удаления';
ELSE
BEGIN
    WHILE @@FETCH_STATUS = 0
    BEGIN
        DELETE FROM Сделки 
        WHERE CURRENT OF SmallDealsCursor;
        
        PRINT 'Удалена сделка ' + CAST(@deal_id AS VARCHAR) + 
              ': покупатель ' + CAST(@customer_id AS VARCHAR) + 
              ', товар ' + CAST(@product_id6 AS VARCHAR) + 
              ', количество ' + CAST(@quantity AS VARCHAR);
        
        FETCH NEXT FROM SmallDealsCursor INTO @deal_id, @customer_id, @product_id6, @quantity;
    END
    PRINT 'Удаление завершено';
END

CLOSE SmallDealsCursor;
DEALLOCATE SmallDealsCursor;

-------- 6.2 Увеличение количества товара в сделках конкретного покупателя 
DECLARE @target_customer_id INT = 1; 

DECLARE UpdateDealsCursor CURSOR FOR 
    SELECT ID_Сделки, ID_Товара, Количество 
    FROM Сделки 
    WHERE ID_Покупателя = @target_customer_id
    FOR UPDATE;

OPEN UpdateDealsCursor;
FETCH NEXT FROM UpdateDealsCursor INTO @deal_id, @product_id, @quantity;

WHILE @@FETCH_STATUS = 0
BEGIN
    DECLARE @stock INT = (SELECT Количество_товара FROM Склад WHERE ID_Товара = @product_id);
    
    IF @stock >= @quantity + 1
    BEGIN
        UPDATE Сделки 
        SET Количество = Количество + 1 
        WHERE CURRENT OF UpdateDealsCursor;
        
        PRINT 'Сделка ' + CAST(@deal_id AS VARCHAR) + 
              ': количество товара ' + CAST(@product_id AS VARCHAR) + 
              ' увеличено с ' + CAST(@quantity AS VARCHAR) + 
              ' на ' + CAST(@quantity + 1 AS VARCHAR);
    END
    ELSE
    BEGIN
        PRINT 'Ошибка в сделке ' + CAST(@deal_id AS VARCHAR) + 
              ': недостаточно товара ' + CAST(@product_id AS VARCHAR) + 
              ' на складе (в наличии: ' + CAST(@stock AS VARCHAR) + ')';
    END
    
    FETCH NEXT FROM UpdateDealsCursor INTO @deal_id, @product_id, @quantity;
END

CLOSE UpdateDealsCursor;
DEALLOCATE UpdateDealsCursor;

-- Проверка результатов
SELECT 
    s.ID_Сделки,
    p.ФИО AS Покупатель,
    t.Наименование AS Товар,
    s.Количество,
    s.Дата_сделки
FROM Сделки s
JOIN Покупатели p ON s.ID_Покупателя = p.ID_Покупателя
JOIN Товары t ON s.ID_Товара = t.ID_Товара
ORDER BY s.ID_Сделки;




























---------- 6.1. Обновление количества товаров на складе после сделок
--DECLARE @deal_id INT, @product_id6 INT, @quantity INT;

--DECLARE ProcessDealsCursor CURSOR FOR 
--SELECT ID_Сделки, ID_Товара, Количество FROM Сделки
--WHERE Дата_сделки >= '2025-03-01'
--FOR UPDATE;

--OPEN ProcessDealsCursor;
--FETCH NEXT FROM ProcessDealsCursor INTO @deal_id, @product_id6, @quantity;

--WHILE @@FETCH_STATUS = 0
--BEGIN
--    UPDATE Склад 
--    SET Количество_товара = Количество_товара - @quantity
--    WHERE ID_Товара = @product_id6;
    
--    PRINT 'Обработана сделка ' + CAST(@deal_id AS VARCHAR) + 
--          ': товар ' + CAST(@product_id6 AS VARCHAR) + 
--          ' уменьшен на ' + CAST(@quantity AS VARCHAR) + ' единиц';
    
--    FETCH NEXT FROM ProcessDealsCursor INTO @deal_id, @product_id6, @quantity;
--END

--CLOSE ProcessDealsCursor;
--DEALLOCATE ProcessDealsCursor;

--SELECT t.Наименование, s.Количество_товара, s.Место_хранения
--FROM Товары t
--JOIN Склад s ON t.ID_Товара = s.ID_Товара;

---------- 6.2. Анализ покупателей и их покупок
--DECLARE @customer_id INT, @customer_name NVARCHAR(255), @total_spent DECIMAL(12,2);

--DECLARE CustomerAnalysisCursor CURSOR FOR
--SELECT 
--    p.ID_Покупателя,
--    p.ФИО,
--    SUM(t.Цена * s.Количество) AS TotalSpent
--FROM Покупатели p
--JOIN Сделки s ON p.ID_Покупателя = s.ID_Покупателя
--JOIN Товары t ON s.ID_Товара = t.ID_Товара
--GROUP BY p.ID_Покупателя, p.ФИО
--ORDER BY TotalSpent DESC;

--OPEN CustomerAnalysisCursor;
--FETCH NEXT FROM CustomerAnalysisCursor INTO @customer_id, @customer_name, @total_spent;

--PRINT 'ТОП покупателей по сумме покупок:';
--PRINT '--------------------------------';

--WHILE @@FETCH_STATUS = 0
--BEGIN
--    PRINT @customer_name + ': ' + CAST(@total_spent AS VARCHAR) + ' руб.';
   
--    IF @total_spent > 2000
--    BEGIN
--        PRINT '   VIP-покупатель! Предложить бонусную программу.';
--    END
    
--    FETCH NEXT FROM CustomerAnalysisCursor INTO @customer_id, @customer_name, @total_spent;
--END

--CLOSE CustomerAnalysisCursor;
--DEALLOCATE CustomerAnalysisCursor;