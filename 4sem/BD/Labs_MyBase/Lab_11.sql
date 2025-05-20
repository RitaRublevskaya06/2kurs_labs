USE Lab_03;

-------- 1. ������ ���� ������� ����� �������
DECLARE @product_list NVARCHAR(MAX) = '';
DECLARE @product_name NVARCHAR(255);

DECLARE ProductCursor CURSOR FOR 
SELECT ������������ FROM ������ ORDER BY ������������;

OPEN ProductCursor;
FETCH NEXT FROM ProductCursor INTO @product_name;

WHILE @@FETCH_STATUS = 0
BEGIN
    IF LEN(@product_list) > 0
        SET @product_list = @product_list + ', ' + @product_name;
    ELSE
        SET @product_list = @product_name;
    
    FETCH NEXT FROM ProductCursor INTO @product_name;
END

CLOSE ProductCursor;
DEALLOCATE ProductCursor;

PRINT '������ ���� �������: ' + @product_list;


-------- 2. ������������ ���������� � ����������� ��������
------ 2.1 ��������� ������
-- ����� 1: �������� � ������������� ���������� �������
DECLARE LocalCustomerCursor CURSOR LOCAL FOR
SELECT ��� FROM ���������� 
WHERE ����� LIKE '%�����%'
ORDER BY ���;

DECLARE @customer_name NVARCHAR(255);

OPEN LocalCustomerCursor;
FETCH NEXT FROM LocalCustomerCursor INTO @customer_name;

PRINT '��������� ������ - ������ ���������� �� ������: ' + @customer_name;
GO

-- ����� 2: ������� ������������ ��������� ������ � ������ ������
DECLARE @customer_name NVARCHAR(255);

-- ��� ������ ������� ������, ��� ��� ������ LocalCustomerCursor ��� ��������� � ����������� ����� ������� ������
FETCH NEXT FROM LocalCustomerCursor INTO @customer_name;
PRINT '��������� ������ - ������ ���������� �� ������: ' + @customer_name;
GO

------ 2.2 ���������� ������
-- ����� 1: �������� � ������������� ����������� �������
DECLARE GlobalCustomerCursor CURSOR GLOBAL FOR
SELECT ��� FROM ���������� 
WHERE ����� LIKE '%������%'
ORDER BY ���;

DECLARE @customer_name NVARCHAR(255);

OPEN GlobalCustomerCursor;
FETCH NEXT FROM GlobalCustomerCursor INTO @customer_name;

PRINT '���������� ������ - ������ ���������� �� ������: ' + @customer_name;
GO

-- ����� 2: ����������� ������ � ���������� ��������
DECLARE @customer_name NVARCHAR(255);

FETCH NEXT FROM GlobalCustomerCursor INTO @customer_name;
PRINT '���������� ������ - ������ ���������� �� ������: ' + @customer_name;

-- �������� � ������������ �������
CLOSE GlobalCustomerCursor;
DEALLOCATE GlobalCustomerCursor;
GO


-------- 3. ������������ ������������ � ������������� ��������
DECLARE @product_id INT, @product_name NVARCHAR(255), @price DECIMAL(10,2);

DECLARE StaticProductCursor CURSOR LOCAL STATIC FOR
SELECT ID_������, ������������, ���� FROM ������ WHERE ���� > 300;

OPEN StaticProductCursor;
PRINT '���������� ������� �������: ' + CAST(@@CURSOR_ROWS AS VARCHAR(10));

UPDATE ������ SET ���� = ���� * 0.9 WHERE ������������ = '�������';
INSERT INTO ������ VALUES ('������� �������', 450.00, '����� ������� �������');

PRINT '������ �� ������������ �������:';
FETCH NEXT FROM StaticProductCursor INTO @product_id, @product_name, @price;
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT CAST(@product_id AS VARCHAR) + ' | ' + @product_name + ' | ' + CAST(@price AS VARCHAR);
    FETCH NEXT FROM StaticProductCursor INTO @product_id, @product_name, @price;
END

CLOSE StaticProductCursor;
DEALLOCATE StaticProductCursor;

-- ������������ ������ 
DECLARE DynamicProductCursor CURSOR LOCAL DYNAMIC FOR
SELECT ID_������, ������������, ���� FROM ������ WHERE ���� > 300;

OPEN DynamicProductCursor;

UPDATE ������ SET ���� = 350.00 WHERE ������������ = '���������';
BEGIN TRY
    DELETE FROM ������ WHERE ������������ = '�������';
END TRY
BEGIN CATCH
    PRINT '�� ������� ������� �����: ' + ERROR_MESSAGE();
END CATCH

PRINT '������ �� ������������� �������:';
FETCH NEXT FROM DynamicProductCursor INTO @product_id, @product_name, @price;
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT CAST(@product_id AS VARCHAR) + ' | ' + @product_name + ' | ' + CAST(@price AS VARCHAR);
    FETCH NEXT FROM DynamicProductCursor INTO @product_id, @product_name, @price;
END

CLOSE DynamicProductCursor;
DEALLOCATE DynamicProductCursor;


-------- 4. ������ � ���������� (SCROLL)
DECLARE @row_num INT, @product_name4 NVARCHAR(255), @price4 DECIMAL(10,2);

DECLARE ScrollProductCursor CURSOR LOCAL SCROLL FOR
SELECT 
    ROW_NUMBER() OVER (ORDER BY ���� DESC) AS RowNum,
    ������������,
    ����
FROM ������
ORDER BY ���� DESC;

OPEN ScrollProductCursor;
PRINT '��������� �� ������� � ������� SCROLL-�������:';

FETCH FIRST FROM ScrollProductCursor INTO @row_num, @product_name4, @price4;
PRINT 'FIRST:     ������ ' + CAST(@row_num AS VARCHAR) + ' - ' + @product_name4 + ' (' + CAST(@price4 AS VARCHAR) + ' ���.)';

FETCH NEXT FROM ScrollProductCursor INTO @row_num, @product_name4, @price4;
PRINT 'NEXT:      ������ ' + CAST(@row_num AS VARCHAR) + ' - ' + @product_name4 + ' (' + CAST(@price4 AS VARCHAR) + ' ���.)';

FETCH ABSOLUTE 3 FROM ScrollProductCursor INTO @row_num, @product_name4, @price4;
PRINT 'ABSOLUTE 3: ������ ' + CAST(@row_num AS VARCHAR) + ' - ' + @product_name4 + ' (' + CAST(@price4 AS VARCHAR) + ' ���.)';

FETCH RELATIVE 2 FROM ScrollProductCursor INTO @row_num, @product_name4, @price4;
PRINT 'RELATIVE 2: ������ ' + CAST(@row_num AS VARCHAR) + ' - ' + @product_name4 + ' (' + CAST(@price4 AS VARCHAR) + ' ���.)';

FETCH PRIOR FROM ScrollProductCursor INTO @row_num, @product_name4, @price4;
PRINT 'PRIOR:     ������ ' + CAST(@row_num AS VARCHAR) + ' - ' + @product_name4 + ' (' + CAST(@price4 AS VARCHAR) + ' ���.)';

FETCH LAST FROM ScrollProductCursor INTO @row_num, @product_name4, @price4;
PRINT 'LAST:      ������ ' + CAST(@row_num AS VARCHAR) + ' - ' + @product_name4 + ' (' + CAST(@price4 AS VARCHAR) + ' ���.)';

CLOSE ScrollProductCursor;
DEALLOCATE ScrollProductCursor;


-------- 5. ������ � ����������� ������ (CURRENT OF)
-- ������� ��������� ������� ��� ������������
SELECT ID_������, ������������, ���� 
INTO #TempProducts
FROM ������
WHERE ���� BETWEEN 200 AND 600;

DECLARE @product_id5 INT, @current_price DECIMAL(10,2);

DECLARE UpdatePriceCursor CURSOR FOR 
SELECT ID_������, ���� FROM #TempProducts
FOR UPDATE;

OPEN UpdatePriceCursor;
FETCH NEXT FROM UpdatePriceCursor INTO @product_id5, @current_price;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- �������� ���� �� 10% ��� ������� ������ 300
    IF @current_price > 300
    BEGIN
        UPDATE #TempProducts 
        SET ���� = ���� * 1.1 
        WHERE CURRENT OF UpdatePriceCursor;
        
        PRINT '���� ������ ID ' + CAST(@product_id5 AS VARCHAR) + 
              ' �������� � ' + CAST(@current_price AS VARCHAR) + 
              ' �� ' + CAST(@current_price * 1.1 AS VARCHAR);
    END
    
    FETCH NEXT FROM UpdatePriceCursor INTO @product_id5, @current_price;
END

CLOSE UpdatePriceCursor;
DEALLOCATE UpdatePriceCursor;

SELECT * FROM #TempProducts;
DROP TABLE #TempProducts;



-------- 6.1 �������� ������ � ����������� ������ ������ 2 (������ �������� ������ ������)
DECLARE @count INT = (SELECT COUNT(*) FROM ������ WHERE ���������� < 2);
PRINT '������� ' + CAST(@count AS VARCHAR) + ' ������ � ����������� ������ ������ 2';

DECLARE @deal_id INT, @customer_id INT, @product_id6 INT, @quantity INT;
DECLARE SmallDealsCursor CURSOR FOR 
    SELECT s.ID_������, s.ID_����������, s.ID_������, s.���������� 
    FROM ������ s
    JOIN ���������� p ON s.ID_���������� = p.ID_����������
    JOIN ������ t ON s.ID_������ = t.ID_������
    WHERE s.���������� < 2
    FOR UPDATE;

OPEN SmallDealsCursor;
FETCH NEXT FROM SmallDealsCursor INTO @deal_id, @customer_id, @product_id6, @quantity;

IF @@FETCH_STATUS <> 0
    PRINT '��� ������ ��� ��������';
ELSE
BEGIN
    WHILE @@FETCH_STATUS = 0
    BEGIN
        DELETE FROM ������ 
        WHERE CURRENT OF SmallDealsCursor;
        
        PRINT '������� ������ ' + CAST(@deal_id AS VARCHAR) + 
              ': ���������� ' + CAST(@customer_id AS VARCHAR) + 
              ', ����� ' + CAST(@product_id6 AS VARCHAR) + 
              ', ���������� ' + CAST(@quantity AS VARCHAR);
        
        FETCH NEXT FROM SmallDealsCursor INTO @deal_id, @customer_id, @product_id6, @quantity;
    END
    PRINT '�������� ���������';
END

CLOSE SmallDealsCursor;
DEALLOCATE SmallDealsCursor;

-------- 6.2 ���������� ���������� ������ � ������� ����������� ���������� 
DECLARE @target_customer_id INT = 1; 

DECLARE UpdateDealsCursor CURSOR FOR 
    SELECT ID_������, ID_������, ���������� 
    FROM ������ 
    WHERE ID_���������� = @target_customer_id
    FOR UPDATE;

OPEN UpdateDealsCursor;
FETCH NEXT FROM UpdateDealsCursor INTO @deal_id, @product_id, @quantity;

WHILE @@FETCH_STATUS = 0
BEGIN
    DECLARE @stock INT = (SELECT ����������_������ FROM ����� WHERE ID_������ = @product_id);
    
    IF @stock >= @quantity + 1
    BEGIN
        UPDATE ������ 
        SET ���������� = ���������� + 1 
        WHERE CURRENT OF UpdateDealsCursor;
        
        PRINT '������ ' + CAST(@deal_id AS VARCHAR) + 
              ': ���������� ������ ' + CAST(@product_id AS VARCHAR) + 
              ' ��������� � ' + CAST(@quantity AS VARCHAR) + 
              ' �� ' + CAST(@quantity + 1 AS VARCHAR);
    END
    ELSE
    BEGIN
        PRINT '������ � ������ ' + CAST(@deal_id AS VARCHAR) + 
              ': ������������ ������ ' + CAST(@product_id AS VARCHAR) + 
              ' �� ������ (� �������: ' + CAST(@stock AS VARCHAR) + ')';
    END
    
    FETCH NEXT FROM UpdateDealsCursor INTO @deal_id, @product_id, @quantity;
END

CLOSE UpdateDealsCursor;
DEALLOCATE UpdateDealsCursor;

-- �������� �����������
SELECT 
    s.ID_������,
    p.��� AS ����������,
    t.������������ AS �����,
    s.����������,
    s.����_������
FROM ������ s
JOIN ���������� p ON s.ID_���������� = p.ID_����������
JOIN ������ t ON s.ID_������ = t.ID_������
ORDER BY s.ID_������;




























---------- 6.1. ���������� ���������� ������� �� ������ ����� ������
--DECLARE @deal_id INT, @product_id6 INT, @quantity INT;

--DECLARE ProcessDealsCursor CURSOR FOR 
--SELECT ID_������, ID_������, ���������� FROM ������
--WHERE ����_������ >= '2025-03-01'
--FOR UPDATE;

--OPEN ProcessDealsCursor;
--FETCH NEXT FROM ProcessDealsCursor INTO @deal_id, @product_id6, @quantity;

--WHILE @@FETCH_STATUS = 0
--BEGIN
--    UPDATE ����� 
--    SET ����������_������ = ����������_������ - @quantity
--    WHERE ID_������ = @product_id6;
    
--    PRINT '���������� ������ ' + CAST(@deal_id AS VARCHAR) + 
--          ': ����� ' + CAST(@product_id6 AS VARCHAR) + 
--          ' �������� �� ' + CAST(@quantity AS VARCHAR) + ' ������';
    
--    FETCH NEXT FROM ProcessDealsCursor INTO @deal_id, @product_id6, @quantity;
--END

--CLOSE ProcessDealsCursor;
--DEALLOCATE ProcessDealsCursor;

--SELECT t.������������, s.����������_������, s.�����_��������
--FROM ������ t
--JOIN ����� s ON t.ID_������ = s.ID_������;

---------- 6.2. ������ ����������� � �� �������
--DECLARE @customer_id INT, @customer_name NVARCHAR(255), @total_spent DECIMAL(12,2);

--DECLARE CustomerAnalysisCursor CURSOR FOR
--SELECT 
--    p.ID_����������,
--    p.���,
--    SUM(t.���� * s.����������) AS TotalSpent
--FROM ���������� p
--JOIN ������ s ON p.ID_���������� = s.ID_����������
--JOIN ������ t ON s.ID_������ = t.ID_������
--GROUP BY p.ID_����������, p.���
--ORDER BY TotalSpent DESC;

--OPEN CustomerAnalysisCursor;
--FETCH NEXT FROM CustomerAnalysisCursor INTO @customer_id, @customer_name, @total_spent;

--PRINT '��� ����������� �� ����� �������:';
--PRINT '--------------------------------';

--WHILE @@FETCH_STATUS = 0
--BEGIN
--    PRINT @customer_name + ': ' + CAST(@total_spent AS VARCHAR) + ' ���.';
   
--    IF @total_spent > 2000
--    BEGIN
--        PRINT '   VIP-����������! ���������� �������� ���������.';
--    END
    
--    FETCH NEXT FROM CustomerAnalysisCursor INTO @customer_id, @customer_name, @total_spent;
--END

--CLOSE CustomerAnalysisCursor;
--DEALLOCATE CustomerAnalysisCursor;