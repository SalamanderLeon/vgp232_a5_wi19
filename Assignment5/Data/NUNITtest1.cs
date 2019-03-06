using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignment5.Data
{
    [TestFixture]
    class NUNITtest1
    {
        [TestCase]
        public void CheckTheHighestAttack()
        {
            int Attack = 0;
            PokemonReader Reader = new PokemonReader();
            if (!File.Exists("pokemon151.xml"))
            {
                throw new Exception("File doesn't exist");
            }
            Pokedex pokedex = Reader.Load("pokemon151.xml");
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                if (pokemon.Attack > Attack)
                {
                    Attack = pokemon.Attack;
                }
            }
            pokedex.GetHighestAttackPokemon();
            Assert.AreEqual(Attack, pokedex.GetHighestAttackPokemon().Attack);
        }

        [TestCase]
        public void CheckTheHighestDefense()
        {
            int Defense = 0;
            PokemonReader Reader = new PokemonReader();
            if (!File.Exists("pokemon151.xml"))
            {
                throw new Exception("File doesn't exist");
            }
            Pokedex pokedex = Reader.Load("pokemon151.xml");
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                if (pokemon.Defense > Defense)
                {
                    Defense = pokemon.Defense;
                }
            }
            pokedex.GetHighestDefensePokemon();
            Assert.AreEqual(Defense, pokedex.GetHighestDefensePokemon().Defense);
        }

        [TestCase]
        public void CheckTheHighestHP()
        {
            int HP = 0;
            PokemonReader Reader = new PokemonReader();
            if (!File.Exists("pokemon151.xml"))
            {
                throw new Exception("File doesn't exist");
            }
            Pokedex pokedex = Reader.Load("pokemon151.xml");
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                if (pokemon.HP> HP)
                {
                    HP = pokemon.HP;
                }
            }
            pokedex.GetHighestHPPokemon();
            Assert.AreEqual(HP, pokedex.GetHighestHPPokemon().HP);
        }

        [TestCase]
        public void CheckTheHighestMaxCP()
        {
            int MaxCP = 0;
            PokemonReader Reader = new PokemonReader();
            if (!File.Exists("pokemon151.xml"))
            {
                throw new Exception("File doesn't exist");
            }
            Pokedex pokedex = Reader.Load("pokemon151.xml");
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                if (pokemon.MaxCP > MaxCP)
                {
                    MaxCP = pokemon.MaxCP;
                }
            }
            pokedex.GetHighestMaxCPPokemon();
            Assert.AreEqual(MaxCP, pokedex.GetHighestMaxCPPokemon().MaxCP);
        }

        [TestCase]
        public void CheckPokemonIndex()
        {
            int index = 120;
            PokemonReader Reader = new PokemonReader();
            if (!File.Exists("pokemon151.xml"))
            {
                throw new Exception("File doesn't exist");
            }
            Pokedex pokedex = Reader.Load("pokemon151.xml");
            for (int i = 0; i < pokedex.Pokemons.Count; i++)
            {
                if(pokedex.GetPokemonByIndex(index).Index == index)
                {
                    Assert.AreEqual(index, pokedex.GetPokemonByIndex(index).Index);
                }
            }
        }

        [TestCase]
        public void CheckPokemonName()
        {
            string name = "Mew";
            PokemonReader Reader = new PokemonReader();
            if (!File.Exists("pokemon151.xml"))
            {
                throw new Exception("File doesn't exist");
            }
            Pokedex pokedex = Reader.Load("pokemon151.xml");
            for (int i = 0; i < pokedex.Pokemons.Count; i++)
            {
                if (pokedex.GetPokemonByName(name).Name == name)
                {
                    Assert.AreEqual(name, pokedex.GetPokemonByName(name).Name);
                }
            }
        }

        [TestCase]
        public void CheckPokemonTypes()
        {
            string Type = "Poision";
            PokemonReader Reader = new PokemonReader();
            if (!File.Exists("pokemon151.xml"))
            {
                throw new Exception("File doesn't exist");
            }
            Pokedex pokedex = Reader.Load("pokemon151.xml");
            for (int i = 0; i < pokedex.Pokemons.Count; i++)
            {
                if (pokedex.GetPokemonByName(Type).Type1 == Type)
                {
                    Assert.AreEqual(Type, pokedex.GetPokemonsOfType(Type)[i].Type1);
                }
                if (pokedex.GetPokemonByName(Type).Type2 == Type)
                {
                    Assert.AreEqual(Type, pokedex.GetPokemonsOfType(Type)[i].Type2);
                }
            }
        }
        [TestCase]
        public void CheckSeiralization()
        {
            PokemonReader Reader = new PokemonReader();
            if (!File.Exists("pokemon151.xml"))
            {
                throw new Exception("File doesn't exist");
            }
            Pokedex pokedex = Reader.Load("pokemon151.xml");
            Pokedex PokedexforBag = new Pokedex();
            PokemonBag Bag = new PokemonBag();
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                if(pokemon.Name == "Pikachu")
                {
                    Bag.Pokemons.Add(pokemon.Index);
                    Bag.Pokemons.Add(pokemon.Index);
                }
                if(pokemon.Name == "Nidoking")
                {
                    Bag.Pokemons.Add(pokemon.Index);
                }
                
            }
            for (int i = 0; i < Bag.Pokemons.Count; i++)
            {
                for (int f = 0; f < pokedex.Pokemons.Count; f++)
                {
                    if (Bag.Pokemons[i] == pokedex.Pokemons[f].Index)
                    { 
                        PokedexforBag.Pokemons.Add(pokedex.Pokemons[f]);
                    }
                }
            }

            try
            {
                if(File.Exists("nUnitTest.xml"))
                {
                    File.Delete("nUnitTest.xml");
                }
                Reader.Save("nUnitTest.xml", PokedexforBag);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : {0}", ex);
            }
        }

    }
}
