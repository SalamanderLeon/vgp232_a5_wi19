﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    [XmlRoot("ItemsData")]
    public class ItemsData
    {
        [XmlArray("Items")]
        [XmlArrayItem("Item")]
        public List<Item> Items { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ItemsData()
        {
            Items = new List<Item>();
        }

        /// <summary>
        /// Gets all the items that are equal or less than level requirement
        /// </summary>
        /// <param name="level">The minimum required level</param>
        /// <returns>List of items that meet the requirement</returns>
        public List<Item> UnlockedItemsAtLevel(int level)
        {
            // TODO: implement function to get all items and add unit to confirm it works.
            List<Item> items = new List<Item>();
            try
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (level >= items[i].UnlockRequirement)
                    {
                        items.Add(items[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Can't implement by {0}", ex.Message));
            }

            return items;
        }

        /// <summary>
        /// Gets the item with the matching name
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <returns>The item with the name specified or null if not found</returns>
        public Item FindItem(string name)
        {
            // TODO: implement function to find the item with the name specified.
            Item item = new Item();
            try
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].Name == name)
                    {
                        item.Name = Items[i].Name;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Can't implement by {0}", ex.Message));
            }

            return item;
        }
    }
}
