using System.Collections.Generic;

namespace DotnetStarter.Logic;

public class Grid
{
    private int _xSize;
    private int _ySize;

    private Dictionary<int, List<int>> _obstacles = new();

    public Grid(int xSize, int ySize, List<(int, int)> obstacles)
    {
        _xSize = xSize;
        _ySize = ySize;
        foreach ((int x, int y) in obstacles)
        {
            AddObstacle(x, y);
        }
    }

    public (int, int) WrapCoordinates(int x, int y)
    {
        x = WrapCoordinate(x, _xSize);
        y = WrapCoordinate(y, _ySize);

        return (x, y);
    }

    private int WrapCoordinate(int coordinate, int maxCoordinate)
    {
        if (coordinate > maxCoordinate)
        {
            coordinate = 0;
        }
        if (coordinate < 0)
        {
            coordinate = maxCoordinate;
        }

        return coordinate;
    }
    
    public bool IsFieldObstacle(int x, int y)
    {
        if (_obstacles.TryGetValue(x, out var obstacleY))
        {
            return obstacleY.Contains(y);
        }

        return false;
    }

    private void AddObstacle(int x, int y)
    {
        if (!_obstacles.ContainsKey(x))
        {
            _obstacles[x] = new();
        }

        if (!_obstacles[x].Contains(y))
        {
            _obstacles[x].Add(y);
        }
    }
}