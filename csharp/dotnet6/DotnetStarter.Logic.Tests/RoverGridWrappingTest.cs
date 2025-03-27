using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverGridWrappingTest
{
    private const int gridXSize = 7;
    private const int gridYSize = 8;

    private const string goNorthOverGridLimit = "MMMMMMMMM";

    [Fact]
    public void RoverWrapsAroundGoingNorth()
    {
        Rover rover = new Rover(gridXSize, gridYSize);
        Assert.Equal("0:0:N", rover.ExecuteCommand(goNorthOverGridLimit));
    }
}