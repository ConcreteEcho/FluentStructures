namespace Fluent.Structures.Model;

/// <summary>
/// Represents a Rebar Group construction state with a specified father object.
/// </summary>
public interface IRebarGroupWithFather
{
    /// <summary>
    /// Sets the polygons for the Rebar Group.
    /// </summary>
    /// <param name="polygons">ArrayList of polygons for the Rebar Group.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithPolygons Polygons(ArrayList polygons);

    /// <summary>
    /// Sets the polygons for the Rebar Group.
    /// </summary>
    /// <param name="polygons">Array of Polygons.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithPolygons Polygons(params Polygon[] polygons);

    /// <summary>
    /// Sets the polygons for the Rebar Group.
    /// </summary>
    /// <param name="polygons">List of Polygons.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithPolygons Polygons(List<Polygon> polygons);

    /// <summary>
    /// Sets a single polygon for the Rebar Group using an array of Tekla Points.
    /// </summary>
    /// <param name="points">Array of Tekla Points representing the polygon.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithPolygons Polygons(params TSG.Point[] points);

    /// <summary>
    /// Sets a single polygon for the Rebar Group using an List of Tekla Points.
    /// </summary>
    /// <param name="points">List of Tekla Points representing the polygon.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithPolygons Polygons(List<TSG.Point> points);
}