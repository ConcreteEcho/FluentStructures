namespace Fluent.Structures.Model;

public interface IEmptyBeam
{
    public IBeamWithStartAndEndPoints StartAndEndPoint(TSG.Point startPoint, TSG.Point endPoint);
    public IBeamWithStartPoint StartPoint(TSG.Point startPoint);
}

public interface IBeamWithStartPoint
{
    public IBeamWithStartAndEndPoints EndPoint(TSG.Point endPoint);
}

public interface IBeamWithStartAndEndPoints
{
    public IBeamWithProfile Profile(string profile);
}

public interface IBeamWithProfile
{
    public ICompletedBeam Material(string material);
}

public interface ICompletedBeam
{
    public ICompletedBeam Name(string name);
    public ICompletedBeam Class(string @class);
    public ICompletedBeam AssemblyNumbering(string assemblyPrefix, int assemblyStartNumber);
    public ICompletedBeam PartNumbering(string partPrefix, int partStartNumber);
    public ICompletedBeam PlanePosition(TSM.Position.PlaneEnum planeEnum, double planeOffset);
    public ICompletedBeam DepthPosition(TSM.Position.DepthEnum depthEnum, double depthOffset);
    public ICompletedBeam RotationPosition(TSM.Position.RotationEnum rotationEnum, double rotationOffset);
    public Beam Build();
}