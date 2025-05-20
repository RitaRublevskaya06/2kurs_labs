USE UNIVER;

---- Задание 1: Работа с переменными разных типов
DECLARE @char_var CHAR(10) = 'Char',
        @varchar_var VARCHAR(20) = 'Varchar',
        @datetime_var DATETIME,
        @time_var TIME,
        @int_var INT,
        @smallint_var SMALLINT,
        @tinyint_var TINYINT,
        @numeric_var NUMERIC(12,5);

SET @datetime_var = GETDATE();
SET @time_var = CONVERT(TIME, GETDATE());
SET @int_var = 1234567890;
SET @smallint_var = 32767;
SET @tinyint_var = 255;
SET @numeric_var = 1234567.12345;

SELECT @datetime_var = TRY_CONVERT(DATETIME, '2023-05-15 14:30:00'),
       @time_var = TRY_CONVERT(TIME, '14:30:00');

IF @datetime_var IS NULL
    SET @datetime_var = GETDATE();

IF @time_var IS NULL
    SET @time_var = CONVERT(TIME, GETDATE());

SELECT 
    @char_var AS char_variable,
    @varchar_var AS varchar_variable,
    @int_var AS int_variable,
    @smallint_var AS smallint_variable;

BEGIN
    PRINT 'Datetime: ' + ISNULL(CONVERT(VARCHAR(30), @datetime_var, 120), 'Invalid date');
    PRINT 'Time: ' + ISNULL(CONVERT(VARCHAR(30), @time_var, 108), 'Invalid time');
    PRINT 'Tinyint: ' + CAST(@tinyint_var AS VARCHAR(10));
    PRINT 'Numeric: ' + CAST(@numeric_var AS VARCHAR(20));
END

---- Задание 2: Анализ вместимости аудиторий
DECLARE @total_capacity INT;
SELECT @total_capacity = SUM(AUDITORIUM_CAPACITY) FROM AUDITORIUM;

IF @total_capacity > 200
BEGIN
    DECLARE @auditorium_count INT, @avg_capacity DECIMAL(10,2), 
            @below_avg_count INT, @below_avg_percent DECIMAL(5,2);
    
    SELECT @auditorium_count = COUNT(*) FROM AUDITORIUM;
    SELECT @avg_capacity = AVG(AUDITORIUM_CAPACITY) FROM AUDITORIUM;
    SELECT @below_avg_count = COUNT(*) 
    FROM AUDITORIUM 
    WHERE AUDITORIUM_CAPACITY < @avg_capacity;
    
    SET @below_avg_percent = (@below_avg_count * 100.0) / @auditorium_count;
    
    SELECT @auditorium_count AS 'Количество аудиторий',
           @avg_capacity AS 'Средняя вместимость',
           @below_avg_count AS 'Количество аудиторий с вместимостью ниже средней',
           @below_avg_percent AS 'Процент таких аудиторий';
END
ELSE
BEGIN
    PRINT 'Общая вместимость аудиторий: ' + CAST(@total_capacity AS VARCHAR);
END

------ Задание 3. Глобальные переменные
SELECT 
    @@ROWCOUNT AS 'Число обработанных строк',
    @@VERSION AS 'Версия SQL Server',
    @@SPID AS 'Идентификатор процесса',
    @@ERROR AS 'Код последней ошибки',
    @@SERVERNAME AS 'Имя сервера',
    @@TRANCOUNT AS 'Уровень вложенности транзакции',
    @@FETCH_STATUS AS 'Статус считывания',
    @@NESTLEVEL AS 'Уровень вложенности процедуры';


---- Задание 4. Различные T-SQL скрипты
---- 4.1 Вычисление значения переменной z
DECLARE @x FLOAT = 5, @t FLOAT = 10, @z FLOAT;

IF @t > @x
    SET @z = POWER(SIN(@t), 2);
ELSE IF @t < @x
    SET @z = 4 * (@t + @x);
ELSE
    SET @z = 1 - EXP(@x - 2);

PRINT 'Значение z: ' + CAST(@z AS VARCHAR);

---- 4.2 Преобразование ФИО в сокращенное
DECLARE @full_name VARCHAR(100) = 'Макейчик Татьяна Леонидовна';
DECLARE @short_name VARCHAR(100);

SET @short_name = 
    SUBSTRING(@full_name, 1, CHARINDEX(' ', @full_name)) + ' ' + 
    SUBSTRING(@full_name, CHARINDEX(' ', @full_name) + 1, 1) + '. ' +
    SUBSTRING(@full_name, 
              CHARINDEX(' ', @full_name, CHARINDEX(' ', @full_name) + 1) + 1, 
              1) + '.';

PRINT 'Полное имя: ' + @full_name;
PRINT 'Сокращенное имя: ' + @short_name;

---- 4.3 Поиск студентов с ДР в следующем месяце и их возраст
DECLARE @current_month INT = MONTH(GETDATE());
DECLARE @next_month INT = @current_month + 1;
IF @next_month > 12 SET @next_month = 1;

SELECT 
    NAME AS 'ФИО студента',
    BDAY AS 'Дата рождения',
    DATEDIFF(YEAR, BDAY, GETDATE()) - 
        CASE 
            WHEN MONTH(BDAY) > MONTH(GETDATE()) OR 
                 (MONTH(BDAY) = MONTH(GETDATE()) AND DAY(BDAY) > DAY(GETDATE())) 
            THEN 1 
            ELSE 0 
        END AS 'Возраст'
FROM STUDENT
WHERE MONTH(BDAY) = @next_month;

---- 4.4 Поиск дня недели сдачи экзамена по БД
SELECT 
    DATENAME(WEEKDAY, PDATE) AS 'День недели',
    COUNT(*) AS 'Количество экзаменов'
FROM PROGRESS
WHERE SUBJECT = 'DB'
GROUP BY DATENAME(WEEKDAY, PDATE);


---- Задание 5. Конструкция IF...ELSE
DECLARE @it_students INT;
SELECT @it_students = COUNT(*) 
FROM STUDENT s
JOIN GROUPS g ON s.IDGROUP = g.IDGROUP
JOIN FACULTY f ON g.FACULTY = f.FACULTY
WHERE f.FACULTY_NAME = 'Faculty of Information Technology';

IF @it_students > 50
    PRINT 'На факультете информационных технологий более 50 студентов: ' + CAST(@it_students AS VARCHAR);
ELSE
    PRINT 'На факультете информационных технологий 50 или менее студентов: ' + CAST(@it_students AS VARCHAR);

---- Задание 6. Анализ оценок с помощью CASE
SELECT 
    s.NAME AS 'Студент',
    p.NOTE AS 'Оценка',
    CASE 
        WHEN p.NOTE BETWEEN 9 AND 10 THEN 'Отлично'
        WHEN p.NOTE BETWEEN 7 AND 8 THEN 'Хорошо'
        WHEN p.NOTE BETWEEN 5 AND 6 THEN 'Удовлетворительно'
        ELSE 'Неудовлетворительно'
    END AS 'Результат'
FROM PROGRESS p
JOIN STUDENT s ON p.IDSTUDENT = s.IDSTUDENT
JOIN GROUPS g ON s.IDGROUP = g.IDGROUP
JOIN FACULTY f ON g.FACULTY = f.FACULTY
WHERE f.FACULTY_NAME = 'Faculty of Information Technology'
ORDER BY p.NOTE DESC;


---- Задание 7. Временная локальная таблица
CREATE TABLE #TempTable (
    ID INT,
    Name VARCHAR(50),
    Value NUMERIC(10,2)
);

DECLARE @counter INT = 1;
WHILE @counter <= 10
BEGIN
    INSERT INTO #TempTable (ID, Name, Value)
    VALUES (@counter, 'Item ' + CAST(@counter AS VARCHAR), RAND() * 100);
    
    SET @counter = @counter + 1;
END

SELECT * FROM #TempTable;

DROP TABLE #TempTable;



---- Задание 8. Оператор RETURN
DECLARE @input INT = -5;
--DECLARE @input INT = 16;

IF @input < 0
BEGIN
    PRINT 'Отрицательное число!';
    RETURN;
END

PRINT 'Квадратный корень: ' + CAST(SQRT(@input) AS VARCHAR);


---- Задание 9. Обработка ошибок с TRY/CATCH
BEGIN TRY
    DECLARE @a INT = 10, @b INT = 0;
    DECLARE @result INT = @a / @b;
    
    PRINT 'Результат: ' + CAST(@result AS VARCHAR);
END TRY
BEGIN CATCH
    PRINT 'Произошла ошибка:';
    PRINT 'Код ошибки: ' + CAST(ERROR_NUMBER() AS VARCHAR);
    PRINT 'Сообщение: ' + ERROR_MESSAGE();
    PRINT 'Строка: ' + CAST(ERROR_LINE() AS VARCHAR);
    PRINT 'Процедура: ' + ISNULL(ERROR_PROCEDURE(), 'N/A');
    PRINT 'Уровень серьезности: ' + CAST(ERROR_SEVERITY() AS VARCHAR);
    PRINT 'Состояние: ' + CAST(ERROR_STATE() AS VARCHAR);
END CATCH