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
    class NUNITtest2
    {
        [TestCase]
        public void CheckFindItem()
        {
            string name = "Potion";
            if(!File.Exists("itemData.xml"))
            {
                throw new Exception("File doesn't exist");
            }
            ItemsData itemsData = new ItemsData();
            // Need to deserialization: itemData.xml
            foreach(Item item in itemsData.Items)
            {
                if(item.Name == name)
                {
                    Assert.AreEqual(name, itemsData.FindItem(name).Name);
                }
            }
        }
        [TestCase]
        public void UnlockItemsatLevel()
        {
            int Level = 13;
            List<Item> items = new List<Item>();
            if (!File.Exists("itemData.xml"))
            {
                throw new Exception("File doesn't exist");
            }
            ItemsData itemsData = new ItemsData();
            // Need to deserialization: itemData.xml
            foreach (Item item in itemsData.Items)
            {
                if (Level >= item.UnlockRequirement)
                {
                    items.Add(item);
                }
            }
            Assert.AreEqual(6, items.Count);
            //Assert
        }
    }
}
