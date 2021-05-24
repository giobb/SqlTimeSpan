using System;
using Microsoft.SqlServer.Server;

static public partial class SqlTimeSpanUdfs
{
    [SqlFunction]
    public static DateTime AddTS(DateTime dt, SqlTimeSpan ts)
    {
        return (dt.Add(TimeSpan.FromTicks(ts.Ticks)));
    }

    [SqlFunction]
    public static DateTime SubtractTS(DateTime dt, SqlTimeSpan ts)
    {
        return (dt.Subtract(TimeSpan.FromTicks(ts.Ticks)));
    }

    [SqlFunction]
    public static SqlTimeSpan DateDiff2(DateTime start, DateTime end)
    {
        TimeSpan ts = end - start;
        return new SqlTimeSpan(ts, false);
    }

    [SqlFunction]
    public static DateTimeOffset AddTSOffset(DateTimeOffset dt, SqlTimeSpan ts)
    {
        return (dt.Add(TimeSpan.FromTicks(ts.Ticks)));
    }

    [SqlFunction]
    public static DateTimeOffset SubtractTSOffset(DateTimeOffset dt, SqlTimeSpan ts)
    {
        return (dt.Subtract(TimeSpan.FromTicks(ts.Ticks)));
    }

    [SqlFunction]
    public static SqlTimeSpan DateDiffOffset(DateTimeOffset start, DateTimeOffset end)
    {
        TimeSpan ts = end - start;
        return new SqlTimeSpan(ts, false);
    }
    
};

