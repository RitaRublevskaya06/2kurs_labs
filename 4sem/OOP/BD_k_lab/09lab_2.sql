INSERT INTO People (Name, Phone) 
VALUES ('Иван', '12345678');


INSERT INTO Orders (Order_price, Date_of_order, PersonId) 
VALUES (100, GETDATE(), 1);


INSERT INTO People (Name, Phone) VALUES
('Иван', '12364899'),
('Мария', '98745632'),
('Алексей', '12547836'),
('Ольга', '95174236'),
('Дмитрий', '32145698'),
('Анна', '15874962'),
('Сергей', '12365478'),
('Екатерина', '96325874'),
('Павел', '14785236'),
('Наталья', '96325814'),
('Артем', '21587496'),
('Виктория', '45698721'),
('Игорь', '65248791'),
('Татьяна', '74135886'),
('Андрей', '85214736');

INSERT INTO Orders (Order_price, Date_of_order, PersonId) VALUES
(150, DATEADD(DAY, -10, GETDATE()), 1),
(200, DATEADD(DAY, -9, GETDATE()), 2),
(300, DATEADD(DAY, -8, GETDATE()), 3),
(250, DATEADD(DAY, -7, GETDATE()), 4),
(180, DATEADD(DAY, -6, GETDATE()), 5),
(220, DATEADD(DAY, -5, GETDATE()), 6),
(190, DATEADD(DAY, -4, GETDATE()), 7),
(210, DATEADD(DAY, -3, GETDATE()), 8),
(270, DATEADD(DAY, -2, GETDATE()), 9),
(320, DATEADD(DAY, -1, GETDATE()), 10),
(130, GETDATE(), 11),
(280, GETDATE(), 12),
(170, GETDATE(), 13),
(240, GETDATE(), 14),
(290, GETDATE(), 15);


SELECT * FROM People;
SELECT * FROM Orders;



SELECT COLUMN_NAME 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Orders';
