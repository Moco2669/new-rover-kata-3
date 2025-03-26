using System.Collections.Generic;
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
}

public class Rover
{
    public IEnumerable<char> ExecuteCommand(string s)
    {
        switch (s)
        {
            case "M":
                return "0:1:N";
            case "L":
                return "0:0:W";
        }
        return "0:1:N";
    }
}