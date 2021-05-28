using SLackerSLab.SqlTypes;
using SLackerSLab.Test.Extensions;
using System;
using Xunit;

namespace SLackerSLab.Test
{
    public class SqlTimeSpanTest
    {
        [Fact]
        public void InternalCtor_Must_Result_to_NotNull()
        {
            var target = new SqlTimeSpan(this.GetTimeSpan(), false);
            Assert.Equal(this.GetTimeSpan(), target.SystemTimeSpan);
            Assert.False(target.IsNull);
        }

        [Fact]
        public void ToStringTest()
        {
            var target = new SqlTimeSpan(this.GetTimeSpan(), false);
            Assert.Equal(this.GetTimeSpan().ToString(), target.ToString());
            Assert.False(target.IsNull);
        }

        [Fact]
        public void ParseTest()
        {
            var ts = new SqlTimeSpan(this.GetTimeSpan(), false);
            var target = SqlTimeSpan.Parse(ts.ToString());
            Assert.Equal(this.GetTimeSpan().ToString(), target.ToString());
            Assert.False(target.IsNull);
        }

        [Fact]
        public void SqlNullTest()
        {
            var target = SqlTimeSpan.Null;
            Assert.True(target.IsNull);
        }

        [Fact]
        public void CreateSqlTimeSpanTest()
        {
            var ts = this.GetTimeSpan();
            var target = SqlTimeSpan.CreateSqlTimeSpan(ts.Days, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Assert.Equal(ts, target.SystemTimeSpan);
        }

        [Fact]
        public void FromDaysTest()
        {
            var ts = TimeSpan.FromDays(2);
            var target = SqlTimeSpan.FromDays(ts.Days);
            Assert.Equal(ts, target.SystemTimeSpan);
        }

        [Fact]
        public void FromHoursTest()
        {
            var ts = TimeSpan.FromHours(2);
            var target = SqlTimeSpan.FromHours(ts.Hours);
            Assert.Equal(ts, target.SystemTimeSpan);
        }

        [Fact]
        public void FromMinutesTest()
        {
            var ts = TimeSpan.FromMinutes(2);
            var target = SqlTimeSpan.FromMinutes(ts.Minutes);
            Assert.Equal(ts, target.SystemTimeSpan);
        }

        [Fact]
        public void FromSecondsTest()
        {
            var ts = TimeSpan.FromSeconds(2);
            var target = SqlTimeSpan.FromSeconds(ts.Seconds);
            Assert.Equal(ts, target.SystemTimeSpan);
        }

        [Fact]
        public void FromMillisecondsTest()
        {
            var ts = TimeSpan.FromMilliseconds(2);
            var target = SqlTimeSpan.FromMilliseconds(ts.Milliseconds);
            Assert.Equal(ts, target.SystemTimeSpan);
        }

        [Fact]
        public void FromTicksTest()
        {
            var ts = TimeSpan.FromTicks(2000);
            var target = SqlTimeSpan.FromTicks(ts.Ticks);
            Assert.Equal(ts, target.SystemTimeSpan);
        }

        [Fact]
        public void GetSystemTimeSpan()
        {
            var target = new SqlTimeSpan(this.GetTimeSpan(), false);
            Assert.Equal(this.GetTimeSpan(), target.GetSystemTimeSpan());
        }

        [Fact]
        public void XxxTest()
        {
            var ts = this.GetTimeSpan();
            var target = new SqlTimeSpan(ts, false);
            Assert.Equal(ts.Days, target.Days);
            Assert.Equal(ts.Hours, target.Hours);
            Assert.Equal(ts.Minutes, target.Minutes);
            Assert.Equal(ts.Seconds, target.Seconds);
            Assert.Equal(ts.Milliseconds, target.Milliseconds);
        }

        [Fact]
        public void TotalXXXTests()
        {
            var ts = this.GetTimeSpan();
            var target = new SqlTimeSpan(ts, false);
            Assert.Equal(ts.TotalDays, target.TotalDays);
            Assert.Equal(ts.TotalHours, target.TotalHours);
            Assert.Equal(ts.TotalMinutes, target.TotalMinutes);
            Assert.Equal(ts.TotalSeconds, target.TotalSeconds);
            Assert.Equal(ts.TotalMilliseconds, target.TotalMilliseconds);
        }

        [Fact]
        public void TicksTests()
        {
            var ts = this.GetTimeSpan();
            var target = new SqlTimeSpan(ts, false);
            Assert.Equal(ts.Ticks, target.Ticks);
        }

        [Fact]
        public void TicksPerXxxTest()
        {
            Assert.Equal(TimeSpan.TicksPerDay, SqlTimeSpan.TicksPerDay);
            Assert.Equal(TimeSpan.TicksPerHour, SqlTimeSpan.TicksPerHour);
            Assert.Equal(TimeSpan.TicksPerMinute, SqlTimeSpan.TicksPerMinute);
            Assert.Equal(TimeSpan.TicksPerSecond, SqlTimeSpan.TicksPerSecond);
            Assert.Equal(TimeSpan.TicksPerMillisecond, SqlTimeSpan.TicksPerMillisecond);
            Assert.Equal(TimeSpan.TicksPerDay, SqlTimeSpan.TicksPerDay);
        }

        [Fact]
        public void OtherConstantTest()
        {
            Assert.Equal(TimeSpan.MinValue, SqlTimeSpan.MinValue.SystemTimeSpan);
            Assert.Equal(TimeSpan.MaxValue, SqlTimeSpan.MaxValue.SystemTimeSpan);
            Assert.Equal(TimeSpan.Zero, SqlTimeSpan.Zero.SystemTimeSpan);
            Assert.Equal(TimeSpan.MinValue, SqlTimeSpan.MinValue.SystemTimeSpan);
        }

        [Fact]
        public void AddTSTest()
        {
            var target = new SqlTimeSpan(this.GetTimeSpan(), false);
            var ts1 = new SqlTimeSpan(this.GetTimeSpan(), false);
            target.AddTS(ts1);
            Assert.Equal(this.GetTimeSpan() + this.GetTimeSpan(), target.SystemTimeSpan);
        }

        [Fact]
        public void EqualsTest()
        {
            var target = new SqlTimeSpan(this.GetTimeSpan(), false);
            var ts1 = new SqlTimeSpan(this.GetTimeSpan(), false);
            Assert.True(target.Equals(ts1));
        }

        [Fact]
        public void DurationTest()
        {
            var target = new SqlTimeSpan(this.GetTimeSpan(), false);
            Assert.Equal(this.GetTimeSpan().Duration(), target.Duration().SystemTimeSpan);
        }

        [Fact]
        public void NegateTest()
        {
            var target = new SqlTimeSpan(this.GetTimeSpan(), false);
            target.Negate();
            Assert.Equal(this.GetTimeSpan().Negate(), target.SystemTimeSpan);
        }

        [Fact]
        public void GetNegatedTest()
        {
            var target = new SqlTimeSpan(this.GetTimeSpan(), false);
            Assert.Equal(this.GetTimeSpan().Negate(), target.GetNegated().SystemTimeSpan);
        }
    }
}
