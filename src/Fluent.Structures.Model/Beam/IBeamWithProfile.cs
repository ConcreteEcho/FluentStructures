namespace Fluent.Structures.Model;

/// <summary>
/// Represents an interface for completing the configuration of a Tekla Structures Beam with the builder pattern.
/// </summary>
public interface IBeamWithProfile
{
    /// <summary>
    /// Specifies the material of the beam.
    /// </summary>
    /// <param name="material">The material of the beam.</param>
    /// <returns>An interface for further configuration.</returns>
    public ICompletedBeam Material(string material);
}