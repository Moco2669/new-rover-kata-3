using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverGridWrappingTest
{
    private const string goNorthOverGridLimit = "MMMMMMMMM";
    private const string goEastOverGridLimit = "RMMMMMMMM";
    private const string goSouthOverGridLimit = "RRM";
    
    [Fact]
    public void RoverWrapsAroundGoingNorth()
    {
        Rover rover = RoverBuilder.CreateRover();
        Assert.Equal("0:0:N", rover.ExecuteCommand(goNorthOverGridLimit));
    }

    [Fact]
    public void RoverWrapsAroundGoingEast()
    {
        Rover rover = RoverBuilder.CreateRover();
        Assert.Equal("0:0:E", rover.ExecuteCommand(goEastOverGridLimit));
    }

    [Fact]
    public void RoverWrapsAroundGoingSouth()
    {
        Rover rover = RoverBuilder.CreateRover();
        Assert.Equal("0:8:S", rover.ExecuteCommand(goSouthOverGridLimit));
    }
}