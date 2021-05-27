use master
go
exec sp_configure 'clr enabled', '1'
go
reconfigure
go

-- Disable the clr strict security just to ease the cataloguing
-- WARNING! This is NOT a good practice
exec sp_configure 'show advanced options', '1'
go
reconfigure
go
exec sp_configure 'clr strict security', '0'
go
reconfigure
go

create database Sample
go
use Sample
go

create assembly [SLackerSLab.SqlTimeSpan]
from '<your path here>\source\repos\SqlTimeSpan\SqlTimeSpan\bin\Release\SLackerSLab.SqlTimeSpan.dll'
with permission_set = safe
go

create type TimeSpan
external name [SLackerSLab.SqlTimeSpan].[SLackerSLab.SqlTypes.SqlTimeSpan]
go

create function dbo.TSAddToDT(@dt datetime, @ts TimeSpan)
returns datetime AS 
external name [SLackerSLab.SqlTimeSpan].[SLackerSLab.SqlFunctions.SqlTimeSpanUdfs].TSAddToDT
go

create function [dbo].[TSDateDiff](@start datetime, @end datetime)
returns TimeSpan AS 
external name [SLackerSLab.SqlTimeSpan].[SLackerSLab.SqlFunctions.SqlTimeSpanUdfs].TSDateDiff
go

create function [dbo].TSAddToOffset(@dt datetimeoffset, @ts TimeSpan)
returns datetimeoffset AS 
external name [SLackerSLab.SqlTimeSpan].[SLackerSLab.SqlFunctions.SqlTimeSpanUdfs].TSAddToOffset
go

create function [dbo].[TSDateDiffOffset](@start datetimeoffset, @end datetimeoffset)
returns TimeSpan AS 
external name [SLackerSLab.SqlTimeSpan].[SLackerSLab.SqlFunctions.SqlTimeSpanUdfs].TSDateDiffOffset
go

create function [dbo].[TSApproxEquals](@start TimeSpan, @end TimeSpan, @allowedMargin TimeSpan )
returns bit AS 
external name [SLackerSLab.SqlTimeSpan].[SLackerSLab.SqlFunctions.SqlTimeSpanUdfs].TSApproxEquals
go

create aggregate dbo.SumTS (@tsToAdd TimeSpan)
returns TimeSpan 
external name [SLackerSLab.SqlTimeSpan].[SLackerSLab.SqlAggregates.SumTS]
go

use master
go