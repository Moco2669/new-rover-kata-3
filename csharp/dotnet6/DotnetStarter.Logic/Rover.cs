using System;
using System.Collections.Generic;

namespace DotnetStarter.Logic;

public class Rover
{
    private Orientation _facing = new North();
    private Field _position = new Field(0, 0);
    private Grid _grid;

    private Field Next => GetNextField();
    private bool FacingObstacle => _grid.IsFieldObstacle(Next);

    public Rover(Grid grid)
    {
        _grid = grid;
    }
    
    private Field GetNextField()
    {
        Field step = _facing.Step();
        Field next = _position + step;
        next = _grid.WrapCoordinates(next);
        return next;
    }

    private string Position => (FacingObstacle ? "O:" : "") + _position.X + ":" + _position.Y + ":" + _facing;

    public string ExecuteCommand(string commands)
    {
        foreach (char command in commands)
        {
            switch (command)
            {
                case 'M':
                    if (FacingObstacle) return Position;
                    _position = Next;
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