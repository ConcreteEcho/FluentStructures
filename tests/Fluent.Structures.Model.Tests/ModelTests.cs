using FluentAssertions;

namespace Fluent.Structures.Model.Tests;

public class ModelTests
{
    private Model _model;

    [SetUp]
    public void Setup()
    {
        _model = new Model();
    }

    [Test]
    public void ConnectionStatusWhenTeklaIsOpened()
    {
        _model.IsConnected.Should().BeTrue();
    }
}