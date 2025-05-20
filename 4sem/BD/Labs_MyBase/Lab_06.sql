USE  Lab_03;

-- 1. Запрос для вычисления максимальной, минимальной, средней цены, суммарной стоимости и общего количества товаров каждого типа на складе
SELECT 
    S.Место_хранения,
    MAX(T.Цена) AS MAX_PRICE,
    MIN(T.Цена) AS MIN_PRICE,
    CAST(AVG(T.Цена) AS decimal(10,2)) AS AVG_PRICE,
    SUM(T.Цена * S.Количество_товара) AS TOTAL_VALUE,
    COUNT(T.ID_Товара) AS PRODUCT_COUNT
FROM 
    Товары T
INNER JOIN 
    Склад S ON T.ID_Товара = S.ID_Товара
GROUP BY 
    S.Место_хранения;

-- 2. Запрос для вычисления количества сделок в заданных ценовых интервалах
SELECT 
    PRICE_RANGE,
    COUNT(*) AS DEAL_COUNT
FROM 
    (SELECT 
        CASE 
            WHEN (T.Цена * SD.Количество) BETWEEN 0 AND 500 THEN '0-500'
            WHEN (T.Цена * SD.Количество) BETWEEN 501 AND 1000 THEN '501-1000'
            WHEN (T.Цена * SD.Количество) BETWEEN 1001 AND 2000 THEN '1001-2000'
            ELSE '2000+'
        END AS PRICE_RANGE
    FROM 
        Сделки SD
    INNER JOIN 
        Товары T ON SD.ID_Товара = T.ID_Товара) AS Subquery
GROUP BY 
    PRICE_RANGE
ORDER BY 
    PRICE_RANGE DESC;

-- 3. Запрос для вычисления средней стоимости сделки для каждого покупателя
SELECT 
    P.ФИО AS BUYER_NAME,
    CAST(AVG(T.Цена * SD.Количество) AS decimal(10,2)) AS AVG_DEAL_VALUE
FROM 
    Покупатели P
INNER JOIN 
    Сделки SD ON P.ID_Покупателя = SD.ID_Покупателя
INNER JOIN 
    Товары T ON SD.ID_Товара = T.ID_Товара
GROUP BY 
    P.ФИО
ORDER BY 
    AVG_DEAL_VALUE DESC;

-- 4. Запрос для расчета средней стоимости сделки только для определенных товаров (Телефон и Ноутбук)
SELECT 
    P.ФИО AS BUYER_NAME,
    CAST(AVG(T.Цена * SD.Количество) AS decimal(10,2)) AS AVG_DEAL_VALUE
FROM 
    Покупатели P
INNER JOIN 
    Сделки SD ON P.ID_Покупателя = SD.ID_Покупателя
INNER JOIN 
    Товары T ON SD.ID_Товара = T.ID_Товара
WHERE 
    T.Наименование IN ('Телефон', 'Ноутбук')
GROUP BY 
    P.ФИО
ORDER BY 
    AVG_DEAL_VALUE DESC;

-- 5. Запрос для вывода покупателей, товаров и средней стоимости сделок для определенного адреса ('Москва, ул. Ленина, 5')
SELECT 
    P.Адрес,
    P.ФИО AS BUYER_NAME,
    T.Наименование AS PRODUCT_NAME,
    CAST(AVG(T.Цена * SD.Количество) AS decimal(10,2)) AS AVG_DEAL_VALUE
FROM 
    Покупатели P
LEFT JOIN 
    Сделки SD ON P.ID_Покупателя = SD.ID_Покупателя
LEFT JOIN 
    Товары T ON SD.ID_Товара = T.ID_Товара
WHERE 
    P.Адрес = 'Москва, ул. Ленина, 5'
GROUP BY 
    P.Адрес, P.ФИО, T.Наименование
ORDER BY 
    AVG_DEAL_VALUE DESC;

-- 6. Запрос для вычисления количества покупателей, совершивших сделки на сумму 1000-2000 и 2000+
SELECT 
    T.Наименование AS PRODUCT_NAME,
    COUNT(DISTINCT SD.ID_Покупателя) AS BUYER_COUNT
FROM 
    Сделки SD
INNER JOIN 
    Товары T ON SD.ID_Товара = T.ID_Товара
WHERE 
    (T.Цена * SD.Количество) BETWEEN 1000 AND 2000
    OR (T.Цена * SD.Количество) > 2000
GROUP BY 
    T.Наименование
HAVING 
    COUNT(DISTINCT SD.ID_Покупателя) > 0
ORDER BY 
    T.Наименование;