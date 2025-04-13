using System;
using System.Diagnostics.Metrics;
using System.Xml;

namespace DotnetStarter.Logic;

public class North : Orientation
{
    public override Orientation TurnLeft()
    {
        return new West();
    }

    public override Orientation TurnRight()
    {
        return new East();
    }

    public override Field Step()
    {
        return new Field(0, 1);
    }

    public override string ToString()
    {
        return "N";
    }
}