use Sample
go

drop aggregate dbo.SumTS
go

drop function dbo.TSDateDiff
go

drop function dbo.TSAddToDT
go

drop function dbo.TSDateDiffOffset
go

drop function dbo.TSAddToOffset
go

drop function dbo.TSApproxEquals
go

if object_id('Test') is not null 
	 drop table Test
go 

drop type TimeSpan
go

drop assembly [SLackerSLab.SqlTimeSpan]
go



use master
go



drop database Sample
go

exec sp_configure 'show advanced options', '1'
go
reconfigure
go 

exec sp_configure 'clr strict security', '0'
go
reconfigure
go

exec sp_configure 'show advanced options', '0'
go
reconfigure
go 


