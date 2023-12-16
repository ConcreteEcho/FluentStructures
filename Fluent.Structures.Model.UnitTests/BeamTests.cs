namespace Fluent.Structures.Model.UnitTests;

public class BeamTests
{
    private TSM.Beam _tekla = null!;

    private readonly TSG.Point _startPoint = new(1, 2, 3);
    private readonly TSG.Point _endPoint = new(4, 5, 6);
    private readonly TSM.Profile _profile = new() { ProfileString = "D567", };
    private readonly TSM.Material _material = new() { MaterialString = "C355", };
    private const string Class = "654321";
    private const string Name = "Beam name";
    private readonly TSM.NumberingSeries _partNumber = new("part", 101);
    private readonly TSM.NumberingSeries _assemblyNumber = new("assembly", 909);
    private const TSM.Part.CastUnitTypeEnum CastUnitType = TSM.Part.CastUnitTypeEnum.CAST_IN_PLACE;
    private const string Finish = "Painting";
    private readonly TS.Identifier _identifier = new(1234567);
    private const int PourPhase = 4567;

    private readonly TSM.Offset _startPointOffset = new()
    {
        Dx = 67,
        Dy = 73,
        Dz = 81,
    };

    private readonly TSM.Offset _endPointOffset = new()
    {
        Dx = 93,
        Dy = 97,
        Dz = 103,
    };

    private readonly TSM.DeformingData _deformingData = new()
    {
        Shortening = 14d,
        Cambering = 3.5d,
        Angle = 45d,
        Angle2 = 90d,
    };

    private readonly TSM.Position _position = new()
    {
        Depth = TSM.Position.DepthEnum.MIDDLE,
        DepthOffset = 12,
        Rotation = TSM.Position.RotationEnum.TOP,
        RotationOffset = 23,
        Plane = TSM.Position.PlaneEnum.RIGHT,
        PlaneOffset = 34,
    };

    [SetUp]
    public void SetupTeklaBeam()
        => _tekla = new TSM.Beam()
        {
            StartPoint = _startPoint,
            EndPoint = _endPoint,
            Profile = _profile,
            Material = _material,
            Class = Class,
            Name = Name,
            PartNumber = _partNumber,
            AssemblyNumber = _assemblyNumber,
            Position = _position,
            CastUnitType = CastUnitType,
            Finish = Finish,
            Identifier = _identifier,
            DeformingData = _deformingData,
            PourPhase = PourPhase,
            StartPointOffset = _startPointOffset,
            EndPointOffset = _endPointOffset,
        };

    [Test]
    public void Required_fluent_properties_equals_to_tekla_properties()
    {
        var fluent = GetDefaultFluentBeam().Build();

        fluent.StartPoint.Should().BeEquivalentTo(_tekla.StartPoint);
        fluent.EndPoint.Should().BeEquivalentTo(_tekla.EndPoint);
        fluent.Profile.Should().BeEquivalentTo(_tekla.Profile.ProfileString);
        fluent.Material.Should().BeEquivalentTo(_tekla.Material.MaterialString);
    }

    [Test]
    public void All_fluent_properties_equals_to_tekla_properties()
    {
        var fluent = GetDefaultFluentBeam()
           .Class(Class)
           .Name(Name)
           .PartNumbering(_partNumber.Prefix, _partNumber.StartNumber)
           .AssemblyNumbering(_assemblyNumber.Prefix, _assemblyNumber.StartNumber)
           .DepthPosition(_position.Depth, _position.DepthOffset)
           .PlanePosition(_position.Plane, _position.PlaneOffset)
           .RotationPosition(_position.Rotation, _position.RotationOffset)
           .CastUnitType(CastUnitType)
           .Finish(Finish)
           .Identifier(_identifier)
           .DeformingData(_deformingData)
           .PourPhase(PourPhase)
           .StartPointOffset(_startPointOffset)
           .EndPointOffset(_endPointOffset)
           .Build();

        fluent.Class.Should().BeEquivalentTo(_tekla.Class);
        fluent.Name.Should().BeEquivalentTo(_tekla.Name);
        fluent.PartPrefix.Should().BeEquivalentTo(_tekla.PartNumber.Prefix);
        fluent.PartStartNumber.Should().Be(_tekla.PartNumber.StartNumber);
        fluent.AssemblyPrefix.Should().BeEquivalentTo(_tekla.AssemblyNumber.Prefix);
        fluent.AssemblyStartNumber.Should().Be(_tekla.AssemblyNumber.StartNumber);
        fluent.DepthPosition.Should().Be(_tekla.Position.Depth);
        fluent.DepthOffset.Should().Be(_tekla.Position.DepthOffset);
        fluent.PlanePosition.Should().Be(_tekla.Position.Plane);
        fluent.PlaneOffset.Should().Be(_tekla.Position.PlaneOffset);
        fluent.RotationPosition.Should().Be(_tekla.Position.Rotation);
        fluent.RotationOffset.Should().Be(_tekla.Position.RotationOffset);
        fluent.CastUnitType.Should().Be(_tekla.CastUnitType);
        fluent.Finish.Should().BeEquivalentTo(_tekla.Finish);
        fluent.Identifier.Should().BeEquivalentTo(_tekla.Identifier);
        fluent.DeformingData.Should().BeEquivalentTo(_tekla.DeformingData);
        fluent.PourPhase.Should().Be(_tekla.PourPhase);
        fluent.StartPointOffset.Should().BeEquivalentTo(_tekla.StartPointOffset);
        fluent.EndPointOffset.Should().BeEquivalentTo(_tekla.EndPointOffset);
    }

    [Test]
    public void Fluent_default_beam_properties_is_set()
    {
        var fluent = Beam.BuildBeam.Default().Build();

        fluent.StartPoint.Should().NotBeNull();
        fluent.EndPoint.Should().NotBeNull();
        fluent.Profile.Should().NotBeNullOrEmpty();
        fluent.Material.Should().NotBeNullOrEmpty();
        fluent.Class.Should().NotBeNullOrEmpty();
    }

    private ICompletedBeam GetDefaultFluentBeam()
        => Beam.BuildBeam.With()
           .StartPoint(_startPoint)
           .EndPoint(_endPoint)
           .Profile(_profile.ProfileString)
           .Material(_material.MaterialString);
}