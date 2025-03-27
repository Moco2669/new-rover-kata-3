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

    public override (int, int) Step()
    {
        return (1, 0);
    }

    public override string ToString()
    {
        return "E";
    }
}