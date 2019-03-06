using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    [XmlRoot("Pokedex")]
    public class Pokedex
    {
        [XmlArray("Pokemons")]
        [XmlArrayItem("Pokemon")]
        public List<Pokemon> Pokemons { get; set; }

        public Pokedex()
        {
            Pokemons = new List<Pokemon>();
        }

        public Pokemon GetPokemonByIndex(int index)
        {
            Pokemon poke = new Pokemon();
            for (int i = 0; i < Pokemons.Count; i++)
            {
                if (Pokemons[i].Index == index)
                {
                    poke.Index = Pokemons[i].Index;
                    Console.WriteLine(index);
                }
            }
            return poke;
        }

        public Pokemon GetPokemonByName(string name)
        {
            Pokemon poke = new Pokemon();
            for (int i = 0; i < Pokemons.Count; i++)
            {
                if (Pokemons[i].Name == name)
                {
                    poke.Name = Pokemons[i].Name;
                    Console.WriteLine(name);

                }
            }
            return poke;
        }

        public List<Pokemon> GetPokemonsOfType(string type)
        {
            List<Pokemon> poke = new List<Pokemon>();
            // Note to check both Type1 and Type2
            for (int i = 0; i < Pokemons.Count; i++)
            {
                if (Pokemons[i].Type1 == type)
                {
                    poke.Add(Pokemons[i]);
                    Console.WriteLine(type);
                }
                if (Pokemons[i].Type2 == type)
                {
                    poke.Add(Pokemons[i]);
                    Console.WriteLine(type);
                }
            }
            return poke;
        }

        public Pokemon GetHighestHPPokemon()
        {
            Pokemon poke = new Pokemon();
            int Highest = 0;
            string Name = "";
            for (int i = 0; i < Pokemons.Count; i++)
            {
                if (Pokemons[i].HP > Highest)
                {
                    Highest = Pokemons[i].HP;
                    Name = Pokemons[i].Name;
                }
            }
            poke.HP = Highest;
            poke.Name = Name;
            Console.WriteLine("The highest health point is {0}, and {1}", Highest, Name);
            return poke;
        }

        public Pokemon GetHighestAttackPokemon()
        {
            Pokemon poke = new Pokemon();
            int Highest = 0;
            string Name = "";
            for (int i = 0; i < Pokemons.Count; i++)
            {
                if (Pokemons[i].Attack > Highest)
                {
                    Highest = Pokemons[i].Attack;
                    Name = Pokemons[i].Name;
                }
            }
            poke.Attack = Highest;
            poke.Name = Name;
            Console.WriteLine("The highest attack is {0}, and {1}", Highest, Name);
            return poke;
        }

        public Pokemon GetHighestDefensePokemon()
        {
            Pokemon poke = new Pokemon();
            int Highest = 0;
            string Name = "";
            for (int i = 0; i < Pokemons.Count; i++)
            {
                if (Pokemons[i].Defense > Highest)
                {
                    Highest = Pokemons[i].Defense;
                    Name = Pokemons[i].Name;
                }
            }
            Console.WriteLine("The highest defense is {0}, {1}", Highest, Name);
            poke.Defense = Highest;
            poke.Name = Name;
            return poke;
        }

        public Pokemon GetHighestMaxCPPokemon()
        {
            Pokemon poke = new Pokemon();
            int Highest = 0;
            string Name = "";
            for (int i = 0; i < Pokemons.Count; i++)
            {
                if (Pokemons[i].MaxCP > Highest)
                {
                    Highest = Pokemons[i].MaxCP;
                    Name = Pokemons[i].Name;
                }
            }
            Console.WriteLine("The highest Max CP is {0}, and {1}", Highest, Name);
            poke.MaxCP = Highest;
            poke.Name = Name;
            return poke;
        }

    }
}