namespace Fluent.Structures.Model;

/// <summary>
/// Represents an interface for starting the construction of a Beam with the builder pattern.
/// </summary>
public interface IEmptyBeam
{
    /// <summary>
    /// Specifies the start and end points of the beam.
    /// </summary>
    /// <param name="startPoint">The starting point of the beam.</param>
    /// <param name="endPoint">The ending point of the beam.</param>
    /// <returns>An interface for further configuration.</returns>
    public IBeamWithStartAndEndPoints StartAndEndPoint(TSG.Point startPoint, TSG.Point endPoint);

    /// <summary>
    /// Specifies the starting point of the beam.
    /// </summary>
    /// <param name="startPoint">The starting point of the beam.</param>
    /// <returns>An interface for further configuration.</returns>
    public IBeamWithStartPoint StartPoint(TSG.Point startPoint);
}