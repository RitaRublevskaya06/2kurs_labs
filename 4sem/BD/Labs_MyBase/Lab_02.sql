-- Связываем таблицу "Склад" с "Товары"
ALTER TABLE Склад
ADD CONSTRAINT FK_Склад_Товар
FOREIGN KEY (Товар_ID) REFERENCES Товары(ID) ON DELETE CASCADE;

-- Связываем таблицу "Сделки" с "Покупатели"
ALTER TABLE Сделки
ADD CONSTRAINT FK_Сделки_Покупатель
FOREIGN KEY (Покупатель_ID) REFERENCES Покупатели(ID) ON DELETE CASCADE;

-- Связываем таблицу "Сделки" с "Товары"
ALTER TABLE Сделки
ADD CONSTRAINT FK_Сделки_Товар
FOREIGN KEY (Товар_ID) REFERENCES Товары(ID) ON DELETE CASCADE;
