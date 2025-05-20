USE  Lab_03;

-- 1. ������ ��� ���������� ������������, �����������, ������� ����, ��������� ��������� � ������ ���������� ������� ������� ���� �� ������
SELECT 
    S.�����_��������,
    MAX(T.����) AS MAX_PRICE,
    MIN(T.����) AS MIN_PRICE,
    CAST(AVG(T.����) AS decimal(10,2)) AS AVG_PRICE,
    SUM(T.���� * S.����������_������) AS TOTAL_VALUE,
    COUNT(T.ID_������) AS PRODUCT_COUNT
FROM 
    ������ T
INNER JOIN 
    ����� S ON T.ID_������ = S.ID_������
GROUP BY 
    S.�����_��������;

-- 2. ������ ��� ���������� ���������� ������ � �������� ������� ����������
SELECT 
    PRICE_RANGE,
    COUNT(*) AS DEAL_COUNT
FROM 
    (SELECT 
        CASE 
            WHEN (T.���� * SD.����������) BETWEEN 0 AND 500 THEN '0-500'
            WHEN (T.���� * SD.����������) BETWEEN 501 AND 1000 THEN '501-1000'
            WHEN (T.���� * SD.����������) BETWEEN 1001 AND 2000 THEN '1001-2000'
            ELSE '2000+'
        END AS PRICE_RANGE
    FROM 
        ������ SD
    INNER JOIN 
        ������ T ON SD.ID_������ = T.ID_������) AS Subquery
GROUP BY 
    PRICE_RANGE
ORDER BY 
    PRICE_RANGE DESC;

-- 3. ������ ��� ���������� ������� ��������� ������ ��� ������� ����������
SELECT 
    P.��� AS BUYER_NAME,
    CAST(AVG(T.���� * SD.����������) AS decimal(10,2)) AS AVG_DEAL_VALUE
FROM 
    ���������� P
INNER JOIN 
    ������ SD ON P.ID_���������� = SD.ID_����������
INNER JOIN 
    ������ T ON SD.ID_������ = T.ID_������
GROUP BY 
    P.���
ORDER BY 
    AVG_DEAL_VALUE DESC;

-- 4. ������ ��� ������� ������� ��������� ������ ������ ��� ������������ ������� (������� � �������)
SELECT 
    P.��� AS BUYER_NAME,
    CAST(AVG(T.���� * SD.����������) AS decimal(10,2)) AS AVG_DEAL_VALUE
FROM 
    ���������� P
INNER JOIN 
    ������ SD ON P.ID_���������� = SD.ID_����������
INNER JOIN 
    ������ T ON SD.ID_������ = T.ID_������
WHERE 
    T.������������ IN ('�������', '�������')
GROUP BY 
    P.���
ORDER BY 
    AVG_DEAL_VALUE DESC;

-- 5. ������ ��� ������ �����������, ������� � ������� ��������� ������ ��� ������������� ������ ('������, ��. ������, 5')
SELECT 
    P.�����,
    P.��� AS BUYER_NAME,
    T.������������ AS PRODUCT_NAME,
    CAST(AVG(T.���� * SD.����������) AS decimal(10,2)) AS AVG_DEAL_VALUE
FROM 
    ���������� P
LEFT JOIN 
    ������ SD ON P.ID_���������� = SD.ID_����������
LEFT JOIN 
    ������ T ON SD.ID_������ = T.ID_������
WHERE 
    P.����� = '������, ��. ������, 5'
GROUP BY 
    P.�����, P.���, T.������������
ORDER BY 
    AVG_DEAL_VALUE DESC;

-- 6. ������ ��� ���������� ���������� �����������, ����������� ������ �� ����� 1000-2000 � 2000+
SELECT 
    T.������������ AS PRODUCT_NAME,
    COUNT(DISTINCT SD.ID_����������) AS BUYER_COUNT
FROM 
    ������ SD
INNER JOIN 
    ������ T ON SD.ID_������ = T.ID_������
WHERE 
    (T.���� * SD.����������) BETWEEN 1000 AND 2000
    OR (T.���� * SD.����������) > 2000
GROUP BY 
    T.������������
HAVING 
    COUNT(DISTINCT SD.ID_����������) > 0
ORDER BY 
    T.������������;