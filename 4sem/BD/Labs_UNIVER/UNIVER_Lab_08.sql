--USE UNIVER;

-- 1. ������������� "�������������"
--CREATE VIEW ������������� AS
--SELECT 
--    TEACHER AS ���, 
--    TEACHER_NAME AS ���_�������������, 
--    GENDER AS ���, 
--    PULPIT AS ���_�������
--FROM TEACHER;

---- 2. ������������� "���������� ������"
--CREATE VIEW ����������_������ AS
--SELECT 
--    f.FACULTY_NAME AS ���������, 
--    COUNT(p.PULPIT) AS ����������_������
--FROM FACULTY f
--LEFT JOIN PULPIT p ON f.FACULTY = p.FACULTY
--GROUP BY f.FACULTY_NAME;

---- 3. ������������� "���������" � ������������ �����������
--CREATE VIEW ��������� AS
--SELECT 
--    AUDITORIUM AS ���, 
--    AUDITORIUM_NAME AS ������������_���������
--FROM AUDITORIUM
--WHERE AUDITORIUM_TYPE LIKE 'LK%'
--WITH CHECK OPTION;

---- 4. ������������� "����������_���������"
--CREATE VIEW ����������_��������� AS
--SELECT 
--    AUDITORIUM AS ���, 
--    AUDITORIUM_NAME AS ������������_���������
--FROM AUDITORIUM
--WHERE AUDITORIUM_TYPE LIKE 'LK%';

---- 5. ������������� "����������"
--CREATE VIEW ���������� AS
--SELECT TOP 100 PERCENT
--    SUBJECT AS ���, 
--    SUBJECT_NAME AS ������������_����������, 
--    PULPIT AS ���_�������
--FROM SUBJECT
--ORDER BY SUBJECT_NAME;

---- 6. ���������� ������������� "����������_������" � ��������� � ������
--ALTER VIEW ����������_������ WITH SCHEMABINDING AS
--SELECT 
--    f.FACULTY_NAME AS ���������, 
--    COUNT(p.PULPIT) AS ����������_������
--FROM dbo.FACULTY f
--LEFT JOIN dbo.PULPIT p ON f.FACULTY = p.FACULTY
--GROUP BY f.FACULTY_NAME;



















-------- ��� ������� ������� ������, ��� ��� ������������� ��������� � �������
------ALTER TABLE dbo.FACULTY DROP COLUMN FACULTY_NAME;
