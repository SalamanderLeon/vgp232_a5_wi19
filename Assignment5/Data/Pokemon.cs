using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Data
{
    public class Pokemon
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int MaxCP { get; set; }
        public override string ToString()
        {
            return string.Format("Index: {0}\n" +
                "Name: {1}\n" +
                "Type1: {2}\n" +
                "Type2: {3}\n" +
                "HP: {4}\n" +
                "Attack: {5}\n" +
                "Defence: {6}\n" +
                "MaxCP: {7}", Index, Name, Type1, Type2, HP, Attack, Defense, MaxCP);
        }
    }
}