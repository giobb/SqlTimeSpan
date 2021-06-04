using static SLackerSLab.SqlFunctions.SqlTimeSpanUdfs;
using Xunit;
using System;
using SLackerSLab.SqlTypes;

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
    }
}
