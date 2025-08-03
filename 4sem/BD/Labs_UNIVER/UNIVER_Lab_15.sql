USE univer;
GO

IF OBJECT_ID('TR_AUDIT', 'U') IS NOT NULL
    DROP TABLE TR_AUDIT;
GO


CREATE TABLE TR_AUDIT
(
    ID int IDENTITY PRIMARY KEY,
    STMT varchar(20) CHECK (STMT IN ('INS', 'DEL', 'UPD')),
    TRNAME varchar(50),
    CC varchar(300)
);
GO

DROP TRIGGER IF EXISTS TR_TEACHER_INS;
DROP TRIGGER IF EXISTS TR_TEACHER_DEL;
DROP TRIGGER IF EXISTS TR_TEACHER_UPD;
DROP TRIGGER IF EXISTS TR_TEACHE;
GO


-- 1 Триггер на вставку в TEACHER
CREATE TRIGGER TR_TEACHER_INS
ON TEACHER
AFTER INSERT
AS
BEGIN
    DECLARE @a1 varchar(20), @a2 varchar(200), @a3 char(1), @a4 varchar(16), @in varchar(300);
    PRINT N'Операция вставки';
    SET @a1 = (SELECT TEACHER FROM inserted);
    SET @a2 = (SELECT TEACHER_NAME FROM inserted);
    SET @a3 = (SELECT GENDER FROM inserted);
    SET @a4 = (SELECT PULPIT FROM inserted);
    SET @in = @a1 + N' ' + @a2 + N' ' + @a3 + N' ' + @a4;
    INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES ('INS', 'TR_TEACHER_INS', @in);
END
GO


-- 2 Триггер на удаление из TEACHER
CREATE TRIGGER TR_TEACHER_DEL
ON TEACHER
AFTER DELETE
AS
BEGIN
    DECLARE @a1 varchar(20), @a2 varchar(200), @a3 char(1), @a4 varchar(16), @in varchar(300);
    PRINT N'Операция удаления';
    SET @a1 = (SELECT TEACHER FROM deleted);
    SET @a2 = (SELECT TEACHER_NAME FROM deleted);
    SET @a3 = (SELECT GENDER FROM deleted);
    SET @a4 = (SELECT PULPIT FROM deleted);
    SET @in = @a1 + N' ' + @a2 + N' ' + @a3 + N' ' + @a4;
    INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES ('DEL', 'TR_TEACHER_DEL', @in);
END
GO


-- 3 Триггер на обновление в TEACHER
CREATE TRIGGER TR_TEACHER_UPD
ON TEACHER
AFTER UPDATE
AS
BEGIN
    DECLARE @a1 varchar(20), @a2 varchar(200), @a3 char(1), @a4 varchar(16);
    DECLARE @b1 varchar(20), @b2 varchar(200), @b3 char(1), @b4 varchar(16);
    DECLARE @in1 varchar(300);
    DECLARE @in2 varchar(300);

    PRINT N'Операция обновления';

    SET @a1 = (SELECT TEACHER FROM inserted);
    SET @a2 = (SELECT TEACHER_NAME FROM inserted);
    SET @a3 = (SELECT GENDER FROM inserted);
    SET @a4 = (SELECT PULPIT FROM inserted);
    SET @in1 = 'AFTER: ' + @a1 + N' ' + @a2 + N' ' + @a3 + N' ' + @a4;
    INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES ('UPD', 'TR_TEACHER_UPD', @in1);

    SET @b1 = (SELECT TEACHER FROM deleted);
    SET @b2 = (SELECT TEACHER_NAME FROM deleted);
    SET @b3 = (SELECT GENDER FROM deleted);
    SET @b4 = (SELECT PULPIT FROM deleted);
    SET @in2 = 'BEFORE: ' + @b1 + N' ' + @b2 + N' ' + @b3 + N' ' + @b4;
    INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES ('UPD', 'TR_TEACHER_UPD', @in2);
END
GO


-- 4 Универсальный триггер на все операции (вставка, удаление, обновление)
CREATE TRIGGER TR_TEACHE
ON TEACHER
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    DECLARE @a1 varchar(20), @a2 varchar(200), @a3 char(1), @a4 varchar(16), @in varchar(300);
    DECLARE @ins int = (SELECT COUNT(*) FROM inserted), @del int = (SELECT COUNT(*) FROM deleted);

    IF @ins > 0 AND @del = 0
    BEGIN
        PRINT N'Операция вставки';
        SET @a1 = (SELECT TEACHER FROM inserted);
        SET @a2 = (SELECT TEACHER_NAME FROM inserted);
        SET @a3 = (SELECT GENDER FROM inserted);
        SET @a4 = (SELECT PULPIT FROM inserted);
        SET @in = @a1 + N' ' + @a2 + N' ' + @a3 + N' ' + @a4;
        INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES ('INS', 'TR_TEACHE', @in);
    END
    ELSE IF @ins = 0 AND @del > 0
    BEGIN
        PRINT N'Операция удаления';
        SET @a1 = (SELECT TEACHER FROM deleted);
        SET @a2 = (SELECT TEACHER_NAME FROM deleted);
        SET @a3 = (SELECT GENDER FROM deleted);
        SET @a4 = (SELECT PULPIT FROM deleted);
        SET @in = @a1 + N' ' + @a2 + N' ' + @a3 + N' ' + @a4;
        INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES ('DEL', 'TR_TEACHE', @in);
    END
    ELSE IF @ins > 0 AND @del > 0
    BEGIN
        PRINT N'Операция обновления';
        SET @a1 = (SELECT TEACHER FROM inserted);
        SET @a2 = (SELECT TEACHER_NAME FROM inserted);
        SET @a3 = (SELECT GENDER FROM inserted);
        SET @a4 = (SELECT PULPIT FROM inserted);
        SET @in = 'INS: ' + @a1 + N' ' + @a2 + N' ' + @a3 + N' ' + @a4;
        INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES ('UPD', 'TR_TEACHE', @in);

        SET @a1 = (SELECT TEACHER FROM deleted);
        SET @a2 = (SELECT TEACHER_NAME FROM deleted);
        SET @a3 = (SELECT GENDER FROM deleted);
        SET @a4 = (SELECT PULPIT FROM deleted);
        SET @in = 'DEL: ' + @a1 + N' ' + @a2 + N' ' + @a3 + N' ' + @a4;
        INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES ('UPD', 'TR_TEACHE', @in);
    END
END
GO


-- Тестируем 

DELETE FROM TEACHER WHERE TEACHER = 'NOA';
GO

INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('NOA', 'Olga Alexandrovna Nistyuk', 'F', 'ISIT');
GO

SELECT * FROM TR_AUDIT;
GO



DELETE FROM TEACHER WHERE TEACHER = 'NOA';
GO

SELECT * FROM TR_AUDIT;
GO

INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('NOA', 'Olga Alexandrovna Nistyuk', 'F', 'ISIT');
GO

DELETE FROM TEACHER WHERE TEACHER = 'XXX';
GO
UPDATE TEACHER SET TEACHER = 'XXX' WHERE TEACHER_NAME = 'Olga Alexandrovna Nistyuk';
GO



SELECT * FROM TR_AUDIT;
GO

SELECT * FROM TEACHER;
GO




----- 5 Проверка выполняется до срабатывания AFTER

go
insert into TEACHER(TEACHER,TEACHER_NAME,GENDER,PULPIT) values ('NOA','Olga Alexandrovna Nistyuk','','ISIT');





------ 6 Создать для таблицы TEACHER 
GO
DROP TRIGGER IF EXISTS TR_TEACHER_DEL1;
DROP TRIGGER IF EXISTS TR_TEACHER_DEL2;
DROP TRIGGER IF EXISTS TR_TEACHER_DEL3;
GO


IF OBJECT_ID('dbo.TR_AUDIT', 'U') IS NULL
BEGIN
    CREATE TABLE TR_AUDIT (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        STMT NVARCHAR(10),
        TRNAME NVARCHAR(100),
        CC NVARCHAR(300),
        LOGDATE DATETIME DEFAULT GETDATE()
    );
END
GO


CREATE TRIGGER TR_TEACHER_DEL1
ON TEACHER
AFTER DELETE
AS
BEGIN
    PRINT 'TR_TEACHER_DEL1';
    INSERT INTO TR_AUDIT (STMT, TRNAME, CC)
    SELECT
        'DEL',
        'TR_TEACHER_DEL1',
        d.TEACHER + N' ' + d.TEACHER_NAME + N' ' + d.GENDER + N' ' + d.PULPIT
    FROM deleted d;
END
GO


CREATE TRIGGER TR_TEACHER_DEL2
ON TEACHER
AFTER DELETE
AS
BEGIN
    PRINT 'TR_TEACHER_DEL2';
    INSERT INTO TR_AUDIT (STMT, TRNAME, CC)
    SELECT
        'DEL',
        'TR_TEACHER_DEL2',
        d.TEACHER + N' ' + d.TEACHER_NAME + N' ' + d.GENDER + N' ' + d.PULPIT
    FROM deleted d;
END
GO


CREATE TRIGGER TR_TEACHER_DEL3
ON TEACHER
AFTER DELETE
AS
BEGIN
    PRINT 'TR_TEACHER_DEL3';
    INSERT INTO TR_AUDIT (STMT, TRNAME, CC)
    SELECT
        'DEL',
        'TR_TEACHER_DEL3',
        d.TEACHER + N' ' + d.TEACHER_NAME + N' ' + d.GENDER + N' ' + d.PULPIT
    FROM deleted d;
END
GO


EXEC SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL3', @order = 'First', @stmttype = 'DELETE';
EXEC SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL2', @order = 'Last', @stmttype = 'DELETE';
GO

INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES ('FD', 'ForDelete', 'F', 'ISIT');
GO

SELECT * FROM TEACHER WHERE TEACHER = 'FD';
GO

DELETE FROM TEACHER WHERE TEACHER = 'FD';
GO

SELECT * FROM TR_AUDIT;
GO






----- 7
go

IF OBJECT_ID('Tech_Tran', 'TR') IS NOT NULL
    DROP TRIGGER Tech_Tran;
GO
create trigger Tech_Tran
on TEACHER after INSERT, DELETE, UPDATE
as declare @c int = (select count(TEACHER) from TEACHER)
if(@c > 20)
begin
	raiserror(N'Общее кол-во преподавателей не дожно быть > 20', 10,1);
	rollback
end
return

select*FROM TEACHER

begin tran
	insert into TEACHER(TEACHER,TEACHER_NAME,GENDER,PULPIT) values ('FD1','ForDelete','F','ISIT');
	insert into TEACHER(TEACHER,TEACHER_NAME,GENDER,PULPIT) values ('FD2','ForDelete','F','ISIT');
	insert into TEACHER(TEACHER,TEACHER_NAME,GENDER,PULPIT) values ('FD3','ForDelete','F','ISIT');
	insert into TEACHER(TEACHER,TEACHER_NAME,GENDER,PULPIT) values ('FD4','ForDelete','F','ISIT');
	insert into TEACHER(TEACHER,TEACHER_NAME,GENDER,PULPIT) values ('FD5','ForDelete','F','ISIT');
commit tran






---- 8 



SELECT * FROM sys.triggers;
SELECT * FROM sys.trigger_events;
GO

DECLARE @sql NVARCHAR(MAX) = N'';
SELECT @sql += 
    'DROP TRIGGER IF EXISTS ' + 
    QUOTENAME(SCHEMA_NAME(o.schema_id)) + '.' + QUOTENAME(t.name) + ';' + CHAR(13)
FROM sys.triggers t
JOIN sys.objects o ON t.parent_id = o.object_id
WHERE t.is_ms_shipped = 0; 

PRINT @sql;
EXEC sp_executesql @sql;
GO


SELECT * FROM FACULTY;
GO


CREATE TRIGGER Fac_INSTEAD_OF
ON FACULTY
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR(N'Нельзя удалить факультет!', 16, 1);
    RETURN;
END;
GO


DELETE FROM FACULTY WHERE FACULTY = 'IT';
GO


SELECT * FROM TEACHER;
GO


CREATE TRIGGER TEACHER_INSTEAD_OF
ON TEACHER
INSTEAD OF INSERT
AS
BEGIN
    INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT) 
    VALUES ('NOA', 'Olga Alexandrovna Nistyuk', 'F', 'ISIT');
    RETURN;
END;
GO


INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT) 
VALUES ('NOA', 'Olga Alexandrovna Nistyuk', '', 'ISIT');
GO


SELECT * FROM TEACHER WHERE TEACHER = 'NOA';
GO




----- 9 
go

DROP TRIGGER DDL_PRODAJI ON DATABASE;
go

create trigger DDL_PRODAJI on database for DDL_DATABASE_LEVEL_EVENTS as   
begin
    DECLARE @EventType NVARCHAR(100) = EVENTDATA().value('(/EVENT_INSTANCE/EventType)[1]', 'NVARCHAR(100)');
    DECLARE @ObjectName NVARCHAR(255) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectName)[1]', 'NVARCHAR(255)');
    DECLARE @ObjectType NVARCHAR(100) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectType)[1]', 'NVARCHAR(100)');
    PRINT N'Обнаружено DDL-событие:';
    PRINT N'Тип события: ' + @EventType;
    PRINT N'Имя объекта: ' + @ObjectName;
    PRINT N'Тип объекта: ' + @ObjectType;
  IF @EventType IN ('CREATE_TABLE', 'DROP_TABLE')
  begin
       DECLARE @Message NVARCHAR(500) = N'Операция ' + @EventType + 
                                        N' над таблицей ' + @ObjectName + 
                                        N' запрещена в базе данных UNIVER.';
        PRINT @Message;
        RAISERROR(@Message, 16, 1);
        ROLLBACK;
   end;
end
go

drop TABLE TEACHER;
go

select * from TEACHER;
go


CREATE TABLE TEACHER
(
    TEACHER    CHAR(10) CONSTRAINT TEACHER_PK PRIMARY KEY,
    TEACHER_NAME  VARCHAR(100), 
    GENDER     CHAR(1) CHECK (GENDER IN ('M', 'F')),
    PULPIT   CHAR(20) CONSTRAINT TEACHER_PULPIT_FK FOREIGN KEY REFERENCES PULPIT(PULPIT) 
);
go

INSERT INTO TEACHER (TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES 
    ('SMLV', 'Smelov Vladimir Vladislavovich', 'M', 'ISIT'),
    ('DTK', 'Dyatko Alexander Arkadievich', 'M', 'LV'),
    ('URB', 'Urbanovich Pavel Pavlovich', 'M', 'ISIT'),
    ('GRN', 'Gurin Nikolay Ivanovich', 'M', 'ISIT'),
    ('ZLK', 'Zhilak Nadezhda Alexandrovna', 'F', 'ISIT'),
    ('MRZ', 'Moroz Elena Stanislavovna', 'F', 'ISIT'),
    ('BRTSHVCH', 'Bartashevich Svyatoslav Alexandrovich', 'M', 'PIAHP'),
    ('ARS', 'Arsentiev Vitaliy Arsentievich', 'M', 'PIAHP'),
    ('NVRV', 'Neverov Alexander Vasilievich', 'M', 'MIEP'),
    ('RVKCH', 'Rovkach Andrey Ivanovich', 'M', 'LV'),
    ('DMDK', 'Demidko Marina Nikolaevna', 'F', 'LPISPS'),
    ('BRG', 'Burganskaya Tatyana Minaevna', 'F', 'LPISPS'),
    ('RZHK', 'Rozhkov Leonid Nikolaevich', 'M', 'LV'),
    ('ZVGTSV', 'Zvyagintsev Vyacheslav Borisovich', 'M', 'LZIDV'),
    ('BZBRDV', 'Bezborodov Vladimir Stepanovich', 'M', 'OH'),
    ('NSKVTS', 'Naskovets Mikhail Trofimovich', 'M', 'TL');
go
