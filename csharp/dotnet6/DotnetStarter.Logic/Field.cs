namespace DotnetStarter.Logic;

public class Field
{
    private int _x;
    private int _y;

    public int X => _x;
    public int Y => _y;

    public Field(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public static Field operator +(Field a, Field b)
    {
        return new Field(a._x + b._x, a._y + b._y);
    } 
}