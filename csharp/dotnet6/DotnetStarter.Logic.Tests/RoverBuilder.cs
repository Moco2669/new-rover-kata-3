using System.Collections.Generic;
using System.Linq;

namespace DotnetStarter.Logic.Tests;

public class RoverBuilder
{
    private Rover _rover;
    private int _gridXSize;
    private int _gridYSize;
    private List<(int, int)> _obstacles;

    public RoverBuilder CreateRover(int gridXSize = 7, int gridYSize = 8)
    {
        _gridXSize = gridXSize;
        _gridYSize = gridYSize;
        _obstacles = new();
        return this;
    }

    public RoverBuilder WithObstacles(List<(int, int)> obstacles)
    {
        _obstacles.AddRange(obstacles);
        return this;
    }

    public Rover Build()
    {
        _rover = new Rover(new Grid(_gridXSize, _gridYSize, _obstacles));
        return _rover;
    }
}