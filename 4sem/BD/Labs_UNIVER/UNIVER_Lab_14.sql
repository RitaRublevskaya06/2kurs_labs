USE UNIVER;

---- 1. Разработать скалярную функцию с именем COUNT_STUDENTS
---- 1.1
GO
CREATE FUNCTION COUNT_STUDENTS (@faculty VARCHAR(20)) RETURNS INT
AS 
BEGIN
	DECLARE @rc INT = 0;
	SET @rc = (
		SELECT COUNT(*) 
		FROM FACULTY f 
		JOIN GROUPS g ON f.FACULTY = g.FACULTY
		JOIN STUDENT s ON s.IDGROUP = g.IDGROUP 
		WHERE f.FACULTY = @faculty
	);
	RETURN @rc;
END;
GO

DECLARE @f INT = dbo.COUNT_STUDENTS('IT');
PRINT N'Кол-во студентов: ' + CAST(@f AS VARCHAR(3));
GO

---- 1.2
ALTER FUNCTION COUNT_STUDENTS (@faculty VARCHAR(20), @prof VARCHAR(20) = NULL) RETURNS INT
AS 
BEGIN
	DECLARE @rc INT = 0;
	SET @rc = (
		SELECT COUNT(*) 
		FROM FACULTY f 
		JOIN GROUPS g ON f.FACULTY = g.FACULTY
		JOIN STUDENT s ON s.IDGROUP = g.IDGROUP 
		WHERE f.FACULTY = @faculty 
		AND g.PROFESSION = ISNULL(@prof, g.PROFESSION)
	);
	RETURN @rc;
END;
GO

SELECT 
    f.FACULTY,
    g.PROFESSION,
    dbo.COUNT_STUDENTS(f.FACULTY, g.PROFESSION) AS StudentsCount
FROM FACULTY f
JOIN GROUPS g ON f.FACULTY = g.FACULTY;


---- 2. Разработать скалярную функцию с именем FSUBJECTS
GO
CREATE FUNCTION FSUBJECTS (@p VARCHAR(20)) RETURNS NVARCHAR(300) 
AS 
BEGIN
	DECLARE @tv CHAR(20);  
    DECLARE @t NVARCHAR(300) = N'Дисциплины: ';  
	DECLARE SCursor CURSOR LOCAL STATIC 
		FOR SELECT SUBJECT FROM SUBJECT WHERE PULPIT = @p;
                                                      
	OPEN SCursor;	  
    FETCH SCursor INTO @tv;   	 
    WHILE @@FETCH_STATUS = 0                                     
    BEGIN 
		SET @t = @t + N', ' + RTRIM(@tv);         
        FETCH SCursor INTO @tv; 
    END;
    
    CLOSE SCursor;
    DEALLOCATE SCursor;
    
	RETURN @t;
END
GO

SELECT PULPIT, dbo.FSUBJECTS(SUBJECT.PULPIT) FROM SUBJECT;

---- 3. Разработать табличную функцию FFACPUL
IF OBJECT_ID('dbo.FFACPUL', 'IF') IS NOT NULL
    DROP FUNCTION dbo.FFACPUL;
GO

CREATE FUNCTION dbo.FFACPUL (
    @faculty_code VARCHAR(20) = NULL,
    @pulpit_code VARCHAR(20) = NULL
) 
RETURNS TABLE 
AS 
RETURN (
    SELECT 
        f.FACULTY,
        p.PULPIT
    FROM dbo.FACULTY f 
    LEFT JOIN dbo.PULPIT p ON f.FACULTY = p.FACULTY
    WHERE 
        (@faculty_code IS NULL OR f.FACULTY = @faculty_code)
        AND (@pulpit_code IS NULL OR p.PULPIT = @pulpit_code)
);
GO

SELECT * FROM dbo.FFACPUL(NULL, NULL);
SELECT * FROM dbo.FFACPUL('IT', NULL)
SELECT * FROM dbo.FFACPUL(NULL, 'ISIT')
SELECT * FROM dbo.FFACPUL('IT', 'ISIT')


---- 4. Разработать функцию FCTEACHER
GO
IF OBJECT_ID('dbo.FCTEACHER', 'FN') IS NOT NULL
    DROP FUNCTION dbo.FCTEACHER;
GO

CREATE FUNCTION dbo.FCTEACHER (@pulpit NVARCHAR(20) = NULL) RETURNS INT
AS
BEGIN
    RETURN (
        SELECT COUNT(*) 
        FROM TEACHER 
        WHERE 
            @pulpit IS NULL 
            OR PULPIT = @pulpit
    );
END;
GO

SELECT PULPIT, dbo.FCTEACHER(PULPIT) AS [Колво преподавателей] 
FROM PULPIT;
GO

SELECT dbo.FCTEACHER(NULL) AS [Всего преподавателей];
