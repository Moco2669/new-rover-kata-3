using System.Collections.Immutable;
using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverObstacleTest
{
    private const int obstacleXPosition = 4;
    private const int obstacleYPosition = 5;
    private const int gridXSize = 7;
    private const int gridYSize = 8;
    private const string obstacleIndication = "O";
    private const string separator = ":";

    private readonly string moveToObstacleFromNorth =
        new CommandBuilder().TurnRight().MoveTimes(obstacleXPosition)
        .TurnLeft().MoveTimes(obstacleYPosition - 1).Build();
    private readonly string moveToObstacleFromSouth =
        new CommandBuilder().TurnRight().MoveTimes(obstacleXPosition).TurnRight().MoveTimes(gridYSize - obstacleYPosition).Build();

    private readonly string moveToObstacleFromEast =
        new CommandBuilder().MoveTimes(obstacleYPosition).TurnRight().MoveTimes(obstacleXPosition - 1).Build();

    private readonly string moveToObstacleFromWest =
        new CommandBuilder().MoveTimes(obstacleYPosition).TurnLeft().MoveTimes(gridXSize - obstacleXPosition).Build();
    
    private readonly string obstaclePositionFromNorth =
        obstacleIndication + separator +
        obstacleXPosition + separator +
        (obstacleYPosition - 1) + separator +
        new North();

    private readonly string obstaclePositionFromSouth =
        obstacleIndication + separator +
        obstacleXPosition + separator +
        (obstacleYPosition + 1) + separator +
        new South();

    private readonly string obstaclePositionFromEast =
        obstacleIndication + separator +
        (obstacleXPosition - 1) + separator +
        obstacleYPosition + separator +
        new East();

    private readonly string obstaclePositionFromWest =
        obstacleIndication + separator +
        (obstacleXPosition + 1) + separator +
        obstacleYPosition + separator +
        new West();
    
    [Fact]
    public void RoverReportsObstacleFromNorth()
    {
        Rover rover = RoverBuilder.CreateRover(gridXSize, gridYSize).AddObstacle(obstacleXPosition, obstacleYPosition);
        Assert.Equal(obstaclePositionFromNorth, rover.ExecuteCommand(moveToObstacleFromNorth));
    }

    [Fact]
    public void RoverReportsObstacleFromSouth()
    {
        Rover rover = RoverBuilder.CreateRover(gridXSize, gridYSize).AddObstacle(obstacleXPosition, obstacleYPosition);
        Assert.Equal(obstaclePositionFromSouth, rover.ExecuteCommand(moveToObstacleFromSouth));
    }

    [Fact]
    public void RoverReportsObstacleFromEast()
    {
        Rover rover = RoverBuilder.CreateRover(gridXSize, gridYSize).AddObstacle(obstacleXPosition, obstacleYPosition);
        Assert.Equal(obstaclePositionFromEast, rover.ExecuteCommand(moveToObstacleFromEast));
    }

    [Fact]
    public void RoverReportsObstacleFromWest()
    {
        Rover rover = RoverBuilder.CreateRover(gridXSize, gridYSize).AddObstacle(obstacleXPosition, obstacleYPosition);
        Assert.Equal(obstaclePositionFromWest, rover.ExecuteCommand(moveToObstacleFromWest));
    }
}