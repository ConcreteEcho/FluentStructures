namespace Fluent.Structures.Model;

/// <summary>
/// Represents a Rebar Group construction state with a specified start hook.
/// </summary>
public interface IRebarGroupWithStartHook
{
    /// <summary>
    /// Sets the end hook for the Rebar Group.
    /// </summary>
    /// <param name="endHook">Rebar hook data for the end.</param>
    /// <returns>An interface for completing the construction.</returns>
    public ICompletedRebarGroup EndHook(TSM.RebarHookData endHook);

    /// <summary>
    /// Sets the end hook for the Rebar Group using a predefined shape.
    /// </summary>
    /// <param name="endShapeEnum">Predefined shape for the end hook.</param>
    /// <returns>An interface for completing the construction.</returns>
    public ICompletedRebarGroup EndHook(
        TSM.RebarHookData.RebarHookShapeEnum endShapeEnum =
            TSM.RebarHookData.RebarHookShapeEnum.NO_HOOK);
}