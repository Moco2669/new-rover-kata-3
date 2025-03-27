using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverGridWrappingTest
{
    private const string goNorthOverGridLimit = "MMMMMMMMM";

    [Fact]
    public void RoverWrapsAroundGoingNorth()
    {
        Rover rover = RoverBuilder.CreateRover();
        Assert.Equal("0:0:N", rover.ExecuteCommand(goNorthOverGridLimit));
    }
}