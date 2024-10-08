public class Player : LevelElement
{
    public string Name { get; set; }

    public int HP { get; set; }

    public Player(int x, int y, char icon, ConsoleColor color) : base(x, y, icon, color)
    {
        Name = "Sofia";
        HP = 100;
    }
}