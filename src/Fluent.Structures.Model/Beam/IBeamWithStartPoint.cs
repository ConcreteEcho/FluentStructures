namespace Fluent.Structures.Model;

/// <summary>
/// Represents an interface for specifying the end point of a Tekla Structures Beam with the builder pattern.
/// </summary>
public interface IBeamWithStartPoint
{
    /// <summary>
    /// Specifies the ending point of the beam.
    /// </summary>
    /// <param name="endPoint">The ending point of the beam.</param>
    /// <returns>An interface for further configuration.</returns>
    public IBeamWithStartAndEndPoints EndPoint(TSG.Point endPoint);
}