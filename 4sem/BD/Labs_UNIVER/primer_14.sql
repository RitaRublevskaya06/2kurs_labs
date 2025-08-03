

































use UNIVER;

----1 Количество студентов в группе
go
create function dbo.StCount (@grpup_id int)
RETURNS int
as
begin
	return (select count(*) from STUDENT where IDGROUP = @grpup_id)
end;
GO
select dbo.StCount(2) as StudentCount

drop function dbo.StCount


-----2 Средний балл студента
go 
create function dbo.AVGP (@student_id int)
returns DECIMAL(5,2)
as
begin
	return (
		select avg(cast(NOTE as DECIMAL))
		from PROGRESS
		where IDSTUDENT = @student_id )
end;
go
select dbo.AVGP(1002) as LMNBV


drop function dbo.AVGP

---- 3 Количество преподавателей на факультете
go
create function HG (@facul char(10))
returns int
as
begin
	return(
		select count (*)
		from TEACHER t
		join PULPIT p on p.PULPIT = t.PULPIT
		where p.FACULTY = @facul)
end;

go 
select dbo.HG('IT') as 'Кол-во'


drop function dbo.HG

select count (*)
		from TEACHER t
		join PULPIT p on p.PULPIT = t.PULPIT
		where p.FACULTY = 'IT'



------- 6 Преподаватели кафедры
go
create function SDFGd (@pul char(20))
returns int
as
begin
return (select COUNT (*)
		from TEACHER
		where PULPIT = @pul)

end;
go 
select dbo.SDFGd('ISIT') as 'кол-во'


drop function dbo.SDFGd





---- 7 Количество конкретных оценок
go
create function DDFGHJ (@dfb int)
returns int 
as
begin
	return(
			select COUNT(*)
			from PROGRESS
			where NOTE = @dfb )
end;

go 
select dbo.DDFGHJ(8) as 'Кол-во оценок'

