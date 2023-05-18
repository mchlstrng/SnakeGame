using System.Drawing;

public class Game
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int Score { get; set; }
    public Snake Snake { get; set; }
    public Point Food { get; set; }

    public Game(int width, int height)
    {
        Width = width;
        Height = height;
        Snake = new Snake();
        GenerateFood();
        Score = 0;
    }

    internal void Draw()
    {
        Console.Clear();
        //draw the game board
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                //draw the snake
                if (Snake.Body.Any(b => b.X == j && b.Y == i))
                {
                    Console.Write("O");
                }
                //draw the food
                else if (Food.X == j && Food.Y == i)
                {
                    Console.Write("X");
                }
                //draw the border
                else if (i == 0 || i == Height - 1 || j == 0 || j == Width - 1)
                {
                    Console.Write("#");
                }
                //draw the empty space
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
 
    }

    internal void Update()
    {
        //update the game state
        Snake.Move();
        if (Snake.Body.Last().X == Food.X && Snake.Body.Last().Y == Food.Y)
        {
            Snake.Grow();
            Score++;
            GenerateFood();
        }
    }

    private void GenerateFood()
    {
        var x = new Random().Next(1, Width - 1);
        var y = new Random().Next(1, Height - 1);
        Food = new Point(x, y);
    }
}