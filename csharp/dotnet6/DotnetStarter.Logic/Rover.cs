using System;
using System.Collections.Generic;

namespace DotnetStarter.Logic;

public class Rover
{
    private Orientation _facing = new North();
    private int _xPos = 0;
    private int _yPos = 0;

    private Grid _grid;

    private bool FacingObstacle
    {
        get
        {
            (int nextX, int nextY) = GetNextField();
            return _grid.IsFieldObstacle(nextX, nextY);
        }
    }

    public Rover(Grid grid)
    {
        _grid = grid;
    }
    
    private (int, int) GetNextField()
    {
        (int xIncrement, int yIncrement) = _facing.Step();
        int xNext = _xPos + xIncrement;
        int yNext = _yPos + yIncrement;
        (xNext, yNext) = _grid.WrapCoordinates(xNext, yNext);
        return (xNext, yNext);
    }

    private string Position => (FacingObstacle ? "O:" : "") + _xPos + ":" + _yPos + ":" + _facing;

    public string ExecuteCommand(string commands)
    {
        foreach (char command in commands)
        {
            switch (command)
            {
                case 'M':
                    if (FacingObstacle) return Position;

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
}