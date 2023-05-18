using System.Drawing;

public class Snake
{
    public List<Point> Body { get; set; }
    public Point Direction { get; set; }
    public bool IsGameOver { get; set; }

    public Snake()
    {
        Body = new List<Point>();
        Body.Add(new Point(5, 5));
        Direction = new Point(1, 0);
    }

    public void Move()
    {
        var head = Body.Last();
        var newHead = new Point(head.X + Direction.X, head.Y + Direction.Y);
        Body.Add(newHead);
        Body.RemoveAt(0);
    }

    public bool CollidesWith(Point point)
    {
        return Body.Any(b => b.X == point.X && b.Y == point.Y);
    }

    internal void Grow()
    {
        var head = Body.Last();
        var newHead = new Point(head.X + Direction.X, head.Y + Direction.Y);
        Body.Add(newHead);
    }
}