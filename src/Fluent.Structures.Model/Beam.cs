namespace Fluent.Structures.Model;

public sealed class Beam
{
    private readonly TSM.Beam _tsmBeam;

    private Beam(TSM.Beam.BeamTypeEnum beamTypeEnum = TSM.Beam.BeamTypeEnum.BEAM)
        => _tsmBeam = new TSM.Beam(beamTypeEnum);

    public TSM.Assembly GetAssembly()
        => _tsmBeam.GetAssembly();

    public TSM.Beam GetTSMBeam => _tsmBeam;

    public void Insert()
        => _tsmBeam.Insert();

    #region Builder
    public class BuildBeam : IEmptyBeam, IBeamWithStartPoint, IBeamWithStartAndEndPoints, IBeamWithProfile, ICompletedBeam
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
                StartPoint = new TSG.Point(0, 0),
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

        public ICompletedBeam RotationPosition(TSM.Position.RotationEnum rotationEnum, double rotationOffset)
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

    #region Properties
    public TSG.Point? StartPoint
    {
        get => _tsmBeam.StartPoint;
        private set => _tsmBeam.StartPoint = value;
    }

    public TSG.Point? EndPoint
    {
        get => _tsmBeam.EndPoint;
        private set => _tsmBeam.EndPoint = value;
    }

    public string? Profile
    {
        get => _tsmBeam.Profile.ProfileString;
        private set => _tsmBeam.Profile.ProfileString = value;
    }

    public string? Material
    {
        get => _tsmBeam.Material?.MaterialString;
        private set => _tsmBeam.Material.MaterialString = value;
    }

    public string? Name
    {
        get => _tsmBeam.Name;
        private set => _tsmBeam.Name = value;
    }

    public string? Class
    {
        get => _tsmBeam.Class;
        private set => _tsmBeam.Class = value;
    }

    public string? AssemblyPrefix
    {
        get => _tsmBeam.AssemblyNumber.Prefix;
        private set => _tsmBeam.AssemblyNumber.Prefix = value;
    }

    public int AssemblyStartNumber
    {
        get => _tsmBeam.AssemblyNumber!.StartNumber;
        private set => _tsmBeam.AssemblyNumber!.StartNumber = value;
    }

    public string? PartPrefix
    {
        get => _tsmBeam.PartNumber.Prefix;
        private set => _tsmBeam.PartNumber.Prefix = value;
    }

    public int PartStartNumber
    {
        get => _tsmBeam.PartNumber!.StartNumber;
        private set => _tsmBeam.PartNumber!.StartNumber = value;
    }

    public TSM.Position.DepthEnum DepthPosition
    {
        get => _tsmBeam.Position.Depth;
        private set => _tsmBeam.Position.Depth = value;
    }

    public double DepthOffest
    {
        get => _tsmBeam.Position!.DepthOffset;
        private set => _tsmBeam.Position!.DepthOffset = value;
    }

    public TSM.Position.PlaneEnum PlanePosition
    {
        get => _tsmBeam.Position.Plane;
        private set => _tsmBeam.Position.Plane = value;
    }

    public double PlaneOffset
    {
        get => _tsmBeam.Position.PlaneOffset;
        private set => _tsmBeam.Position.PlaneOffset = value;
    }

    public TSM.Position.RotationEnum RotationPosition
    {
        get => _tsmBeam.Position.Rotation;
        private set => _tsmBeam.Position.Rotation = value;
    }

    public double RotationOffset
    {
        get => _tsmBeam.Position.RotationOffset;
        private set => _tsmBeam.Position.RotationOffset = value;
    }
    #endregion
}