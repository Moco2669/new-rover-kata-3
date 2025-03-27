namespace DotnetStarter.Logic.Tests;

public class RoverBuilder
{
    private const int gridXSize = 7;
    private const int gridYSize = 8;
    
    public static Rover CreateRover()
    {
        return new Rover(gridXSize, gridYSize);
    }
}