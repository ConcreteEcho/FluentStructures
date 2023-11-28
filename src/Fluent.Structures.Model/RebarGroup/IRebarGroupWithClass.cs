namespace Fluent.Structures.Model;

/// <summary>
/// Represents a Rebar Group construction state with a specified class.
/// </summary>
public interface IRebarGroupWithClass
{
    /// <summary>
    /// Sets the spacings for the Rebar Group.
    /// </summary>
    /// <param name="spacings">ArrayList of spacings.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithSpacings Spacings(ArrayList spacings);

    /// <summary>
    /// Sets the spacings for the Rebar Group using an array.
    /// </summary>
    /// <param name="spacings">Array of spacings.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithSpacings Spacings(params double[] spacings);

    /// <summary>
    /// Sets the spacings for the Rebar Group using a list.
    /// </summary>
    /// <param name="spacings">List of spacings.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithSpacings Spacings(List<double> spacings);
}