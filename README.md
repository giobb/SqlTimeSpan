# SqlTimeSpan
SqlTimeSpan is a SQL Server User-Defined Type (UDT) port of the .NET System.TimeSpan. It provides all the convenience of object-based types while maintaing compatibility
with the native temporal types like DateTime and DatetimeOffset. This project is originally from my CodeProject article [SqlTimeSpan](https://www.codeproject.com/Articles/38271/SqlTimeSpan). I encourage you to read that and the accompanying article [Vector: A Concept-Driven Approach to SQL UDT](https://www.codeproject.com/Articles/28626/Vector-A-Concept-Driven-Approach-to-SQL-UDT) to gain good understanding of this project and UDT respectively.

## Motiviation
SQL Server has no good construct for time span. One has to rely on the awkward function DATEPART to retrieve the different units of the time span. The solution is usually write a SQL function that converts the time span to a single unit, say seconds or minutes. SqlTimeSpan provides an alternative using UDT and object-based syntax. 
