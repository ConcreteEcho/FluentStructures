namespace Fluent.Structures.Model;

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
    /// Specifies the position information for the beam.
    /// </summary>
    /// <param name="position">The position object containing information about the beam's location.</param>
    /// <returns>An interface for further configuration or finalizing the construction.</returns>
    public ICompletedBeam Position(TSM.Position position);

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
    /// <returns>An interface for further configuration or finalizing the construction.</returns>
    public ICompletedBeam CastUnitType(TSM.Part.CastUnitTypeEnum castUnitTypeEnum);

    /// <summary>
    /// Specifies the finish of the beam.
    /// </summary>
    /// <param name="finish">The finish of the beam.</param>
    /// <returns>An interface for further configuration or finalizing the construction.</returns>
    public ICompletedBeam Finish(string finish);

    /// <summary>
    /// Specifies the identifier for the beam.
    /// </summary>
    /// <param name="identifier">The identifier for the beam.</param>
    /// <returns>An interface for further configuration or finalizing the construction.</returns>
    public ICompletedBeam Identifier(TS.Identifier identifier);

    /// <summary>
    /// Specifies the deforming data for the beam.
    /// </summary>
    /// <param name="deformingData">The deforming data for the beam.</param>
    /// <returns>An interface for further configuration or finalizing the construction.</returns>
    public ICompletedBeam DeformingData(TSM.DeformingData deformingData);

    /// <summary>
    /// Specifies the pour phase for the beam.
    /// </summary>
    /// <param name="pourPhase">The pour phase for the beam.</param>
    /// <returns>An interface for further configuration or finalizing the construction.</returns>
    public ICompletedBeam PourPhase(int pourPhase);

    /// <summary>
    /// Specifies the start point offset for the beam.
    /// </summary>
    /// <param name="startPointOffset">The offset for the start point of the beam.</param>
    /// <returns>An interface for further configuration or finalizing the construction.</returns>
    public ICompletedBeam StartPointOffset(TSM.Offset startPointOffset);

    /// <summary>
    /// Specifies the end point offset for the beam.
    /// </summary>
    /// <param name="endPointOffset">The offset for the end point of the beam.</param>
    /// <returns>An interface for further configuration or finalizing the construction.</returns>
    public ICompletedBeam EndPointOffset(TSM.Offset endPointOffset);

    /// <summary>
    /// Finalizes the construction and returns the Beam object.
    /// </summary>
    /// <returns>The finalized Beam object.</returns>
    public Beam Build();
}