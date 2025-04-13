using System.Collections.Immutable;
using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverObstacleTest
{
    private const int ObstacleXPosition = 4;
    private const int ObstacleYPosition = 5;
    private const int GridXSize = 7;
    private const int GridYSize = 8;
    private const string ObstacleIndication = "O";
    private const string Separator = ":";

    private readonly string _moveToObstacleFromNorth =
        new CommandBuilder().TurnRight().MoveTimes(ObstacleXPosition)
        .TurnLeft().MoveTimes(ObstacleYPosition - 1).Build();
    private readonly string _moveToObstacleFromSouth =
        new CommandBuilder().TurnRight().MoveTimes(ObstacleXPosition).TurnRight().MoveTimes(GridYSize - ObstacleYPosition).Build();

    private readonly string _moveToObstacleFromEast =
        new CommandBuilder().MoveTimes(ObstacleYPosition).TurnRight().MoveTimes(ObstacleXPosition - 1).Build();

    private readonly string _moveToObstacleFromWest =
        new CommandBuilder().MoveTimes(ObstacleYPosition).TurnLeft().MoveTimes(GridXSize - ObstacleXPosition).Build();
    
    private readonly string _obstaclePositionFromNorth =
        ObstacleIndication + Separator +
        ObstacleXPosition + Separator +
        (ObstacleYPosition - 1) + Separator +
        new North();

    private readonly string _obstaclePositionFromSouth =
        ObstacleIndication + Separator +
        ObstacleXPosition + Separator +
        (ObstacleYPosition + 1) + Separator +
        new South();

    private readonly string _obstaclePositionFromEast =
        ObstacleIndication + Separator +
        (ObstacleXPosition - 1) + Separator +
        ObstacleYPosition + Separator +
        new East();

    private readonly string _obstaclePositionFromWest =
        ObstacleIndication + Separator +
        (ObstacleXPosition + 1) + Separator +
        ObstacleYPosition + Separator +
        new West();

    private Rover _rover;

    public RoverObstacleTest()
    {
        _rover = RoverBuilder.CreateRover(GridXSize, GridYSize).AddObstacle(ObstacleXPosition, ObstacleYPosition);
    }
    
    [Fact]
    public void RoverReportsObstacleFromNorth()
    {
        Assert.Equal(_obstaclePositionFromNorth, _rover.ExecuteCommand(_moveToObstacleFromNorth));
    }

    [Fact]
    public void RoverReportsObstacleFromSouth()
    {
        Assert.Equal(_obstaclePositionFromSouth, _rover.ExecuteCommand(_moveToObstacleFromSouth));
    }

    [Fact]
    public void RoverReportsObstacleFromEast()
    {
        Assert.Equal(_obstaclePositionFromEast, _rover.ExecuteCommand(_moveToObstacleFromEast));
    }

    [Fact]
    public void RoverReportsObstacleFromWest()
    {
        Assert.Equal(_obstaclePositionFromWest, _rover.ExecuteCommand(_moveToObstacleFromWest));
    }
}