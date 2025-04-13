using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverMovementTest
{
    private const string Move = "M";
    private const string TurnEastAndMove = "RM";
    private const string MoveNorthAndBackSouth = "MMLLM";
    private const string MoveEastAndBackWest = "RMMLLM";

    private Rover _rover;

    public RoverMovementTest()
    {
        _rover = RoverBuilder.CreateRover();
    }
    
    [Fact]
    public void RoverMovesNorth()
    {
        Assert.Equal("0:1:N", _rover.ExecuteCommand(Move));
    }

    [Fact]
    public void RoverMovesEast()
    {
        Assert.Equal("1:0:E", _rover.ExecuteCommand(TurnEastAndMove));
    }

    [Fact]
    public void RoverMovesSouth()
    {
        Assert.Equal("0:1:S", _rover.ExecuteCommand(MoveNorthAndBackSouth));
    }

    [Fact]
    public void RoverMovesWest()
    {
        Assert.Equal("1:0:W", _rover.ExecuteCommand(MoveEastAndBackWest));
    }
}