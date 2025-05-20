--USE UNIVER;

-- 1. Представление "Преподаватель"
--CREATE VIEW Преподаватель AS
--SELECT 
--    TEACHER AS Код, 
--    TEACHER_NAME AS Имя_преподавателя, 
--    GENDER AS Пол, 
--    PULPIT AS Код_кафедры
--FROM TEACHER;

---- 2. Представление "Количество кафедр"
--CREATE VIEW Количество_кафедр AS
--SELECT 
--    f.FACULTY_NAME AS Факультет, 
--    COUNT(p.PULPIT) AS Количество_кафедр
--FROM FACULTY f
--LEFT JOIN PULPIT p ON f.FACULTY = p.FACULTY
--GROUP BY f.FACULTY_NAME;

---- 3. Представление "Аудитории" с возможностью модификации
--CREATE VIEW Аудитории AS
--SELECT 
--    AUDITORIUM AS Код, 
--    AUDITORIUM_NAME AS Наименование_аудитории
--FROM AUDITORIUM
--WHERE AUDITORIUM_TYPE LIKE 'LK%'
--WITH CHECK OPTION;

---- 4. Представление "Лекционные_аудитории"
--CREATE VIEW Лекционные_аудитории AS
--SELECT 
--    AUDITORIUM AS Код, 
--    AUDITORIUM_NAME AS Наименование_аудитории
--FROM AUDITORIUM
--WHERE AUDITORIUM_TYPE LIKE 'LK%';

---- 5. Представление "Дисциплины"
--CREATE VIEW Дисциплины AS
--SELECT TOP 100 PERCENT
--    SUBJECT AS Код, 
--    SUBJECT_NAME AS Наименование_дисциплины, 
--    PULPIT AS Код_кафедры
--FROM SUBJECT
--ORDER BY SUBJECT_NAME;

---- 6. Измененное представление "Количество_кафедр" с привязкой к схемам
--ALTER VIEW Количество_кафедр WITH SCHEMABINDING AS
--SELECT 
--    f.FACULTY_NAME AS Факультет, 
--    COUNT(p.PULPIT) AS Количество_кафедр
--FROM dbo.FACULTY f
--LEFT JOIN dbo.PULPIT p ON f.FACULTY = p.FACULTY
--GROUP BY f.FACULTY_NAME;



















-------- Эта команда вызовет ошибку, так как представление привязано к таблице
------ALTER TABLE dbo.FACULTY DROP COLUMN FACULTY_NAME;
