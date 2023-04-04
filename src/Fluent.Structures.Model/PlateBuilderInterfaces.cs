namespace Fluent.Structures.Model;

public interface IEmptyPlate
{
    IPlateWithPoints Points(params TSM.ContourPoint[] points);
    IPlateWithPoints Contour(TSM.Contour contour);
}

public interface IPlateWithPoints
{
    IPlateWithProfile Profile(string profile);
}

public interface IPlateWithProfile
{
    ICompletedPlate Material(string material);
}

public interface ICompletedPlate
{
    public ICompletedPlate WithName(string name);
    public ICompletedPlate WithClass(string @class);
    public ICompletedPlate WithAssemblyNumbering(string assemblyPrefix, int assemblyStartNumber);
    public ICompletedPlate WithPartNumbering(string partPrefix, int partStartNumber);
    public ICompletedPlate WithDepthPosition(TSM.Position.DepthEnum depthEnum, double depthOffset);
    public Plate Build();
}