USE UNIVER;

-- 1. Выбор аудиторий и их типов
SELECT a.AUDITORIUM, at.AUDITORIUM_TYPENAME
FROM AUDITORIUM a
INNER JOIN AUDITORIUM_TYPE at ON a.AUDITORIUM_TYPE = at.AUDITORIUM_TYPE;


--2. Поиск аудиторий типа "Computer Lab"
SELECT a.AUDITORIUM, at.AUDITORIUM_TYPENAME
FROM AUDITORIUM a
INNER JOIN AUDITORIUM_TYPE at ON a.AUDITORIUM_TYPE = at.AUDITORIUM_TYPE
WHERE at.AUDITORIUM_TYPENAME LIKE '%Computer%';

--3. Информация об успеваемости студентов
SELECT f.FACULTY_NAME AS Факультет, 
       p.PULPIT_NAME AS Кафедра, 
       pr.PROFESSION_NAME AS Специальность, 
       s.SUBJECT_NAME AS Дисциплина, 
       st.NAME AS Имя_Студента, 
       CASE 
           WHEN prg.NOTE = 6 THEN 'шесть' 
           WHEN prg.NOTE = 7 THEN 'семь' 
           WHEN prg.NOTE = 8 THEN 'восемь' 
       END AS Оценка
FROM PROGRESS prg
INNER JOIN STUDENT st ON prg.IDSTUDENT = st.IDSTUDENT
INNER JOIN GROUPS g ON st.IDGROUP = g.IDGROUP
INNER JOIN PROFESSION pr ON g.PROFESSION = pr.PROFESSION
INNER JOIN FACULTY f ON pr.FACULTY = f.FACULTY
INNER JOIN SUBJECT s ON prg.SUBJECT = s.SUBJECT
INNER JOIN PULPIT p ON s.PULPIT = p.PULPIT
WHERE prg.NOTE BETWEEN 6 AND 8
ORDER BY prg.NOTE DESC;

--4. Кафедры и их преподаватели
SELECT p.PULPIT_NAME AS Кафедра, 
       ISNULL(t.TEACHER_NAME, '***') AS Преподаватель
FROM PULPIT p
LEFT OUTER JOIN TEACHER t ON p.PULPIT = t.PULPIT;

-- 5.  Создание таблиц
 CREATE TABLE Employees (
     ID INT,
     Name VARCHAR(50)
 );
 INSERT INTO Employees (ID, Name)
 VALUES (1, 'Daniel'),
        (2, 'Emma'),
        (3, 'Frank');
        
 CREATE TABLE Departments (
     ID INT,
     Description VARCHAR(50)
 );
 INSERT INTO Departments (ID, Description)
 VALUES (2, 'Physics'),
        (3, 'Chemistry'),
        (4, 'Literature');

-- 5_1. Элементы из Employees, отсутствующие в Departments
SELECT  E.ID, E.Name
FROM Employees E
FULL OUTER JOIN Departments D ON E.ID = D.ID
WHERE D.ID IS NULL;

-- 5_2. Элементы из Departments, отсутствующие в Employees
SELECT  D.ID, D.Description
FROM Employees E
FULL OUTER JOIN Departments D ON E.ID = D.ID
WHERE E.ID IS NULL;

-- 5_3. Элементы, присутствующие в обеих таблицах
SELECT 
    E.ID, 
    E.Name, 
    D.Description
FROM Employees E
FULL OUTER JOIN Departments D ON E.ID = D.ID
WHERE E.ID IS NOT NULL AND D.ID IS NOT NULL;


--6. Декартово произведение типов аудиторий и аудиторий
SELECT at.AUDITORIUM_TYPENAME AS AuditoriumType,  
    a.AUDITORIUM_NAME AS Auditorium           
FROM AUDITORIUM_TYPE AT
CROSS JOIN AUDITORIUM A;