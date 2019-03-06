using Assignment5.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Assignment 5 - Pokemon Edition");
            PokemonReader reader = new PokemonReader();
            
            PokemonBag Bag = new PokemonBag();
            Pokedex PokedexforBag = new Pokedex();

            // TODO: load the pokemon151 xml
            string Pokemonfile = "pokemon151.xml";
            if (!File.Exists(Pokemonfile))
            {
                throw new Exception(string.Format("{0} does not exist", Pokemonfile));
            }
            Pokedex pokedex = reader.Load(Pokemonfile);
            // List out all the pokemons loaded
            Console.WriteLine("Pokemon list: ");
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                Console.WriteLine(pokemon.Name);
            }
            // TODO: Add item reader and print out all the items
            string ItemDataPath = "itemData.xml";
            if (!File.Exists(ItemDataPath))
            {
                throw new Exception(string.Format("{0} does not exist", ItemDataPath));
            }
            ItemsData itemsData = new ItemsData();
            using (var reader1 = new StreamReader(ItemDataPath))
            {
                XmlSerializer serializers = new XmlSerializer(typeof(ItemsData));
                try
                {
                    itemsData = serializers.Deserialize(reader1) as ItemsData;
                    Console.WriteLine("");
                    Console.WriteLine("Item list: ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Cannot load {0} due to the following {1}", ItemDataPath, ex.Message);
                }
                finally
                {
                    foreach (Item item in itemsData.Items)
                    {
                        Console.WriteLine(itemsData.FindItem(item.Name).Name);
                    }
                }
                
            }
                
            // TODO: hook up item data to display with the inventory

            var source = new Inventory()
            {
               ItemToQuantity =
                 new Dictionary<object, object> { { "Poke ball", 10 }, { "Potion", 10 } }
            };

            // TODO: move this into a inventory with a serialize and deserialize function.
            string inventoryFile = "inventory.xml";
            using (var writer = XmlWriter.Create(inventoryFile))
                (new XmlSerializer(typeof(Inventory))).Serialize(writer, source);

            using (var reader2 = new StreamReader(inventoryFile))
            {
                var serializer = new XmlSerializer(typeof(Inventory));
                try
                {
                    Inventory inventory = serializer.Deserialize(reader2) as Inventory;
                    if (inventory != null)
                    {
                        foreach (var item in inventory.ItemToQuantity)
                        {
                            Console.WriteLine("Item: {0} Quantity: {1}", item.Key, item.Value);
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Cannot load {0} due to the following {1}",
                        inventoryFile, ex.Message);
                }
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
            PokemonReader reader3 = new PokemonReader();
            pokedex = reader3.Load("Mybag.xml");
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                Console.WriteLine(pokedex.GetPokemonByIndex(pokemon.Index).Name);
            }
            Console.ReadKey();
        }
    }
}
