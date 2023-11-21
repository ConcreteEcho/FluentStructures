namespace Fluent.Structures.Model;

public sealed class Plate
{
    private readonly TSM.ContourPlate _tsmPlate;

    private Plate()
        => _tsmPlate = new TSM.ContourPlate();

    public void Insert()
        => _tsmPlate.Insert();

    public TSM.Assembly GetAssembly()
        => _tsmPlate.GetAssembly();

    #region Builder
    public class BuildPlate : IEmptyPlate, IPlateWithPoints, IPlateWithProfile, ICompletedPlate
    {
        private readonly Plate _plate = new();

        public static IEmptyPlate With()
            => new BuildPlate();

        public IPlateWithPoints Points(params TSM.ContourPoint[] points)
        {
            var arrList = new ArrayList();
            foreach (var point in points)
                arrList.Add(point);
            _plate.Points = arrList;
            return this;
        }

        public IPlateWithPoints Contour(TSM.Contour contour)
        {
            _plate.Contour = contour;
            return this;
        }

        public IPlateWithProfile Profile(string profile)
        {
            _plate.Profile = profile;
            return this;
        }

        public ICompletedPlate Material(string material)
        {
            _plate.Material = material;
            return this;
        }

        public ICompletedPlate WithName(string name)
        {
            _plate.Name = name;
            return this;
        }

        public ICompletedPlate WithClass(string @class)
        {
            _plate.Class = @class;
            return this;
        }

        public ICompletedPlate WithAssemblyNumbering(string assemblyPrefix, int assemblyStartNumber)
        {
            _plate.AssemblyPrefix = assemblyPrefix;
            _plate.AssemblyStartNumber = assemblyStartNumber;
            return this;
        }

        public ICompletedPlate WithPartNumbering(string partPrefix, int partStartNumber)
        {
            _plate.PartPrefix = partPrefix;
            _plate.PartStartNumber = partStartNumber;
            return this;
        }

        public ICompletedPlate WithDepthPosition(TSM.Position.DepthEnum depthEnum, double depthOffset)
        {
            _plate.DepthPosition = depthEnum;
            _plate.DepthOffest = depthOffset;
            return this;
        }

        public Plate Build()
            => _plate;
    }
    #endregion

    #region Properties
    public TSM.Contour Contour
    {
        get => _tsmPlate.Contour!;
        private set => _tsmPlate.Contour = value;
    }

    public ArrayList Points
    {
        get => _tsmPlate.Contour!.ContourPoints!;
        private set => _tsmPlate.Contour!.ContourPoints = value;
    }

    public string? Profile
    {
        get => _tsmPlate.Profile.ProfileString;
        private set => _tsmPlate.Profile.ProfileString = value;
    }

    public string? Material
    {
        get => _tsmPlate.Material?.MaterialString;
        private set => _tsmPlate.Material.MaterialString = value;
    }

    public string? Name
    {
        get => _tsmPlate.Name;
        private set => _tsmPlate.Name = value;
    }

    public string? Class
    {
        get => _tsmPlate.Class;
        private set => _tsmPlate.Class = value;
    }

    public string? AssemblyPrefix
    {
        get => _tsmPlate.AssemblyNumber.Prefix;
        private set => _tsmPlate.AssemblyNumber.Prefix = value;
    }

    public int AssemblyStartNumber
    {
        get => _tsmPlate.AssemblyNumber!.StartNumber;
        private set => _tsmPlate.AssemblyNumber!.StartNumber = value;
    }

    public string? PartPrefix
    {
        get => _tsmPlate.PartNumber.Prefix;
        private set => _tsmPlate.PartNumber.Prefix = value;
    }

    public int PartStartNumber
    {
        get => _tsmPlate.PartNumber!.StartNumber;
        private set => _tsmPlate.PartNumber!.StartNumber = value;
    }

    public TSM.Position.DepthEnum DepthPosition
    {
        get => _tsmPlate.Position.Depth;
        private set => _tsmPlate.Position.Depth = value;
    }

    public double DepthOffest
    {
        get => _tsmPlate.Position!.DepthOffset;
        private set => _tsmPlate.Position!.DepthOffset = value;
    }
    #endregion
}