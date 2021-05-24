using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

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
            _accumulatedTS = SqlTimeSpan.Add(_accumulatedTS, tsToAdd);
        if (_isEmpty == true)
            _isEmpty = false;
    }

    public void Merge(SumTS group)
    {
        _accumulatedTS = SqlTimeSpan.Add(_accumulatedTS, group.Terminate());
    }

    public SqlTimeSpan Terminate()
    {
        SqlTimeSpan returnValue = SqlTimeSpan.Null;
        if (!_isEmpty)
            returnValue = _accumulatedTS;
        return returnValue;
    }   
}

