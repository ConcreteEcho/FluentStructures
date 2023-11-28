using System;
using System.Linq;
using Tekla.Structures.Forming;

namespace Fluent.Structures.Model;

/// <summary>
/// Represents a Rebar Group in a Tekla Structures Model with fluent interface for construction.
/// </summary>
public sealed class RebarGroup
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RebarGroup"/> class.
    /// </summary>
    private RebarGroup()
        => TeklaRebarGroup = new TSM.RebarGroup();

    /// <summary>
    /// Gets or sets the Tekla Structures Rebar Group instance.
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public TSM.RebarGroup TeklaRebarGroup { get; }

    /// <summary>
    /// Inserts the Rebar Group into the Tekla Structures model.
    /// </summary>
    /// <returns>True on success.</returns>
    public bool Insert()
        => TeklaRebarGroup.Insert();

    /// <summary>
    /// Deletes the Rebar Group from the Tekla Structures model.
    /// </summary>
    /// <returns>True on success.</returns>
    public bool Delete()
        => TeklaRebarGroup.Delete();

    /// <summary>
    /// Builder class for creating a Rebar Group.
    /// Implements various interfaces for a fluent and type-safe construction process.
    /// </summary>
    public class BuildRebarGroup : IEmptyRebarGroup, IRebarGroupWithFather, IRebarGroupWithPolygons,
                                   IRebarGroupWithStartPoint, IRebarGroupWithStartAndEndPoints,
                                   IRebarGroupWithGrade, IRebarGroupWithSize,
                                   IRebarGroupWithRadiusValues, IRebarGroupWithClass,
                                   IRebarGroupWithSpacings, IRebarGroupWithStartHook,
                                   ICompletedRebarGroup
    {
        /// <summary>
        /// The RebarGroup instance being constructed.
        /// </summary>
        private readonly RebarGroup _rebarGroup = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildRebarGroup"/> class.
        /// </summary>
        private BuildRebarGroup() {}

        /// <summary>
        /// Entry point to start configuring the Rebar Group class
        /// </summary>
        /// <returns>An interface for starting the construction process.</returns>
        public static IEmptyRebarGroup With()
            => new BuildRebarGroup();

        /// <inheritdoc />
        public IRebarGroupWithFather Father(TSM.ModelObject father)
        {
            _rebarGroup.Father = father;
            return this;
        }

        /// <inheritdoc />
        public IRebarGroupWithPolygons Polygons(ArrayList polygons)
        {
            var list = new List<Polygon>();

            foreach (var polygon in polygons)
                if (polygon is TSM.Polygon p)
                    list.Add(p);
                else
                    throw new ArgumentException(
                        $"Array list contains {polygon.GetType()
                        } which is not Tekla Structures Polygon"
                    );

            return Polygons(list);
        }

        public IRebarGroupWithPolygons Polygons(params Polygon[] polygons)
            => Polygons(polygons.ToList());

        public IRebarGroupWithPolygons Polygons(List<Polygon> polygons)
        {
            _rebarGroup.Polygons = polygons;
            return this;
        }

        /// <inheritdoc />
        public IRebarGroupWithPolygons Polygons(params TSG.Point[] points)
            => Polygons(points.ToList());

        public IRebarGroupWithPolygons Polygons(List<TSG.Point> points)
        {
            var polygon = Polygon.BuildPolygon.With().Points(points).Build();
            _rebarGroup.Polygons = new List<Polygon> { polygon, };
            return this;
        }

        /// <inheritdoc />
        public IRebarGroupWithStartPoint StartPoint(TSG.Point start)
        {
            _rebarGroup.StartPoint = start;
            return this;
        }

        /// <inheritdoc />
        public IRebarGroupWithStartAndEndPoints StartAndEndPoints(TSG.Point start, TSG.Point end)
        {
            _rebarGroup.StartPoint = start;
            _rebarGroup.EndPoint = end;
            return this;
        }

        /// <inheritdoc />
        public IRebarGroupWithStartAndEndPoints EndPoint(TSG.Point end)
        {
            _rebarGroup.EndPoint = end;
            return this;
        }

        /// <inheritdoc />
        public IRebarGroupWithGrade Grade(string grade)
        {
            _rebarGroup.Grade = grade;
            return this;
        }

        /// <inheritdoc />
        public IRebarGroupWithSize Size(string size)
        {
            _rebarGroup.Size = size;
            return this;
        }

        /// <inheritdoc />
        public IRebarGroupWithRadiusValues RadiusValues(ArrayList radiusValues)
        {
            _rebarGroup.RadiusValues = new List<double>(radiusValues.Cast<double>());
            return this;
        }

        /// <inheritdoc />
        public IRebarGroupWithRadiusValues RadiusValues(params double[] radiusValues)
        {
            _rebarGroup.RadiusValues = radiusValues.ToList();
            return this;
        }

        /// <inheritdoc />
        public IRebarGroupWithRadiusValues RadiusValues(List<double> radiusValues)
        {
            _rebarGroup.RadiusValues = radiusValues;
            return this;
        }

        /// <inheritdoc />
        public IRebarGroupWithClass Class(int @class)
        {
            _rebarGroup.Class = @class;
            return this;
        }

        /// <inheritdoc />
        public IRebarGroupWithSpacings Spacings(ArrayList spacings)
            => Spacings(spacings.Cast<double>().ToList());

        public IRebarGroupWithSpacings Spacings(params double[] spacings)
            => Spacings(spacings.ToList());

        public IRebarGroupWithSpacings Spacings(List<double> spacings)
        {
            _rebarGroup.Spacings = spacings;
            return this;
        }

        public IRebarGroupWithStartHook StartHook(TSM.RebarHookData startHook)
        {
            _rebarGroup.StartHook = startHook;
            return this;
        }

        /// <inheritdoc />
        public IRebarGroupWithStartHook StartHook(TSM.RebarHookData.RebarHookShapeEnum shapeEnum)
            => StartHook(new TSM.RebarHookData { Shape = shapeEnum, });

        /// <inheritdoc />
        public ICompletedRebarGroup StartAndEndHooks(TSM.RebarHookData startHook,
            TSM.RebarHookData endHook)
        {
            _rebarGroup.StartHook = startHook;
            _rebarGroup.EndHook = endHook;
            return this;
        }

        /// <inheritdoc />
        public ICompletedRebarGroup StartAndEndHooks(
            TSM.RebarHookData.RebarHookShapeEnum startShapeEnum,
            TSM.RebarHookData.RebarHookShapeEnum endShapeEnum)
        {
            var startHookData = new TSM.RebarHookData { Shape = startShapeEnum, };
            var endHookData = new TSM.RebarHookData { Shape = endShapeEnum, };
            _rebarGroup.StartHook = startHookData;
            _rebarGroup.EndHook = endHookData;
            return this;
        }

        /// <inheritdoc />
        public ICompletedRebarGroup EndHook(TSM.RebarHookData endHook)
        {
            _rebarGroup.EndHook = endHook;
            return this;
        }

        /// <inheritdoc />
        public ICompletedRebarGroup EndHook(TSM.RebarHookData.RebarHookShapeEnum endShapeEnum)
            => EndHook(new TSM.RebarHookData { Shape = endShapeEnum });

        /// <inheritdoc />
        public ICompletedRebarGroup Name(string name)
        {
            _rebarGroup.Name = name;
            return this;
        }

        /// <inheritdoc />
        public ICompletedRebarGroup SpacingType(
            TSM.BaseRebarGroup.RebarGroupSpacingTypeEnum spacingType)
        {
            _rebarGroup.SpacingType = spacingType;
            return this;
        }

        /// <inheritdoc />
        public ICompletedRebarGroup StartFromPlaneOffset(double startFromPlaneOffset)
        {
            _rebarGroup.StartFromPlaneOffset = startFromPlaneOffset;
            return this;
        }

        /// <inheritdoc />
        public ICompletedRebarGroup EndFromPlaneOffset(double endFromPlaneOffset)
        {
            _rebarGroup.EndFromPlaneOffset = endFromPlaneOffset;
            return this;
        }

        /// <inheritdoc />
        public ICompletedRebarGroup NumberingSeries(string prefix, int startNumber)
            => NumberingSeries(new TSM.NumberingSeries(prefix, startNumber));

        public ICompletedRebarGroup NumberingSeries(TSM.NumberingSeries numberingSeries)
        {
            _rebarGroup.NumberingSeries = numberingSeries;
            return this;
        }

        /// <inheritdoc />
        public ICompletedRebarGroup StartPointOffsetValue(double startPointOffsetValue)
        {
            _rebarGroup.StartPointOffsetValue = startPointOffsetValue;
            return this;
        }

        /// <inheritdoc />
        public ICompletedRebarGroup EndPointOffsetValue(double endPointOffsetValue)
        {
            _rebarGroup.EndPointOffsetValue = endPointOffsetValue;
            return this;
        }

        public ICompletedRebarGroup StartPointOffsetType(
            TSM.Reinforcement.RebarOffsetTypeEnum startPointOffsetType)
        {
            _rebarGroup.StartPointOffsetType = startPointOffsetType;
            return this;
        }

        public ICompletedRebarGroup EndPointOffsetType(
            TSM.Reinforcement.RebarOffsetTypeEnum endPointOffsetType)
        {
            _rebarGroup.EndPointOffsetType = endPointOffsetType;
            return this;
        }

        public ICompletedRebarGroup OnPlaneOffsets(ArrayList onPlaneOffsets)
            => OnPlaneOffsets(onPlaneOffsets.Cast<double>().ToList());

        public ICompletedRebarGroup OnPlaneOffsets(List<double> onPlaneOffsets)
        {
            _rebarGroup.OnPlaneOffsets = onPlaneOffsets;
            return this;
        }

        public ICompletedRebarGroup OnPlaneOffsets(params double[] onPlaneOffsets)
            => OnPlaneOffsets(onPlaneOffsets.ToList());

        public ICompletedRebarGroup ExcludeType(TSM.BaseRebarGroup.ExcludeTypeEnum excludeType)
        {
            _rebarGroup.ExcludeType = excludeType;
            return this;
        }

        public ICompletedRebarGroup StirrupType(
            TSM.RebarGroup.RebarGroupStirrupTypeEnum stirrupType)
        {
            _rebarGroup.StirrupType = stirrupType;
            return this;
        }

        public ICompletedRebarGroup Identifier(TS.Identifier identifier)
        {
            _rebarGroup.Identifier = identifier;
            return this;
        }

        public ICompletedRebarGroup InputPointDeformingState(DeformingType deformingType)
        {
            _rebarGroup.InputPointDeformingState = deformingType;
            return this;
        }

        /// <inheritdoc />
        public RebarGroup Build()
            => _rebarGroup;
    }

    #region properties

    /// <summary>
    /// Gets or sets the offset value at the end point of the Rebar Group.
    /// </summary>
    public double EndPointOffsetValue
    {
        get => TeklaRebarGroup.EndPointOffsetValue;
        private set => TeklaRebarGroup.EndPointOffsetValue = value;
    }

    /// <summary>
    /// Gets or sets the offset value at the start point of the Rebar Group.
    /// </summary>
    public double StartPointOffsetValue
    {
        get => TeklaRebarGroup.StartPointOffsetValue;
        private set => TeklaRebarGroup.StartPointOffsetValue = value;
    }

    /// <summary>
    /// Gets or sets the numbering series of the Rebar Group.
    /// </summary>
    public TSM.NumberingSeries NumberingSeries
    {
        get => TeklaRebarGroup.NumberingSeries;
        private set => TeklaRebarGroup.NumberingSeries = value;
    }

    /// <summary>
    /// Gets or sets the offset value from the plane at the end of the Rebar Group.
    /// </summary>
    public double EndFromPlaneOffset
    {
        get => TeklaRebarGroup.EndFromPlaneOffset;
        private set => TeklaRebarGroup.EndFromPlaneOffset = value;
    }

    /// <summary>
    /// Gets or sets the offset value from the plane at the start of the Rebar Group.
    /// </summary>
    public double StartFromPlaneOffset
    {
        get => TeklaRebarGroup.StartFromPlaneOffset;
        private set => TeklaRebarGroup.StartFromPlaneOffset = value;
    }

    /// <summary>
    /// Gets or sets the spacing type of the Rebar Group.
    /// </summary>
    public TSM.BaseRebarGroup.RebarGroupSpacingTypeEnum SpacingType
    {
        get => TeklaRebarGroup.SpacingType;
        private set => TeklaRebarGroup.SpacingType = value;
    }

    /// <summary>
    /// Gets or sets the name of the Rebar Group.
    /// </summary>
    public string Name
    {
        get => TeklaRebarGroup.Name;
        private set => TeklaRebarGroup.Name = value;
    }

    /// <summary>
    /// Gets or sets the end hook data of the Rebar Group.
    /// </summary>
    public TSM.RebarHookData EndHook
    {
        get => TeklaRebarGroup.EndHook;
        private set => TeklaRebarGroup.EndHook = value;
    }

    /// <summary>
    /// Gets or sets the start hook data of the Rebar Group.
    /// </summary>
    public TSM.RebarHookData StartHook
    {
        get => TeklaRebarGroup.StartHook;
        private set => TeklaRebarGroup.StartHook = value;
    }

    /// <summary>
    /// Gets or sets the spacings of the Rebar Group.
    /// </summary>
    public List<double> Spacings
    {
        get => new(TeklaRebarGroup.Spacings.Cast<double>());
        private set => TeklaRebarGroup.Spacings = new ArrayList(value);
    }

    /// <summary>
    /// Gets or sets the class of the Rebar Group.
    /// </summary>
    public int Class
    {
        get => TeklaRebarGroup.Class;
        private set => TeklaRebarGroup.Class = value;
    }

    /// <summary>
    /// Gets or sets the radius values of the Rebar Group.
    /// </summary>
    public List<double> RadiusValues
    {
        get => new(TeklaRebarGroup.RadiusValues.Cast<double>());
        private set => TeklaRebarGroup.RadiusValues = new ArrayList(value);
    }

    /// <summary>
    /// Gets or sets the size of the Rebar Group.
    /// </summary>
    public string Size
    {
        get => TeklaRebarGroup.Size;
        private set => TeklaRebarGroup.Size = value;
    }

    /// <summary>
    /// Gets or sets the grade of the Rebar Group.
    /// </summary>
    public string Grade
    {
        get => TeklaRebarGroup.Grade;
        private set => TeklaRebarGroup.Grade = value;
    }

    /// <summary>
    /// Gets or sets the end point of the Rebar Group.
    /// </summary>
    public TSG.Point EndPoint
    {
        get => TeklaRebarGroup.EndPoint;
        private set => TeklaRebarGroup.EndPoint = value;
    }

    /// <summary>
    /// Gets or sets the start point of the Rebar Group.
    /// </summary>
    public TSG.Point StartPoint
    {
        get => TeklaRebarGroup.StartPoint;
        private set => TeklaRebarGroup.StartPoint = value;
    }

    /// <summary>
    /// Gets or sets the polygons of the Rebar Group.
    /// </summary>
    public List<Polygon> Polygons
    {
        get => new(TeklaRebarGroup.Polygons.Cast<Polygon>());
        private set => TeklaRebarGroup.Polygons = new ArrayList(value);
    }

    /// <summary>
    /// Gets or sets the father model object of the Rebar Group.
    /// </summary>
    public TSM.ModelObject Father
    {
        get => TeklaRebarGroup.Father;
        private set => TeklaRebarGroup.Father = value;
    }

    /// <summary>
    /// Gets or sets the offset type at the start point of the Rebar Group.
    /// </summary>
    public TSM.Reinforcement.RebarOffsetTypeEnum StartPointOffsetType
    {
        get => TeklaRebarGroup.StartPointOffsetType;
        private set => TeklaRebarGroup.StartPointOffsetType = value;
    }

    /// <summary>
    /// Gets or sets the offset type at the end point of the Rebar Group.
    /// </summary>
    public TSM.Reinforcement.RebarOffsetTypeEnum EndPointOffsetType
    {
        get => TeklaRebarGroup.EndPointOffsetType;
        private set => TeklaRebarGroup.EndPointOffsetType = value;
    }

    /// <summary>
    /// Gets or sets on-plane offsets for the Rebar Group.
    /// </summary>
    public List<double> OnPlaneOffsets
    {
        get => new(TeklaRebarGroup.OnPlaneOffsets.Cast<double>());
        private set => TeklaRebarGroup.OnPlaneOffsets = new ArrayList(value);
    }

    /// <summary>
    /// Gets or sets the exclude type for the Rebar Group.
    /// </summary>
    public TSM.BaseRebarGroup.ExcludeTypeEnum ExcludeType
    {
        get => TeklaRebarGroup.ExcludeType;
        private set => TeklaRebarGroup.ExcludeType = value;
    }

    /// <summary>
    /// Gets or sets the stirrup type for the Rebar Group.
    /// </summary>
    public TSM.RebarGroup.RebarGroupStirrupTypeEnum StirrupType
    {
        get => TeklaRebarGroup.StirrupType;
        private set => TeklaRebarGroup.StirrupType = value;
    }

    /// <summary>
    /// Gets or sets the identifier for the Rebar Group.
    /// </summary>
    public TS.Identifier Identifier
    {
        get => TeklaRebarGroup.Identifier;
        private set => TeklaRebarGroup.Identifier = value;
    }

    /// <summary>
    /// Gets or sets the input deforming state for the Rebar Group.
    /// </summary>
    public DeformingType InputPointDeformingState
    {
        get => TeklaRebarGroup.InputPointDeformingState;
        private set => TeklaRebarGroup.InputPointDeformingState = value;
    }

    #endregion
}