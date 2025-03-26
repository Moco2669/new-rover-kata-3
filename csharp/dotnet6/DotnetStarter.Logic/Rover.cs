using System.Collections.Generic;

public class Rover
{
    private List<string> _orientations;
    private int _orientationIndex;

    private string _orientation
    {
        get
        {
            return _orientations[_orientationIndex];
        }
    }

    public Rover()
    {
        _orientations = new List<string>() { "N", "W", "S", "E"};
        _orientationIndex = 0;
    }
    
    public IEnumerable<char> ExecuteCommand(string s)
    {
        foreach (char c in s)
        {
            switch (c)
            {
                case 'M':
                    return "0:1:N";
                case 'L':
                    TurnLeft();
                    break;
                case 'R':
                    TurnRIght();
                    break;
            }
        }
        return "0:0:" + _orientation;
    }

    private void TurnRIght()
    {
        _orientationIndex--;
        WrapAroundOrientation();
    }

    private void TurnLeft()
    {
        _orientationIndex++;
        WrapAroundOrientation();
    }

    private void WrapAroundOrientation()
    {
        _orientationIndex = (_orientationIndex + 4) % 4;
    }
}