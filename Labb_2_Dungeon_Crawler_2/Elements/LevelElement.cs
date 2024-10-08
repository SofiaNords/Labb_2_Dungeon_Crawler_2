public abstract class LevelElement
{
    public virtual int PositionX { get; set; }
    public virtual int PositionY { get; set; }
    protected char Icon { get; set; }
    protected ConsoleColor Color { get; set; }

    public LevelElement(int x, int y, char icon, ConsoleColor color)
    {
        PositionX = x;
        PositionY = y;
        Icon = icon;
        Color = color;
    }


    public void Draw()
    {
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(PositionX, PositionY);
        Console.Write(Icon);
        Console.ResetColor();
    }

}