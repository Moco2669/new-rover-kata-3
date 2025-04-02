using System.Collections.Immutable;
using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverObstacleTest
{
    private const int obstacleXPosition = 4;
    private const int obstacleYPosition = 5;
    private const int gridXSize = 7;
    private const int gridYSize = 8;
    private const string obstacleIndication = "O:";

    private readonly string moveToObstacleFromNorth = new CommandBuilder().TurnRight().MoveTimes(obstacleXPosition)
        .TurnLeft().MoveTimes(obstacleYPosition - 1).Build();
    private readonly string moveToObstacleFromSouth = new CommandBuilder().TurnRight().MoveTimes(obstacleXPosition).TurnRight().MoveTimes(gridYSize - obstacleYPosition).Build();
    private readonly string obstaclePositionFromNorth = obstacleIndication + obstacleXPosition + ":" + (obstacleYPosition - 1) + ":" + new North();

    private readonly string obstaclePositionFromSouth =
        obstacleIndication + obstacleXPosition + ":" + (obstacleYPosition + 1) + ":" + new South();
    
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
}