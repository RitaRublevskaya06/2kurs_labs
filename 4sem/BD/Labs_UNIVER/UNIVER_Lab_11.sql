USE UNIVER;

------ 1. Cписок дисциплин на кафедре ИСиТ
DECLARE @subject_list NVARCHAR(MAX) = '';
DECLARE @subject_name NVARCHAR(100);

DECLARE SubjectCursor CURSOR FOR 
SELECT RTRIM(SUBJECT_NAME) FROM SUBJECT 
WHERE PULPIT = 'ISIT'
ORDER BY SUBJECT_NAME;

OPEN SubjectCursor;
FETCH NEXT FROM SubjectCursor INTO @subject_name;

WHILE @@FETCH_STATUS = 0
BEGIN
    IF LEN(@subject_list) > 0
        SET @subject_list = @subject_list + ', ' + @subject_name;
    ELSE
        SET @subject_list = @subject_name;
    
    FETCH NEXT FROM SubjectCursor INTO @subject_name;
END

CLOSE SubjectCursor;
DEALLOCATE SubjectCursor;

PRINT 'Дисциплины кафедры ИСиТ: ' + @subject_list;


-------- 2. Сценарий, демонстрирующий отличие глобального курсора от локального 
------ 2.1 Локальный курсор
DECLARE LocalStudentCursor CURSOR LOCAL FOR
SELECT NAME FROM STUDENT 
WHERE IDGROUP IN (SELECT IDGROUP FROM GROUPS WHERE FACULTY = 'IT')
ORDER BY NAME;

DECLARE @student_name NVARCHAR(100);

OPEN LocalStudentCursor;
FETCH NEXT FROM LocalStudentCursor INTO @student_name;

PRINT 'Локальный курсор - первый студент: ' + @student_name;
GO

DECLARE @student_name NVARCHAR(100);

FETCH NEXT FROM LocalStudentCursor INTO @student_name;
PRINT 'Локальный курсор - второй студент: ' + @student_name;
GO

------ 2.2 Глобальный курсор
DECLARE GlobalStudentCursor CURSOR GLOBAL FOR
SELECT NAME FROM STUDENT 
WHERE IDGROUP IN (SELECT IDGROUP FROM GROUPS WHERE FACULTY = 'IT')
ORDER BY NAME;

DECLARE @student_name NVARCHAR(100);

OPEN GlobalStudentCursor;
FETCH NEXT FROM GlobalStudentCursor INTO @student_name;

PRINT 'Глобальный курсор - первый студент: ' + @student_name;
GO

DECLARE @student_name NVARCHAR(100);

FETCH NEXT FROM GlobalStudentCursor INTO @student_name;
PRINT 'Глобальный курсор - второй студент: ' + @student_name;

CLOSE GlobalStudentCursor;
DEALLOCATE GlobalStudentCursor;
GO

-------- 3. Сценарий, демонстрирующий отличие статических курсоров от динамических 
------ 3.1 Статический курсор 
CREATE TABLE #TempProgress (
    StudentID INT,
    Subject CHAR(10),
    Note INT
);
INSERT INTO #TempProgress
SELECT IDSTUDENT, SUBJECT, NOTE 
FROM PROGRESS 
WHERE SUBJECT = 'OAP' AND NOTE >= 4;
DECLARE @student_id INT, @subject CHAR(10), @note INT;

DECLARE StaticCursor CURSOR LOCAL STATIC FOR
SELECT StudentID, Subject, Note FROM #TempProgress
ORDER BY StudentID;

OPEN StaticCursor;
PRINT 'Количество строк в статическом курсоре: ' + CAST(@@CURSOR_ROWS AS VARCHAR(10));

UPDATE #TempProgress SET Note = 10 WHERE StudentID = 1001;
DELETE FROM #TempProgress WHERE StudentID = 1002;
INSERT INTO #TempProgress VALUES (1004, 'OAP', 7);

PRINT 'Данные из статического курсора:';
FETCH NEXT FROM StaticCursor INTO @student_id, @subject, @note;
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT CAST(@student_id AS VARCHAR) + ' | ' + @subject + ' | ' + CAST(@note AS VARCHAR);
    FETCH NEXT FROM StaticCursor INTO @student_id, @subject, @note;
END

CLOSE StaticCursor;
DEALLOCATE StaticCursor;

PRINT 'Актуальные данные в таблице:';
SELECT * FROM #TempProgress ORDER BY StudentID;

DROP TABLE #TempProgress;

------ 3.2 Динамический курсор 
CREATE TABLE #TempProgress1 (
    StudentID1 INT,
    Subject1 CHAR(10),
    Note1 INT
);

INSERT INTO #TempProgress1
SELECT IDSTUDENT, SUBJECT, NOTE 
FROM PROGRESS 
WHERE SUBJECT = 'DB' AND NOTE >= 4;

DECLARE @student_id1 INT, @subject1 CHAR(10), @note1 INT;

DECLARE DynamicCursor CURSOR LOCAL DYNAMIC FOR
SELECT StudentID1, Subject1, Note1 FROM #TempProgress1
ORDER BY StudentID1;

OPEN DynamicCursor;

UPDATE #TempProgress1 SET Note1 = 9 WHERE StudentID1 = 1014;
DELETE FROM #TempProgress1 WHERE StudentID1 = 1015;
INSERT INTO #TempProgress1 VALUES (1017, 'DB', 6);

PRINT 'Данные из динамического курсора:';
FETCH NEXT FROM DynamicCursor INTO @student_id1, @subject1, @note1;
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT CAST(@student_id1 AS VARCHAR) + ' | ' + @subject1 + ' | ' + CAST(@note1 AS VARCHAR);
    FETCH NEXT FROM DynamicCursor INTO @student_id1, @subject1, @note1;
END

CLOSE DynamicCursor;
DEALLOCATE DynamicCursor;

PRINT 'Актуальные данные в таблице:';
SELECT * FROM #TempProgress1 ORDER BY StudentID1;


DROP TABLE #TempProgress1;


-------- 4. Сценарий, демонстрирующий свойства навигации 
CREATE TABLE #TempSubjects (
    RowNum INT,
    SubjectName NVARCHAR(100),
    Faculty CHAR(10)
);
INSERT INTO #TempSubjects
SELECT 
    ROW_NUMBER() OVER (ORDER BY SUBJECT_NAME) AS RowNum,
    SUBJECT_NAME,
    'ISIT' AS Faculty
FROM SUBJECT
WHERE PULPIT = 'ISIT';

DECLARE @row_num INT, @subject_name NVARCHAR(100), @faculty CHAR(10);

DECLARE ScrollCursor CURSOR LOCAL SCROLL FOR
SELECT RowNum, SubjectName, Faculty 
FROM #TempSubjects
ORDER BY RowNum;

OPEN ScrollCursor;
PRINT 'Навигация по дисциплинам кафедры ИСиТ с помощью SCROLL-курсора:';
PRINT '-----------------------------------------------------------';

FETCH FIRST FROM ScrollCursor INTO @row_num, @subject_name, @faculty;
PRINT 'FIRST:     Строка ' + CAST(@row_num AS VARCHAR) + ' - ' + @subject_name;

FETCH NEXT FROM ScrollCursor INTO @row_num, @subject_name, @faculty;
PRINT 'NEXT:      Строка ' + CAST(@row_num AS VARCHAR) + ' - ' + @subject_name;

FETCH ABSOLUTE 3 FROM ScrollCursor INTO @row_num, @subject_name, @faculty;
PRINT 'ABSOLUTE 3: Строка ' + CAST(@row_num AS VARCHAR) + ' - ' + @subject_name;

FETCH RELATIVE 5 FROM ScrollCursor INTO @row_num, @subject_name, @faculty;
PRINT 'RELATIVE 5: Строка ' + CAST(@row_num AS VARCHAR) + ' - ' + @subject_name;

FETCH PRIOR FROM ScrollCursor INTO @row_num, @subject_name, @faculty;
PRINT 'PRIOR:     Строка ' + CAST(@row_num AS VARCHAR) + ' - ' + @subject_name;

FETCH ABSOLUTE -3 FROM ScrollCursor INTO @row_num, @subject_name, @faculty;
PRINT 'ABSOLUTE -3: Строка ' + CAST(@row_num AS VARCHAR) + ' - ' + @subject_name;

FETCH RELATIVE -5 FROM ScrollCursor INTO @row_num, @subject_name, @faculty;
PRINT 'RELATIVE -5: Строка ' + CAST(@row_num AS VARCHAR) + ' - ' + @subject_name;

FETCH LAST FROM ScrollCursor INTO @row_num, @subject_name, @faculty;
PRINT 'LAST:      Строка ' + CAST(@row_num AS VARCHAR) + ' - ' + @subject_name;

CLOSE ScrollCursor;
DEALLOCATE ScrollCursor;

DROP TABLE #TempSubjects;


------- 5. Курсор, демонстрирующий применение конструкции CURRENT OF
CREATE TABLE #TempProgress (
    StudentID INT,
    Subject CHAR(10),
    Note INT
);

INSERT INTO #TempProgress VALUES 
(1001, 'OAP', 5),
(1002, 'OAP', 3),
(1003, 'OAP', 4);

DECLARE @id INT, @mark INT;
DECLARE StudentCursor CURSOR FOR 
SELECT StudentID, Note FROM #TempProgress
FOR UPDATE;

OPEN StudentCursor;
FETCH NEXT FROM StudentCursor INTO @id, @mark;

WHILE @@FETCH_STATUS = 0
BEGIN
    UPDATE #TempProgress SET Note = Note + 1 
    WHERE CURRENT OF StudentCursor;
    
    IF @mark < 4
        DELETE FROM #TempProgress WHERE CURRENT OF StudentCursor;
    
    FETCH NEXT FROM StudentCursor INTO @id, @mark;
END

CLOSE StudentCursor;
DEALLOCATE StudentCursor;

SELECT * FROM #TempProgress;
DROP TABLE #TempProgress;


------- 6.1 Удаление записей о студентах с оценками ниже 6
DECLARE @count INT = (SELECT COUNT(*) FROM PROGRESS WHERE NOTE < 6);
PRINT 'Найдено ' + CAST(@count AS VARCHAR) + ' записей с оценками ниже 6';

DECLARE @idstudent6 INT, @subject6 CHAR(10), @note6 INT;
DECLARE BadGradesCursor CURSOR FOR 
    SELECT p.IDSTUDENT, p.SUBJECT, p.NOTE 
    FROM PROGRESS p
    JOIN STUDENT s ON p.IDSTUDENT = s.IDSTUDENT
    JOIN GROUPS g ON s.IDGROUP = g.IDGROUP
    WHERE p.NOTE < 6
    FOR UPDATE;

OPEN BadGradesCursor;
FETCH NEXT FROM BadGradesCursor INTO @idstudent6, @subject6, @note6;

IF @@FETCH_STATUS <> 0
    PRINT 'Нет записей для удаления';
ELSE
BEGIN
    WHILE @@FETCH_STATUS = 0
    BEGIN
        DELETE FROM PROGRESS 
        WHERE CURRENT OF BadGradesCursor;
        
        PRINT 'Удалена оценка ' + CAST(@note6 AS VARCHAR) + 
              ' студента ' + CAST(@idstudent6 AS VARCHAR) + 
              ' по предмету ' + @subject6;
        
        FETCH NEXT FROM BadGradesCursor INTO @idstudent6, @subject6, @note6;
    END
    PRINT 'Удаление завершено';
END

CLOSE BadGradesCursor;
DEALLOCATE BadGradesCursor;


--------- 6.2 Увеличение оценки конкретному студенту
DECLARE @target_id INT = 1002;

DECLARE UpdateGradeCursor CURSOR FOR 
    SELECT IDSTUDENT, SUBJECT, NOTE 
    FROM PROGRESS 
    WHERE IDSTUDENT = @target_id
    FOR UPDATE;

OPEN UpdateGradeCursor;
FETCH NEXT FROM UpdateGradeCursor INTO @idstudent6, @subject6, @note6;

WHILE @@FETCH_STATUS = 0
BEGIN
    UPDATE PROGRESS 
    SET NOTE = NOTE + 1 
    WHERE CURRENT OF UpdateGradeCursor;
    
    PRINT 'Студент ' + CAST(@idstudent6 AS VARCHAR) + 
          ' по предмету ' + @subject6 + 
          ': оценка изменена с ' + CAST(@note6 AS VARCHAR) + 
          ' на ' + CAST(@note6 + 1 AS VARCHAR);
    
    FETCH NEXT FROM UpdateGradeCursor INTO @idstudent6, @subject6, @note6;
END

CLOSE UpdateGradeCursor;
DEALLOCATE UpdateGradeCursor;


