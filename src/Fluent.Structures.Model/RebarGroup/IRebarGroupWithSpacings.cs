namespace Fluent.Structures.Model;

/// <summary>
/// Represents a Rebar Group construction state with specified spacings.
/// </summary>
public interface IRebarGroupWithSpacings
{
    /// <summary>
    /// Sets the start hook for the Rebar Group.
    /// </summary>
    /// <param name="startHook">Rebar hook data for the start.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithStartHook StartHook(TSM.RebarHookData startHook);

    /// <summary>
    /// Sets the start hook for the Rebar Group using a predefined shape.
    /// </summary>
    /// <param name="shapeEnum">Predefined shape for the start hook.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithStartHook StartHook(
        TSM.RebarHookData.RebarHookShapeEnum shapeEnum =
            TSM.RebarHookData.RebarHookShapeEnum.NO_HOOK);

    /// <summary>
    /// Sets both start and end hooks for the Rebar Group.
    /// </summary>
    /// <param name="startHook">Rebar hook data for the start.</param>
    /// <param name="endHook">Rebar hook data for the end.</param>
    /// <returns>An interface for completing the construction.</returns>
    public ICompletedRebarGroup StartAndEndHooks(TSM.RebarHookData startHook,
        TSM.RebarHookData endHook);

    /// <summary>
    /// Sets both start and end hooks for the Rebar Group using predefined shapes.
    /// </summary>
    /// <param name="startShapeEnum">Predefined shape for the start hook.</param>
    /// <param name="endShapeEnum">Predefined shape for the end hook.</param>
    /// <returns>An interface for completing the construction.</returns>
    public ICompletedRebarGroup StartAndEndHooks(
        TSM.RebarHookData.RebarHookShapeEnum startShapeEnum =
            TSM.RebarHookData.RebarHookShapeEnum.NO_HOOK,
        TSM.RebarHookData.RebarHookShapeEnum endShapeEnum =
            TSM.RebarHookData.RebarHookShapeEnum.NO_HOOK);
}