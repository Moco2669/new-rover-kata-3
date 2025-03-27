using System;
using System.Collections.Generic;

namespace DotnetStarter.Logic;

public class Rover
{
    private Orientation _facing = new North();
    private int _xPos = 0;
    private int _yPos = 0;

    private int _gridXSize = Int32.MaxValue;
    private int _gridYSize = Int32.MaxValue;

    private string Position
    {
        get
        {
            return _xPos + ":" + _yPos + ":" + _facing;
        }
    }

    public string ExecuteCommand(string commands)
    {
        foreach (char command in commands)
        {
            switch (command)
            {
                case 'M':
                    (int xIncrement, int yIncrement) = _facing.Step();
                    _xPos += xIncrement;
                    _yPos += yIncrement;
                    if (_yPos > _gridYSize)
                    {
                        _yPos = 0;
                    }
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

    public void PutOnGrid(int gridXSize, int gridYSize)
    {
        _gridXSize = gridXSize;
        _gridYSize = gridYSize;
    }
}