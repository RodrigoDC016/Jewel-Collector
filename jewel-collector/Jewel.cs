using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//alteração realizada por Rodrigo Cardador
namespace jewel_collector
{
    public enum JewelType
    {
        Red = 100,
        Green = 50,
        Blue = 10
    }

    public class Jewel
    {
        public int X { get; }
        public int Y { get; }
        public JewelType Type { get; }

        public Jewel(int x, int y, JewelType type)
        {
            X = x;
            Y = y;
            Type = type;
        }
    }
}
