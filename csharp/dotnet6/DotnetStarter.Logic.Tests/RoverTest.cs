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
}

public class Rover
{
    public IEnumerable<char> ExecuteCommand(string s)
    {
        return "0:1:N";
    }
}