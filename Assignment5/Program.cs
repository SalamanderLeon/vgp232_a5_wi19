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
                XmlSerializer serializers = new XmlSerializer(typeof(Pokedex));
                try
                {
                    pokedex = serializers.Deserialize(reader) as Pokedex;
                    Console.WriteLine("File has been loaded: {0}", Pokemonfile);
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
            ItemsData itemsData = new ItemsData();
            using (var reader = new StreamReader(ItemDataPath))
            {
                XmlSerializer serializers = new XmlSerializer(typeof(ItemsData));
                try
                {
                    itemsData = serializers.Deserialize(reader) as ItemsData;
                    Console.WriteLine("File has been loaded: {0}", ItemDataPath);
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
