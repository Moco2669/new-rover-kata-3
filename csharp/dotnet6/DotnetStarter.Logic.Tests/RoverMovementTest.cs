using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverMovementTest
{
    [Fact]
    public void RoverMovesNorth()
    {
        Rover rover = new();
        Assert.Equal("0:1:N", rover.ExecuteCommand("M"));
    }

    [Fact]
    public void RoverMovesEast()
    {
        Rover rover = new();
        Assert.Equal("1:0:E", rover.ExecuteCommand("RM"));
    }
}