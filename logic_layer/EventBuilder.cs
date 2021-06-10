using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.models;

namespace RPG.logic_layer
{
    public class EventBuilder
    {
        static EventBuilder _instance;
        Location[] _locations;
        EventBase[] _events;
        int lastId = -1;
        BuffBase[] _buffs;
        Item[] _items;

        public Location[] locations { get { return _locations; } }
        
        public EventBase[] events { get { return _events; } }

        public BuffBase[] buffs { get { return _buffs; } }

        public Item[] items { get { return _items; } }
        private EventBuilder() { }

        public static EventBuilder instance
        {
            get
            {
                if(instance == null)
                {
                    _instance = new EventBuilder();
                }
                return _instance;
            }
        }

        public void setLocations(Location[] locations)
        {
            _locations = locations;
        }

        public void setEvents(EventBase[] events)
        {
            _events = events;
        }

        public void setBuffs(BuffBase[] buffs)
        {
            _buffs = buffs;
        }

        private Location[] chooseLocations(int[] locations)
        {
            Random random = new();
            Location[] res = new Location[3];

            for (int i = 0; i < 3; i++)
            {
                while (true)
                {
                    int idLoc = random.Next(locations.Length - 1);
                    bool found = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (locations[j] == idLoc)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        locations[i] = idLoc;
                        break;
                    }
                }
            }
            for(int i = 0; i < 3; i++)
            {
                res[i] = _locations.Single(location => location.id == locations[i]);
            }
            return res;
        }

        private Buff[] findBuffs(int[] buffs)
        {
            Buff[] res = new Buff[buffs.Length];
            Random random = new();
            for(int i = 0; i < buffs.Length; i++)
            {
                BuffBase temp = _buffs.Single(buff => buff.id == buffs[i]);
                int time = random.Next(1, 5);
                res[i] = new Buff(temp, time);
            }
            return res;
        }

        private Choice[] createChoices(ChoiceBase[] choices)
        {
            Choice[] res = new Choice[choices.Length];
            Random random = new Random();

            for(int i = 0; i < res.Length; i++)
            {
                ChoiceBase curr = choices[i];
                Buff[] win = findBuffs(curr.buffsWin);
                Buff[] lose = findBuffs(curr.buffsLose);
                Item item = null;
                if (curr.item) //TODO: Filtrowac po klasie
                {
                    item = _items[random.Next(_items.Length - 1)];
                }
                res[i] = new Choice(curr.desc, curr.chance, curr.win, curr.lose, curr.statsWin, curr.statsLose, win, lose, curr.flags, item);
            }
            return res;
        }


        public Event[] nextEvents()
        {
            Random random = new();
            Event[] res = new Event[3];
            Location[] locations;
            Choice[] choices;
            while (true)
            {
                int id = random.Next(_events.Length - 1);
                if (id != lastId)
                {
                    EventBase curr = _events.Single(_event => _event.id == id);
                    locations = chooseLocations(curr.locations);
                    choices = createChoices(curr.choices);
                    for(int i = 0; i < 3; i++)
                    {
                        res[i] = new Event(curr.id, curr.desc, locations[i], choices);
                    }
                    lastId = id;
                    break;
                }
            }
            return res;
        }

        public Event initialEvent()
        {
            EventBase start = _events.Single(_event => _event.id == -1);
            Location location = _locations.Single(location => location.id == start.locations[0]);
            Event res = new Event(start.id, start.desc, location, createChoices(start.choices));
            lastId = -1;
            return res;
        }

        public Event deathEvent(int type) //TODO: poprawić to
        {
            EventBase death = _events.Single(_event => _event.id == -1 - type);
            Event res = new Event(death.id, death.desc, null, null);
            return res;
        }
    }
}
