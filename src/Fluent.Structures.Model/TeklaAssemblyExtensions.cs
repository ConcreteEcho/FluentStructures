namespace Fluent.Structures.Model;

public static class TeklaAssemblyExtensions
{
    public static IEnumerable<TSM.Part> GetAllParts(this TSM.Assembly? assembly)
    {
        var mainPart = assembly?.GetMainPart();
        var secondaries = assembly?.GetSecondaries();

        if (mainPart is TSM.Part part)
            yield return part;

        foreach (var secondary in secondaries)
            if (secondary is TSM.Part p)
                yield return p;
    }
}