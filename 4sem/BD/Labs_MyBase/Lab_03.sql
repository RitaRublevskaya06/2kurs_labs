 1. 
 IF EXISTS (SELECT name FROM sys.databases WHERE name = 'Lab_02')
   DROP DATABASE Lab_02;
GO
CREATE DATABASE Lab_03;
GO
USE Lab_03;
GO

---- 2. 
CREATE TABLE ������ (
	ID_������ INT PRIMARY KEY IDENTITY,
	������������ NVARCHAR(255) NOT NULL,
	���� DECIMAL(10,2) NOT NULL,
	�������� TEXT
);

CREATE TABLE ���������� (
	ID_���������� INT PRIMARY KEY IDENTITY,
	��� NVARCHAR(255) NOT NULL,
	������� NVARCHAR(20) NOT NULL,
	����� NVARCHAR(255) NOT NULL
);

CREATE TABLE ����� (
	ID_����� INT PRIMARY KEY IDENTITY,
	ID_������ INT NOT NULL,
	����������_������ INT NOT NULL,
	�����_�������� NVARCHAR(255) NOT NULL,
	����������_����� INT NOT NULL,
	FOREIGN KEY (ID_������) REFERENCES ������(ID_������)
);

CREATE TABLE ������ (
	ID_������ INT PRIMARY KEY IDENTITY,
	ID_���������� INT NOT NULL,
	ID_������ INT NOT NULL,
	����_������ DATE NOT NULL,
	���������� INT NOT NULL,
	FOREIGN KEY (ID_����������) REFERENCES ����������(ID_����������),
	FOREIGN KEY (ID_������) REFERENCES ������(ID_������)
);



-- 4. 
INSERT INTO ������ (������������, ����, ��������)  VALUES
('�������', 500.00, '�������� 128GB'),
('�������', 1200.00, '������� �������'),
('���������', 700.00, '4K UND ���������'),
('�������', 300.00, '������� 64GB'),
('�����-����', 200.00, '�����-���� � �������� ������������ ����������'),
('�������', 400.00, '27" Full HD �������'),
('�������', 150.00, '����������� Bluetooth �������'),
('����', 50.00, '������� ������������ ����');

INSERT INTO ���������� (���, �������, �����) VALUES
('������ ���� ��������', '3758974125', '�����, ��. ��������, 5'),
('������ ���� ��������', '89117654321', '������, ��. ������, 5'),
('��������� �� ����������', '3758475962', '������, ��. ������, 5'),
('�������� ������ ���������', '89512345678', '����, ��. ���������, 7'),
('�������� ����� ����������', '3754861257', '�����, ��. ������������, 25'),
('��������� ������ ���������', '375299876543', '�����, ��. �������, 12'),
('������� ����� ����������', '375334567890', '������, ��. ����������, 9');

INSERT INTO ����� (ID_������, ����������_������, �����_��������, ����������_�����) VALUES
(1, 90, '������ A1', 50),
(2, 50, '������ B1', 50),
(3, 70, '������ C1', 50),
(4, 60, '������ D1', 30),
(5, 75, '������ E1', 50),
(6, 40, '������ B5', 30),
(7, 100, '������ C6', 25),
(8, 150, '������ E7', 20);


INSERT INTO ������(ID_����������, ID_������, ����_������, ����������) VALUES
(1, 1, '2025-01-03', 3),
(2, 2, '2025-02-28', 2),
(3, 3, '2025-01-03', 2),
(4, 4, '2025-02-28', 4),
(5, 5, '2025-02-28', 3),
(6, 6, '2025-03-01', 2),  -- ��������� ������ 2 ��������
(7, 7, '2025-03-03', 4),  -- ������� ����� 4 �������
(1, 8, '2025-03-05', 1),  -- ������ ����� ����
(2, 6, '2025-03-06', 1),  -- ������ ����� �������
(5, 7, '2025-03-07', 2);  -- �������� ������ �������

INSERT INTO ������ (ID_����������, ID_������, ����_������, ����������)
VALUES (1, 6, '2025-04-10', 1);  -- ������ (�����) ����� �������


-- 3.
ALTER TABLE ������ ADD ������������� NVARCHAR(255) NOT NULL;
ALTER TABLE ������ ADD CONSTRAINT CK_���� CHECK (���� > 0);
-- ��������� ���������, ����� ������� �������
ALTER TABLE ������ DROP COLUMN �������������;

-- 5.
SELECT * FROM ������;
SELECT ������������, ���� FROM ������;
SELECT COUNT(*) AS ����������_������� FROM ������;

UPDATE ������ SET ���� = 550 WHERE ID_������ = 1;
SELECT * FROM ������;


SELECT ������������, ���� FROM ������ ORDER BY ���� ASC; -- �� �����������
SELECT ������������, ���� FROM ������ ORDER BY ���� DESC; -- �� ��������.







--SELECT ������������ [������� ������], ���� FROM ������ WHERE ���� < 500;
--DELETE from ������ Where ������������ = '����';






-- 6.
--ALTER DATABASE Lab_03 MODIFY FILE (NAME = 'Lab_03',  FILENAME = 'D:\Univer\SQLData\Lab_03.mdf');

-- 7.
--ALTER DATABASE X_MyBASE ADD FILEGROUP FG1;
--CREATE TABLE AUDITORIUM (
--    AUDITORIUM CHAR(20) PRIMARY KEY,
--    AUDITORIUM_TYPE CHAR(10) FOREIGN KEY REFERENCES AUDITORIUM_TYPE(AUDITORIUM_TYPE),
--    AUDITORIUM_CAPACITY INT DEFAULT 1 CHECK (AUDITORIUM_CAPACITY BETWEEN 1 AND 300),
--    AUDITORIUM_NAME VARCHAR(50)
--) ON FG1;










