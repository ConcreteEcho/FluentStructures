namespace Fluent.Structures.Model;

public sealed class Beam
{
    private Beam(TSM.Beam.BeamTypeEnum beamTypeEnum = TSM.Beam.BeamTypeEnum.BEAM)
        => TeklaBeam = new TSM.Beam(beamTypeEnum);

    public TSM.Assembly TeklaAssembly()
        => TeklaBeam.GetAssembly();

    public TSM.Beam TeklaBeam { get; }

    public bool Insert()
        => TeklaBeam.Insert();

    #region Builder

    public class BuildBeam : IEmptyBeam, IBeamWithStartPoint, IBeamWithStartAndEndPoints,
                             IBeamWithProfile, ICompletedBeam
    {
        private readonly Beam _beam = new();

        private BuildBeam() {}

        private BuildBeam(Beam beam)
            => _beam = beam;

        public static IEmptyBeam With()
            => new BuildBeam();

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

        public IBeamWithStartAndEndPoints StartAndEndPoint(TSG.Point startPoint, TSG.Point endPoint)
        {
            _beam.StartPoint = startPoint;
            _beam.EndPoint = endPoint;
            return this;
        }

        public IBeamWithStartPoint StartPoint(TSG.Point startPoint)
        {
            _beam.StartPoint = startPoint;
            return this;
        }

        public IBeamWithProfile Profile(string profile)
        {
            _beam.Profile = profile;
            return this;
        }

        public ICompletedBeam Material(string material)
        {
            _beam.Material = material;
            return this;
        }

        public ICompletedBeam Name(string name)
        {
            _beam.Name = name;
            return this;
        }

        public ICompletedBeam Class(string @class)
        {
            _beam.Class = @class;
            return this;
        }

        public ICompletedBeam AssemblyNumbering(string assemblyPrefix, int assemblyStartNumber)
        {
            _beam.AssemblyPrefix = assemblyPrefix;
            _beam.AssemblyStartNumber = assemblyStartNumber;
            return this;
        }

        public ICompletedBeam PartNumbering(string partPrefix, int partStartNumber)
        {
            _beam.PartPrefix = partPrefix;
            _beam.PartStartNumber = partStartNumber;
            return this;
        }

        public ICompletedBeam PlanePosition(TSM.Position.PlaneEnum planeEnum, double planeOffset)
        {
            _beam.PlanePosition = planeEnum;
            _beam.PlaneOffset = planeOffset;
            return this;
        }

        public ICompletedBeam DepthPosition(TSM.Position.DepthEnum depthEnum, double depthOffset)
        {
            _beam.DepthPosition = depthEnum;
            _beam.DepthOffest = depthOffset;
            return this;
        }

        public ICompletedBeam RotationPosition(TSM.Position.RotationEnum rotationEnum,
            double rotationOffset)
        {
            _beam.RotationPosition = rotationEnum;
            _beam.RotationOffset = rotationOffset;
            return this;
        }

        public Beam Build()
            => _beam;

        public IBeamWithStartAndEndPoints EndPoint(TSG.Point endPoint)
        {
            _beam.EndPoint = endPoint;
            return this;
        }
    }

    #endregion

    public static implicit operator TSM.Beam(Beam beam)
        => beam.TeklaBeam;

    #region Properties

    public TSG.Point? StartPoint
    {
        get => TeklaBeam.StartPoint;
        private set => TeklaBeam.StartPoint = value;
    }

    public TSG.Point? EndPoint
    {
        get => TeklaBeam.EndPoint;
        private set => TeklaBeam.EndPoint = value;
    }

    public string? Profile
    {
        get => TeklaBeam.Profile.ProfileString;
        private set => TeklaBeam.Profile.ProfileString = value;
    }

    public string? Material
    {
        get => TeklaBeam.Material?.MaterialString;
        private set => TeklaBeam.Material.MaterialString = value;
    }

    public string? Name
    {
        get => TeklaBeam.Name;
        private set => TeklaBeam.Name = value;
    }

    public string? Class
    {
        get => TeklaBeam.Class;
        private set => TeklaBeam.Class = value;
    }

    public string? AssemblyPrefix
    {
        get => TeklaBeam.AssemblyNumber.Prefix;
        private set => TeklaBeam.AssemblyNumber.Prefix = value;
    }

    public int AssemblyStartNumber
    {
        get => TeklaBeam.AssemblyNumber!.StartNumber;
        private set => TeklaBeam.AssemblyNumber!.StartNumber = value;
    }

    public string? PartPrefix
    {
        get => TeklaBeam.PartNumber.Prefix;
        private set => TeklaBeam.PartNumber.Prefix = value;
    }

    public int PartStartNumber
    {
        get => TeklaBeam.PartNumber!.StartNumber;
        private set => TeklaBeam.PartNumber!.StartNumber = value;
    }

    public TSM.Position.DepthEnum DepthPosition
    {
        get => TeklaBeam.Position.Depth;
        private set => TeklaBeam.Position.Depth = value;
    }

    public double DepthOffest
    {
        get => TeklaBeam.Position!.DepthOffset;
        private set => TeklaBeam.Position!.DepthOffset = value;
    }

    public TSM.Position.PlaneEnum PlanePosition
    {
        get => TeklaBeam.Position.Plane;
        private set => TeklaBeam.Position.Plane = value;
    }

    public double PlaneOffset
    {
        get => TeklaBeam.Position.PlaneOffset;
        private set => TeklaBeam.Position.PlaneOffset = value;
    }

    public TSM.Position.RotationEnum RotationPosition
    {
        get => TeklaBeam.Position.Rotation;
        private set => TeklaBeam.Position.Rotation = value;
    }

    public double RotationOffset
    {
        get => TeklaBeam.Position.RotationOffset;
        private set => TeklaBeam.Position.RotationOffset = value;
    }

    #endregion
}