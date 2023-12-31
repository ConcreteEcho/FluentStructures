using System.Diagnostics;
using TSM = Tekla.Structures.Model;
using TSS = Tekla.Structures.Service;
using System.Reflection;
using FluentAssertions;

namespace Fluent.Structures.Model.IntegrationTests;

public class Tests
{
    private const string TsVersion = "2022.0";
    private const string TsBinDirectory = $@"C:\TeklaStructures\{TsVersion}\bin";
    private const string TsModelsPath = @"C:\TeklaStructuresModels\";
    private const string TsModelName = "Model-integration-tests";
    private readonly string _tsModelPath = Path.Combine(TsModelsPath, TsModelName);

    private const string EnvironmentIni = $@"C:\TeklaStructures\{TsVersion
    }\Environments\default\env_Default_environment.ini";

    private const string RoleIni = $@"C:\TeklaStructures\{TsVersion
    }\Environments\default\role_Steel_Detailer.ini";

    private TSS.TeklaStructuresService _ts = null!;

    [SetUp]
    public void Setup()
    {
        AppDomain.CurrentDomain.AssemblyResolve += (_, a) => TeklaBinResolve(a);
        _ts = new TSS.TeklaStructuresService(
            new DirectoryInfo(TsBinDirectory),
            "ENGLISH",
            new FileInfo(EnvironmentIni),
            new FileInfo(RoleIni)
        );
        _ts.Initialize(new DirectoryInfo(TsModelsPath));
        if (CreateModel() is not true)
            Assert.Fail();
    }

    private bool CreateModel()
        => new TSM.ModelHandler().CreateNewSingleUserModel(
            TsModelName,
            TsModelsPath
        );

    [TearDown]
    public void Teardown()
    {
        _ts.Dispose();
        Directory.Delete(_tsModelPath);
    }

    private static Assembly? TeklaBinResolve(ResolveEventArgs args)
    {
        var requestedAssembly = new AssemblyName(args.Name);
        Trace.WriteLine($"Trying to find: {args.Name}");

        if (File.Exists(Path.Combine(TsBinDirectory, requestedAssembly.Name + ".dll")))
        {
            Trace.WriteLine($"Requested assembly: {requestedAssembly.FullName}");
            return Assembly.LoadFile(Path.Combine(TsBinDirectory, requestedAssembly.Name + ".dll"));
        }

        Trace.WriteLine($"Assembly {args.Name} was not found");
        return null;
    }

    [Test]
    public void Test()
        => _ts.Ping().Should().Be("Pong");
}