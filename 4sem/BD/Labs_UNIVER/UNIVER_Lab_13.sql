USE UNIVER;

----1. ��������� ��� �������� ����� � ������ ����������� �������
DROP PROCEDURE PSUBJECT;
GO
CREATE PROCEDURE PSUBJECT
AS
BEGIN
    DECLARE @m INT = (SELECT COUNT(*) FROM SUBJECT);
    SELECT * FROM SUBJECT;
    RETURN @m;
END

DECLARE @n INT = 0;
EXEC @n = PSUBJECT;
PRINT '���������� �������: ' + CAST(@n AS VARCHAR);


----2. ���������������� ��������� � �����������
GO
/****** Object:  StoredProcedure [dbo].[PSUBJECT]    Script Date: 23.05.2025 22:21:14 ******/
SET ANSI_NULLS ON --��������� � null
GO
SET QUOTED_IDENTIFIER ON --�������
GO

ALTER PROCEDURE PSUBJECT 
    @p VARCHAR(20),
    @s INT OUTPUT 
AS
BEGIN
    DECLARE @total_count INT = (SELECT COUNT(*) FROM SUBJECT);
    PRINT N'���������: @p = ' + @p + N', @s = ' + CAST(@s AS VARCHAR(3));
    SELECT * FROM SUBJECT WHERE PULPIT = @p;
    SET @s = @@ROWCOUNT;
    IF @s = 0
        PRINT N'�������� ��� ������� ' + @p + N' �� �������!';
    RETURN @total_count;
END;
GO

DECLARE 
    @total INT,  
    @count INT,
    @pulpit VARCHAR(20) = 'ISIT'; 
SET @count = 0;

EXEC @total = PSUBJECT 
    @p = @pulpit, 
    @s = @count OUTPUT;

PRINT N'����� ���������� ���������: ' + CAST(@total AS VARCHAR);
PRINT N'���������� ��������� �� ������� ' + @pulpit + N': ' + CAST(@count AS VARCHAR);


---- 3. ������� ��������� ��������� ������� � ������ #SUBJECT. 
GO
ALTER PROCEDURE [dbo].[PSUBJECT] @p VARCHAR(20)
AS
BEGIN
    DECLARE @k INT = (SELECT COUNT(*) FROM SUBJECT);
    SELECT * FROM SUBJECT WHERE SUBJECT.PULPIT = @p;
END;
GO

CREATE TABLE #SUBJECT(
    SUBJECT VARCHAR(10) PRIMARY KEY,
    SUBJECT_NAME  VARCHAR(100),
    PULPIT  VARCHAR(10)
);

INSERT INTO #SUBJECT 
EXEC PSUBJECT @p = 'ISIT';

SELECT * FROM #SUBJECT;


---- 4. ����������� ��������� � ������ PAUDITORIUM_INSERT.
GO
CREATE PROCEDURE PAUDITORIUM_INSERT 
    @a CHAR(20), 
    @n VARCHAR(50), 
    @c INT, 
    @t CHAR(10)
AS
    DECLARE @rc INT = 1;
BEGIN TRY
    INSERT INTO AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_CAPACITY, AUDITORIUM_TYPE)
    VALUES (@a, @n, @c, @t);
    RETURN @rc;
END TRY
BEGIN CATCH
    PRINT N'����� ������: ' + CAST(ERROR_NUMBER() AS VARCHAR(6));
    PRINT N'���������: ' + ERROR_MESSAGE();
    PRINT N'�������: ' + CAST(ERROR_SEVERITY() AS VARCHAR(6));
    PRINT N'�����: ' + CAST(ERROR_STATE() AS VARCHAR(8));
    PRINT N'����� ������: ' + CAST(ERROR_LINE() AS VARCHAR(8));
    
    IF ERROR_PROCEDURE() IS NOT NULL
        PRINT N'��� ���������: ' + ERROR_PROCEDURE();
    
    RETURN -1;
END CATCH;
GO
DELETE FROM AUDITORIUM WHERE AUDITORIUM = '999-1';
GO

DECLARE @rc INT;
EXEC @rc = PAUDITORIUM_INSERT 
    @a = '999-1', 
    @n = '999-1', 
    @c = 99, 
    @t = 'LK-K';
PRINT N'��� ������: ' + CAST(@rc AS VARCHAR(3));

---- 5. ����������� ��������� � ������ SUBJECT_REPORT
GO
CREATE PROCEDURE SUBJECT_REPORT @p CHAR(10) AS
BEGIN
    DECLARE @rc INT = 0;
    DECLARE @subject_list NVARCHAR(MAX) = '';
    DECLARE @subject_name NVARCHAR(50);
    
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM SUBJECT WHERE PULPIT = @p)
            RAISERROR('������ � ����������', 11, 1);
        
        DECLARE subject_cursor CURSOR FOR SELECT RTRIM(SUBJECT) FROM SUBJECT WHERE PULPIT = @p;
        OPEN subject_cursor;
        FETCH NEXT FROM subject_cursor INTO @subject_name;
        WHILE @@FETCH_STATUS = 0
        BEGIN
            IF @rc > 0
                SET @subject_list = @subject_list + ', ' + @subject_name;
            ELSE
                SET @subject_list = @subject_name;
                
            SET @rc = @rc + 1;
            FETCH NEXT FROM subject_cursor INTO @subject_name;
        END;
        PRINT N'���������� �������:';
        PRINT @subject_list;
        CLOSE subject_cursor;
        DEALLOCATE subject_cursor;
        RETURN @rc;
    END TRY
    BEGIN CATCH
        PRINT '������ � ����������';
        IF ERROR_PROCEDURE() IS NOT NULL
            PRINT '��� ���������: ' + ERROR_PROCEDURE();
        IF CURSOR_STATUS('global', 'subject_cursor') >= 0
        BEGIN
            CLOSE subject_cursor;
            DEALLOCATE subject_cursor;
        END;
        RETURN @rc;
    END CATCH;
END;

DECLARE @rct INT;
EXEC @rct = SUBJECT_REPORT @p = 'ISIT';
PRINT N'���������� ���������: ' + CAST(@rct AS VARCHAR(10));


---- 6. ����������� ��������� � ������ PAUDITORIUM_INSERTX
GO
CREATE PROCEDURE PAUDITORIUM_INSERTX 
    @a CHAR(20), 
    @n VARCHAR(50), 
    @c INT, 
    @t CHAR(10), 
    @tn VARCHAR(50)
AS
    DECLARE @rc INT = 1;
BEGIN TRY
    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    BEGIN TRANSACTION;
    
    INSERT INTO AUDITORIUM_TYPE (AUDITORIUM_TYPE, AUDITORIUM_TYPENAME)
    VALUES (@t, @tn);
    
    EXEC @rc = PAUDITORIUM_INSERT @a = @a, @n = @n, @c = @c, @t = @t;
    
    COMMIT TRANSACTION;
    RETURN @rc;
END TRY
BEGIN CATCH
    PRINT N'����� ������: ' + CAST(ERROR_NUMBER() AS VARCHAR(6));
    PRINT N'���������: ' + ERROR_MESSAGE();
    PRINT N'�������: ' + CAST(ERROR_SEVERITY() AS VARCHAR(6));
    PRINT N'�����: ' + CAST(ERROR_STATE() AS VARCHAR(8));
    PRINT N'����� ������: ' + CAST(ERROR_LINE() AS VARCHAR(8));
    
    IF ERROR_PROCEDURE() IS NOT NULL
        PRINT N'��� ���������: ' + ERROR_PROCEDURE();
    
    IF @@TRANCOUNT > 0 
        ROLLBACK TRANSACTION;
    
    RETURN -1;
END CATCH;
GO

DELETE FROM AUDITORIUM WHERE AUDITORIUM = '999-1';
GO

DECLARE @rc INT;
EXEC @rc = PAUDITORIUM_INSERTX 
    @a = '999-1', 
    @n = '999-1', 
    @c = 99, 
    @t = 'BB', 
    @tn = 'bybody lab';
    
PRINT N'��� ������: ' + CAST(@rc AS VARCHAR(3));

