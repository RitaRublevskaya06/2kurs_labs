--USE Lab_03;

------ 1. Кластеризованный индекс
--exec sp_helpindex 'Товары';
--exec sp_helpindex 'Склад';
--exec sp_helpindex 'Сделки';

--CHECKPOINT;
--DBCC DROPCLEANBUFFERS;
--SELECT * FROM Товары WHERE Цена BETWEEN 300 AND 1000 ORDER BY Цена;


------ 2. Некластеризованный составной индекс
--CREATE INDEX IX_Товары_Цена_Наименование ON Товары(Цена, Наименование);

--SELECT * FROM Товары 
--WHERE Цена > 500 AND Наименование LIKE 'Теле%';

--SELECT * FROM Товары 
--ORDER BY Цена, Наименование;

--DROP INDEX IX_Товары_Цена_Наименование  ON Товары;


------ 3. Некластеризованный индекс покрытия
--CREATE INDEX IX_Склад_ID_Товара_INCLUDE ON Склад(ID_Товара) INCLUDE (Количество_товара);
--SELECT Количество_товара FROM Склад WHERE ID_Товара = 1;



------  4. Фильтруемый индекс
--CREATE INDEX IX_Товары_Фильтр_Цена ON Товары(Цена) 
--WHERE (Цена >= 1000 AND Цена < 1500);

--SELECT Цена FROM Товары WHERE Цена BETWEEN 1000 AND 1500;




-------- 5. Фрагментация индекса
--CREATE INDEX IX_Товары_Цена ON Товары(Цена);

--SELECT 
--    name [Индекс], 
--    avg_fragmentation_in_percent [Фрагментация (%)]
--FROM sys.dm_db_index_physical_stats(DB_ID(), OBJECT_ID('Товары'), NULL, NULL, NULL) ss 
--JOIN sys.indexes ii ON ss.object_id = ii.object_id AND ss.index_id = ii.index_id 
--WHERE name IS NOT NULL;

--ALTER INDEX IX_Товары_Цена ON Товары REORGANIZE;

--ALTER INDEX IX_Товары_Цена ON Товары REBUILD WITH (ONLINE = OFF);


------- 6. Пример использования FILLFACTOR
--DROP INDEX IX_Товары_Цена ON Товары;
--CREATE INDEX IX_Товары_Цена ON Товары(Цена) WITH (FILLFACTOR = 65);

--INSERT INTO Товары (Наименование, Цена, Описание)
--VALUES ('Новый товар', 900.00, 'Тестовый товар');

--SELECT 
--    name [Индекс], 
--    avg_fragmentation_in_percent [Фрагментация (%)]
--FROM sys.dm_db_index_physical_stats(DB_ID(), OBJECT_ID('Товары'), NULL, NULL, NULL) ss 
--JOIN sys.indexes ii ON ss.object_id = ii.object_id AND ss.index_id = ii.index_id 
--WHERE name IS NOT NULL;
