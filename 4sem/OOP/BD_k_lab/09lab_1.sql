USE Lab09;
SELECT * FROM dbo.Orders;
SELECT * FROM dbo.People;


INSERT INTO dbo.People (Name, Age) VALUES ('Иван', 25);
INSERT INTO dbo.Orders (Product, PersonId) VALUES ('Книга', 1);