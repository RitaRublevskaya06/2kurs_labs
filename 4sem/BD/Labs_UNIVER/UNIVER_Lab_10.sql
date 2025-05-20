USE UNIVER;

---- 1. Кластеризованный индекс
exec sp_helpindex 'AUDITORIUM'
exec sp_helpindex 'AUDITORIUM_TYPE'
exec sp_helpindex 'FACULTY'
exec sp_helpindex 'GROUPS'
exec sp_helpindex 'PROFESSION'
exec sp_helpindex 'PULPIT'
exec sp_helpindex 'PROGRESS'
exec sp_helpindex 'STUDENT'
exec sp_helpindex 'SUBJECT'
exec sp_helpindex 'TEACHER'

CREATE TABLE #UNIVER_EXAMPLE (
    ID int,
    DataField varchar(100)
);

DECLARE @i int = 0;
WHILE @i < 2000
BEGIN
    INSERT #UNIVER_EXAMPLE(ID, DataField)
    VALUES (FLOOR(30000*RAND()), REPLICATE('example data ', 5));
    SET @i = @i + 1;
END;

SELECT * FROM #UNIVER_EXAMPLE WHERE ID BETWEEN 1500 AND 2500 ORDER BY ID;

CHECKPOINT;
DBCC DROPCLEANBUFFERS;

CREATE CLUSTERED INDEX #UNIVER_EXAMPLE_CL ON #UNIVER_EXAMPLE(ID ASC);

SELECT * FROM #UNIVER_EXAMPLE WHERE ID BETWEEN 1500 AND 2500 ORDER BY ID;


DROP TABLE IF EXISTS #UNIVER_EXAMPLE;


---- 2. Некластеризованный составной индекс
CREATE TABLE #UNIVER_COMPOSITE (
    KeyField int,
    Counter int IDENTITY(1,1),
    TextField varchar(100)
);

SET NOCOUNT ON;
DECLARE @j int = 0;
WHILE @j < 20000
BEGIN
    INSERT #UNIVER_COMPOSITE(KeyField, TextField)
    VALUES (FLOOR(30000*RAND()), REPLICATE('composite example ', 3));
    SET @j = @j + 1;
END;

CREATE INDEX #UNIVER_COMPOSITE_IDX ON #UNIVER_COMPOSITE(KeyField, Counter);

SELECT * FROM #UNIVER_COMPOSITE WHERE KeyField > 1500 AND Counter < 4500;
SELECT * FROM #UNIVER_COMPOSITE ORDER BY KeyField, Counter;
SELECT * FROM #UNIVER_COMPOSITE WHERE KeyField = 556 AND Counter > 3;


DROP TABLE IF EXISTS #UNIVER_COMPOSITE;



---- 3. Некластеризованный индекс покрытия
CREATE TABLE #UNIVER_COVERING (
    KeyField int,
    Counter int IDENTITY(1,1),
    TextField varchar(100)
);

SET NOCOUNT ON;
DECLARE @k int = 0;
WHILE @k < 20000
BEGIN
    INSERT #UNIVER_COVERING(KeyField, TextField)
    VALUES (FLOOR(30000*RAND()), REPLICATE('covering example', 3));
    SET @k = @k + 1;
END;

CREATE INDEX #UNIVER_COVERING_IDX ON #UNIVER_COVERING(KeyField) INCLUDE (Counter);

SELECT Counter FROM #UNIVER_COVERING WHERE KeyField > 15000;


DROP TABLE IF EXISTS #UNIVER_COVERING;




---- 4. Фильтруемый индекс
CREATE TABLE #UNIVER_FILTERED (
    KeyField int,
    Counter int IDENTITY(1,1),
    TextField varchar(100)
);

SET NOCOUNT ON;
DECLARE @m int = 0;
WHILE @m < 20000
BEGIN
    INSERT #UNIVER_FILTERED(KeyField, TextField)
    VALUES (FLOOR(30000*RAND()), REPLICATE('filtered example', 3));
    SET @m = @m + 1;
END;

CREATE INDEX #UNIVER_FILTERED_IDX ON #UNIVER_FILTERED(KeyField) 
WHERE (KeyField >= 15000 AND KeyField < 20000);

SELECT KeyField FROM #UNIVER_FILTERED WHERE KeyField BETWEEN 5000 AND 19999;
SELECT KeyField FROM #UNIVER_FILTERED WHERE KeyField > 15000 AND KeyField < 20000;
SELECT KeyField FROM #UNIVER_FILTERED WHERE KeyField = 17000; 


DROP TABLE IF EXISTS #UNIVER_FILTERED;



---- 5. Фрагментация индекса 
CREATE TABLE #UNIVER_FRAGMENTATION (
    KeyField int,
    Counter int IDENTITY(1,1),
    TextField varchar(100)
);

SET NOCOUNT ON;
DECLARE @n int = 0;
WHILE @n < 20000
BEGIN
    INSERT #UNIVER_FRAGMENTATION(KeyField, TextField)
    VALUES (FLOOR(30000*RAND()), REPLICATE('fragmentation example', 2));
    SET @n = @n + 1;
END;

CREATE INDEX #UNIVER_FRAG_IDX ON #UNIVER_FRAGMENTATION(KeyField);

INSERT TOP(10000) #UNIVER_FRAGMENTATION(KeyField, TextField) 
SELECT KeyField, TextField FROM #UNIVER_FRAGMENTATION;

SELECT 
    name AS [Индекс], 
    avg_fragmentation_in_percent AS [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(N'TEMPDB'), 
    OBJECT_ID(N'#UNIVER_FRAGMENTATION'), NULL, NULL, NULL) ss
JOIN sys.indexes ii ON ss.object_id = ii.object_id AND ss.index_id = ii.index_id
WHERE name IS NOT NULL;

ALTER INDEX #UNIVER_FRAG_IDX ON #UNIVER_FRAGMENTATION REORGANIZE;

SELECT 
    name AS [Индекс], 
    avg_fragmentation_in_percent AS [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(N'TEMPDB'), 
    OBJECT_ID(N'#UNIVER_FRAGMENTATION'), NULL, NULL, NULL) ss
JOIN sys.indexes ii ON ss.object_id = ii.object_id AND ss.index_id = ii.index_id
WHERE name IS NOT NULL;

ALTER INDEX #UNIVER_FRAG_IDX ON #UNIVER_FRAGMENTATION REBUILD WITH (ONLINE = OFF);

SELECT 
    name AS [Индекс], 
    avg_fragmentation_in_percent AS [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(N'TEMPDB'), 
    OBJECT_ID(N'#UNIVER_FRAGMENTATION'), NULL, NULL, NULL) ss
JOIN sys.indexes ii ON ss.object_id = ii.object_id AND ss.index_id = ii.index_id
WHERE name IS NOT NULL;


DROP TABLE IF EXISTS #UNIVER_FRAGMENTATION;


---- 6. Параметр FILLFACTOR
CREATE TABLE #UNIVER_FILLFACTOR (
    KeyField int,
    Counter int IDENTITY(1,1),
    TextField varchar(100)
);

SET NOCOUNT ON;
DECLARE @n1 int = 0;
WHILE @n1 < 20000
BEGIN
    INSERT #UNIVER_FILLFACTOR(KeyField, TextField)
    VALUES (FLOOR(30000*RAND()), REPLICATE('fillfactor example', 2));
    SET @n1 = @n1 + 1;
END;

CREATE INDEX #UNIVER_FILLFACTOR_IDX ON #UNIVER_FILLFACTOR(KeyField)
WITH (FILLFACTOR = 65);

INSERT TOP(50) PERCENT INTO #UNIVER_FILLFACTOR(KeyField, TextField) 
SELECT KeyField, TextField FROM #UNIVER_FILLFACTOR;

SELECT 
    name AS [Индекс], 
    avg_fragmentation_in_percent AS [Фрагментация (%)],
    page_count AS [Количество страниц],
    avg_page_space_used_in_percent AS [Использовано места на странице (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(N'TEMPDB'), 
    OBJECT_ID(N'#UNIVER_FILLFACTOR'), NULL, NULL, NULL) ss
JOIN sys.indexes ii ON ss.object_id = ii.object_id AND ss.index_id = ii.index_id
WHERE name IS NOT NULL;

CREATE INDEX #UNIVER_FILLFACTOR_IDX2 ON #UNIVER_FILLFACTOR(KeyField)
WITH (FILLFACTOR = 100);

SELECT 
    name AS [Индекс], 
    avg_fragmentation_in_percent AS [Фрагментация (%)],
    page_count AS [Количество страниц],
    avg_page_space_used_in_percent AS [Использовано места на странице (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(N'TEMPDB'), 
    OBJECT_ID(N'#UNIVER_FILLFACTOR'), NULL, NULL, NULL) ss
JOIN sys.indexes ii ON ss.object_id = ii.object_id AND ss.index_id = ii.index_id
WHERE name IS NOT NULL;


DROP TABLE IF EXISTS #UNIVER_FILLFACTOR;

