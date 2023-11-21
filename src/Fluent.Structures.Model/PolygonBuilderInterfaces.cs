namespace Fluent.Structures.Model;

/// <summary>
/// Represents an interface for starting the construction of a Polygon with the builder pattern.
/// </summary>
public interface IEmptyPolygon
{
    /// <summary>
    /// Sets the points of the Polygon from an ArrayList.
    /// </summary>
    /// <param name="points">ArrayList of points to set.</param>
    public ICompletedPolygon Points(ArrayList points);

    /// <summary>
    /// Sets the points of the Polygon from a List of TSG.Points.
    /// </summary>
    /// <param name="points">List of points to set.</param>
    public ICompletedPolygon Points(List<TSG.Point> points);

    /// <summary>
    /// Sets the points of the Polygon from an array of TSG.Points.
    /// </summary>
    /// <param name="points">Array of points to set.</param>
    public ICompletedPolygon Points(params TSG.Point[] points);
}

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