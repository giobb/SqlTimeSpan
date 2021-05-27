using Microsoft.SqlServer.Server;
using SLackerSLab.SqlFunctions;
using SLackerSLab.SqlTypes;
using System;
using System.Diagnostics;

namespace SLackerSLab.SqlAggregates
{
    /// <summary>
    /// Aggregate function for SqlTimeSpan
    /// </summary>
    [Serializable]
    [SqlUserDefinedAggregate(Format.Native)]
    public struct SumTS
    {
        SqlTimeSpan _accumulatedTS;
        bool _isEmpty;

        public void Init()
        {
            _accumulatedTS = new SqlTimeSpan();
            _isEmpty = true;
        }

        public void Accumulate(SqlTimeSpan tsToAdd)
        {
            if (!tsToAdd.IsNull)
                _accumulatedTS.AddTS(tsToAdd);
            if (_isEmpty == true)
                _isEmpty = false;
        }

        public void Merge(SumTS group)
            => _accumulatedTS.AddTS(group.Terminate());


        public SqlTimeSpan Terminate()
        {
            SqlTimeSpan returnValue = SqlTimeSpan.Null;
            if (!_isEmpty)
                returnValue = _accumulatedTS;
            return returnValue;
        }
    }
}
