using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jewel_collector
{
    public enum ObstacleType
    {
        Water,
        Tree
    }

    public class Obstacle
    {
        public int X { get; }
        public int Y { get; }
        public ObstacleType Type { get; }

        public Obstacle(int x, int y, ObstacleType type)
        {
            X = x;
            Y = y;
            Type = type;
        }
        
    }
}
