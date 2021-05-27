using Microsoft.SqlServer.Server;
using System;
using System.Data.SqlTypes;

namespace SLackerSLab.SqlTypes
{
    /// <summary>
    /// An object for compact treatment of time span information.
    /// This is port of the .NET System.TimeSpan struct
    /// </summary>
    [SqlUserDefinedType(Format.Native, IsByteOrdered = true)]
    public struct SqlTimeSpan : INullable
    {
        #region Mandatory Members

        long _ticks;

        internal TimeSpan SystemTimeSpan
        {
            get => TimeSpan.FromTicks(_ticks);
            set => _ticks = value.Ticks;
        }

        public override string ToString()
            => TimeSpan.FromTicks(_ticks).ToString();

        public static SqlTimeSpan Parse(SqlString input)
        {
            bool isNull = TimeSpan.TryParse(input.Value, out TimeSpan ts) == false;
            return new SqlTimeSpan(ts, isNull);           
        }

        public bool IsNull
        {
            [SqlMethod(InvokeIfReceiverIsNull = true)]
            get;
            private set;
        }

        public static SqlTimeSpan Null
        {
            get
            {
                var udt = new SqlTimeSpan
                {
                    IsNull = true
                };
                return udt;
            }
        }

        #endregion

        #region Constructor and Factories

        // SQL-nullability and the fact that our type
        // is a struct necessitate this constructor
        internal SqlTimeSpan(TimeSpan ts, bool isNull)
        {
            IsNull = isNull;
            _ticks = ts.Ticks;

        }

        static public SqlTimeSpan CreateSqlTimeSpan(int days, int hours, int minutes, int seconds, int milliseconds)
        {
            var ts = new TimeSpan(days, hours, minutes, seconds, milliseconds);
            var tsUdt = new SqlTimeSpan(ts, false);
            return tsUdt;
        }

        public static SqlTimeSpan FromDays(double days)
            => new SqlTimeSpan(TimeSpan.FromDays(days), false);

        public static SqlTimeSpan FromHours(double hrs)
            => new SqlTimeSpan(TimeSpan.FromHours(hrs), false);

        public static SqlTimeSpan FromMilliseconds(double ms)
            => new SqlTimeSpan(TimeSpan.FromMilliseconds(ms), false);

        public static SqlTimeSpan FromMinutes(double mins)
            => new SqlTimeSpan(TimeSpan.FromMinutes(mins), false);

        public static SqlTimeSpan FromSeconds(double seconds)
            => new SqlTimeSpan(TimeSpan.FromSeconds(seconds), false);


        public static SqlTimeSpan FromTicks(long ticks)
            => new SqlTimeSpan(TimeSpan.FromTicks(ticks), false);

        #endregion

        #region Properties

        public TimeSpan GetSystemTimeSpan()
        {
            // We ensure this is called only outside SQL Server
            // because TimeSpan is not recognized there
            if (SqlContext.IsAvailable)
                throw new NotSupportedException("GetSystemTimeSpan is not supported inside SQL Server.");

            return SystemTimeSpan;
        }

        public int Days
        {
            get => SystemTimeSpan.Days;
        }

        public int Hours
        {
            get => SystemTimeSpan.Hours;
        }

        public int Milliseconds
        {
            get => SystemTimeSpan.Milliseconds;
        }

        public int Minutes
        {
            get => SystemTimeSpan.Minutes;
        }

        public int Seconds
        {
            get => SystemTimeSpan.Seconds;
        }

        public long Ticks
        {
            [SqlMethod(IsDeterministic = true)]
            get => SystemTimeSpan.Ticks;
        }

        public double TotalDays
        {
            [SqlMethod(IsDeterministic = true)]
            get => SystemTimeSpan.TotalDays;
        }

        public double TotalHours
        {
            [SqlMethod(IsDeterministic = true)]
            get => SystemTimeSpan.TotalHours;
        }

        public double TotalMilliseconds
        {
            [SqlMethod(IsDeterministic = true)]
            get => SystemTimeSpan.TotalMilliseconds;
        }

        public double TotalMinutes
        {
            [SqlMethod(IsDeterministic = true)]
            get => SystemTimeSpan.TotalMinutes;
        }

        public double TotalSeconds
        {
            [SqlMethod(IsDeterministic = true)]
            get => SystemTimeSpan.TotalSeconds;
        }

        static public SqlTimeSpan MaxValue
        {
            get => new SqlTimeSpan(TimeSpan.MaxValue, false);
        }

        static public SqlTimeSpan MinValue
        {
            get => new SqlTimeSpan(TimeSpan.MinValue, false);
        }

        static public SqlTimeSpan Zero
        {
            get => new SqlTimeSpan(TimeSpan.Zero, false);
        }

        static public long TicksPerDay
        {
            get => TimeSpan.TicksPerDay;
        }

        static public long TicksPerHour
        {
            get => TimeSpan.TicksPerHour;
        }

        static public long TicksPerMillisecond
        {
            get => TimeSpan.TicksPerMillisecond;
        }

        static public long TicksPerMinute
        {
            get => TimeSpan.TicksPerMinute;
        }

        static public long TicksPerSecond
        {
            get => TimeSpan.TicksPerSecond;
        }

        #endregion

        #region Methods and Operators

        [SqlMethod(IsMutator = true)]
        public void AddTS(SqlTimeSpan ts)
             => SystemTimeSpan += ts.SystemTimeSpan;
      
        public bool Equals(SqlTimeSpan ts)
            => SystemTimeSpan == ts.SystemTimeSpan;

        public SqlTimeSpan Duration()
            => new SqlTimeSpan(SystemTimeSpan.Duration(), false);

        [SqlMethod(IsMutator = true)]
        public void Negate()
            => SystemTimeSpan = SystemTimeSpan.Negate();

        public SqlTimeSpan GetNegated()
            => new SqlTimeSpan(SystemTimeSpan.Negate(), false);

        #endregion
    }
}

