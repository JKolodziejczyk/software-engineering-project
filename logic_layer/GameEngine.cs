using System;
using System.Collections.Generic;
using System.IO;
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
            BuffsAdapter buffs = new(eventBuilder);
            EventAdapter events = new(eventBuilder);
            LocationsAdapter locations = new(eventBuilder);
            ItemsAdapter items = new(eventBuilder);
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

        public void showItems() //TODO: Dopisać to jak itemy będą skończone
        {
            Item[] items = player.getItems();
            for(int i = 0; i < items.Length; i++)
            {
                Console.WriteLine($"Slot {i + 1}. Item{i}");
            }
        }

        public void showBuffs()
        {
            Buff[] buffs = player.getBuffs();
            for(int i = 0; i < buffs.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {buffs[i].name} efekt: {buffs[i].stats}");
            }
        }

        public void newGame()
        {
            bool error = false;
            while(true){
                Console.Clear();
                printCenter("=====Nowa Gra=====");
                Console.WriteLine("Wybierz klasę postaci:");
                Console.WriteLine("1.Berserker");
                Console.WriteLine("2.Rycerz");
                Console.WriteLine("3.Złodziej");
                Console.WriteLine("\n");
                if (error) Console.WriteLine("Podałeś złą opcję.");
                Console.Write("Twój wybór: ");
                var _class = Console.ReadLine().Trim();
                switch (_class)
                {
                    case "1":
                        {
                            Console.WriteLine("Twoja postać to berserker");
                            player = new Berserker();
                            error = false;
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Twoja postać to rycerz");
                            player = new Knight();
                            error = false;
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Twoja postać to złodziej");
                            player = new Thief();
                            error = false;
                            break;
                        }
                    default:
                        {
                            error = true;
                            break;
                        }
                }
                    if (!error) break;
                }
            //currEvent = eventBuilder.initialEvent();
        }

        public void showStatsScreen()
        {
            Console.Clear();
            printCenter("=====Statystyki=====");
            Console.WriteLine($"Klasa postaci: {player.GetType()}");
            show_stats();
            Console.WriteLine("\nPrzedmioty:");
            showItems();
            Console.WriteLine("\nAktywne efekty:");
            showBuffs();
            Console.WriteLine("\n\nNaciśnij dowolny przycisk aby kontynuować...");
            Console.ReadKey();
        }


        public void showEventScreen(bool error = false)
        {
            Console.Clear();
            Console.WriteLine(currEvent.location.desc);
            Console.WriteLine(currEvent.desc);
            Console.WriteLine("\n\n\n");
            Console.WriteLine("Wybory:");
            for (int i = 0; i < currEvent.choices.Length; i++)
            {
                Console.WriteLine($"{i + 1}. " + currEvent.choices[i].desc);
            }
            Console.WriteLine("\n");
            if (error) Console.WriteLine("Podałeś złą opcję");
            Console.Write("Twój wybór: ");
        }

        public void showAfterEventScreen(Choice choice)
        {
            Console.ReadKey();
        }

        public void showChooseNextEvent(Event[] events)
        {
            bool error = false;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(currEvent.location.next_event);
                Console.WriteLine("\n\n\n");
                Console.WriteLine("Wybory:");
                for (int i = 0; i < events.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {events[i].location}");
                }
                Console.WriteLine("\n");
                if (error) Console.WriteLine("Podałeś złą opcję");
                Console.Write("Twój wybór: ");
                string input = Console.ReadLine();
                int locationIdx;
                if (!int.TryParse(input, out locationIdx))
                {
                    error = true;
                    continue;
                }
                if(locationIdx <= 0 || locationIdx > events.Length)
                {
                    error = true;
                    continue;
                }
                currEvent = events[locationIdx];
                break;
            }
        }

        public void printCenter(string s)
        {
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
        }
        public void startGame()
        {
            newGame();
            while (true)
            {
                bool error = false;
                int choiceIdx;
                while (true) //Pierwszy screen eventu
                {
                    showEventScreen(error);
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out choiceIdx))
                    {
                        error = true;
                        continue;
                    }
                    if (choiceIdx < 0 || choiceIdx > currEvent.choices.Length)
                    {
                        error = true;
                        continue;
                    }
                    if(choiceIdx == 0)
                    {
                        showStatsScreen();
                        error = false;
                    }
                    else
                    {
                        break;
                    }
                }

                showAfterEventScreen(currEvent.choices[choiceIdx - 1]);

                if (player.is_dead()) break;

                showChooseNextEvent(eventBuilder.nextEvents());
            }
            Console.WriteLine("Umarłeś");
            //Death_event
        }

    }
}
