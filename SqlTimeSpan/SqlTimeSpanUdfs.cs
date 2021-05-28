using Microsoft.SqlServer.Server;
using SLackerSLab.SqlTypes;
using System;

namespace SLackerSLab.SqlFunctions
{
    static public class SqlTimeSpanUdfs
    {
        /// <summary>
        /// Adds time span to date time.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ts">The time span to add</param>
        /// <returns>The date time with time span added</returns>
        [SqlFunction]
        public static DateTime TSAddToDT(DateTime dt, SqlTimeSpan ts)
            => dt.Add(TimeSpan.FromTicks(ts.Ticks));

        /// <summary>
        /// Gets the time span between 2 date times
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>The difference time span</returns>
        [SqlFunction]
        public static SqlTimeSpan TSDateDiff(DateTime start, DateTime end)
            => new SqlTimeSpan(end - start, false);

        /// <summary>
        /// Adds time span to time zone senstive data type DateTimeOffset
        /// </summary>
        /// <param name="dt">The date time with timezone info</param>
        /// <param name="ts">The timespan to add</param>
        /// <returns>Date time offset result</returns>
        [SqlFunction]
        public static DateTimeOffset TSAddToOffset(DateTimeOffset dt, SqlTimeSpan ts)
            => dt.Add(TimeSpan.FromTicks(ts.Ticks));

        /// <summary>
        /// Gets the time span between 2 date times with time zone info
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>The difference timespan</returns>
        [SqlFunction]
        public static SqlTimeSpan TSDateDiffOffset(DateTimeOffset start, DateTimeOffset end)
            => new SqlTimeSpan(end - start, false);

        /// <summary>
        /// Equality operation that allows a specified margin of difference
        /// </summary>
        /// <param name="ts1">First time span to compare from</param>
        /// <param name="ts2">Second time span to compare to</param>
        /// <param name="allowedMargin">Allowed margin for diference in time span</param>
        /// <returns></returns>
        [SqlFunction]
        static public bool TSApproxEquals(SqlTimeSpan ts1, SqlTimeSpan ts2
                                       , SqlTimeSpan allowedMargin)
        {
            TimeSpan diff = ts1.SystemTimeSpan - ts2.SystemTimeSpan;
            return (diff.Duration() <= allowedMargin.SystemTimeSpan.Duration());
        }
    }
}
