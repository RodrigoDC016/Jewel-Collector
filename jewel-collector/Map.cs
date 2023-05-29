using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jewel_collector;

namespace jewel_collector
{
    public class Map
    {
        private string[,] map;

        public Map(int width, int height)
        {
            map = new string[width, height];
            InitializeMap();
        }

        private void InitializeMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = "--";
                }
            }
        }

        public void AddJewel(Jewel jewel)
        {
            string symbol = GetJewelSymbol(jewel.Type);
            map[jewel.X, jewel.Y] = symbol;
        }

        public void AddObstacle(Obstacle obstacle)
        {
            string symbol = GetObstacleSymbol(obstacle.Type);
            map[obstacle.X, obstacle.Y] = symbol;
        }

        public void RemoveJewel(Jewel jewel)
        {
            map[jewel.X, jewel.Y] = "--";
        }

        public void PrintMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private string GetJewelSymbol(JewelType type)
        {
            switch (type)
            {
                case JewelType.Red:
                    return "JR";
                case JewelType.Green:
                    return "JG";
                case JewelType.Blue:
                    return "JB";
                default:
                    return "--";
            }
        }

        public void AddRobot(Robot robot)
        {
            map[robot.X, robot.Y] = "ME";
        }

        private string GetObstacleSymbol(ObstacleType type)
        {
            switch (type)
            {
                case ObstacleType.Water:
                    return "##";
                case ObstacleType.Tree:
                    return "$$";
                default:
                    return "--";
            }
        }

        public void UpdateRobotPosition(Robot robot)
        {
            map[robot.X, robot.Y] = "ME";
            map[robot.PreviousX, robot.PreviousY] = "--";
        }

        public Jewel GetJewelAtPosition(int x, int y)
        {
            // Verificar joia à esquerda do robô
            if (x > 0 && (map[x - 1, y] is "JR" || map[x - 1, y] is "JG" || map[x - 1, y] is "JB"))
            {
                JewelType type;
                switch (map[x - 1, y])
                {
                    case "JR":
                        type = JewelType.Red;
                        break;
                    case "JG":
                        type = JewelType.Green;
                        break;
                    case "JB":
                        type = JewelType.Blue;
                        break;
                    default:
                        return null;
                }
                return new Jewel(x - 1, y, type);
            }

            // Verificar joia à direita do robô
            if (x < map.GetLength(0) - 1 && (map[x + 1, y] is "JR" || map[x + 1, y] is "JG" || map[x + 1, y] is "JB"))
            {
                JewelType type;
                switch (map[x + 1, y])
                {
                    case "JR":
                        type = JewelType.Red;
                        break;
                    case "JG":
                        type = JewelType.Green;
                        break;
                    case "JB":
                        type = JewelType.Blue;
                        break;
                    default:
                        return null;
                }
                return new Jewel(x + 1, y, type);
            }

            // Verificar joia acima do robô
            if (y > 0 && (map[x, y - 1] is "JR" || map[x, y - 1] is "JG" || map[x, y - 1] is "JB"))
            {
                JewelType type;
                switch (map[x, y - 1])
                {
                    case "JR":
                        type = JewelType.Red;
                        break;
                    case "JG":
                        type = JewelType.Green;
                        break;
                    case "JB":
                        type = JewelType.Blue;
                        break;
                    default:
                        return null;
                }
                return new Jewel(x, y - 1, type);
            }

            // Verificar joia abaixo do robô
            if (y < map.GetLength(1) - 1 && (map[x, y + 1] is "JR" || map[x, y + 1] is "JG" || map[x, y + 1] is "JB"))
            {
                JewelType type;
                switch (map[x, y + 1])
                {
                    case "JR":
                        type = JewelType.Red;
                        break;
                    case "JG":
                        type = JewelType.Green;
                        break;
                    case "JB":
                        type = JewelType.Blue;
                        break;
                    default:
                        return null;
                }
                return new Jewel(x, y + 1, type);
            }

            return null; // Não há joias adjacentes à posição do robô
        }
    }

}
