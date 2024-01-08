namespace Fluent.Structures.Model.IntegrationTests;

// TODO: need to figure out how to run different TestFixtures at the same time, because tekla dll throws an exception that the service must be initialized once.
// TODO: find out why the tests cant run in the Rider

[TestFixture]
public class Tests
{
    private const string TsVersion = "2022.0";
    private const string TsBinDirectory = $@"C:\TeklaStructures\{TsVersion}\bin";

    private const string ModelsPath = @"C:\TeklaStructuresModels\";
    private const string ModelName = "test_model";
    private static readonly string ModelPath = Path.Combine(ModelsPath, ModelName);

    private const string EnvironmentIni = $@"C:\TeklaStructures\{TsVersion
    }\Environments\default\env_Default_environment.ini";

    private const string RoleIni = $@"C:\TeklaStructures\{TsVersion
    }\Environments\default\role_Steel_Detailer.ini";

    private static TSS.TeklaStructuresService _ts = null!;

    [OneTimeSetUp]
    public static void Setup()
    {
        AppDomain.CurrentDomain.AssemblyResolve += (_, a) => TeklaBinResolve(a);

        _ts = new TSS.TeklaStructuresService(
            new DirectoryInfo(TsBinDirectory),
            "ENGLISH",
            new FileInfo(EnvironmentIni),
            new FileInfo(RoleIni)
        );

        Directory.CreateDirectory(ModelPath);
        _ts.Initialize(new DirectoryInfo(ModelPath));

        new TSM.ModelHandler().CreateNewSingleUserModel(ModelName, ModelsPath).Should().BeTrue();
    }

    [OneTimeTearDown]
    public static void TearDown()
    {
        _ts.Dispose();
        Directory.Delete(ModelPath, true);
    }

    [Test]
    public void Test()
        => _ts.Ping().Should().Be("Pong", "Connection should be established with Tekla");

    [Test]
    public void Test2()
        => _ts.Ping().Should().Be("Pong", "Connection should be established with Tekla");

    [Test]
    public void Test3()
        => _ts.Ping().Should().Be("Pong", "Connection should be established with Tekla");

    [Test]
    public void Test4()
        => _ts.Ping().Should().Be("Pong", "Connection should be established with Tekla");

    private static Assembly? TeklaBinResolve(ResolveEventArgs args)
    {
        var requestedAssembly = new AssemblyName(args.Name);

        if (File.Exists(Path.Combine(TsBinDirectory, requestedAssembly.Name + ".dll")))
            return Assembly.LoadFile(Path.Combine(TsBinDirectory, requestedAssembly.Name + ".dll"));

        return null;
    }
}