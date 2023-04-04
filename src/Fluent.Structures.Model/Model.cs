namespace Fluent.Structures.Model;

public class Model
{
    public TSM.Model TeklaModel;

    public Model()
        => TeklaModel = new TSM.Model();

    public bool IsConnected => TeklaModel.GetConnectionStatus();
}