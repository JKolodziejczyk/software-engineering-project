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
        private Player player;


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
        public void show_stats()
        {
            var stat = player.DisplayStats();
            Console.WriteLine("Atak: {0}",stat[0]);
            Console.WriteLine("Obrona: {0}",stat[1]);
            Console.WriteLine("Szczęście: {0}",stat[2]);
            Console.WriteLine("HP: {0}",stat[3]);
            Console.WriteLine("Energia: {0}",stat[4]);
            Console.WriteLine("Psycha: {0}",stat[5]);
            Console.WriteLine("Złoto: {0}",stat[6]);
        }
        public void newGame()
        {
            printCenter("=====Nowa Gra=====");
            Console.WriteLine("Wybierz klasę postaci:");
            Console.WriteLine("1.Berserker");
            Console.WriteLine("2.Rycerz");
            Console.WriteLine("3.Złodziej");
            bool avaiable_choise = false;
            while (!avaiable_choise)
            {
                var _class = Console.ReadLine();
                switch (_class)
                {
                    case "1" or "Berserker" or "berserker":
                    {
                        Console.WriteLine("Twoja postać to berserker");
                        player =new Berserker();
                        avaiable_choise = true;
                        break;
                    }
                    case "2" or "Rycerz" or "rycerz":
                    {
                        Console.WriteLine("Twoja postać to rycerz");
                        player =new Knight();
                        avaiable_choise = true;
                        break;
                    }
                    case "3" or "Złodziej" or "złodziej":
                    {
                        Console.WriteLine("Twoja postać to złodziej");
                        player =new Thief();
                        avaiable_choise = true;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Wybierz prawidłową opcję");
                        break;
                    }
                }
            }
            

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
            while (!player.is_dead())
            {
                //Events
            }
            Console.WriteLine("Umarłeś");
            //Death_event
        }

    }
}
