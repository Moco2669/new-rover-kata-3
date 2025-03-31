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
        if (yNext > _gridYSize)
        {
            yNext = 0;
        }
        if (xNext > _gridXSize)
        {
            xNext = 0;
        }
        if (yNext < 0)
        {
            yNext = _gridYSize;
        }
        if (xNext < 0)
        {
            xNext = _gridXSize;
        }
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
                    (int xIncrement, int yIncrement) = _facing.Step();
                    int xTemp = _xPos + xIncrement;
                    int yTemp = _yPos + yIncrement;
                    if (yTemp > _gridYSize)
                    {
                        yTemp = 0;
                    }
                    if (xTemp > _gridXSize)
                    {
                        xTemp = 0;
                    }
                    if (yTemp < 0)
                    {
                        yTemp = _gridYSize;
                    }
                    if (xTemp < 0)
                    {
                        xTemp = _gridXSize;
                    }

                    if (IsFieldObstacle(xTemp, yTemp))
                    {
                        return Position;
                    }
                    _xPos = xTemp;
                    _yPos = yTemp;
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
        if (_obstacles.ContainsKey(x))
        {
            return _obstacles[x].Contains(y);
        }

        return false;
    }
}