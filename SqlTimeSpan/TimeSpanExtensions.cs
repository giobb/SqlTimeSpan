using System;

namespace SLackerSLab.SqlTypes
{
    static public class TimeSpanExtensions
    {
        static public SqlTimeSpan ToSqlTimeSpan(this TimeSpan ts)
            => new SqlTimeSpan(ts, false);


        static public bool ApproxEquals(this TimeSpan ts
                                      , TimeSpan tsToCompare
                                      , TimeSpan allowedMargin)
        {
            TimeSpan diff = ts - tsToCompare;
            return (diff.Duration() <= allowedMargin.Duration());
        }
    }
}
