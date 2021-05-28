using System;

namespace SLackerSLab.Test.Extensions
{
    public static class TestExtensions
    {
        public static TimeSpan GetTimeSpan(this object o)
            => new TimeSpan(1, 2, 3, 4, 5);
    }
}
