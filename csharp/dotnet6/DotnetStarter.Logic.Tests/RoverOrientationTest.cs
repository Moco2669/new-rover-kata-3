using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverOrientationTest
{
    private Rover _rover;

    public RoverOrientationTest()
    {
        _rover = new RoverBuilder().CreateRover().Build();
    }
    
    [Fact]
    public void RoverTurnsWest()
    {
        Assert.Equal("0:0:W", _rover.ExecuteCommand("L"));
    }

    [Fact]
    public void RoverTurnsSouth()
    {
        Assert.Equal("0:0:S", _rover.ExecuteCommand("LL"));
    }

    [Fact]
    public void RoverTurnsEastTurningRight()
    {
        Assert.Equal("0:0:E", _rover.ExecuteCommand("R"));
    }

    [Fact]
    public void RoverWrapsAroundTurningLeft()
    {
        Assert.Equal("0:0:N", _rover.ExecuteCommand("LLLL"));
    }

    [Fact]
    public void RoverFacesSouthTurningRight()
    {
        Assert.Equal("0:0:S", _rover.ExecuteCommand("RR"));
    }

    [Fact]
    public void RoverFacesWestTurningRight()
    {
        Assert.Equal("0:0:W", _rover.ExecuteCommand("RRR"));
    }

    [Fact]
    public void RoverWrapsAroundTurningRight()
    {
        Assert.Equal("0:0:N", _rover.ExecuteCommand("RRRR"));
    }

    [Fact]
    public void RoverFacesEastTurningLeft()
    {
        Assert.Equal("0:0:E", _rover.ExecuteCommand("LLL"));
    }
}