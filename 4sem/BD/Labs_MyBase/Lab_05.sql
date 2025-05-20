USE Lab_03;
--ALTER TABLE Товары
--ALTER COLUMN Описание NVARCHAR(MAX);

-- 1. Поиск товаров, купленных покупателями из Минска (IN)
SELECT T.ID_Товара, T.Наименование, T.Цена, T.Описание
FROM Товары T
WHERE T.ID_Товара IN (
    SELECT S.ID_Товара 
    FROM Сделки S
    JOIN Покупатели P ON S.ID_Покупателя = P.ID_Покупателя
    WHERE P.Адрес LIKE '%Минск%'
);

-- 2. То же самое, но через INNER JOIN
SELECT T.ID_Товара, T.Наименование, T.Цена, T.Описание
FROM Товары T
JOIN Сделки S ON T.ID_Товара = S.ID_Товара
JOIN Покупатели P ON S.ID_Покупателя = P.ID_Покупателя
WHERE P.Адрес LIKE '%Минск%';

-- 3. То же самое, но без подзапроса (JOIN всех таблиц)
SELECT T.ID_Товара, T.Наименование, T.Цена, T.Описание
FROM Товары T
JOIN Сделки S ON T.ID_Товара = S.ID_Товара
JOIN Покупатели P ON S.ID_Покупателя = P.ID_Покупателя
JOIN Склад Sk ON T.ID_Товара = Sk.ID_Товара
WHERE P.Адрес LIKE '%Минск%';

-- 4. Самые популярные товары по количеству продаж (TOP + ORDER BY)
SELECT TOP 1 WITH TIES T.ID_Товара, T.Наименование, T.Цена, CAST(T.Описание AS NVARCHAR(MAX)) AS Описание
FROM Товары T
JOIN Сделки S ON T.ID_Товара = S.ID_Товара
GROUP BY T.ID_Товара, T.Наименование, T.Цена, T.Описание
ORDER BY SUM(S.Количество) DESC;


-- 5. Товары, которые не продавались (EXISTS)
SELECT T.ID_Товара, T.Наименование, T.Цена, T.Описание
FROM Товары T
WHERE NOT EXISTS (
    SELECT 1 FROM Сделки S WHERE S.ID_Товара = T.ID_Товара
);

-- 6. Средняя цена товаров по 3 категориям
SELECT
    (SELECT AVG(Цена) FROM Товары WHERE Наименование LIKE '%Телефон%') AS Avg_Телефон,
    (SELECT AVG(Цена) FROM Товары WHERE Наименование LIKE '%Ноутбук%') AS Avg_Ноутбук,
    (SELECT AVG(Цена) FROM Товары WHERE Наименование LIKE '%Смарт-часы%') AS Avg_Часы;

-- 7. Товары, дороже всех товаров в категории "Смарт-часы" (ALL)
SELECT T.ID_Товара, T.Наименование, T.Цена, T.Описание
FROM Товары T
WHERE T.Цена > ALL (
    SELECT Цена FROM Товары WHERE Наименование LIKE '%Смарт-часы%'
);

-- 8. Товары, дороже хотя бы одного ноутбука (ANY)
SELECT T.ID_Товара, T.Наименование, T.Цена, T.Описание
FROM Товары T
WHERE T.Цена > ANY (
    SELECT Цена FROM Товары WHERE Наименование LIKE '%Ноутбук%'
);
