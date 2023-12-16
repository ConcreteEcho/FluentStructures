namespace Fluent.Structures.Model;

/// <summary>
/// Represents an interface for starting the construction of a Rebar Group with the builder pattern.
/// </summary>
public interface IEmptyRebarGroup
{
    /// <summary>
    /// Sets the father object for the Rebar Group.
    /// </summary>
    /// <param name="father">The parent <see cref="TSM.ModelObject"/>.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithFather Father(TSM.ModelObject father);
}