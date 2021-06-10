using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.models;

namespace RPG.logic_layer
{
    public class GameEngine
    {
        EventBuilder eventBuilder;
        static GameEngine _instance;
        Event currEvent;


        private GameEngine() 
        {
            eventBuilder = EventBuilder.instance;
        }

        public static GameEngine instance 
        { 
            get
            {
                if(_instance == null)
                {
                    _instance = new();
                }
                return _instance;
            } 
        }

        public void newGame()
        {
            printCenter("=====Nowa Gra=====");
            Console.WriteLine("Wybierz klase postaci:");
            

            //currEvent = eventBuilder.initialEvent();
        }

        public void printCenter(string s)
        {
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
        }


        public void startGame()
        {
            newGame();
        }

    }
}
