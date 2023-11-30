namespace Fluent.Structures.Model;

/// <summary>
/// Represents a beam in a Tekla Structures Model with fluent interface for construction.
/// </summary>
public sealed class Beam
{
    /// <summary>
    /// Initializes a new instance of the Beam class with an optional specific beam type.
    /// </summary>
    /// <param name="beamTypeEnum">The type of the beam to create.</param>
    private Beam(TSM.Beam.BeamTypeEnum beamTypeEnum = TSM.Beam.BeamTypeEnum.BEAM)
        => TeklaBeam = new TSM.Beam(beamTypeEnum);

    /// <summary>
    /// The underlying Tekla Structures Model beam object.
    /// </summary>
    public TSM.Beam TeklaBeam { get; }

    /// <summary>
    /// Inserts the beam into the Tekla Structures Model.
    /// </summary>
    /// <returns>True if the operation was successful, false otherwise.</returns>
    public bool Insert()
        => TeklaBeam.Insert();

    /// <summary>
    /// Deletes the beam from the Tekla Structures Model.
    /// </summary>
    /// <returns>True if the operation was successful, false otherwise.</returns>
    public bool Delete()
        => TeklaBeam.Delete();

    #region Builder

    /// <summary>
    /// Builder class for creating a Beam.
    /// Implements various interfaces for a fluent and type-safe construction process.
    /// </summary>
    public class BuildBeam : IEmptyBeam, IBeamWithStartPoint, IBeamWithStartAndEndPoints,
                             IBeamWithProfile, ICompletedBeam
    {
        private readonly Beam _beam = new();

        /// <summary>
        /// Private constructor to create an instance of the BuildBeam class.
        /// </summary>
        private BuildBeam() {}

        /// <summary>
        /// Private constructor to create an instance of the BuildBeam class with an existing beam.
        /// </summary>
        /// <param name="beam">An existing Beam instance to build upon.</param>
        private BuildBeam(Beam beam)
            => _beam = beam;

        /// <summary>
        /// Entry point to start configuring the Beam class
        /// </summary>
        /// <returns>An interface for starting the construction process.</returns>
        public static IEmptyBeam With()
            => new BuildBeam();

        /// <summary>
        /// Creates a new instance of the BuildBeam class with default values.
        /// </summary>
        /// <returns>An interface for completing the construction or further configuration.</returns>
        public static ICompletedBeam Default()
        {
            var defBeam = new Beam
            {
                StartPoint = new TSG.Point(0,  0),
                EndPoint = new TSG.Point(6000, 0),
                Profile = "D500",
                Material = "C245",
                Class = "0",
            };

            return new BuildBeam(defBeam);
        }

        /// <inheritdoc />
        public IBeamWithStartAndEndPoints StartAndEndPoint(TSG.Point startPoint, TSG.Point endPoint)
        {
            _beam.StartPoint = startPoint;
            _beam.EndPoint = endPoint;
            return this;
        }

        /// <inheritdoc />
        public IBeamWithStartPoint StartPoint(TSG.Point startPoint)
        {
            _beam.StartPoint = startPoint;
            return this;
        }

        /// <inheritdoc />
        public IBeamWithProfile Profile(string profile)
        {
            _beam.Profile = profile;
            return this;
        }

        /// <inheritdoc />
        public ICompletedBeam Material(string material)
        {
            _beam.Material = material;
            return this;
        }

        /// <inheritdoc />
        public ICompletedBeam Name(string name)
        {
            _beam.Name = name;
            return this;
        }

        /// <inheritdoc />
        public ICompletedBeam Class(string @class)
        {
            _beam.Class = @class;
            return this;
        }

        /// <inheritdoc />
        public ICompletedBeam AssemblyNumbering(string assemblyPrefix, int assemblyStartNumber)
        {
            _beam.AssemblyPrefix = assemblyPrefix;
            _beam.AssemblyStartNumber = assemblyStartNumber;
            return this;
        }

        /// <inheritdoc />
        public ICompletedBeam PartNumbering(string partPrefix, int partStartNumber)
        {
            _beam.PartPrefix = partPrefix;
            _beam.PartStartNumber = partStartNumber;
            return this;
        }

        /// <inheritdoc />
        public ICompletedBeam PlanePosition(TSM.Position.PlaneEnum planeEnum, double planeOffset)
        {
            _beam.PlanePosition = planeEnum;
            _beam.PlaneOffset = planeOffset;
            return this;
        }

        /// <inheritdoc />
        public ICompletedBeam DepthPosition(TSM.Position.DepthEnum depthEnum, double depthOffset)
        {
            _beam.DepthPosition = depthEnum;
            _beam.DepthOffset = depthOffset;
            return this;
        }

        /// <inheritdoc />
        public ICompletedBeam RotationPosition(TSM.Position.RotationEnum rotationEnum,
            double rotationOffset)
        {
            _beam.RotationPosition = rotationEnum;
            _beam.RotationOffset = rotationOffset;
            return this;
        }

        /// <inheritdoc />
        public ICompletedBeam CastUnitType(TSM.Part.CastUnitTypeEnum castUnitTypeEnum)
        {
            _beam.CastUnitTypeEnum = castUnitTypeEnum;
            return this;
        }

        /// <inheritdoc />
        public Beam Build()
            => _beam;

        /// <inheritdoc />
        public IBeamWithStartAndEndPoints EndPoint(TSG.Point endPoint)
        {
            _beam.EndPoint = endPoint;
            return this;
        }
    }

    #endregion

    /// <summary>
    /// Allows for implicit conversion of a Beam object to a Tekla Beam object.
    /// </summary>
    /// <param name="beam">The Beam object to convert.</param>
    /// <returns>The Beam object from Tekla API.</returns>
    public static implicit operator TSM.Beam(Beam beam)
        => beam.TeklaBeam;

    /// <summary>
    /// Implicitly converts a <see cref="Beam"/> object to a <see cref="TSM.ModelObject"/>.
    /// </summary>
    /// <param name="beam">The <see cref="Beam"/> object to convert.</param>
    /// <returns>
    /// The Tekla Structures ModelObject corresponding to the provided <see cref="Beam"/> object.
    /// </returns>
    /// <remarks>
    /// This conversion allows seamless interoperability with Tekla Structures API, treating a <see cref="Beam"/>
    /// as its underlying Tekla Structures ModelObject. Use this conversion when direct interaction with the
    /// Tekla Structures API is required.
    /// </remarks>
    public static implicit operator TSM.ModelObject(Beam beam)
        => beam.TeklaBeam;

    #region Properties

    /// <summary>
    /// Gets or sets the starting point of the Tekla Structures Beam.
    /// </summary>
    /// <remarks>
    /// The starting point is represented as a <see cref="TSG.Point"/> object, which defines the
    /// coordinates (X, Y, Z) of the beginning of the beam in the Tekla Structures model.
    /// </remarks>
    public TSG.Point? StartPoint
    {
        get => TeklaBeam.StartPoint;
        private set => TeklaBeam.StartPoint = value;
    }

    /// <summary>
    /// Gets or sets the ending point of the Tekla Structures Beam.
    /// </summary>
    /// <remarks>
    /// The ending point is represented as a <see cref="TSG.Point"/> object, which defines the
    /// coordinates (X, Y, Z) of the end of the beam in the Tekla Structures model.
    /// </remarks>
    public TSG.Point? EndPoint
    {
        get => TeklaBeam.EndPoint;
        private set => TeklaBeam.EndPoint = value;
    }

    /// <summary>
    /// Gets or sets the profile of the Tekla Structures Beam.
    /// </summary>
    /// <remarks>
    /// The profile is a string representation of the cross-sectional shape and size of the beam.
    /// </remarks>
    public string? Profile
    {
        get => TeklaBeam.Profile.ProfileString;
        private set => TeklaBeam.Profile.ProfileString = value;
    }

    /// <summary>
    /// Gets or sets the material of the Tekla Structures Beam.
    /// </summary>
    /// <remarks>
    /// The material is represented as a string describing the type of material used for the beam.
    /// </remarks>
    public string? Material
    {
        get => TeklaBeam.Material?.MaterialString;
        private set => TeklaBeam.Material.MaterialString = value;
    }

    /// <summary>
    /// Gets or sets the name of the Tekla Structures Beam.
    /// </summary>
    /// <remarks>
    /// The name is a string identifier for the beam in the Tekla Structures model.
    /// </remarks>
    public string? Name
    {
        get => TeklaBeam.Name;
        private set => TeklaBeam.Name = value;
    }

    /// <summary>
    /// Gets or sets the class of the Tekla Structures Beam.
    /// </summary>
    /// <remarks>
    /// The class is a string indicating the class of the beam.
    /// </remarks>
    public string? Class
    {
        get => TeklaBeam.Class;
        private set => TeklaBeam.Class = value;
    }

    /// <summary>
    /// Gets or sets the assembly prefix of the Tekla Structures Beam.
    /// </summary>
    /// <remarks>
    /// The assembly prefix is a string used for assembly numbering to group related components together.
    /// </remarks>
    public string? AssemblyPrefix
    {
        get => TeklaBeam.AssemblyNumber.Prefix;
        private set => TeklaBeam.AssemblyNumber.Prefix = value;
    }

    /// <summary>
    /// Gets or sets the starting number for assembly numbering of the Tekla Structures Beam.
    /// </summary>
    /// <remarks>
    /// Assembly numbering is used to uniquely identify and organize groups of related components in the model.
    /// </remarks>
    public int AssemblyStartNumber
    {
        get => TeklaBeam.AssemblyNumber!.StartNumber;
        private set => TeklaBeam.AssemblyNumber!.StartNumber = value;
    }

    /// <summary>
    /// Gets or sets the part prefix of the Tekla Structures Beam.
    /// </summary>
    /// <remarks>
    /// The part prefix is a string used for part numbering to group related components together.
    /// </remarks>
    public string? PartPrefix
    {
        get => TeklaBeam.PartNumber.Prefix;
        private set => TeklaBeam.PartNumber.Prefix = value;
    }

    /// <summary>
    /// Gets or sets the starting number for part numbering of the Tekla Structures Beam.
    /// </summary>
    /// <remarks>
    /// Part numbering is used to uniquely identify and organize individual components in the model.
    /// </remarks>
    public int PartStartNumber
    {
        get => TeklaBeam.PartNumber!.StartNumber;
        private set => TeklaBeam.PartNumber!.StartNumber = value;
    }

    /// <summary>
    /// Gets or sets the depth position of the Tekla Structures Beam.
    /// </summary>
    /// <remarks>
    /// The depth position is represented by an enum indicating the orientation of the beam in the model.
    /// </remarks>
    public TSM.Position.DepthEnum DepthPosition
    {
        get => TeklaBeam.Position.Depth;
        private set => TeklaBeam.Position.Depth = value;
    }

    /// <summary>
    /// Gets or sets the depth offset of the Tekla Structures Beam.
    /// </summary>
    /// <remarks>
    /// The depth offset is a numerical value representing the distance of the beam in the depth position.
    /// </remarks>
    public double DepthOffset
    {
        get => TeklaBeam.Position!.DepthOffset;
        private set => TeklaBeam.Position!.DepthOffset = value;
    }

    /// <summary>
    /// Gets or sets the plane position of the Tekla Structures Beam.
    /// </summary>
    /// <remarks>
    /// The plane position is represented by an enum indicating the orientation of the beam in the model.
    /// </remarks>
    public TSM.Position.PlaneEnum PlanePosition
    {
        get => TeklaBeam.Position.Plane;
        private set => TeklaBeam.Position.Plane = value;
    }

    /// <summary>
    /// Gets or sets the plane offset of the Tekla Structures Beam.
    /// </summary>
    /// <remarks>
    /// The plane offset is a numerical value representing the distance of the beam in the plane position.
    /// </remarks>
    public double PlaneOffset
    {
        get => TeklaBeam.Position.PlaneOffset;
        private set => TeklaBeam.Position.PlaneOffset = value;
    }

    /// <summary>
    /// Gets or sets the rotation position of the Tekla Structures Beam.
    /// </summary>
    /// <remarks>
    /// The rotation position is represented by an enum indicating the orientation of the beam in the model.
    /// </remarks>
    public TSM.Position.RotationEnum RotationPosition
    {
        get => TeklaBeam.Position.Rotation;
        private set => TeklaBeam.Position.Rotation = value;
    }

    /// <summary>
    /// Gets or sets the rotation offset of the Tekla Structures Beam.
    /// </summary>
    /// <remarks>
    /// The rotation offset is a numerical value representing the rotation angle of the beam.
    /// </remarks>
    public double RotationOffset
    {
        get => TeklaBeam.Position.RotationOffset;
        private set => TeklaBeam.Position.RotationOffset = value;
    }

    /// <summary>
    /// Gets or sets the cast unit type of the Tekla Structures Beam.
    /// </summary>
    /// <remarks>
    /// The cast unit type is an enum representing the type of casting unit for the beam.
    /// </remarks>
    public TSM.Part.CastUnitTypeEnum CastUnitTypeEnum
    {
        get => TeklaBeam.CastUnitType;
        private set => TeklaBeam.CastUnitType = value;
    }

    #endregion
}