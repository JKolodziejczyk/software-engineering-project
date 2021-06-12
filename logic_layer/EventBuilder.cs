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
        Location[] _locations { get; set; }
        EventBase[] _events { get; set; }
        int lastId = -1;
        BuffBase[] _buffs { get; set; }
        Item[] _items { get; set; }
        int _playerType { get; set; }
        public Location[] locations { get { return _locations; } }

        public EventBase[] events { get { return _events; } }

        public BuffBase[] buffs { get { return _buffs; } }
        public Item[] items { get { return _items; } }

        private EventBuilder() { }

        public static EventBuilder instance
        {
            get
            {
                if(_instance == null)
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

        public void setItems(Item[] items)
        {
            _items = items;
        }

        public void setPlayerType(int type)
        {
            _playerType = type;
        }

        private Location[] chooseLocations(int[] locations)
        {
            Random random = new();
            Location[] res = new Location[3];
            int[] currLocations = new int[3];
            for (int i = 0; i < 3; i++)
            {
                while (true)
                {
                    int idLoc = random.Next(locations.Length);
                    bool found = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (currLocations[j] == locations[idLoc])
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        currLocations[i] = locations[idLoc];
                        break;
                    }
                }
            }
            for(int i = 0; i < 3; i++)
            {
                res[i] = _locations.Single(location => location.id == currLocations[i]);
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
                if (curr.item)
                {
                    item = _items[random.Next(_items.Length)];
                    while(true)
                    {
                        if (_playerType == 1 && (item.owner == 1 || (item.owner == 0 && item.type != 2))) break;
                        if (_playerType == 2 && (item.owner == 2 || item.owner == 0)) break;
                        if (_playerType == 3 && (item.owner == 3 || (item.owner == 0 && item.type != 2))) break;
                        item = _items[random.Next(_items.Length)];
                    }
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
                int id = random.Next(_events.Length - 4);
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
            Location location = _locations.Single(location => location.id == -1);
            Event res = new Event(start.id, start.desc, location, createChoices(start.choices));
            lastId = -1;
            return res;
        }

        public Event deathEvent(int type)
        {
            EventBase death = _events.Single(_event => _event.id == -1 - type);
            Event res = new Event(death.id, death.desc, null, null);
            return res;
        }
    }
}
