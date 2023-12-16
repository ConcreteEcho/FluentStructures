namespace Fluent.Structures.Model;

/// <summary>
/// Represents a Rebar Group construction state with a specified size.
/// </summary>
public interface IRebarGroupWithSize
{
    /// <summary>
    /// Sets the radius values for the Rebar Group.
    /// </summary>
    /// <param name="radiusValues">ArrayList of radius values.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithRadiusValues RadiusValues(ArrayList radiusValues);

    /// <summary>
    /// Sets the radius values for the Rebar Group using an array.
    /// </summary>
    /// <param name="radiusValues">Array of radius values.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithRadiusValues RadiusValues(params double[] radiusValues);

    /// <summary>
    /// Sets the radius values for the Rebar Group using a list.
    /// </summary>
    /// <param name="radiusValues">List of radius values.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithRadiusValues RadiusValues(List<double> radiusValues);
}