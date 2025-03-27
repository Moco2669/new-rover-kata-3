namespace DotnetStarter.Logic;

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
        return (-1, 0);
    }

    public override string ToString()
    {
        return "W";
    }
}