using static SLackerSLab.SqlFunctions.SqlTimeSpanUdfs;
using Xunit;
using System;
using SLackerSLab.SqlTypes;
using System.Timers;

namespace SLackerSLab.Test
{
    public class SqlTimeSpanUdfsTest
    {
        [Fact]
        public void TSAddToDTTest()
        {
            var result = TSAddToDT(DateTime.Parse("1/1/2021 5:00 AM"), SqlTimeSpan.FromHours(1));
            Assert.Equal(DateTime.Parse("1/1/2021 6:00 AM"), result);
        }

        [Fact]
        public void TSDateDiffTest()
        {
            var result = TSDateDiff(DateTime.Parse("1/1/2021"), DateTime.Parse("1/2/2021 1:00 AM"));
            Assert.Equal(SqlTimeSpan.FromHours(25), result);
        }

        [Fact]
        public void TSAddToOffsetDTTest()
        {
            var result = TSAddToOffset(DateTimeOffset.Parse("1/1/2021 5:00 AM +0800"), SqlTimeSpan.FromHours(1));
            Assert.Equal(DateTime.Parse("1/1/2021 6:00 AM +0800"), result);
        }

        [Fact]
        public void TSDateDiffOffTest()
        {
            var result = TSDateDiffOffset(DateTimeOffset.Parse("1/1/2021 +0800"), DateTimeOffset.Parse("1/1/2021 1:00 AM +0600"));
            Assert.Equal(SqlTimeSpan.FromHours(3), result);
        }

        [Theory]
        [InlineData( "1:00:01", "1:00:02", "0:00:01", true)]
        [InlineData("1:00:01", "1:00:03", "0:00:01", false)]
        public void TSApproxEqualsTest(string timespan0, string timespan1, string timespanAllowedMargin, bool expected)
        {
            var ts0 = SqlTimeSpan.Parse(timespan0);
            var ts1 = SqlTimeSpan.Parse(timespan1);
            var tsAllowedMargin = SqlTimeSpan.Parse(timespanAllowedMargin);
            var result = TSApproxEquals(ts0, ts1, tsAllowedMargin);
            Assert.True(result == expected);            
        }
    }
}
