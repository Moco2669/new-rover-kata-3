namespace DotnetStarter.Logic.Tests;

public class RoverBuilder
{
    public static Rover CreateRover(int gridXSize = 7, int gridYSize = 8)
    {
        return new Rover(gridXSize, gridYSize);
    }
}