--USE Lab_03;

---- 1. ������������� "�������"
--CREATE VIEW ������� AS
--SELECT 
--    ID_���������� AS ���,
--    ��� AS ���_����������,
--    ������� AS �������,
--    ����� AS �����
--FROM ����������;


---- 2. ������������� "����������_�������_��_������"
--CREATE VIEW ����������_������_��_������ AS
--SELECT 
--	t.������������ AS �����,
--	SUM(s.����������_������) AS ����������_��_������
--FROM ������ t
--JOIN ����� s ON t.ID_������ = s.ID_������
--GROUP BY t.������������;


---- 3. ������������� "������������_������" � ������������ �����������
--CREATE VIEW ������������_������ AS
--SELECT 
--    ID_������ AS ���,
--    ������������ AS ��������,
--    ���� AS ����
--FROM ������
--WHERE ���� > 500
--WITH CHECK OPTION;

---- 4. ������������� "�������_������"
--CREATE VIEW �������_������ AS
--SELECT 
--    ID_������ AS ���,
--    ������������ AS ��������,
--    ���� AS ����
--FROM ������
--WHERE ���� <= 500;

---- 5. ������������� "������_�_������������" � �����������
--CREATE VIEW ������_�_������������ AS
--SELECT TOP 100 PERCENT
--    s.ID_������ AS ���_������,
--    p.��� AS ����������,
--    t.������������ AS �����,
--    s.����_������ AS ����,
--    s.���������� AS ����������
--FROM ������ s
--JOIN ���������� p ON s.ID_���������� = p.ID_����������
--JOIN ������ t ON s.ID_������ = t.ID_������
--ORDER BY s.����_������ DESC;


---- 6. ���������� ������������� "����������_�������_��_������" � ��������� � ������
--ALTER VIEW ����������_������_��_������ WITH SCHEMABINDING AS
--SELECT 
--    t.������������ AS �����,
--    SUM(s.����������_������) AS ����������_��_������
--FROM dbo.������ t
--JOIN dbo.����� s ON t.ID_������ = s.ID_������
--GROUP BY t.������������;



























---- 6,1 (2). ������������� "����������_�������_��_������"
--CREATE VIEW ����������_������_��_������_1 AS
--SELECT 
--	t.������������ AS �����,
--	SUM(s.����������_������) AS ����������_��_������
--FROM ������ t
--JOIN ����� s ON t.ID_������ = s.ID_������
--GROUP BY t.������������;
	
--DROP VIEW ����������_������_��_������_1