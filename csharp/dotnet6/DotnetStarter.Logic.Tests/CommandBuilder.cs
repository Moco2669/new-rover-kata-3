namespace DotnetStarter.Logic.Tests;

public class CommandBuilder
{
    private string command = "";

    public CommandBuilder TurnLeft()
    {
        command += "L";
        return this;
    }

    public CommandBuilder TurnRight()
    {
        command += "R";
        return this;
    }

    public CommandBuilder MoveTimes(int times)
    {
        for (int i = 0; i < times; ++i)
        {
            command += "M";
        }

        return this;
    }

    public string Build()
    {
        return command;
    }
}