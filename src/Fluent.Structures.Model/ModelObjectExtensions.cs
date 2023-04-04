namespace Fluent.Structures.Model;

public static class ModelObjectEnumeratorExtensions
{
    public static IEnumerable<TSM.ModelObject> GetEnumerable(this TSM.ModelObjectEnumerator? enumerator)
    {
        while (enumerator is not null && enumerator.MoveNext())
            if (enumerator.Current != null)
                yield return enumerator.Current;
    }

    public static string? GetAssemblyPos(this TSM.ModelObject? modelObject)
    {
        var s = string.Empty;
        modelObject?.GetReportProperty("ASSEMBLY_POS", ref s);
        return s;
    }

    public static string? GetPartPos(this TSM.ModelObject? modelObject)
    {
        var s = string.Empty;
        modelObject?.GetReportProperty("PART_POS", ref s);
        return s;
    }
}