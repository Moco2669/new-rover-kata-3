using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverMovementTest
{
    private const string move = "M";
    private const string turnEastAndMove = "RM";
    private const string moveNorthAndBackSouth = "MMLLM";
    private const string moveEastAndBackWest = "RMMLLM";
    
    [Fact]
    public void RoverMovesNorth()
    {
        Rover rover = new();
        Assert.Equal("0:1:N", rover.ExecuteCommand(move));
    }

    [Fact]
    public void RoverMovesEast()
    {
        Rover rover = new();
        Assert.Equal("1:0:E", rover.ExecuteCommand(turnEastAndMove));
    }

    [Fact]
    public void RoverMovesSouth()
    {
        Rover rover = new();
        Assert.Equal("0:1:S", rover.ExecuteCommand(moveNorthAndBackSouth));
    }

    [Fact]
    public void RoverMovesWest()
    {
        Rover rover = new();
        Assert.Equal("1:0:W", rover.ExecuteCommand(moveEastAndBackWest));
    }
}