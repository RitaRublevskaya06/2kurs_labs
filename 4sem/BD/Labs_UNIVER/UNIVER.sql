USE UNIVER;

DROP TABLE IF EXISTS PROGRESS;
DROP TABLE IF EXISTS STUDENT;
DROP TABLE IF EXISTS GROUPS;
DROP TABLE IF EXISTS SUBJECT;
DROP TABLE IF EXISTS TEACHER;
DROP TABLE IF EXISTS PULPIT;
DROP TABLE IF EXISTS PROFESSION;
DROP TABLE IF EXISTS FACULTY;
DROP TABLE IF EXISTS AUDITORIUM;
DROP TABLE IF EXISTS AUDITORIUM_TYPE;

------------ Create and populate AUDITORIUM_TYPE table
CREATE TABLE AUDITORIUM_TYPE 
(
    AUDITORIUM_TYPE  CHAR(10) CONSTRAINT AUDITORIUM_TYPE_PK PRIMARY KEY,  
    AUDITORIUM_TYPENAME  VARCHAR(30)       
);

INSERT INTO AUDITORIUM_TYPE (AUDITORIUM_TYPE, AUDITORIUM_TYPENAME)
VALUES 
    ('LK', 'Lecture Hall'),
    ('LB-K', 'Computer Lab'),
    ('LK-K', 'Lecture Hall with Projector'),
    ('LB-X', 'Chemistry Lab'),
    ('LB-SK', 'Special Computer Lab');

------------- Create and populate AUDITORIUM table
CREATE TABLE AUDITORIUM 
(
    AUDITORIUM   CHAR(20) CONSTRAINT AUDITORIUM_PK PRIMARY KEY,              
    AUDITORIUM_TYPE     CHAR(10) CONSTRAINT AUDITORIUM_AUDITORIUM_TYPE_FK FOREIGN KEY REFERENCES AUDITORIUM_TYPE(AUDITORIUM_TYPE), 
    AUDITORIUM_CAPACITY  INTEGER CONSTRAINT AUDITORIUM_CAPACITY_CHECK DEFAULT 1 CHECK (AUDITORIUM_CAPACITY BETWEEN 1 AND 300),  -- Capacity
    AUDITORIUM_NAME      VARCHAR(50)                                     
);

INSERT INTO AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
VALUES 
    ('206-1', '206-1', 'LB-K', 15),
    ('301-1', '301-1', 'LB-K', 15),
    ('236-1', '236-1', 'LK', 60),
    ('313-1', '313-1', 'LK-K', 60),
    ('324-1', '324-1', 'LK-K', 50),
    ('413-1', '413-1', 'LB-K', 15),
    ('423-1', '423-1', 'LB-K', 90),
    ('408-2', '408-2', 'LK', 90);

------ Create and populate FACULTY table
CREATE TABLE FACULTY
(
    FACULTY      CHAR(10) CONSTRAINT FACULTY_PK PRIMARY KEY,
    FACULTY_NAME  VARCHAR(50) DEFAULT '???'
);

INSERT INTO FACULTY (FACULTY, FACULTY_NAME)
VALUES 
    ('HTT', 'Chemical Technology and Engineering'),
    ('LHF', 'Forestry Faculty'),
    ('IEF', 'Engineering and Economics Faculty'),
    ('TTLP', 'Technology and Techniques of the Forest Industry'),
    ('TOV', 'Technology of Organic Substances'),
    ('IT', 'Faculty of Information Technology');

------ Create and populate PROFESSION table
CREATE TABLE PROFESSION
(
    PROFESSION   CHAR(20) CONSTRAINT PROFESSION_PK PRIMARY KEY,
    FACULTY    CHAR(10) CONSTRAINT PROFESSION_FACULTY_FK FOREIGN KEY REFERENCES FACULTY(FACULTY),
    PROFESSION_NAME VARCHAR(100),    
    QUALIFICATION   VARCHAR(50)  
);

INSERT INTO PROFESSION (FACULTY, PROFESSION, PROFESSION_NAME, QUALIFICATION)
VALUES 
    ('IT', '1-40 01 02', 'Information Systems and Technologies', 'Software Engineer'),
    ('IT', '1-47 01 01', 'Publishing', 'Editor-Technologist'),
    ('IT', '1-36 06 01', 'Printing Equipment and Information Processing Systems', 'Electromechanical Engineer'),
    ('HTT', '1-36 01 08', 'Design and Production of Composite Materials', 'Mechanical Engineer'),
    ('HTT', '1-36 07 01', 'Machines and Apparatus of Chemical Productions', 'Mechanical Engineer'),
    ('LHF', '1-75 01 01', 'Forestry', 'Forestry Engineer'),
    ('LHF', '1-75 02 01', 'Landscape Architecture', 'Landscape Architect'),
    ('LHF', '1-89 02 02', 'Tourism and Nature Management', 'Tourism Specialist'),
    ('IEF', '1-25 01 07', 'Economics and Enterprise Management', 'Economist-Manager'),
    ('IEF', '1-25 01 08', 'Accounting, Analysis, and Audit', 'Economist'),
    ('TTLP', '1-36 05 01', 'Machines and Equipment of the Forest Complex', 'Mechanical Engineer'),
    ('TTLP', '1-46 01 01', 'Forest Engineering', 'Technological Engineer'),
    ('TOV', '1-48 01 02', 'Chemical Technology of Organic Substances', 'Chemical Engineer'),
    ('TOV', '1-48 01 05', 'Chemical Technology of Wood Processing', 'Chemical Engineer'),
    ('TOV', '1-54 01 03', 'Physical and Chemical Methods and Quality Control Instruments', 'Certification Engineer');
	------ Create and populate PULPIT table
CREATE TABLE PULPIT 
(
    PULPIT   CHAR(20) CONSTRAINT PULPIT_PK PRIMARY KEY,
    PULPIT_NAME  VARCHAR(100), 
    FACULTY   CHAR(10) CONSTRAINT PULPIT_FACULTY_FK FOREIGN KEY REFERENCES FACULTY(FACULTY) 
);

INSERT INTO PULPIT (PULPIT, PULPIT_NAME, FACULTY)
VALUES 
    ('ISIT', 'Information Systems and Technologies', 'IT'),
    ('LV', 'Forestry', 'LHF'),
    ('LU', 'Forest Management', 'LHF'),
    ('LZIDV', 'Forest Protection and Wood Science', 'LHF'),
    ('LKIP', 'Forest Cultures and Soil Science', 'LHF'),
    ('TIP', 'Tourism and Nature Management', 'LHF'),
    ('LPISPS', 'Landscape Design and Park Construction', 'LHF'),
    ('TL', 'Forest Transport', 'TTLP'),
    ('LMILZ', 'Forest Machines and Logging Technology', 'TTLP'),
    ('TDP', 'Wood Processing Technologies', 'TTLP'),
    ('TIDID', 'Technology and Design of Wood Products', 'TTLP'),
    ('OH', 'Organic Chemistry', 'TOV'),
    ('HPD', 'Chemical Processing of Wood', 'TOV'),
    ('TNVOHT', 'Technology of Inorganic Substances and General Chemical Technology', 'HTT'),
    ('PIAHP', 'Processes and Apparatus of Chemical Productions', 'HTT'),
    ('ETM', 'Economic Theory and Marketing', 'IEF'),
    ('MIEP', 'Management and Economics of Nature Management', 'IEF'),
    ('SBUAA', 'Statistics, Accounting, Analysis, and Audit', 'IEF');
------ Create and populate TEACHER table
CREATE TABLE TEACHER
(
    TEACHER    CHAR(10) CONSTRAINT TEACHER_PK PRIMARY KEY,
    TEACHER_NAME  VARCHAR(100), 
    GENDER     CHAR(1) CHECK (GENDER IN ('M', 'F')),
    PULPIT   CHAR(20) CONSTRAINT TEACHER_PULPIT_FK FOREIGN KEY REFERENCES PULPIT(PULPIT) 
);

INSERT INTO TEACHER (TEACHER, TEACHER_NAME, GENDER, PULPIT)
VALUES 
    ('SMLV', 'Smelov Vladimir Vladislavovich', 'M', 'ISIT'),
    ('DTK', 'Dyatko Alexander Arkadievich', 'M', 'LV'),
    ('URB', 'Urbanovich Pavel Pavlovich', 'M', 'ISIT'),
    ('GRN', 'Gurin Nikolay Ivanovich', 'M', 'ISIT'),
    ('ZLK', 'Zhilak Nadezhda Alexandrovna', 'F', 'ISIT'),
    ('MRZ', 'Moroz Elena Stanislavovna', 'F', 'ISIT'),
    ('BRTSHVCH', 'Bartashevich Svyatoslav Alexandrovich', 'M', 'PIAHP'),
    ('ARS', 'Arsentiev Vitaliy Arsentievich', 'M', 'PIAHP'),
    ('NVRV', 'Neverov Alexander Vasilievich', 'M', 'MIEP'),
    ('RVKCH', 'Rovkach Andrey Ivanovich', 'M', 'LV'),
    ('DMDK', 'Demidko Marina Nikolaevna', 'F', 'LPISPS'),
    ('BRG', 'Burganskaya Tatyana Minaevna', 'F', 'LPISPS'),
    ('RZHK', 'Rozhkov Leonid Nikolaevich', 'M', 'LV'),
    ('ZVGTSV', 'Zvyagintsev Vyacheslav Borisovich', 'M', 'LZIDV'),
    ('BZBRDV', 'Bezborodov Vladimir Stepanovich', 'M', 'OH'),
    ('NSKVTS', 'Naskovets Mikhail Trofimovich', 'M', 'TL');

------ Create and populate SUBJECT table
CREATE TABLE SUBJECT
(
    SUBJECT  CHAR(10) CONSTRAINT SUBJECT_PK PRIMARY KEY, 
    SUBJECT_NAME VARCHAR(100) UNIQUE,
    PULPIT  CHAR(20) CONSTRAINT SUBJECT_PULPIT_FK FOREIGN KEY REFERENCES PULPIT(PULPIT)   
);

INSERT INTO SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
VALUES 
    ('DB', 'Database Systems', 'ISIT'),
    ('BD', 'Databases', 'ISIT'),
    ('INF', 'Information Technologies', 'ISIT'),
    ('OAP', 'Fundamentals of Algorithms and Programming', 'ISIT'),
    ('PZ', 'Knowledge Representation in Computer Systems', 'ISIT'),
    ('PSP', 'Programming Network Applications', 'ISIT'),
    ('MSOI', 'Modeling of Information Processing Systems', 'ISIT'),
    ('PIS', 'Design of Information Systems', 'ISIT'),
    ('KG', 'Computer Geometry', 'ISIT'),
    ('PMAPL', 'Printing Machines, Automata, and Production Lines', 'PIAHP'),
    ('KMS', 'Computer Multimedia Systems', 'ISIT'),
    ('OPP', 'Organization of Printing Production', 'PIAHP'),
    ('DM', 'Discrete Mathematics', 'ISIT'),
    ('MP', 'Mathematical Programming', 'ISIT'),
    ('LEVM', 'Logical Foundations of Computers', 'ISIT'),
    ('OOP', 'Object-Oriented Programming', 'ISIT'),
    ('EP', 'Economics of Nature Management', 'MIEP'),
    ('ET', 'Economic Theory', 'ETM'),
    ('BLZPOO', 'Biology of Forest Animals and Birds with Basics of Hunting', 'LV'),
    ('OSPLPH', 'Fundamentals of Landscape and Park Management', 'LPISPS'),
    ('IG', 'Engineering Geodesy', 'LU'),
    ('LV', 'Forestry', 'LZIDV'),
    ('OH', 'Organic Chemistry', 'OH'),
    ('TRI', 'Technology of Rubber Products', 'TNVOHT'),
    ('VTL', 'Water Transport of Forest', 'TL'),
    ('TIOL', 'Technology and Equipment of Logging', 'LMILZ'),
    ('TOPI', 'Technology of Mineral Processing', 'TNVOHT'),
    ('PEH', 'Applied Electrochemistry', 'HPD');

  
------ Create and populate GROUPS table
CREATE TABLE GROUPS 
(
    IDGROUP  INTEGER IDENTITY(1,1) CONSTRAINT GROUP_PK PRIMARY KEY,              
    FACULTY   CHAR(10) CONSTRAINT GROUPS_FACULTY_FK FOREIGN KEY REFERENCES FACULTY(FACULTY), 
    PROFESSION  CHAR(20) CONSTRAINT GROUPS_PROFESSION_FK FOREIGN KEY REFERENCES PROFESSION(PROFESSION),
    YEAR_FIRST  SMALLINT CHECK (YEAR_FIRST <= YEAR(GETDATE()))                  
);

INSERT INTO GROUPS (FACULTY, PROFESSION, YEAR_FIRST)
VALUES 
    ('IT', '1-40 01 02', 2013),
    ('IT', '1-40 01 02', 2012),
    ('IT', '1-40 01 02', 2011),
    ('IT', '1-40 01 02', 2010),
    ('IT', '1-47 01 01', 2013),
    ('IT', '1-47 01 01', 2012),
    ('IT', '1-47 01 01', 2011),
    ('IT', '1-36 06 01', 2010),
    ('IT', '1-36 06 01', 2013),
    ('IT', '1-36 06 01', 2012),
    ('IT', '1-36 06 01', 2011),
    ('HTT', '1-36 01 08', 2013),
    ('HTT', '1-36 01 08', 2012),
    ('HTT', '1-36 07 01', 2011),
    ('HTT', '1-36 07 01', 2010),
    ('TOV', '1-48 01 02', 2012),
    ('TOV', '1-48 01 02', 2011),
    ('TOV', '1-48 01 05', 2013),
    ('TOV', '1-54 01 03', 2012),
    ('LHF', '1-75 01 01', 2013),
    ('LHF', '1-75 02 01', 2012),
    ('LHF', '1-75 02 01', 2011),
    ('LHF', '1-89 02 02', 2012),
    ('LHF', '1-89 02 02', 2011),
    ('TTLP', '1-36 05 01', 2013),
    ('TTLP', '1-36 05 01', 2012),
    ('TTLP', '1-46 01 01', 2012),
    ('IEF', '1-25 01 07', 2013),
    ('IEF', '1-25 01 07', 2012),
    ('IEF', '1-25 01 07', 2010),
    ('IEF', '1-25 01 08', 2013),
    ('IEF', '1-25 01 08', 2012);

------ Create and populate STUDENT table
CREATE TABLE STUDENT 
(
    IDSTUDENT   INTEGER IDENTITY(1000,1) CONSTRAINT STUDENT_PK PRIMARY KEY,
    IDGROUP   INTEGER CONSTRAINT STUDENT_GROUP_FK FOREIGN KEY REFERENCES GROUPS(IDGROUP),        
    NAME   NVARCHAR(100), 
    BDAY   DATE,
    STAMP  TIMESTAMP,
    INFO     XML,
    FOTO     VARBINARY(MAX)
);

INSERT INTO STUDENT (IDGROUP, NAME, BDAY)
VALUES 
    (2, 'Silyuk Valeria Ivanovna', '1994-07-12'),
    (2, 'Sergel Violetta Nikolaevna', '1994-03-06'),
    (2, 'Dobrodey Olga Anatolievna', '1994-11-09'),
    (2, 'Podolyak Maria Sergeevna', '1994-10-04'),
    (2, 'Nikitenko Ekaterina Dmitrievna', '1994-01-08'),
    (3, 'Yatskevich Galina Iosifovna', '1993-08-02'),
    (3, 'Osadchaya Ela Vasilievna', '1993-12-07'),
    (3, 'Akulova Elena Gennadievna', '1993-12-02'),
    (4, 'Pleshkun Milana Anatolievna', '1992-03-08'),
    (4, 'Buyanova Maria Alexandrovna', '1992-06-02'),
    (4, 'Kharchenko Elena Gennadievna', '1992-12-11'),
    (4, 'Kruchenok Evgeny Alexandrovich', '1992-05-11'),
    (4, 'Borokhovsky Vitaly Petrovich', '1992-11-09'),
    (4, 'Matskevich Nadezhda Valeryevna', '1992-11-01'),
    (5, 'Loginova Maria Vyacheslavovna', '1995-07-08'),
    (5, 'Belko Natalia Nikolaevna', '1995-11-02'),
    (5, 'Selilo Ekaterina Gennadievna', '1995-05-07'),
    (5, 'Drozd Anastasia Andreevna', '1995-08-04'),
    (6, 'Kozlovskaya Elena Evgenievna', '1994-11-08'),
    (6, 'Potapnin Kirill Olegovich', '1994-03-02'),
    (6, 'Ravkovskaya Olga Nikolaevna', '1994-06-04'),
    (6, 'Khodoronok Alexandra Vadimovna', '1994-11-09'),
    (6, 'Ramuk Vladislav Yuryevich', '1994-07-04'),
    (7, 'Neruganenok Maria Vladimirovna', '1993-01-03'),
    (7, 'Tsyganok Anna Petrovna', '1993-09-12'),
    (7, 'Masilevich Oksana Igorevna', '1993-06-12'),
    (7, 'Aleksievich Elizaveta Viktorovna', '1993-02-09'),
    (7, 'Vatolin Maxim Andreevich', '1993-07-04'),
    (8, 'Sinitsa Valeria Andreevna', '1992-01-08'),
    (8, 'Kudryashova Alina Nikolaevna', '1992-05-12'),
    (8, 'Migulina Elena Leonidovna', '1992-11-08'),
    (8, 'Shpilenia Alexey Sergeevich', '1992-03-12'),
    (9, 'Astafiev Igor Alexandrovich', '1995-08-10'),
    (9, 'Gaytukevich Andrey Igorevich', '1995-05-02'),
    (9, 'Ruchenya Natalia Alexandrovna', '1995-01-08'),
    (9, 'Tarasevich Anastasia Ivanovna', '1995-09-11'),
    (10, 'Zhoglin Nikolay Vladimirovich', '1994-01-08'),
    (10, 'Sanko Andrey Dmitrievich', '1994-09-11'),
    (10, 'Peshchur Anna Alexandrovna', '1994-04-06'),
    (10, 'Buchalis Nikita Leonidovich', '1994-08-12'),
    (11, 'Lavrenchuk Vladislav Nikolaevich', '1993-11-07'),
    (11, 'Vlasik Evgenia Viktorovna', '1993-06-04'),
    (11, 'Abramov Denis Dmitrievich', '1993-12-10'),
    (11, 'Olenchik Sergey Nikolaevich', '1993-07-04'),
    (11, 'Savinko Pavel Andreevich', '1993-01-08'),
    (11, 'Bakun Alexey Viktorovich', '1993-09-02'),
    (12, 'Ban Sergey Anatolievich', '1995-12-11'),
    (12, 'Secheyko Ilya Alexandrovich', '1995-06-10'),
    (12, 'Kuzmicheva Anna Andreevna', '1995-08-09'),
    (12, 'Burko Diana Frantsevna', '1995-07-04'),
    (12, 'Danilenko Maxim Vasilievich', '1995-03-08'),
    (12, 'Zizyuk Olga Olegovna', '1995-09-12'),
    (13, 'Sharapo Maria Vladimirovna', '1994-10-08'),
    (13, 'Kasperovich Vadim Viktorovich', '1994-02-10'),
    (13, 'Chuprygin Arseny Alexandrovich', '1994-11-11'),
    (13, 'Voevodskaya Olga Leonidovna', '1994-02-10'),
    (13, 'Metushevsky Denis Igorevich', '1994-01-12'),
    (14, 'Lovetskaya Valeria Alexandrovna', '1993-09-11'),
    (14, 'Dvorak Antonina Nikolaevna', '1993-12-01'),
    (14, 'Shchuka Tatyana Nikolaevna', '1993-06-09'),
    (14, 'Koblinets Alexandra Evgenievna', '1993-01-05'),
    (14, 'Fomichevskaya Elena Ernestovna', '1993-07-01'),
    (15, 'Besarab Margarita Vadimovna', '1992-04-07'),
    (15, 'Baduro Victoria Sergeevna', '1992-12-10'),
    (15, 'Tarasenko Olga Viktorovna', '1992-05-05'),
    (15, 'Afanasenko Olga Vladimirovna', '1992-01-11'),
    (15, 'Chuikevich Irina Dmitrievna', '1992-06-04'),
    (16, 'Brel Alesya Alexeevna', '1994-01-08'),
    (16, 'Kuznetsova Anastasia Andreevna', '1994-02-07'),
    (16, 'Tomina Karina Gennadievna', '1994-06-12'),
    (16, 'Dubrov Pavel Igorevich', '1994-07-03'),
    (16, 'Shpakov Viktor Andreevich', '1994-07-04'),
    (17, 'Shneider Anastasia Dmitrievna', '1993-11-08'),
    (17, 'Shygina Elena Viktorovna', '1993-04-02'),
	(17, 'Klyueva Anna Ivanovna', '1993-06-03'),
    (17, 'Domorad Marina Andreevna', '1993-11-05'),
    (17, 'Linchuk Mikhail Alexandrovich', '1993-07-03'),
    (18, 'Vasilyeva Darya Olegovna', '1995-01-08'),
    (18, 'Shchigelskaya Ekaterina Andreevna', '1995-09-06'),
    (18, 'Sazonova Ekaterina Dmitrievna', '1995-03-08'),
    (18, 'Bakunovich Alina Olegovna', '1995-08-07');

------ Create and populate PROGRESS table
CREATE TABLE PROGRESS
(
    SUBJECT   CHAR(10) CONSTRAINT PROGRESS_SUBJECT_FK FOREIGN KEY REFERENCES SUBJECT(SUBJECT),                
    IDSTUDENT INTEGER CONSTRAINT PROGRESS_IDSTUDENT_FK FOREIGN KEY REFERENCES STUDENT(IDSTUDENT),        
    PDATE    DATE, 
    NOTE     INTEGER CHECK (NOTE BETWEEN 1 AND 10)
);

INSERT INTO PROGRESS (SUBJECT, IDSTUDENT, PDATE, NOTE)
VALUES 
    ('OAP', 1001, '2013-10-01', 8), -- Ensure 'OAP' exists in SUBJECT
    ('OAP', 1002, '2013-10-01', 7), -- Ensure 'OAP' exists in SUBJECT
    ('OAP', 1003, '2013-10-01', 5), -- Ensure 'OAP' exists in SUBJECT
    ('OAP', 1005, '2013-10-01', 4), -- Ensure 'OAP' exists in SUBJECT
    ('DB', 1014, '2013-12-01', 5),
    ('DB', 1015, '2013-12-01', 9),
    ('DB', 1016, '2013-12-01', 5),
    ('DB', 1017, '2013-12-01', 4),
    ('KG', 1018, '2013-05-06', 4),
    ('KG', 1019, '2013-05-06', 7),
    ('KG', 1020, '2013-05-06', 7),
    ('KG', 1021, '2013-05-06', 9),
    ('KG', 1022, '2013-05-06', 5),
    ('KG', 1023, '2013-05-06', 6);