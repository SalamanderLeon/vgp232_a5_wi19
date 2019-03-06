using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;

namespace Assignment5.Data
{
    [TestFixture]
    class NUNITtest2
    {
        [TestCase]
        public void CheckFindItem()
        {
            string name = "Potion";
            string ItemPath = "itemData.xml";
            if(!File.Exists("itemData.xml"))
            {
                throw new Exception("File doesn't exist");
            }
            ItemsData itemsData = new ItemsData();
            using (var reader = new StreamReader(ItemPath))
            {
                XmlSerializer serializers = new XmlSerializer(typeof(ItemsData));
                try
                {
                    itemsData = serializers.Deserialize(reader) as ItemsData;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Cannot load {0} due to the following {1}", ItemPath, ex.Message);
                }
            }
            foreach (Item item in itemsData.Items)
            {
                if(item.Name == name)
                {
                    Assert.AreEqual(name, itemsData.FindItem(name).Name);
                }
            }
        }
        [TestCase]
        public void CheckUnlockItemsatLevel()
        {
            int Level = 13;
            string ItemPath = "itemData.xml";
            List<Item> items = new List<Item>();
            if (!File.Exists("itemData.xml"))
            {
                throw new Exception("File doesn't exist");
            }
            ItemsData itemsData = new ItemsData();
            using (var reader = new StreamReader(ItemPath))
            {
                XmlSerializer serializers = new XmlSerializer(typeof(ItemsData));
                try
                {
                    itemsData = serializers.Deserialize(reader) as ItemsData;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Cannot load {0} due to the following {1}", ItemPath, ex.Message);
                }
            }
            foreach (Item item in itemsData.Items)
            {
                if (Level <= item.UnlockRequirement)
                {
                    items.Add(item);
                }
            }
            Assert.AreEqual(6, items.Count);
            //Assert
        }
        [TestCase]
        public void CheckInventoryXML()
        {
            string InventoryPath = "NUnitTestforInventory.xml";
            var source = new Inventory()
            {
                ItemToQuantity =
                 new Dictionary<object, object> { { "Great ball", 25 } }
            };
            using (var writer = XmlWriter.Create(InventoryPath))
                (new XmlSerializer(typeof(Inventory))).Serialize(writer, source);

            using (var reader = new StreamReader(InventoryPath))
            {
                var serializer = new XmlSerializer(typeof(Inventory));
                try
                {
                    Inventory inventory = serializer.Deserialize(reader) as Inventory;
                    if (inventory != null)
                    {
                        foreach (var item in inventory.ItemToQuantity)
                        {
                            Assert.AreEqual("Great ball", item.Key);
                            Assert.AreEqual(25, item.Value);
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Cannot load {0} due to the following {1}",
                        InventoryPath, ex.Message);
                }

            }
        }
    }
}
