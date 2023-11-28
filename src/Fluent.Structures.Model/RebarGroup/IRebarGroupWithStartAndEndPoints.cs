namespace Fluent.Structures.Model;

/// <summary>
/// Represents a Rebar Group construction state with specified starting and ending points.
/// </summary>
public interface IRebarGroupWithStartAndEndPoints
{
    /// <summary>
    /// Sets the grade for the Rebar Group.
    /// </summary>
    /// <param name="grade">The grade of the rebar.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithGrade Grade(string grade);
}