namespace DotnetStarter.Logic;

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