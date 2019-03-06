using Assignment5.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Assignment 5 - Pokemon Edition");
            PokemonReader reader = new PokemonReader();
            if (!File.Exists("pokemon151.xml"))
            {
                throw new Exception("File doesn't exist: pokemon151.xml");
            }
            Pokedex pokedex = reader.Load("pokemon151.xml");
            PokemonBag Bag = new PokemonBag();
            Pokedex PokedexforBag = new Pokedex();
            // List out all the pokemons loaded
            
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                Console.WriteLine(pokemon.Name);

            }
            Bag.Pokemons.Add(pokedex.GetPokemonByName("Bulbasaur").Index);
            Bag.Pokemons.Add(pokedex.GetPokemonByName("Bulbasaur").Index);
            Bag.Pokemons.Add(pokedex.GetPokemonByName("Charizard").Index);
            Bag.Pokemons.Add(pokedex.GetPokemonByName("Dragonite").Index);
            Bag.Pokemons.Add(pokedex.GetPokemonByName("Mew").Index);
            Console.WriteLine("");
            // Check What pokemon has the highest point.
            pokedex.GetHighestAttackPokemon();
            pokedex.GetHighestDefensePokemon();
            pokedex.GetHighestHPPokemon();
            pokedex.GetHighestMaxCPPokemon();
            Console.WriteLine("");
            // TODO: Add a pokemon bag with 2 bulbsaur, 1 charlizard, 1 mew and 1 dragonite
            // and save it out and load it back and list it out.
            for (int i = 0; i < Bag.Pokemons.Count; i++)
            {
                for (int f = 0; f < pokedex.Pokemons.Count; f++)
                {
                    if (Bag.Pokemons[i] == pokedex.Pokemons[f].Index)
                    {
                        PokedexforBag.Pokemons.Add(pokedex.Pokemons[f]); // PokedexforBag is from the class of Pokedex
                    }
                }
            }
            reader.Save("Mybag.xml", PokedexforBag);
            PokemonReader reader2 = new PokemonReader();
            pokedex = reader.Load("Mybag.xml");
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                Console.WriteLine(pokedex.GetPokemonByIndex(pokemon.Index).Name);
            }
            
            Console.ReadKey();
        }
    }
}
