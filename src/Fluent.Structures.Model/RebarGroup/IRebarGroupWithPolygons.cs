namespace Fluent.Structures.Model;

/// <summary>
/// Represents a Rebar Group construction state with specified polygons.
/// </summary>
public interface IRebarGroupWithPolygons
{
    /// <summary>
    /// Sets the starting point for the Rebar Group.
    /// </summary>
    /// <param name="start">The starting point.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithStartPoint StartPoint(TSG.Point start);

    /// <summary>
    /// Sets the starting and ending points for the Rebar Group.
    /// </summary>
    /// <param name="start">The starting point.</param>
    /// <param name="end">The ending point.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithStartAndEndPoints StartAndEndPoints(TSG.Point start, TSG.Point end);
}