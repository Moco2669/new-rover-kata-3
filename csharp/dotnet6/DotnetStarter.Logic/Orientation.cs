namespace DotnetStarter.Logic;

public abstract class Orientation
{
    public abstract Orientation TurnLeft();
    public abstract Orientation TurnRight();

    public abstract override string ToString();
}