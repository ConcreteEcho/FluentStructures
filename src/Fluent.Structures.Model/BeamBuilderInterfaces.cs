namespace Fluent.Structures.Model;

/// <summary>
/// Represents an interface for starting the construction of a Beam with the builder pattern.
/// </summary>
public interface IEmptyBeam
{
    /// <summary>
    /// Specifies the start and end points of the beam.
    /// </summary>
    /// <param name="startPoint">The starting point of the beam.</param>
    /// <param name="endPoint">The ending point of the beam.</param>
    /// <returns>An interface for further configuration.</returns>
    public IBeamWithStartAndEndPoints StartAndEndPoint(TSG.Point startPoint, TSG.Point endPoint);

    /// <summary>
    /// Specifies the starting point of the beam.
    /// </summary>
    /// <param name="startPoint">The starting point of the beam.</param>
    /// <returns>An interface for further configuration.</returns>
    public IBeamWithStartPoint StartPoint(TSG.Point startPoint);
}

/// <summary>
/// Represents an interface for specifying the end point of a Tekla Structures Beam with the builder pattern.
/// </summary>
public interface IBeamWithStartPoint
{
    /// <summary>
    /// Specifies the ending point of the beam.
    /// </summary>
    /// <param name="endPoint">The ending point of the beam.</param>
    /// <returns>An interface for further configuration.</returns>
    public IBeamWithStartAndEndPoints EndPoint(TSG.Point endPoint);
}

/// <summary>
/// Represents an interface for specifying the profile of a Tekla Structures Beam with the builder pattern.
/// </summary>
public interface IBeamWithStartAndEndPoints
{
    /// <summary>
    /// Specifies the profile of the beam.
    /// </summary>
    /// <param name="profile">The profile of the beam.</param>
    /// <returns>An interface for further configuration.</returns>
    public IBeamWithProfile Profile(string profile);
}

/// <summary>
/// Represents an interface for completing the configuration of a Tekla Structures Beam with the builder pattern.
/// </summary>
public interface IBeamWithProfile
{
    /// <summary>
    /// Specifies the material of the beam.
    /// </summary>
    /// <param name="material">The material of the beam.</param>
    /// <returns>An interface for further configuration.</returns>
    public ICompletedBeam Material(string material);
}

/// <summary>
/// Represents an interface for finalizing the construction of a Beam with the builder pattern.
/// </summary>
public interface ICompletedBeam
{
    /// <summary>
    /// Specifies the name of the beam.
    /// </summary>
    /// <param name="name">The name of the beam.</param>
    /// <returns>An interface for further configuration or finalizing the construction.</returns>
    public ICompletedBeam Name(string name);

    /// <summary>
    /// Specifies the class of the beam.
    /// </summary>
    /// <param name="class">The class of the beam.</param>
    /// <returns>An interface for further configuration or finalizing the construction.</returns>
    public ICompletedBeam Class(string @class);

    /// <summary>
    /// Specifies the assembly numbering details for the beam.
    /// </summary>
    /// <param name="assemblyPrefix">The assembly prefix of the beam.</param>
    /// <param name="assemblyStartNumber">The starting number for assembly numbering.</param>
    /// <returns>An interface for further configuration or finalizing the construction.</returns>
    public ICompletedBeam AssemblyNumbering(string assemblyPrefix, int assemblyStartNumber);

    /// <summary>
    /// Specifies the part numbering details for the beam.
    /// </summary>
    /// <param name="partPrefix">The part prefix of the beam.</param>
    /// <param name="partStartNumber">The starting number for part numbering.</param>
    /// <returns>An interface for further configuration or finalizing the construction.</returns>
    public ICompletedBeam PartNumbering(string partPrefix, int partStartNumber);

    /// <summary>
    /// Specifies the position of the beam in the plane.
    /// </summary>
    /// <param name="planeEnum">The plane position enum.</param>
    /// <param name="planeOffset">The offset in the plane position.</param>
    /// <returns>An interface for further configuration or finalizing the construction.</returns>
    public ICompletedBeam PlanePosition(TSM.Position.PlaneEnum planeEnum, double planeOffset);

    /// <summary>
    /// Specifies the depth position of the beam.
    /// </summary>
    /// <param name="depthEnum">The depth position enum.</param>
    /// <param name="depthOffset">The offset in the depth position.</param>
    /// <returns>An interface for further configuration or finalizing the construction.</returns>
    public ICompletedBeam DepthPosition(TSM.Position.DepthEnum depthEnum, double depthOffset);

    /// <summary>
    /// Specifies the rotation position of the beam.
    /// </summary>
    /// <param name="rotationEnum">The rotation position enum.</param>
    /// <param name="rotationOffset">The offset in the rotation position.</param>
    /// <returns>An interface for further configuration or finalizing the construction.</returns>
    public ICompletedBeam RotationPosition(TSM.Position.RotationEnum rotationEnum,
        double rotationOffset);

    /// <summary>
    /// Specifies the cast unit type of the beam.
    /// </summary>
    /// <param name="castUnitTypeEnum">The cast unit type enum.</param>
    /// <returns>The finalized Tekla Structures Beam object.</returns>
    public ICompletedBeam CastUnitType(TSM.Part.CastUnitTypeEnum castUnitTypeEnum);

    /// <summary>
    /// Finalizes the construction and returns the Beam object.
    /// </summary>
    /// <returns>The finalized Beam object.</returns>
    public Beam Build();
}