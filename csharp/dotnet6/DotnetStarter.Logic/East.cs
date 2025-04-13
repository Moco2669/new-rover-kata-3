namespace DotnetStarter.Logic;

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

    public override Field Step()
    {
        return new Field(1, 0);
    }

    public override string ToString()
    {
        return "E";
    }
}