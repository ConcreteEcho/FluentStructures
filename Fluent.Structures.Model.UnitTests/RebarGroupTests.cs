namespace Fluent.Structures.Model.UnitTests;

public class RebarGroupTests
{
    private readonly TSM.ModelObject _father = new TSM.Beam(TSM.Beam.BeamTypeEnum.BEAM);

    private readonly ArrayList _polygons = new()
    {
        new TSM.Polygon
        {
            Points = new ArrayList
            {
                new TSG.Point(-100, 0), new TSG.Point(100, 0), new TSG.Point(100, 200),
                new TSG.Point(-100, 200),
            },
        },
    };

    private readonly TSG.Point _startPoint = new(1, 2, 3);

    private readonly TSG.Point _endPoint = new(123, 456, 789);

    private const string Grade = "A500C";
    private const string Size = "25";

    private readonly ArrayList _radiusValues = new() { 80d, };

    private const int Class = 123456;

    private readonly ArrayList _spacings = new() { 100d, 150d, 200d, 250d, 300d, };

    private readonly TSM.RebarHookData _startHook = new()
    {
        Shape = TSM.RebarHookData.RebarHookShapeEnum.CUSTOM_HOOK, Angle = 35d, Length = 123d,
        Radius = 80d,
    };

    private readonly TSM.RebarHookData _endHook = new()
    {
        Shape = TSM.RebarHookData.RebarHookShapeEnum.NO_HOOK,
    };

    private readonly TSM.NumberingSeries _numberingSeries = new("prefix", 666);

    private const TSM.BaseRebarGroup.RebarGroupSpacingTypeEnum SpacingType =
        TSM.BaseRebarGroup.RebarGroupSpacingTypeEnum.SPACING_TYPE_EXACT_SPACINGS;

    private const double StartPointOffsetValue = 11;
    private const double EndPointOffsetValue = 22;
    private const double StartFromPlaneOffset = 33;
    private const double EndFromPlaneOffset = 44;

    private const string Name = "rebar group name";

    private const TSM.Reinforcement.RebarOffsetTypeEnum StartPointOffsetType =
        TSM.Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_LEG_LENGTH;

    private const TSM.Reinforcement.RebarOffsetTypeEnum EndPointOffsetType =
        TSM.Reinforcement.RebarOffsetTypeEnum.OFFSET_TYPE_COVER_THICKNESS;

    private readonly ArrayList _onPlaneOffsets = new() { 15d, 16d, 17d, 18d, };

    private const TSM.BaseRebarGroup.ExcludeTypeEnum ExcludeType =
        TSM.BaseRebarGroup.ExcludeTypeEnum.EXCLUDE_TYPE_BOTH;

    private const TSM.RebarGroup.RebarGroupStirrupTypeEnum StirrupType =
        TSM.RebarGroup.RebarGroupStirrupTypeEnum.STIRRUP_TYPE_POLYGONAL;

    private const Tekla.Structures.Forming.DeformingType InputPointDeformingType =
        Tekla.Structures.Forming.DeformingType.UNDEFORMED;

    private readonly TS.Identifier _identifier = new() { ID = 98765432, };

    private TSM.RebarGroup _tekla = null!;

    [SetUp]
    public void SetupTeklaRebarGroup()
        => _tekla = new TSM.RebarGroup()
        {
            Father = _father,
            Polygons = _polygons,
            StartPoint = _startPoint,
            EndPoint = _endPoint,
            Grade = Grade,
            Size = Size,
            RadiusValues = _radiusValues,
            Class = Class,
            Spacings = _spacings,
            StartHook = _startHook,
            EndHook = _endHook,
            NumberingSeries = _numberingSeries,
            SpacingType = SpacingType,
            StartPointOffsetValue = StartPointOffsetValue,
            EndPointOffsetValue = EndPointOffsetValue,
            StartFromPlaneOffset = StartFromPlaneOffset,
            EndFromPlaneOffset = EndFromPlaneOffset,
            Name = Name,
            StartPointOffsetType = StartPointOffsetType,
            EndPointOffsetType = EndPointOffsetType,
            OnPlaneOffsets = _onPlaneOffsets,
            ExcludeType = ExcludeType,
            StirrupType = StirrupType,
            Identifier = _identifier,
            InputPointDeformingState = InputPointDeformingType,
        };

    [Test]
    public void Required_fluent_properties_equals_to_tekla_properties()
    {
        var fluent = GetDefaultFluentRebarGroup().Build();

        fluent.Father.Should().BeEquivalentTo(_tekla.Father);
        fluent.Polygons.Should().BeEquivalentTo(_tekla.Polygons.Cast<TSM.Polygon>());
        fluent.StartPoint.Should().BeEquivalentTo(_tekla.StartPoint);
        fluent.EndPoint.Should().BeEquivalentTo(_tekla.EndPoint);
        fluent.Grade.Should().BeEquivalentTo(_tekla.Grade);
        fluent.Size.Should().BeEquivalentTo(_tekla.Size);
        fluent.RadiusValues.Should().BeEquivalentTo(_tekla.RadiusValues.Cast<double>());
        fluent.Class.Should().Be(_tekla.Class);
        fluent.Spacings.Should().BeEquivalentTo(_tekla.Spacings.Cast<double>());
        fluent.StartHook.Should().BeEquivalentTo(_tekla.StartHook);
        fluent.EndHook.Should().BeEquivalentTo(_tekla.EndHook);
    }

    [Test]
    public void Fluent_numbering_equals_to_tekla_numbering()
    {
        var incompleteRebarGroup = GetDefaultFluentRebarGroup();
        incompleteRebarGroup.NumberingSeries(_numberingSeries.Prefix, _numberingSeries.StartNumber);
        var fluent = incompleteRebarGroup.Build();

        fluent.NumberingSeries.Should().BeEquivalentTo(_tekla.NumberingSeries);
    }

    [Test]
    public void Fluent_Spacing_type_equals_to_tekla_spacing_type()
    {
        var incompleteRebarGroup = GetDefaultFluentRebarGroup();
        incompleteRebarGroup.SpacingType(SpacingType);
        var fluent = incompleteRebarGroup.Build();

        fluent.SpacingType.Should().Be(_tekla.SpacingType);
    }

    [Test]
    public void Fluent_start_point_offset_value_equals_to_tekla_value()
    {
        var incompleteRebarGroup = GetDefaultFluentRebarGroup();
        incompleteRebarGroup.StartPointOffsetValue(StartPointOffsetValue);
        var fluent = incompleteRebarGroup.Build();

        fluent.StartPointOffsetValue.Should().Be(_tekla.StartPointOffsetValue);
    }

    [Test]
    public void Fluent_end_point_offset_value_equals_to_tekla_value()
    {
        var incompleteRebarGroup = GetDefaultFluentRebarGroup();
        incompleteRebarGroup.EndPointOffsetValue(EndPointOffsetValue);
        var fluent = incompleteRebarGroup.Build();

        fluent.EndPointOffsetValue.Should().Be(_tekla.EndPointOffsetValue);
    }

    [Test]
    public void Fluent_start_from_plane_offset_equals_to_tekla_offset()
    {
        var incompleteRebarGroup = GetDefaultFluentRebarGroup();
        incompleteRebarGroup.StartFromPlaneOffset(StartFromPlaneOffset);
        var fluent = incompleteRebarGroup.Build();

        fluent.StartFromPlaneOffset.Should().Be(_tekla.StartFromPlaneOffset);
    }

    [Test]
    public void Fluent_end_from_plane_offset_equals_to_tekla_offset()
    {
        var incompleteRebarGroup = GetDefaultFluentRebarGroup();
        incompleteRebarGroup.EndFromPlaneOffset(EndFromPlaneOffset);
        var fluent = incompleteRebarGroup.Build();

        fluent.EndFromPlaneOffset.Should().Be(_tekla.EndFromPlaneOffset);
    }

    [Test]
    public void Fluent_name_equals_to_tekla_name()
    {
        var incompleteRebarGroup = GetDefaultFluentRebarGroup();
        incompleteRebarGroup.Name(Name);
        var fluent = incompleteRebarGroup.Build();

        fluent.Name.Should().BeEquivalentTo(_tekla.Name);
    }

    [Test]
    public void Fluent_start_point_offset_type_equals_tekla_type()
    {
        var incompleteRebarGroup = GetDefaultFluentRebarGroup();
        incompleteRebarGroup.StartPointOffsetType(StartPointOffsetType);
        var fluent = incompleteRebarGroup.Build();

        fluent.StartPointOffsetType.Should().Be(_tekla.StartPointOffsetType);
    }

    [Test]
    public void Fluent_end_point_offset_type_equals_tekla_type()
    {
        var incompleteRebarGroup = GetDefaultFluentRebarGroup();
        incompleteRebarGroup.EndPointOffsetType(EndPointOffsetType);
        var fluent = incompleteRebarGroup.Build();

        fluent.EndPointOffsetType.Should().Be(_tekla.EndPointOffsetType);
    }

    [Test]
    public void Fluent_on_plane_offsets_equals_tekla_offsets()
    {
        var incompleteRebarGroup = GetDefaultFluentRebarGroup();
        incompleteRebarGroup.OnPlaneOffsets(_onPlaneOffsets);
        var fluent = incompleteRebarGroup.Build();

        fluent.OnPlaneOffsets.Should().BeEquivalentTo(_tekla.OnPlaneOffsets.Cast<double>());
    }

    [Test]
    public void Fluent_exclude_type_equals_tekla_type()
    {
        var incompleteRebarGroup = GetDefaultFluentRebarGroup();
        incompleteRebarGroup.ExcludeType(ExcludeType);
        var fluent = incompleteRebarGroup.Build();

        fluent.ExcludeType.Should().Be(_tekla.ExcludeType);
    }

    [Test]
    public void Fluent_stirrup_type_equals_tekla_type()
    {
        var incompleteRebarGroup = GetDefaultFluentRebarGroup();
        incompleteRebarGroup.StirrupType(StirrupType);
        var fluent = incompleteRebarGroup.Build();

        fluent.StirrupType.Should().Be(_tekla.StirrupType);
    }

    [Test]
    public void Fluent_identifier_equals_tekla_identifier()
    {
        var incompleteRebarGroup = GetDefaultFluentRebarGroup();
        incompleteRebarGroup.Identifier(_identifier);
        var fluent = incompleteRebarGroup.Build();

        fluent.Identifier.Should().BeEquivalentTo(_tekla.Identifier);
    }

    [Test]
    public void Fluent_input_point_deforming_type_equals_tekla_type()
    {
        var incompleteRebarGroup = GetDefaultFluentRebarGroup();
        incompleteRebarGroup.InputPointDeformingState(InputPointDeformingType);
        var fluent = incompleteRebarGroup.Build();

        fluent.InputPointDeformingState.Should().Be(_tekla.InputPointDeformingState);
    }

    [Test]
    public void Fluent_radius_values_equals_tekla_values()
    {
        var incompleteRebarGroup = RebarGroup.BuildRebarGroup.With()
           .Father(_father)
           .Polygons(_polygons)
           .StartPoint(_startPoint)
           .EndPoint(_endPoint)
           .Grade(Grade)
           .Size(Size);

        var arrayRadiuses = incompleteRebarGroup.RadiusValues(
            (double)(_radiusValues[0] ?? throw new InvalidOperationException())
        );
        var listRadiuses =
            incompleteRebarGroup.RadiusValues(new List<double>(_radiusValues.Cast<double>()));

        var arrayRebarGroup = arrayRadiuses.Class(Class)
           .Spacings(_spacings)
           .StartHook(_startHook)
           .EndHook(_endHook)
           .Build();

        var listRebarGroup = listRadiuses.Class(Class)
           .Spacings(_spacings)
           .StartHook(_startHook)
           .EndHook(_endHook)
           .Build();

        arrayRebarGroup.RadiusValues.Should().BeEquivalentTo(_tekla.RadiusValues.Cast<double>());
        listRebarGroup.RadiusValues.Should().BeEquivalentTo(_tekla.RadiusValues.Cast<double>());
    }

    [Test]
    public void Fluent_polygons_from_point_array_equals_tekla_polygons()
    {
        var incompleteRebarGroup = RebarGroup.BuildRebarGroup.With()
           .Father(_father);

        var pointsArrayPolygon = incompleteRebarGroup.Polygons(
            (_polygons[0] as TSM.Polygon)?.Points?.Cast<TSG.Point>().ToArray()
            ?? throw new ArgumentNullException()
        );

        var pointsArrayRebarGroup = pointsArrayPolygon.StartPoint(_startPoint)
           .EndPoint(_endPoint)
           .Grade(Grade)
           .Size(Size)
           .RadiusValues(_radiusValues)
           .Class(Class)
           .Spacings(_spacings)
           .StartHook(_startHook)
           .EndHook(_endHook)
           .Build();

        pointsArrayRebarGroup.Polygons.Should().BeEquivalentTo(_tekla.Polygons.Cast<TSM.Polygon>());
    }

    [Test]
    public void Fluent_polygons_from_polygon_array_equals_tekla_polygons()
    {
        var incompleteRebarGroup = RebarGroup.BuildRebarGroup.With()
           .Father(_father);

        var polygonsArrayPolygon = incompleteRebarGroup.Polygons(
            _polygons[0] as TSM.Polygon ?? throw new ArgumentNullException()
        );

        var polygonsArrayRebarGroup = polygonsArrayPolygon.StartPoint(_startPoint)
           .EndPoint(_endPoint)
           .Grade(Grade)
           .Size(Size)
           .RadiusValues(_radiusValues)
           .Class(Class)
           .Spacings(_spacings)
           .StartHook(_startHook)
           .EndHook(_endHook)
           .Build();

        polygonsArrayRebarGroup.Polygons.Should()
           .BeEquivalentTo(_tekla.Polygons.Cast<TSM.Polygon>());
    }

    [Test]
    public void Fluent_polygons_from_point_list_equals_tekla_polygons()
    {
        var incompleteRebarGroup = RebarGroup.BuildRebarGroup.With()
           .Father(_father);

        var pointsListPolygon = incompleteRebarGroup.Polygons(
            (_polygons[0] as TSM.Polygon)?.Points?.Cast<TSG.Point>().ToList()
            ?? throw new ArgumentNullException()
        );

        var pointsListRebarGroup = pointsListPolygon.StartPoint(_startPoint)
           .EndPoint(_endPoint)
           .Grade(Grade)
           .Size(Size)
           .RadiusValues(_radiusValues)
           .Class(Class)
           .Spacings(_spacings)
           .StartHook(_startHook)
           .EndHook(_endHook)
           .Build();

        pointsListRebarGroup.Polygons.Should().BeEquivalentTo(_tekla.Polygons.Cast<TSM.Polygon>());
    }

    private ICompletedRebarGroup GetDefaultFluentRebarGroup()
        => RebarGroup.BuildRebarGroup.With()
           .Father(_father)
           .Polygons(_polygons)
           .StartPoint(_startPoint)
           .EndPoint(_endPoint)
           .Grade(Grade)
           .Size(Size)
           .RadiusValues(_radiusValues)
           .Class(Class)
           .Spacings(_spacings)
           .StartHook(_startHook)
           .EndHook(_endHook);
}