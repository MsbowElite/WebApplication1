using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbMemory
    {

        private static DbMemory _db;

        public static void Initialize()
        {
            GenerateDatabase();
        }

        private static void GenerateDatabase()
        {
            List<State> states = GenerateStates();
            List<Person> persons = GeneratePersons(states);

            _db = new DbMemory { States = states, Persons = persons };
        }

        private static List<State> GenerateStates()
        {

            return new List<State>()
            {
                    new State()
                    {
                        Id = 1,
                        Name = "AC"
                    },
                    new State()
                    {
                        Id = 2,
                        Name = "AL"
                    },
                    new State()
                    {
                        Id = 3,
                        Name = "AP"
                    },
                    new State()
                    {
                        Id = 4,
                        Name = "AM"
                    },
                    new State()
                    {
                        Id = 5,
                        Name = "BA"
                    },
                    new State()
                    {
                        Id = 6,
                        Name = "CE"
                    },
                    new State()
                    {
                        Id = 7,
                        Name = "DF"
                    },
                    new State()
                    {
                        Id = 8,
                        Name = "ES"
                    },
                    new State()
                    {
                        Id = 9,
                        Name = "GO"
                    },
                    new State()
                    {
                        Id = 10,
                        Name = "MA"
                    },

            };

        }

        private static List<Person> GeneratePersons(List<State> states)
        {

            int counter = 1;
            List<Person> persons = new List<Person>();

            foreach (var state in states)
            {
                persons.Add(new Person() { Id = counter, Name = String.Concat("Joao", counter), StateId = state.Id });
            }

            return persons;
        }
    }
}
