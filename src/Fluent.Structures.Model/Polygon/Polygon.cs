using System;
using System.Linq;

namespace Fluent.Structures.Model;

/// <summary>
/// Represents a Polygon in a Tekla Structures Model with fluent interface for construction.
/// </summary>
public class Polygon : IEnumerable<TSG.Point>
{
    /// <summary>
    /// Gets the Tekla Structures Polygon associated with this Polygon instance.
    /// </summary>
    public TSM.Polygon TeklaPolygon { get; }

    private Polygon()
        => TeklaPolygon = new TSM.Polygon();

    /// <summary>
    /// Builder class for creating a Polygon.
    /// Implements various interfaces for a fluent and type-safe construction process.
    /// </summary>
    public class BuildPolygon : IEmptyPolygon, ICompletedPolygon
    {
        private readonly Polygon _polygon = new();

        private BuildPolygon() {}

        /// <summary>
        /// Entry point to start configuring the Polygon class
        /// </summary>
        /// <returns>An interface for starting the construction process.</returns>
        public static IEmptyPolygon With()
            => new BuildPolygon();

        public ICompletedPolygon Points(ArrayList points)
        {
            var list = new List<TSG.Point>();

            foreach (var point in points)
                if (point is TSG.Point p)
                    list.Add(p);
                else
                    throw new ArgumentException(
                        $"Array list contains {point.GetType()} which is not Tekla Structures Point"
                    );

            _polygon.Points = list;
            return this;
        }

        public ICompletedPolygon Points(List<TSG.Point> points)
        {
            _polygon.Points = points;
            return this;
        }

        public ICompletedPolygon Points(params TSG.Point[] points)
        {
            _polygon.Points = points.ToList();
            return this;
        }

        public Polygon Build()
            => _polygon;
    }

    /// <summary>
    /// Gets or sets the points of the Polygon.
    /// </summary>
    public List<TSG.Point> Points
    {
        get => new(TeklaPolygon.Points.Cast<TSG.Point>());
        private set => TeklaPolygon.Points = new ArrayList(value);
    }

    /// <summary>
    /// Returns an enumerator that iterates through the points of the Polygon.
    /// </summary>
    public IEnumerator<TSG.Point> GetEnumerator()
        => Points.GetEnumerator();

    /// <summary>
    /// Returns an enumerator that iterates through the points of the Polygon.
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    /// <summary>
    /// Implicitly converts a Polygon to a Tekla Structures Polygon.
    /// </summary>
    public static implicit operator TSM.Polygon(Polygon polygon)
        => polygon.TeklaPolygon;

    /// <summary>
    /// Implicitly converts a Tekla Structures Polygon to a Polygon.
    /// </summary>
    public static implicit operator Polygon(TSM.Polygon polygon)
        => BuildPolygon.With().Points(polygon.Points).Build();
}