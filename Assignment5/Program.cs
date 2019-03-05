using Assignment5.Data;
using System;
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

            // TODO: load the pokemon151 xml
            string Pokemonfile = "pokemon151.xml";
            Pokedex pokedex = new Pokedex();
            if (!File.Exists(Pokemonfile))
            {
                throw new Exception(string.Format("{0} does not exist", Pokemonfile));
            }
            using (var reader = new StreamReader(Pokemonfile))
            {
                var serializers = new XmlSerializer(typeof(Pokedex));
                try
                {
                    pokedex = serializers.Deserialize(reader) as Pokedex;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Cannot load {0} due to the following {1}", Pokemonfile, ex.Message);
                }

            }

            // TODO: Add item reader and print out all the items
            string ItemDataPath = "itemData.xml";
            if (!File.Exists(ItemDataPath))
            {
                throw new Exception(string.Format("{0} does not exist", ItemDataPath));
            }
            using (var reader = new StreamReader(ItemDataPath))
            {
                var serializers = new XmlSerializer(typeof(ItemsData));
                try
                {
                    ItemsData itemsData = serializers.Deserialize(reader) as ItemsData;

                    foreach (Item item in itemsData.Items)
                {
                    Console.WriteLine("Name: {0}", item.Name);
                    Console.WriteLine("Requirement: {0}", item.UnlockRequirement);
                    Console.WriteLine("Description: {0}", item.Description);
                    Console.WriteLine("Effect: {0}", item.Effect);
                }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Cannot load {0} due to the following {1}", ItemDataPath, ex.Message);
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

            using (var reader = new StreamReader(inventoryFile))
            {
                var serializer = new XmlSerializer(typeof(Inventory));
                try
                {
                    Inventory inventory = serializer.Deserialize(reader) as Inventory;
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


            Console.ReadKey();
        }
    }
}
