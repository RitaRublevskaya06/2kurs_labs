USE Lab_03;

---- 1. ����� ������� ����������
SET NOCOUNT ON;
DECLARE @flag CHAR = 'c';

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.�����_�����') AND type IN (N'U'))
    DROP TABLE �����_�����;

DECLARE @count INT;
SET IMPLICIT_TRANSACTIONS ON;

CREATE TABLE �����_����� (
    ID_����� INT PRIMARY KEY IDENTITY,
    ID_������ INT NOT NULL,
    �����_�������� INT CHECK (�����_�������� > 0),
    FOREIGN KEY (ID_������) REFERENCES ������(ID_������)
);

INSERT INTO �����_����� (ID_������, �����_��������) VALUES 
(1, 500), (2, 300);
SET @count = (SELECT COUNT(*) FROM �����_�����);
PRINT '���������� �������: ' + CAST(@count AS VARCHAR);

IF @flag = 'c'
    COMMIT;
ELSE
    ROLLBACK;

SET IMPLICIT_TRANSACTIONS OFF;

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.�����_�����') AND type IN (N'U'))
    PRINT '������� �����_����� ����������';
ELSE
    PRINT '������� �����_����� �� ����������';


---- 2. ����� ���������� � ���������� ������
BEGIN TRY
    BEGIN TRANSACTION;
        UPDATE ������
        SET ���������� = 5
        WHERE ID_������ = 1;
        
        DELETE FROM ������
        WHERE ID_������ = 2;
        
        COMMIT TRANSACTION;
        PRINT '���������� ������� ���������';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT '������: ' + ERROR_MESSAGE();
END CATCH;


---- 3. ����������� ����� (SAVE TRANSACTION)
BEGIN TRANSACTION;
BEGIN TRY
    INSERT INTO ���������� (���, �������, �����) 
    VALUES ('��� ���� ����������', '3751111111', '�������� ����� 2');
    
    SAVE TRANSACTION SavePoint1;
    
    INSERT INTO ����� (ID_������, ����������_������, �����_��������, ����������_�����)
    VALUES (1, 50, '������ A2', 20);
    
    COMMIT TRANSACTION;
    PRINT '��� �������� ������� ���������';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION SavePoint1;
    COMMIT TRANSACTION;
    PRINT '������: ' + ERROR_MESSAGE();
END CATCH;



---- 4. �������� ������������ ����������
---- �������� A
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN TRANSACTION;
    SELECT * FROM ������ WHERE ID_���������� = 1;
    -- ����� ��� ������������
COMMIT;

---- �������� B
BEGIN TRANSACTION;
    UPDATE ������ SET ���������� = 10 WHERE ID_������ = 1;
    -- ����� ��� ������������
ROLLBACK;


---- 5. ������� �������� READ COMMITTED
---- �������� A
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
BEGIN TRANSACTION;
    SELECT SUM(����������) FROM ������ 
    WHERE ID_������ = 1;
    -- ����� ��� ������������
COMMIT;

---- �������� B
BEGIN TRANSACTION;
    UPDATE ������ SET ���� = ���� * 1.1 
    WHERE ID_������ = 1;
COMMIT;


---- 6. ������� �������� REPEATABLE READ
---- �������� A
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
BEGIN TRANSACTION;
    SELECT * FROM ����� 
    WHERE ID_������ = 1;
    -- ����� ��� ������������
COMMIT;

---- �������� B
BEGIN TRANSACTION;
    INSERT INTO ������ (ID_����������, ID_������, ����_������, ����������)
    VALUES (1, 1, GETDATE(), 2);
COMMIT;


---- 7. ������� �������� SERIALIZABLE
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRANSACTION;
    DELETE FROM ������ 
    WHERE ID_������ BETWEEN 10 AND 20;
    
    INSERT INTO ������ (ID_����������, ID_������, ����_������, ����������)
    VALUES (2, 2, GETDATE(), 3);
COMMIT;

---- �������� B
BEGIN TRANSACTION;
    DELETE FROM ������ 
    WHERE ID_������ = 15;
COMMIT;


---- 8. ��������� ����������
BEGIN TRANSACTION �����������������;
    PRINT '������� �����������: ' + CAST(@@TRANCOUNT AS VARCHAR);
    
    BEGIN TRANSACTION ��������������������;
        PRINT '������� �����������: ' + CAST(@@TRANCOUNT AS VARCHAR);
        INSERT INTO ������ (������������, ����) 
        VALUES ('�������� �����', 99.99);
        COMMIT TRANSACTION ��������������������;
    
    PRINT '������� �����������: ' + CAST(@@TRANCOUNT AS VARCHAR);
    
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION �����������������;


