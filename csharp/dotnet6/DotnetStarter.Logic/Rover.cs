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

    public Rover(int GridXSize, int GridYSize)
    {
        _gridXSize = GridXSize;
        _gridYSize = GridYSize;
    }

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
                    if (_xPos > _gridXSize)
                    {
                        _xPos = 0;
                    }
                    if (_yPos < 0)
                    {
                        _yPos = _gridYSize;
                    }

                    if (_xPos < 0)
                    {
                        _xPos = _gridXSize;
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