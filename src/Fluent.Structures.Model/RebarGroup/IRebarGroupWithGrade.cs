namespace Fluent.Structures.Model;

/// <summary>
/// Represents a Rebar Group construction state with a specified grade.
/// </summary>
public interface IRebarGroupWithGrade
{
    /// <summary>
    /// Sets the size for the Rebar Group.
    /// </summary>
    /// <param name="size">The size of the rebar.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithSize Size(string size);
}