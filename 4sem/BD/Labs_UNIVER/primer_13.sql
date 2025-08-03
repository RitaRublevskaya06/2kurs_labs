
































---- 1 Изменение оценки студента
alter procedure Pr
as
begin
	update PROGRESS
	set NOTE = case when NOTE < 10 then NOTE + 1 else 10 
end
	print 'успешно';
end;
exec Pr ;



select * from PROGRESS;


---- 2 Изменение оценки студента
alter procedure Pr
	@id_st int
as
begin
	update PROGRESS
	set NOTE = case when NOTE < 10 then NOTE + 1 else 10 
end
	where IDSTUDENT = @id_st;
	print 'успешно';
end;
 
exec Pr @id_st = 1003;


--drop procedure Pr

---- 3 Добавление нового студента
go
create procedure Kr
	@gr_id int,
	@name nvarchar(100),
	@pdata date
as
begin
	insert into STUDENT(IDGROUP, [NAME], BDAY)
	values (@gr_id, @name, @pdata)
	return scope_identity();
end;
exec Kr @gr_id = 4, @name = 'Oleg', @pdata = '2002-05-15';

select * from STUDENT

--drop procedure Kr

------DELETE FROM STUDENT WHERE IDSTUDENT = 1129; 


---- 4 Расчет средней оценки по предмету
select * from PROGRESS

create procedure LH
	@s_code char(10)
as
begin
	select avg(NOTE*1.0) AS AAVG
	from PROGRESS
	where [SUBJECT] = @s_code
	return @@rowcount
end;

exec LH @s_code = 'KG'

--drop procedure LH

---- 5. Расчет среднего балла группы
create procedure GF
	@group_id int
as 
begin
	select avg([NOTE]*1.0) as AAAVVg
	from PROGRESS p
	join STUDENT s on p.IDSTUDENT = s.IDSTUDENT
	where s.IDGROUP = @group_id;
end;

exec GF @group_id = 2;

select *  
	from PROGRESS p
	join STUDENT s on p.IDSTUDENT = s.IDSTUDENT
	where s.IDGROUP = 2;


--drop procedure GF

---- 6 Расчет среднего балла ученика

create procedure GF4
	@stud_id int
as 
begin
	select avg([NOTE]*1.0) as AAAVVggg
	from PROGRESS p
	join STUDENT s on p.IDSTUDENT = s.IDSTUDENT
	where s.IDSTUDENT = @stud_id;
end;

exec GF4 @stud_id = 1002;

select *  
	from PROGRESS p
	join STUDENT s on p.IDSTUDENT = s.IDSTUDENT
	where s.IDSTUDENT = 1002;



--drop procedure GF4




----- 6.
go
create procedure JH
	@del_id int
as
begin
	delete from STUDENT
	where IDSTUDENT = @del_id
end;

exec JH @del_id = 1131


drop procedure JH





go
create procedure L
	@student_id int,
	@grop_id int
as
begin
	update STUDENT
	set IDGROUP = @grop_id
	where IDSTUDENT = @student_id
end;

exec L @student_id = 1095, @grop_id = 10





select * from PROGRESS where IDSTUDENT = 1054












INSERT INTO PROGRESS([SUBJECT], IDSTUDENT, PDATE, NOTE)
VALUES ('BD', 1002, '2023-11-20', 8), ('KG', 1002, '2023-11-20', 7); 