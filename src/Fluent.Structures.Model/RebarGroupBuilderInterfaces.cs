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

/// <summary>
/// Represents a Rebar Group construction state with a specified father object.
/// </summary>
public interface IRebarGroupWithFather
{
    /// <summary>
    /// Sets the polygons for the Rebar Group.
    /// </summary>
    /// <param name="polygons">ArrayList of polygons for the Rebar Group.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithPolygons Polygons(ArrayList polygons);

    /// <summary>
    /// Sets the polygons for the Rebar Group.
    /// </summary>
    /// <param name="polygons">Array of Tekla Polygons.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithPolygons Polygons(params TSM.Polygon[] polygons);

    /// <summary>
    /// Sets a single polygon for the Rebar Group using an array of Tekla Points.
    /// </summary>
    /// <param name="points">Array of Tekla Points representing the polygon.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithPolygons Polygons(params TSG.Point[] points);
}

/// <summary>
/// Represents a Rebar Group construction state with specified polygons.
/// </summary>
public interface IRebarGroupWithPolygons
{
    /// <summary>
    /// Sets the starting point for the Rebar Group.
    /// </summary>
    /// <param name="start">The starting point.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithStartPoint StartPoint(TSG.Point start);

    /// <summary>
    /// Sets the starting and ending points for the Rebar Group.
    /// </summary>
    /// <param name="start">The starting point.</param>
    /// <param name="end">The ending point.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithStartAndEndPoints StartAndEndPoints(TSG.Point start, TSG.Point end);
}

/// <summary>
/// Represents a Rebar Group construction state with a specified starting point.
/// </summary>
public interface IRebarGroupWithStartPoint
{
    /// <summary>
    /// Sets the ending point for the Rebar Group.
    /// </summary>
    /// <param name="end">The ending point.</param>
    /// <returns>An interface for further construction.</returns>
    public IRebarGroupWithStartAndEndPoints EndPoint(TSG.Point end);
}

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
    /// Builds and returns the finalized Rebar Group.
    /// </summary>
    /// <returns>The constructed Rebar Group.</returns>
    public RebarGroup Build();
}
