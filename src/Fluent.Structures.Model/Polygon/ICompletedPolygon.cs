namespace Fluent.Structures.Model;

/// <summary>
/// Represents an interface for finalizing the construction of a Polygon with the builder pattern.
/// </summary>
public interface ICompletedPolygon
{
    /// <summary>
    /// Finalizes the construction and returns the Polygon object.
    /// </summary>
    /// <returns>The finalized Polygon object.</returns>
    public Polygon Build();
}