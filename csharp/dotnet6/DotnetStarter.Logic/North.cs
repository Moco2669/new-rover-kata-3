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

    public override (int, int) Step()
    {
        return (0, 1);
    }

    public override string ToString()
    {
        return "N";
    }
}

public class West : Orientation
{
    public override Orientation TurnLeft()
    {
        return new South();
    }

    public override Orientation TurnRight()
    {
        return new North();
    }

    public override (int, int) Step()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return "W";
    }
}

public class South : Orientation
{
    public override Orientation TurnLeft()
    {
        return new East();
    }

    public override Orientation TurnRight()
    {
        return new West();
    }

    public override (int, int) Step()
    {
        return (0, -1);
    }

    public override string ToString()
    {
        return "S";
    }
}

public class East : Orientation
{
    public override Orientation TurnLeft()
    {
        return new North();
    }

    public override Orientation TurnRight()
    {
        return new South();
    }

    public override (int, int) Step()
    {
        return (1, 0);
    }

    public override string ToString()
    {
        return "E";
    }
}