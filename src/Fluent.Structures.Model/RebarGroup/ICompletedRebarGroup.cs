namespace Fluent.Structures.Model;

/// <summary>
/// Represents a completed state for constructing a Tekla Structures Rebar Group.
/// </summary>
public interface ICompletedRebarGroup
{
    /// <summary>
    /// Sets the name for the Rebar Group.
    /// </summary>
    /// <param name="name">The name of the Rebar Group.</param>
    /// <returns>An interface for further construction.</returns>
    public ICompletedRebarGroup Name(string name);

    /// <summary>
    /// Sets the spacing type for the Rebar Group.
    /// </summary>
    /// <param name="spacingType">Spacing type for the Rebar Group.</param>
    /// <returns>An interface for further construction.</returns>
    public ICompletedRebarGroup SpacingType(
        TSM.BaseRebarGroup.RebarGroupSpacingTypeEnum spacingType);

    /// <summary>
    /// Sets the start offset from the reference plane for the Rebar Group.
    /// </summary>
    /// <param name="startFromPlaneOffset">Start offset from the reference plane.</param>
    /// <returns>An interface for further construction.</returns>
    public ICompletedRebarGroup StartFromPlaneOffset(double startFromPlaneOffset);

    /// <summary>
    /// Sets the end offset from the reference plane for the Rebar Group.
    /// </summary>
    /// <param name="endFromPlaneOffset">End offset from the reference plane.</param>
    /// <returns>An interface for further construction.</returns>
    public ICompletedRebarGroup EndFromPlaneOffset(double endFromPlaneOffset);

    /// <summary>
    /// Sets the numbering series for the Rebar Group.
    /// </summary>
    /// <param name="prefix">Prefix for the numbering series.</param>
    /// <param name="startNumber">Starting number for the numbering series.</param>
    /// <returns>An interface for further construction.</returns>
    public ICompletedRebarGroup NumberingSeries(string prefix, int startNumber);

    /// <summary>
    /// Sets the numbering series for the Rebar Group.
    /// </summary>
    /// <param name="numberingSeries">Numbering series.</param>
    /// <returns>An interface for further construction.</returns>
    public ICompletedRebarGroup NumberingSeries(TSM.NumberingSeries numberingSeries);

    /// <summary>
    /// Sets the start point offset value for the Rebar Group.
    /// </summary>
    /// <param name="startPointOffsetValue">Start point offset value.</param>
    /// <returns>An interface for further construction.</returns>
    public ICompletedRebarGroup StartPointOffsetValue(double startPointOffsetValue);

    /// <summary>
    /// Sets the end point offset value for the Rebar Group.
    /// </summary>
    /// <param name="endPointOffsetValue">End point offset value.</param>
    /// <returns>An interface for further construction.</returns>
    public ICompletedRebarGroup EndPointOffsetValue(double endPointOffsetValue);

    /// <summary>
    /// Sets the start point offset type for the Rebar Group.
    /// </summary>
    /// <param name="startPointOffsetType">Start point offset type.</param>
    /// <returns>An interface for further construction.</returns>
    public ICompletedRebarGroup StartPointOffsetType(
        TSM.Reinforcement.RebarOffsetTypeEnum startPointOffsetType);

    /// <summary>
    /// Sets the end point offset type for the Rebar Group.
    /// </summary>
    /// <param name="endPointOffsetType">End point offset type.</param>
    /// <returns>An interface for further construction.</returns>
    public ICompletedRebarGroup EndPointOffsetType(
        TSM.Reinforcement.RebarOffsetTypeEnum endPointOffsetType);

    /// <summary>
    /// Sets on-plane offsets for the Rebar Group.
    /// </summary>
    /// <param name="onPlaneOffsets">ArrayList of on-plane offsets.</param>
    /// <returns>An interface for further construction.</returns>
    public ICompletedRebarGroup OnPlaneOffsets(ArrayList onPlaneOffsets);

    /// <summary>
    /// Sets on-plane offsets for the Rebar Group.
    /// </summary>
    /// <param name="onPlaneOffsets">List of on-plane offsets.</param>
    /// <returns>An interface for further construction.</returns>
    public ICompletedRebarGroup OnPlaneOffsets(List<double> onPlaneOffsets);

    /// <summary>
    /// Sets on-plane offsets for the Rebar Group.
    /// </summary>
    /// <param name="onPlaneOffsets">Array of on-plane offsets.</param>
    /// <returns>An interface for further construction.</returns>
    public ICompletedRebarGroup OnPlaneOffsets(params double[] onPlaneOffsets);

    /// <summary>
    /// Sets the exclude type for the Rebar Group.
    /// </summary>
    /// <param name="excludeType">Exclude type.</param>
    /// <returns>An interface for further construction.</returns>
    public ICompletedRebarGroup ExcludeType(TSM.BaseRebarGroup.ExcludeTypeEnum excludeType);

    /// <summary>
    /// Sets the stirrup type for the Rebar Group.
    /// </summary>
    /// <param name="stirrupType">Stirrup type.</param>
    /// <returns>An interface for further construction.</returns>
    public ICompletedRebarGroup StirrupType(TSM.RebarGroup.RebarGroupStirrupTypeEnum stirrupType);

    /// <summary>
    /// Sets the identifier for the Rebar Group.
    /// </summary>
    /// <param name="identifier">Identifier for the Rebar Group.</param>
    /// <returns>An interface for further construction.</returns>
    public ICompletedRebarGroup Identifier(TS.Identifier identifier);

    /// <summary>
    /// Sets the input deforming state for the Rebar Group.
    /// </summary>
    /// <param name="deformingType">Deforming type for the Rebar Group.</param>
    /// <returns>An interface for further construction.</returns>
    public ICompletedRebarGroup InputPointDeformingState(
        Tekla.Structures.Forming.DeformingType deformingType);

    /// <summary>
    /// Builds and returns the finalized Rebar Group.
    /// </summary>
    /// <returns>The constructed Rebar Group.</returns>
    public RebarGroup Build();
}