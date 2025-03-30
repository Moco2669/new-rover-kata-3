using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverGridWrappingTest
{
    private const int gridXSize = 6;
    private const int gridYSize = 10;
    private readonly string goNorthOverGridLimit = new CommandBuilder().MoveTimes(gridYSize + 1).Build();
    private readonly string goEastOverGridLimit = new CommandBuilder().TurnRight().MoveTimes(gridXSize + 1).Build();
    private readonly string goSouthOverGridLimit = new CommandBuilder().TurnRight().TurnRight().MoveTimes(1).Build();
    private readonly string goWestOverGridLimit = new CommandBuilder().TurnLeft().MoveTimes(1).Build();
    private readonly string startingPositionFacingNorth = "0:0:" + new North();
    private readonly string startingPositionFacingEast = "0:0:" + new East();
    private readonly string maxYCoordinateFacingSouth = "0:" + gridYSize + ":" + new South();
    private readonly string maxXCoordinateFacingWest = gridXSize + ":0:" + new West();
    
    [Fact]
    public void RoverWrapsAroundGoingNorth()
    {
        Rover rover = RoverBuilder.CreateRover(gridXSize:gridXSize, gridYSize:gridYSize);
        Assert.Equal(startingPositionFacingNorth, rover.ExecuteCommand(goNorthOverGridLimit));
    }

    [Fact]
    public void RoverWrapsAroundGoingEast()
    {
        Rover rover = RoverBuilder.CreateRover(gridXSize:gridXSize, gridYSize:gridYSize);
        Assert.Equal(startingPositionFacingEast, rover.ExecuteCommand(goEastOverGridLimit));
    }

    [Fact]
    public void RoverWrapsAroundGoingSouth()
    {
        Rover rover = RoverBuilder.CreateRover(gridXSize:gridXSize, gridYSize:gridYSize);
        Assert.Equal(maxYCoordinateFacingSouth, rover.ExecuteCommand(goSouthOverGridLimit));
    }

    [Fact]
    public void RoverWrapsAroundGoingWest()
    {
        Rover rover = RoverBuilder.CreateRover(gridXSize:gridXSize, gridYSize:gridYSize);
        Assert.Equal(maxXCoordinateFacingWest, rover.ExecuteCommand(goWestOverGridLimit));
    }
}