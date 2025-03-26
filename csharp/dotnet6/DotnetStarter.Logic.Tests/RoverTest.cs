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

    [Fact]
    public void RoverTurnsEastTurningRight()
    {
        Rover rover = new();
        Assert.Equal("0:0:E", rover.ExecuteCommand("R"));
    }

    [Fact]
    public void RoverWrapsAroundTurningLeft()
    {
        Rover rover = new();
        Assert.Equal("0:0:N", rover.ExecuteCommand("LLLL"));
    }

    [Fact]
    public void RoverFacesSouthTurningRight()
    {
        Rover rover = new();
        Assert.Equal("0:0:S", rover.ExecuteCommand("RR"));
    }

    [Fact]
    public void RoverFacesWestTurningRight()
    {
        Rover rover = new();
        Assert.Equal("0:0:W", rover.ExecuteCommand("RRR"));
    }
}