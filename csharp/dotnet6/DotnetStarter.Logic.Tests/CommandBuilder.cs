namespace DotnetStarter.Logic.Tests;

public class CommandBuilder
{
    private string _command = "";

    public CommandBuilder TurnLeft()
    {
        _command += "L";
        return this;
    }

    public CommandBuilder TurnRight()
    {
        _command += "R";
        return this;
    }

    public CommandBuilder MoveTimes(int times)
    {
        for (int i = 0; i < times; ++i)
        {
            _command += "M";
        }

        return this;
    }

    public string Build()
    {
        return _command;
    }
}