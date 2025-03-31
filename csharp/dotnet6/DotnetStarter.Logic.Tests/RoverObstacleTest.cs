using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverObstacleTest
{
    private const int obstacleXPosition = 4;
    private const int obstacleYPosition = 5;
    private const string obstacleIndication = "O:";

    private readonly string moveToObstacleFromNorth = new CommandBuilder().TurnRight().MoveTimes(obstacleXPosition)
        .TurnLeft().MoveTimes(obstacleYPosition - 1).Build();
    private readonly string obstaclePositionFromNorth = obstacleIndication + obstacleXPosition + ":" + (obstacleYPosition - 1) + ":" + new North();
    
    [Fact]
    public void RoverReportsObstacleFromNorth()
    {
        Rover rover = RoverBuilder.CreateRover().AddObstacle(obstacleXPosition, obstacleYPosition);
        Assert.Equal(obstaclePositionFromNorth, rover.ExecuteCommand(moveToObstacleFromNorth));
    }
}