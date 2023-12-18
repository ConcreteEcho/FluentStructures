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
    private const string TsLicenseServer = "27001@127.0.0.1";

    private const string EnvironmentIni = $@"C:\TeklaStructures\{TsVersion
    }\Environments\default\env_Default_environment.ini";

    private const string RoleIni = $@"C:\TeklaStructures\{TsVersion
    }\Environments\default\role_Steel_Detailer.ini";

    private TSS.TeklaStructuresService _ts = null!;

    [SetUp]
    public void Setup()
    {
        ConfigureHeadlessIni();
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
        => _ts.Dispose();

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

    private void ConfigureHeadlessIni()
    {
        var testIniFilePath = Path.Combine(_tsModelPath, "TeklaStructures.ini");
        Directory.CreateDirectory(_tsModelPath);

        // Always make a copy of a main the ini file so we dont break TS installation.
        File.Copy(Path.Combine(TsBinDirectory, "TeklaStructures.ini"), testIniFilePath, true);

        File.AppendAllText(
            testIniFilePath,
            $"\r\nset XS_LICENSE_SERVER_HOST={TsLicenseServer}\r\n"
        );
        File.AppendAllText(testIniFilePath, $"set XS_DEFAULT_LICENSE=Full\r\n");
        File.AppendAllText(testIniFilePath, $"set XS_PLUGIN_DEVELOPER_MODE=false\r\n");
        Environment.SetEnvironmentVariable("TS_OVERRIDE_INI_FILE", testIniFilePath);

        /*var envVar = Environment.GetEnvironmentVariable("TS_OVERRIDE_INI_FILE");
        if (envVar == null || !envVar.Equals(testIniFilePath))
        {
            throw new ArgumentException(
                $"Please set TS_OVERRIDE_INI_FILE, before exec the program: set TS_OVERRIDE_INI_FILE={
                    testIniFilePath}"
            );
        }*/
    }

    [Test]
    public void Test1()
        => _ts.Ping().Should().Be("Pong");
}