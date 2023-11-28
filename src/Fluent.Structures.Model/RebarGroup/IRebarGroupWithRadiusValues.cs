namespace Fluent.Structures.Model;

/// <summary>
/// Represents a Rebar Group construction state with specified radius values.
/// </summary>
public interface IRebarGroupWithRadiusValues
{
    /// <summary>
    /// Sets the class for the Rebar Group.
    /// </summary>
    /// <param name="class">The class of the rebar.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithClass Class(int @class);
}