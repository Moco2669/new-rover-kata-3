using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverGridWrappingTest
{
    private const int GridXSize = 6;
    private const int GridYSize = 10;
    private readonly string _goNorthOverGridLimit = new CommandBuilder().MoveTimes(GridYSize + 1).Build();
    private readonly string _goEastOverGridLimit = new CommandBuilder().TurnRight().MoveTimes(GridXSize + 1).Build();
    private readonly string _goSouthOverGridLimit = new CommandBuilder().TurnRight().TurnRight().MoveTimes(1).Build();
    private readonly string _goWestOverGridLimit = new CommandBuilder().TurnLeft().MoveTimes(1).Build();
    private readonly string _startingPositionFacingNorth = "0:0:" + new North();
    private readonly string _startingPositionFacingEast = "0:0:" + new East();
    private readonly string _maxYCoordinateFacingSouth = "0:" + GridYSize + ":" + new South();
    private readonly string _maxXCoordinateFacingWest = GridXSize + ":0:" + new West();

    private Rover _rover;

    public RoverGridWrappingTest()
    {
        _rover = RoverBuilder.CreateRover(gridXSize:GridXSize, gridYSize:GridYSize);
    }
    
    [Fact]
    public void RoverWrapsAroundGoingNorth()
    {
        Assert.Equal(_startingPositionFacingNorth, _rover.ExecuteCommand(_goNorthOverGridLimit));
    }

    [Fact]
    public void RoverWrapsAroundGoingEast()
    {
        Assert.Equal(_startingPositionFacingEast, _rover.ExecuteCommand(_goEastOverGridLimit));
    }

    [Fact]
    public void RoverWrapsAroundGoingSouth()
    {
        Assert.Equal(_maxYCoordinateFacingSouth, _rover.ExecuteCommand(_goSouthOverGridLimit));
    }

    [Fact]
    public void RoverWrapsAroundGoingWest()
    {
        Assert.Equal(_maxXCoordinateFacingWest, _rover.ExecuteCommand(_goWestOverGridLimit));
    }
}