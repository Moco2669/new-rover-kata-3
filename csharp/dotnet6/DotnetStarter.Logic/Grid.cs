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

    public Field WrapCoordinates(Field field)
    {
        int x = WrapCoordinate(field.X, _xSize);
        int y = WrapCoordinate(field.Y, _ySize);

        return new Field(x, y);
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
    
    public bool IsFieldObstacle(Field field)
    {
        if (_obstacles.TryGetValue(field.X, out var obstacleY))
        {
            return obstacleY.Contains(field.Y);
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