using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverTest
{
    [Fact]
    public void RoverMoves()
    {
        Rover rover = new();
        Assert.Equal("0:1:N", rover.ExecuteCommand("M"));
    }

    [Fact]
    public void RoverTurnsWest()
    {
        Rover rover = new();
        Assert.Equal("0:0:W", rover.ExecuteCommand("L"));
    }

    [Fact]
    public void RoverTurnsSouth()
    {
        Rover rover = new();
        Assert.Equal("0:0:S", rover.ExecuteCommand("LL"));
    }
}

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
        _orientations = new List<string>() { "N", "W", "S" };
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
                    _orientationIndex++;
                    break;
            }
        }
        return "0:0:" + _orientation;
    }
}