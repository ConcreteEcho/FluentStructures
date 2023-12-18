namespace Fluent.Structures.Model.UnitTests;

public class PolygonTests
{
    private ArrayList _points = new()
    {
        new TSG.Point(1,  2,  3), new TSG.Point(4,   5,  6), new TSG.Point(7, 8, 9),
        new TSG.Point(10, 11, 12), new TSG.Point(13, 14, 15),
    };

    private TSM.Polygon _tekla = null!;

    [SetUp]
    public void SetupTeklaPolygon()
        => _tekla = new TSM.Polygon
            { Points = _points, };

    [Test]
    public void Fluent_polygon_from_arraylist_equals_tekla_polygon()
    {
        var fluent = Polygon.BuildPolygon.With().Points(_points).Build();

        fluent.Points.Should().BeEquivalentTo(_tekla.Points.Cast<TSG.Point>());
    }

    [Test]
    public void Fluent_polygon_from_array_equals_tekla_polygon()
    {
        var fluent = Polygon.BuildPolygon.With()
           .Points(_points.Cast<TSG.Point>().ToArray())
           .Build();

        fluent.Points.Should().BeEquivalentTo(_tekla.Points.Cast<TSG.Point>());
    }

    [Test]
    public void Fluent_polygon_from_list_equals_tekla_polygon()
    {
        var fluent = Polygon.BuildPolygon.With()
           .Points(_points.Cast<TSG.Point>().ToList())
           .Build();

        fluent.Points.Should().BeEquivalentTo(_tekla.Points.Cast<TSG.Point>());
    }
}