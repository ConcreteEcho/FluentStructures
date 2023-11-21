using System.Linq;

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
        /// Initializes a new instance of the <see cref="BuildRebarGroup"/> class with an existing RebarGroup instance.
        /// </summary>
        /// <param name="rebarGroup">The existing RebarGroup instance.</param>
        private BuildRebarGroup(RebarGroup rebarGroup) {}

        /// <summary>
        /// Entry point to start configuring the Rebar Group class
        /// </summary>
        /// <returns>An interface for starting the construction process.</returns>
        public static IEmptyRebarGroup With()
            => new BuildRebarGroup();

        public IRebarGroupWithFather Father(TSM.ModelObject father)
        {
            _rebarGroup.Father = father;
            return this;
        }

        public IRebarGroupWithPolygons Polygons(ArrayList polygons)
        {
            _rebarGroup.Polygons = polygons;
            return this;
        }

        public IRebarGroupWithPolygons Polygons(params TSM.Polygon[] polygons)
        {
            _rebarGroup.Polygons = new ArrayList(polygons);
            return this;
        }

        public IRebarGroupWithPolygons Polygons(params TSG.Point[] points)
        {
            var polygon = Polygon.BuildPolygon.With().Points(points).Build();
            _rebarGroup.Polygons = new ArrayList { polygon.TeklaPolygon };
            return this;
        }

        public IRebarGroupWithStartPoint StartPoint(TSG.Point start)
        {
            _rebarGroup.StartPoint = start;
            return this;
        }

        public IRebarGroupWithStartAndEndPoints StartAndEndPoints(TSG.Point start, TSG.Point end)
        {
            _rebarGroup.StartPoint = start;
            _rebarGroup.EndPoint = end;
            return this;
        }

        public IRebarGroupWithStartAndEndPoints EndPoint(TSG.Point end)
        {
            _rebarGroup.EndPoint = end;
            return this;
        }

        public IRebarGroupWithGrade Grade(string grade)
        {
            _rebarGroup.Grade = grade;
            return this;
        }

        public IRebarGroupWithSize Size(string size)
        {
            _rebarGroup.Size = size;
            return this;
        }

        public IRebarGroupWithRadiusValues RadiusValues(ArrayList radiusValues)
        {
            _rebarGroup.RadiusValues = new List<double>(radiusValues.Cast<double>());
            return this;
        }

        public IRebarGroupWithRadiusValues RadiusValues(params double[] radiusValues)
        {
            _rebarGroup.RadiusValues = radiusValues.ToList();
            return this;
        }

        public IRebarGroupWithRadiusValues RadiusValues(List<double> radiusValues)
        {
            _rebarGroup.RadiusValues = radiusValues;
            return this;
        }

        public IRebarGroupWithClass Class(int @class)
        {
            _rebarGroup.Class = @class;
            return this;
        }

        public IRebarGroupWithSpacings Spacings(ArrayList spacings)
        {
            _rebarGroup.Spacings = spacings;
            return this;
        }

        public IRebarGroupWithSpacings Spacings(params double[] spacings)
            => Spacings(new ArrayList(spacings));

        public IRebarGroupWithSpacings Spacings(List<double> spacings)
            => Spacings(new ArrayList(spacings));

        public IRebarGroupWithStartHook StartHook(TSM.RebarHookData startHook)
        {
            _rebarGroup.StartHook = startHook;
            return this;
        }

        public IRebarGroupWithStartHook StartHook(TSM.RebarHookData.RebarHookShapeEnum shapeEnum)
            => StartHook(new TSM.RebarHookData { Shape = shapeEnum });

        public ICompletedRebarGroup StartAndEndHooks(TSM.RebarHookData startHook,
            TSM.RebarHookData endHook)
        {
            _rebarGroup.StartHook = startHook;
            _rebarGroup.EndHook = endHook;
            return this;
        }

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

        public ICompletedRebarGroup EndHook(TSM.RebarHookData endHook)
        {
            _rebarGroup.EndHook = endHook;
            return this;
        }

        public ICompletedRebarGroup EndHook(TSM.RebarHookData.RebarHookShapeEnum endShapeEnum)
            => EndHook(new TSM.RebarHookData { Shape = endShapeEnum });

        public ICompletedRebarGroup Name(string name)
        {
            _rebarGroup.Name = name;
            return this;
        }

        public ICompletedRebarGroup SpacingType(
            TSM.BaseRebarGroup.RebarGroupSpacingTypeEnum spacingType)
        {
            _rebarGroup.SpacingType = spacingType;
            return this;
        }

        public ICompletedRebarGroup StartFromPlaneOffset(double startFromPlaneOffset)
        {
            _rebarGroup.StartFromPlaneOffset = startFromPlaneOffset;
            return this;
        }

        public ICompletedRebarGroup EndFromPlaneOffset(double endFromPlaneOffset)
        {
            _rebarGroup.EndFromPlaneOffset = endFromPlaneOffset;
            return this;
        }

        public ICompletedRebarGroup NumberingSeries(string prefix, int startNumber)
        {
            _rebarGroup.NumberingSeries = new TSM.NumberingSeries(prefix, startNumber);
            return this;
        }

        public ICompletedRebarGroup StartPointOffsetValue(double startPointOffsetValue)
        {
            _rebarGroup.StartPointOffsetValue = startPointOffsetValue;
            return this;
        }

        public ICompletedRebarGroup EndPointOffsetValue(double endPointOffsetValue)
        {
            _rebarGroup.EndPointOffsetValue = endPointOffsetValue;
            return this;
        }

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
    public ArrayList Spacings
    {
        get => TeklaRebarGroup.Spacings;
        private set => TeklaRebarGroup.Spacings = value;
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
    public ArrayList Polygons
    {
        get => TeklaRebarGroup.Polygons;
        private set => TeklaRebarGroup.Polygons = value;
    }

    /// <summary>
    /// Gets or sets the father model object of the Rebar Group.
    /// </summary>
    public TSM.ModelObject Father
    {
        get => TeklaRebarGroup.Father;
        private set => TeklaRebarGroup.Father = value;
    }

    #endregion
}