var game = new Game(40, 20);

while (true)
{
    game.Draw();
    game.Update();
    Thread.Sleep(100);
}