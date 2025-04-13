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

    public override Field Step()
    {
        return new Field(0, -1);
    }

    public override string ToString()
    {
        return "S";
    }
}