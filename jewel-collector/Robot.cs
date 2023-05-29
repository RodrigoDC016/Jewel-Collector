using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jewel_collector
{
    public class Robot
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int PreviousX { get; private set; }
        public int PreviousY { get; private set; }
        public List<Jewel> Bag { get; }

        public Robot(int x, int y)
        {
            X = x;
            Y = y;
            Bag = new List<Jewel>();
        }

        public void MoveNorth()
        {
            PreviousX = X;
            PreviousY = Y;
            X--;
        }

        public void MoveSouth()
        {
            PreviousX = X;
            PreviousY = Y;
            X++;
        }

        public void MoveWest()
        {
            PreviousX = X;
            PreviousY = Y;
            Y--;
        }

        public void MoveEast()
        {
            PreviousX = X;
            PreviousY = Y;
            Y++;
        }

        public void CollectJewel(Jewel jewel)
        {
            Bag.Add(jewel);
        }

        public void PrintBagStatus()
        {
            Console.WriteLine("Total de joias na sacola: " + Bag.Count);
            int totalValue = Bag.Sum(j => (int)j.Type);
            Console.WriteLine("Valor total das joias: " + totalValue);
        }
    }
}
