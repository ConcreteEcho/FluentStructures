namespace Fluent.Structures.Model;

/// <summary>
/// Represents a Rebar Group construction state with a specified starting point.
/// </summary>
public interface IRebarGroupWithStartPoint
{
    /// <summary>
    /// Sets the ending point for the Rebar Group.
    /// </summary>
    /// <param name="end">The ending point.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithStartAndEndPoints EndPoint(TSG.Point end);
}