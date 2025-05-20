 1. 
 IF EXISTS (SELECT name FROM sys.databases WHERE name = 'Lab_02')
   DROP DATABASE Lab_02;
GO
CREATE DATABASE Lab_03;
GO
USE Lab_03;
GO

---- 2. 
CREATE TABLE Товары (
	ID_Товара INT PRIMARY KEY IDENTITY,
	Наименование NVARCHAR(255) NOT NULL,
	Цена DECIMAL(10,2) NOT NULL,
	Описание TEXT
);

CREATE TABLE Покупатели (
	ID_Покупателя INT PRIMARY KEY IDENTITY,
	ФИО NVARCHAR(255) NOT NULL,
	Телефон NVARCHAR(20) NOT NULL,
	Адрес NVARCHAR(255) NOT NULL
);

CREATE TABLE Склад (
	ID_Места INT PRIMARY KEY IDENTITY,
	ID_Товара INT NOT NULL,
	Количество_товара INT NOT NULL,
	Место_хранения NVARCHAR(255) NOT NULL,
	Количество_ячеек INT NOT NULL,
	FOREIGN KEY (ID_Товара) REFERENCES Товары(ID_Товара)
);

CREATE TABLE Сделки (
	ID_Сделки INT PRIMARY KEY IDENTITY,
	ID_Покупателя INT NOT NULL,
	ID_Товара INT NOT NULL,
	Дата_сделки DATE NOT NULL,
	Количество INT NOT NULL,
	FOREIGN KEY (ID_Покупателя) REFERENCES Покупатели(ID_Покупателя),
	FOREIGN KEY (ID_Товара) REFERENCES Товары(ID_Товара)
);



-- 4. 
INSERT INTO Товары (Наименование, Цена, Описание)  VALUES
('Телефон', 500.00, 'Смартфон 128GB'),
('Ноутбук', 1200.00, 'Игровой ноутбук'),
('Телевизор', 700.00, '4K UND телевизор'),
('Планшет', 300.00, 'Планшет 64GB'),
('Смарт-часы', 200.00, 'Смарт-часы с функцией отслеживания активности'),
('Монитор', 400.00, '27" Full HD монитор'),
('Колонка', 150.00, 'Портативная Bluetooth колонка'),
('Мышь', 50.00, 'Игровая беспроводная мышь');

INSERT INTO Покупатели (ФИО, Телефон, Адрес) VALUES
('Иванов Иван Иванович', '3758974125', 'Минск, ул. Невского, 5'),
('Петров Петр Петрович', '89117654321', 'Москва, ул. Ленина, 5'),
('Пономарев Ян Богданович', '3758475962', 'Москва, ул. Ленина, 5'),
('Смирнова Полина Давидовна', '89512345678', 'Лида, ул. Сибирская, 7'),
('Морозова Ольга Михайловна', '3754861257', 'Минск, ул. Дзержинского, 25'),
('Алексеева Марина Сергеевна', '375299876543', 'Брест, ул. Пушкина, 12'),
('Ковалев Артем Алексеевич', '375334567890', 'Гродно, ул. Лермонтова, 9');

INSERT INTO Склад (ID_Товара, Количество_товара, Место_хранения, Количество_ячеек) VALUES
(1, 90, 'Секция A1', 50),
(2, 50, 'Секция B1', 50),
(3, 70, 'Секция C1', 50),
(4, 60, 'Секция D1', 30),
(5, 75, 'Секция E1', 50),
(6, 40, 'Секция B5', 30),
(7, 100, 'Секция C6', 25),
(8, 150, 'Секция E7', 20);


INSERT INTO Сделки(ID_Покупателя, ID_Товара, Дата_сделки, Количество) VALUES
(1, 1, '2025-01-03', 3),
(2, 2, '2025-02-28', 2),
(3, 3, '2025-01-03', 2),
(4, 4, '2025-02-28', 4),
(5, 5, '2025-02-28', 3),
(6, 6, '2025-03-01', 2),  -- Алексеева купила 2 монитора
(7, 7, '2025-03-03', 4),  -- Ковалев купил 4 колонки
(1, 8, '2025-03-05', 1),  -- Иванов купил мышь
(2, 6, '2025-03-06', 1),  -- Петров купил монитор
(5, 7, '2025-03-07', 2);  -- Морозова купила колонки

INSERT INTO Сделки (ID_Покупателя, ID_Товара, Дата_сделки, Количество)
VALUES (1, 6, '2025-04-10', 1);  -- Иванов (Минск) купил монитор


-- 3.
ALTER TABLE Товары ADD Производитель NVARCHAR(255) NOT NULL;
ALTER TABLE Товары ADD CONSTRAINT CK_Цена CHECK (Цена > 0);
-- Проверяем структуру, затем удаляем столбец
ALTER TABLE Товары DROP COLUMN Производитель;

-- 5.
SELECT * FROM Товары;
SELECT Наименование, Цена FROM Товары;
SELECT COUNT(*) AS Количество_записей FROM Товары;

UPDATE Товары SET Цена = 550 WHERE ID_Товара = 1;
SELECT * FROM Товары;


SELECT Наименование, Цена FROM Товары ORDER BY Цена ASC; -- по возрастанию
SELECT Наименование, Цена FROM Товары ORDER BY Цена DESC; -- по убыванию.







--SELECT Наименование [Дешевые товары], Цена FROM Товары WHERE Цена < 500;
--DELETE from ТОВАРЫ Where Наименование = 'Стул';






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










