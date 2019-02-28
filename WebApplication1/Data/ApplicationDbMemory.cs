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

        public static DbMemory GetDb()
        {
            return _db;
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
                    new State()
                    {
                        Id = 11,
                        Name = "MT"
                    },
                    new State()
                    {
                        Id = 12,
                        Name = "MS"
                    },
                    new State()
                    {
                        Id = 13,
                        Name = "MG"
                    },
                    new State()
                    {
                        Id = 14,
                        Name = "PA"
                    },
                    new State()
                    {
                        Id = 15,
                        Name = "PB"
                    },
                    new State()
                    {
                        Id = 16,
                        Name = "PR"
                    },
                    new State()
                    {
                        Id = 17,
                        Name = "PE"
                    },
                    new State()
                    {
                        Id = 18,
                        Name = "PI"
                    },
                    new State()
                    {
                        Id = 19,
                        Name = "RJ"
                    },
                    new State()
                    {
                        Id = 20,
                        Name = "RN"
                    },
                    new State()
                    {
                        Id = 21,
                        Name = "RS"
                    },
                    new State()
                    {
                        Id = 22,
                        Name = "RO"
                    },
                    new State()
                    {
                        Id = 23,
                        Name = "RR"
                    },
                    new State()
                    {
                        Id = 24,
                        Name = "SC"
                    },
                    new State()
                    {
                        Id = 25,
                        Name = "SP"
                    },
                    new State()
                    {
                        Id = 26,
                        Name = "SE"
                    },
                    new State()
                    {
                        Id = 27,
                        Name = "TO"
                    },


            };

        }

        private static List<Person> GeneratePersons(List<State> states)
        {

            int counter = 1;
            List<Person> persons = new List<Person>();

            foreach (var state in states)
            {
                persons.Add(new Person() { Id = counter, Name = String.Concat("Joao", counter), StateId = state.Id, State = state });
                counter++;
            }

            return persons;
        }
    }
}
