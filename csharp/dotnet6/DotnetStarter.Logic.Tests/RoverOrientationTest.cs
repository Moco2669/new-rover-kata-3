using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xunit;

namespace DotnetStarter.Logic.Tests;

public class RoverOrientationTest
{
    [Fact]
    public void RoverTurnsWest()
    {
        Rover rover = RoverBuilder.CreateRover();
        Assert.Equal("0:0:W", rover.ExecuteCommand("L"));
    }

    [Fact]
    public void RoverTurnsSouth()
    {
        Rover rover = RoverBuilder.CreateRover();
        Assert.Equal("0:0:S", rover.ExecuteCommand("LL"));
    }

    [Fact]
    public void RoverTurnsEastTurningRight()
    {
        Rover rover = RoverBuilder.CreateRover();
        Assert.Equal("0:0:E", rover.ExecuteCommand("R"));
    }

    [Fact]
    public void RoverWrapsAroundTurningLeft()
    {
        Rover rover = RoverBuilder.CreateRover();
        Assert.Equal("0:0:N", rover.ExecuteCommand("LLLL"));
    }

    [Fact]
    public void RoverFacesSouthTurningRight()
    {
        Rover rover = RoverBuilder.CreateRover();
        Assert.Equal("0:0:S", rover.ExecuteCommand("RR"));
    }

    [Fact]
    public void RoverFacesWestTurningRight()
    {
        Rover rover = RoverBuilder.CreateRover();
        Assert.Equal("0:0:W", rover.ExecuteCommand("RRR"));
    }

    [Fact]
    public void RoverWrapsAroundTurningRight()
    {
        Rover rover = RoverBuilder.CreateRover();
        Assert.Equal("0:0:N", rover.ExecuteCommand("RRRR"));
    }

    [Fact]
    public void RoverFacesEastTurningLeft()
    {
        Rover rover = RoverBuilder.CreateRover();
        Assert.Equal("0:0:E", rover.ExecuteCommand("LLL"));
    }
}