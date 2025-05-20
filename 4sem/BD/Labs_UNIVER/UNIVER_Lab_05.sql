USE UNIVER;

--1. Использовать в секции WHERE предикат IN c некоррелированным подзапросом к таблице PROFESSION
SELECT PULPIT.PULPIT_NAME
FROM PULPIT
WHERE PULPIT.FACULTY IN (
    SELECT PROFESSION.FACULTY
    FROM PROFESSION
    WHERE PROFESSION.PROFESSION_NAME LIKE '%Technology%'
);

--2. Переписать запрос пункта 1 таким образом, чтобы тот же подзапрос был записан в конструкции INNER JOIN секции FROM внешнего запроса
SELECT DISTINCT PULPIT.PULPIT_NAME
FROM PULPIT
INNER JOIN (
    SELECT DISTINCT FACULTY
    FROM PROFESSION
    WHERE PROFESSION.PROFESSION_NAME LIKE '%Technology%'
) AS PROF_FAC ON PULPIT.FACULTY = PROF_FAC.FACULTY;

--3. Переписать запрос, реализующий 1 пункт без использования подзапроса. Примечание: использовать соединение INNER JOIN трех таблиц
SELECT DISTINCT PULPIT.PULPIT_NAME
FROM PULPIT
INNER JOIN FACULTY ON PULPIT.FACULTY = FACULTY.FACULTY
INNER JOIN PROFESSION ON FACULTY.FACULTY = PROFESSION.FACULTY
WHERE PROFESSION.PROFESSION_NAME LIKE '%Technology%';

--4. На основе таблицы AUDITORIUM сформировать список аудиторий самых больших вместимостей для каждого типа аудитории. 
SELECT AUDITORIUM.AUDITORIUM, AUDITORIUM.AUDITORIUM_NAME, AUDITORIUM.AUDITORIUM_TYPE, AUDITORIUM.AUDITORIUM_CAPACITY
FROM AUDITORIUM 
WHERE AUDITORIUM.AUDITORIUM_CAPACITY = (
    SELECT TOP 1 A2.AUDITORIUM_CAPACITY
    FROM AUDITORIUM A2
    WHERE A2.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE
    ORDER BY A2.AUDITORIUM_CAPACITY DESC
)
ORDER BY AUDITORIUM.AUDITORIUM_CAPACITY DESC;

--5. Использовать предикат EXISTS и коррелированный подзапрос.
--INSERT INTO FACULTY (FACULTY, FACULTY_NAME)
--VALUES ('TEST_1', 'Тест_1');

----DELETE FROM FACULTY
----WHERE FACULTY = 'TEST_1' AND FACULTY_NAME = 'Тест_1';


SELECT F.FACULTY_NAME
FROM FACULTY F
WHERE NOT EXISTS (
    SELECT 1
    FROM PULPIT P
    WHERE P.FACULTY = F.FACULTY
);

--6. На основе таблицы PROGRESS сформировать строку, содержащую средние значения оценок (столбец NOTE) по дисциплинам, имеющим следующие коды: ОАиП, БД и СУБД. 
SELECT 
    (SELECT AVG(NOTE) FROM PROGRESS WHERE SUBJECT = 'OAP') AS AVG_OAIP,
    (SELECT AVG(NOTE) FROM PROGRESS WHERE SUBJECT = 'DB') AS AVG_BD,
    (SELECT AVG(NOTE) FROM PROGRESS WHERE SUBJECT = 'KG') AS AVG_SUBD;

--7. Разработать SELECT-запрос, демонстрирующий способ применения ALL совместно с подзапросом.
SELECT IDSTUDENT, NOTE
FROM PROGRESS
WHERE NOTE > ALL (
    SELECT NOTE
    FROM PROGRESS
    WHERE SUBJECT = 'OAP'
);

--8. Разработать SELECT-запрос, демонстрирующий принцип применения ANY совместно с подзапросом.
SELECT IDSTUDENT, NOTE
FROM PROGRESS
WHERE NOTE > ANY (
    SELECT NOTE
    FROM PROGRESS
    WHERE SUBJECT = 'OAP'
);