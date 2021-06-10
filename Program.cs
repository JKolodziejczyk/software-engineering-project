using System;
using RPG.logic_layer;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine gameEngine = GameEngine.instance;
            gameEngine.startGame();
        }
    }
}
