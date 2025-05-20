--USE Lab_03;

------ 1. ���������������� ������
--exec sp_helpindex '������';
--exec sp_helpindex '�����';
--exec sp_helpindex '������';

--CHECKPOINT;
--DBCC DROPCLEANBUFFERS;
--SELECT * FROM ������ WHERE ���� BETWEEN 300 AND 1000 ORDER BY ����;


------ 2. ������������������ ��������� ������
--CREATE INDEX IX_������_����_������������ ON ������(����, ������������);

--SELECT * FROM ������ 
--WHERE ���� > 500 AND ������������ LIKE '����%';

--SELECT * FROM ������ 
--ORDER BY ����, ������������;

--DROP INDEX IX_������_����_������������  ON ������;


------ 3. ������������������ ������ ��������
--CREATE INDEX IX_�����_ID_������_INCLUDE ON �����(ID_������) INCLUDE (����������_������);
--SELECT ����������_������ FROM ����� WHERE ID_������ = 1;



------  4. ����������� ������
--CREATE INDEX IX_������_������_���� ON ������(����) 
--WHERE (���� >= 1000 AND ���� < 1500);

--SELECT ���� FROM ������ WHERE ���� BETWEEN 1000 AND 1500;




-------- 5. ������������ �������
--CREATE INDEX IX_������_���� ON ������(����);

--SELECT 
--    name [������], 
--    avg_fragmentation_in_percent [������������ (%)]
--FROM sys.dm_db_index_physical_stats(DB_ID(), OBJECT_ID('������'), NULL, NULL, NULL) ss 
--JOIN sys.indexes ii ON ss.object_id = ii.object_id AND ss.index_id = ii.index_id 
--WHERE name IS NOT NULL;

--ALTER INDEX IX_������_���� ON ������ REORGANIZE;

--ALTER INDEX IX_������_���� ON ������ REBUILD WITH (ONLINE = OFF);


------- 6. ������ ������������� FILLFACTOR
--DROP INDEX IX_������_���� ON ������;
--CREATE INDEX IX_������_���� ON ������(����) WITH (FILLFACTOR = 65);

--INSERT INTO ������ (������������, ����, ��������)
--VALUES ('����� �����', 900.00, '�������� �����');

--SELECT 
--    name [������], 
--    avg_fragmentation_in_percent [������������ (%)]
--FROM sys.dm_db_index_physical_stats(DB_ID(), OBJECT_ID('������'), NULL, NULL, NULL) ss 
--JOIN sys.indexes ii ON ss.object_id = ii.object_id AND ss.index_id = ii.index_id 
--WHERE name IS NOT NULL;
