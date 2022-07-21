namespace Charting.Window.Core.Extensions;

public static class IEnumerableTupleExtension
{
    public static IEnumerable<(double, double)> ToIEnumerableTuple(this IEnumerable<Tuple<double, double>> points)
    {
        var newList = new List<(double, double)>();

        foreach (var point in points)
            newList.Add(point.ToValueTuple());

        return newList;
    }
}
