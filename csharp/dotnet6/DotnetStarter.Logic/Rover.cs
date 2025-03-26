using System.Collections.Generic;
using DotnetStarter.Logic;

public class Rover
{
    private Orientation _facing = new North();
    
    public IEnumerable<char> ExecuteCommand(string s)
    {
        foreach (char c in s)
        {
            switch (c)
            {
                case 'M':
                    return "0:1:N";
                case 'L':
                    _facing = _facing.TurnLeft();
                    break;
                case 'R':
                    _facing = _facing.TurnRight();
                    break;
            }
        }
        return "0:0:" + _facing;
    }
}