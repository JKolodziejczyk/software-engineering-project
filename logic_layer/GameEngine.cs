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
            items.readData();
            events.readData();
            locations.readData();
            buffs.readData();
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
            var stat = player.getStats();
            string[] statsNames = { "Atak", "Obrona", "Szczęście", "Zdrowie", "Energia", "Psycha", "Złoto" };
            for(int i = 0; i < stat.Length; i++)
            {
                Console.WriteLine($"{statsNames[i]}: {stat[i]}");
            }
        }

        public void showItems()
        {
            Item[] items = player.getItems();
            string[] types = player.getSlotTypes();
            for(int i = 0; i < items.Length; i++)
            {
                if (items[i] != null) Console.WriteLine($"Slot {i + 1} ({types[i]}). {items[i]._name} {items[i].getStats()}");
                else Console.WriteLine($"Slot {i + 1} ({types[i]}). Puste");
            }
        }

        public void showBuffs()
        {
            Buff[] buffs = player.getBuffs();
            for(int i = 0; i < buffs.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {buffs[i].name} efekt: {buffs[i].getStats()}");
            }
        }

        public void newGame()
        {
            bool error = false;
            while (true)
            {
                Console.Clear();
                printCenter("=====Nowa Gra=====");
                Console.WriteLine("Wybierz klasę postaci:");
                Console.WriteLine("1. Berserker");
                Console.WriteLine("2. Rycerz");
                Console.WriteLine("3. Złodziej\n");
                if (error) Console.WriteLine("Podałeś złą opcję!");
                Console.Write("Twój wybór: ");
                var _class = Console.ReadLine().Trim();
                switch (_class)
                {
                    case "1":
                        {
                            player = new Berserker();
                            error = false;
                            break;
                        }
                    case "2":
                        {
                            player = new Knight();
                            error = false;
                            break;
                        }
                    case "3":
                        {
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
            eventBuilder.setPlayerType(player.classId);
            currEvent = eventBuilder.initialEvent();
        }

        public void showStatsScreen()
        {
            Console.Clear();
            printCenter("=====Statystyki=====");
            Console.WriteLine($"Klasa postaci: {player.getClass()}");
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
            Console.WriteLine(currEvent.location.desc+"\n");
            Console.WriteLine(currEvent.desc);
            Console.WriteLine("\n");
            Console.WriteLine("Wybory:");
            Console.WriteLine("0. Statystyki");
            for (int i = 0; i < currEvent.choices.Length; i++)
            {
                Console.WriteLine($"{i + 1}. " + currEvent.choices[i].desc);
            }
            Console.WriteLine("\n");
            if (error) Console.WriteLine("Podałeś złą opcję!");
            Console.Write("Twój wybór: ");
        }

        public void showAfterEventScreen(Choice choice) //TODO: wyifowac sklepikarza
        {
            Random random = new();
            string[] statsNames = { "Atak", "Obrona", "Szczęście", "Zdrowie", "Energia", "Psycha", "Złoto" };
            int[] lastStats = player.getStats();
            Buff[] buffs;
            double val = random.NextDouble();
            double chance = choice.chance;
            for(int i = 0; i < choice.flags.Length; i++)
            {
                chance += choice.flags[i] * player.getStats()[i] / 100;
            }
            Console.Clear();
            printCenter("=====Podsumowanie=====");
            if(val <= chance) //Wygrana
            {
                Console.WriteLine(choice.win);
                player.changeStats(choice.statsWin);
                player.addBuffs(choice.buffsWin);
                buffs = choice.buffsWin;
            }
            else //Przegrana
            {
                Console.WriteLine(choice.lose);
                player.changeStats(choice.statsLose);
                player.addBuffs(choice.buffsLose);
                buffs = choice.buffsLose;
            }
            int[] newStats = player.getStats();

            Console.WriteLine("\nPodsumowanie statystyk");
            for(int i = 0; i < newStats.Length; i++)
            {
                Console.WriteLine($"{statsNames[i]}: {lastStats[i]} -> {newStats[i]}");
            }
            Console.WriteLine("\nPrzedmioty:");
            showItems();
            Console.WriteLine("\nDodane efekty:");
            int idx = 0;
            foreach(Buff buff in buffs)
            {
                Console.WriteLine($"{idx++}. {buff.name}: {buff.getStats()}");
            }
            if(choice.item != null) { }
            else { }
            Console.WriteLine("\n\nNaciśnij dowolny przycisk aby kontynuować...");
            Console.ReadKey();
        }

        public void showChooseNextEvent(Event[] events)
        {
            bool error = false;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(currEvent.location.next_event);
                Console.WriteLine("\n");
                Console.WriteLine("Wybory:");
                for (int i = 0; i < events.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {events[i].location.name}");
                }
                Console.WriteLine("\n");
                if (error) Console.WriteLine("Podałeś złą opcję!");
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
                currEvent = events[locationIdx - 1];
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
                player.apply_buffs();
                if (player.is_dead() != 0) break;

                showChooseNextEvent(eventBuilder.nextEvents());
            }
            //Death_event
            currEvent = eventBuilder.deathEvent(player.is_dead());
            Console.Clear();
            printCenter("=====Umarłeś=====");
            Console.WriteLine(currEvent.desc);
            Console.WriteLine("\n\nNaciśnij dowolny przycisk aby kontynuować...");
            Console.ReadKey();
        }

    }
}
