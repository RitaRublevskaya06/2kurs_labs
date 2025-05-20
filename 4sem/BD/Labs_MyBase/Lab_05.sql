USE Lab_03;
--ALTER TABLE ������
--ALTER COLUMN �������� NVARCHAR(MAX);

-- 1. ����� �������, ��������� ������������ �� ������ (IN)
SELECT T.ID_������, T.������������, T.����, T.��������
FROM ������ T
WHERE T.ID_������ IN (
    SELECT S.ID_������ 
    FROM ������ S
    JOIN ���������� P ON S.ID_���������� = P.ID_����������
    WHERE P.����� LIKE '%�����%'
);

-- 2. �� �� �����, �� ����� INNER JOIN
SELECT T.ID_������, T.������������, T.����, T.��������
FROM ������ T
JOIN ������ S ON T.ID_������ = S.ID_������
JOIN ���������� P ON S.ID_���������� = P.ID_����������
WHERE P.����� LIKE '%�����%';

-- 3. �� �� �����, �� ��� ���������� (JOIN ���� ������)
SELECT T.ID_������, T.������������, T.����, T.��������
FROM ������ T
JOIN ������ S ON T.ID_������ = S.ID_������
JOIN ���������� P ON S.ID_���������� = P.ID_����������
JOIN ����� Sk ON T.ID_������ = Sk.ID_������
WHERE P.����� LIKE '%�����%';

-- 4. ����� ���������� ������ �� ���������� ������ (TOP + ORDER BY)
SELECT TOP 1 WITH TIES T.ID_������, T.������������, T.����, CAST(T.�������� AS NVARCHAR(MAX)) AS ��������
FROM ������ T
JOIN ������ S ON T.ID_������ = S.ID_������
GROUP BY T.ID_������, T.������������, T.����, T.��������
ORDER BY SUM(S.����������) DESC;


-- 5. ������, ������� �� ����������� (EXISTS)
SELECT T.ID_������, T.������������, T.����, T.��������
FROM ������ T
WHERE NOT EXISTS (
    SELECT 1 FROM ������ S WHERE S.ID_������ = T.ID_������
);

-- 6. ������� ���� ������� �� 3 ����������
SELECT
    (SELECT AVG(����) FROM ������ WHERE ������������ LIKE '%�������%') AS Avg_�������,
    (SELECT AVG(����) FROM ������ WHERE ������������ LIKE '%�������%') AS Avg_�������,
    (SELECT AVG(����) FROM ������ WHERE ������������ LIKE '%�����-����%') AS Avg_����;

-- 7. ������, ������ ���� ������� � ��������� "�����-����" (ALL)
SELECT T.ID_������, T.������������, T.����, T.��������
FROM ������ T
WHERE T.���� > ALL (
    SELECT ���� FROM ������ WHERE ������������ LIKE '%�����-����%'
);

-- 8. ������, ������ ���� �� ������ �������� (ANY)
SELECT T.ID_������, T.������������, T.����, T.��������
FROM ������ T
WHERE T.���� > ANY (
    SELECT ���� FROM ������ WHERE ������������ LIKE '%�������%'
);
