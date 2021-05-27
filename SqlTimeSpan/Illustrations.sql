use Sample
go

declare @dt datetime2 = getdate(),
        @ts timespan,
		@resultTS TimeSpan

select @ts = 'invalid value'
select @ts as [TimeSpan initialized with invalid value]
select @ts = '10.20:30:40.50'
select @ts as [TimeSpan initialized with valid value]

select @ts = TimeSpan::FromDays(-1)

select dbo.TSAddToDT(@dt, @ts) as [SqlTimeSpan.TSAddToDT]

select @resultTS = dbo.TSDateDiff('1/20/2020',getdate())
select dbo.TSDateDiffOffset(GETDATE(), '1/20/2021').ToString() AS [DateDiff negative]
select dbo.TSDateDiffOffset(GETDATE(), '1/20/2021').Duration().ToString() AS [DateDiff negative duration]

-- Some random query properties
select @resultTS.TotalDays as [TimeSpan.TotalDays]
select @resultTS.TotalHours as [TimeSpan.TotalHours]
select @resultTS.Days as [TimeSpan.Days]
select @resultTS.Ticks as [TimeSpan.Ticks]

-- some static methods 
select TimeSpan::CreateSqlTimeSpan(11,23,59,9,8).ToString() [from constructor],
 TimeSpan::MinValue.ToString() [MinValue], TimeSpan::MaxValue.ToString() [MaxValue],
 TimeSpan::TicksPerDay [TicksPerDay]
 go

 if object_id('Test') is not null 
	 drop table Test

go 
 -- now the fun part - as column!
 create table Test
 (
	id int,
	ts TimeSpan
 )
 go
 insert Test values 
 (1, '6:12:09:45'),
 (2, TimeSpan::FromDays(15)),
 (3, '-3:15:14:30')
 go

 select id, ts.ToString() from Test 
 go

 select id, ts.ToString() from Test 
 where ts = TimeSpan::FromDays(15)
select * from Test

 update Test 
 set ts.AddTS(TimeSpan::FromHours(-48))
 where ts = TimeSpan::FromDays(15)
 select id, ts.ToString() from Test

 go
 -- Aggregate
 select dbo.SumTS(ts).ToString() as [SumTS] from Test

 -- with datetimeoffset
 declare @manilaDT datetimeoffset
		,@seattleDT datetimeoffset
		,@timeDiff timespan

select @seattleDT = SYSDATETIMEOFFSET()
	  ,@manilaDT = TODATETIMEOFFSET(dbo.TSAddToDT('5/28/2021 15:50','0.2:02:45.0'), '+08:00')  -- +2hrs 45min but in +8:00 TZ
	  ,@timeDiff = dbo.TSDateDiffOffset(@seattleDT, @manilaDT)

select @seattleDT "seattle time", @manilaDT "manila time", @timeDiff.ToString() "Sql Timespan"

 use master
 go
