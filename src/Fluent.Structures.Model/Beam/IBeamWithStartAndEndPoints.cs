namespace Fluent.Structures.Model;

/// <summary>
/// Represents an interface for specifying the profile of a Tekla Structures Beam with the builder pattern.
/// </summary>
public interface IBeamWithStartAndEndPoints
{
    /// <summary>
    /// Specifies the profile of the beam.
    /// </summary>
    /// <param name="profile">The profile of the beam.</param>
    /// <returns>An interface for further configuration.</returns>
    public IBeamWithProfile Profile(string profile);
}