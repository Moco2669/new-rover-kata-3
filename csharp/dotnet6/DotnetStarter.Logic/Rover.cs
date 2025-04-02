using System;
using System.Collections.Generic;

namespace DotnetStarter.Logic;

public class Rover
{
    private Orientation _facing = new North();
    private int _xPos = 0;
    private int _yPos = 0;

    private int _gridXSize;
    private int _gridYSize;

    private Dictionary<int, List<int>> _obstacles = new Dictionary<int, List<int>>();

    private bool FacingObstacle
    {
        get
        {
            (int nextX, int nextY) = GetNextField();
            return IsFieldObstacle(nextX, nextY);
        }
    }

    private (int, int) GetNextField()
    {
        (int xIncrement, int yIncrement) = _facing.Step();
        int xNext = _xPos + xIncrement;
        int yNext = _yPos + yIncrement;
        xNext = WrapCoordinates(xNext, _gridXSize);
        yNext = WrapCoordinates(yNext, _gridYSize);
        return (xNext, yNext);
    }

    public Rover(int gridXSize, int gridYSize)
    {
        _gridXSize = gridXSize;
        _gridYSize = gridYSize;
    }

    private string Position => (FacingObstacle ? "O:" : "") + _xPos + ":" + _yPos + ":" + _facing;

    public string ExecuteCommand(string commands)
    {
        foreach (char command in commands)
        {
            switch (command)
            {
                case 'M':
                    if (FacingObstacle)
                    {
                        return Position;
                    }

                    (int nextX, int nextY) = GetNextField();
                    _xPos = nextX;
                    _yPos = nextY;
                    break;
                case 'L':
                    _facing = _facing.TurnLeft();
                    break;
                case 'R':
                    _facing = _facing.TurnRight();
                    break;
            }
        }
        return Position;
    }

    private int WrapCoordinates(int coordinate, int maxCoordinate)
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

    public Rover AddObstacle(int obstacleXPosition, int obstacleYPosition)
    {
        if (!_obstacles.ContainsKey(obstacleXPosition))
        {
            _obstacles[obstacleXPosition] = new();
        }

        if (!_obstacles[obstacleXPosition].Contains(obstacleYPosition))
        {
            _obstacles[obstacleXPosition].Add(obstacleYPosition);
        }

        return this;
    }

    private bool IsFieldObstacle(int x, int y)
    {
        if (_obstacles.TryGetValue(x, out var obstacleY))
        {
            return obstacleY.Contains(y);
        }

        return false;
    }
}