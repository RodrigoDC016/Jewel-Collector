using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Alteracao realizada por Rodrigo Cardador

namespace jewel_collector
{
    public class JewelCollector
    {

        public static void Main()
        {

            bool running = true;
            Map map = new Map(10, 10);

            Jewel redJewel_one = new Jewel(2, 8, JewelType.Red);
            Jewel redJewel_two = new Jewel(8, 8, JewelType.Red);
            Jewel greenJewel_one = new Jewel(9, 1, JewelType.Green);
            Jewel greenJewel_two = new Jewel(7, 6, JewelType.Green);
            Jewel blueJewel_one = new Jewel(3,4, JewelType.Blue);
            Jewel blueJewel_two = new Jewel(2, 1, JewelType.Blue);

            map.AddJewel(redJewel_one);
            map.AddJewel(redJewel_two);
            map.AddJewel(greenJewel_one);
            map.AddJewel(greenJewel_two);
            map.AddJewel(blueJewel_one);
            map.AddJewel(blueJewel_two);


            Obstacle waterObstacle_one = new Obstacle(5, 0, ObstacleType.Water);
            Obstacle waterObstacle_two = new Obstacle(5, 1, ObstacleType.Water);
            Obstacle waterObstacle_three = new Obstacle(5, 2, ObstacleType.Water);
            Obstacle waterObstacle_four = new Obstacle(5, 3, ObstacleType.Water);
            Obstacle waterObstacle_five = new Obstacle(5, 4, ObstacleType.Water);
            Obstacle waterObstacle_six = new Obstacle(5, 5, ObstacleType.Water);
            Obstacle waterObstacle_seven = new Obstacle(5, 6, ObstacleType.Water);
            Obstacle treeObstacle_one = new Obstacle(5,9, ObstacleType.Tree);
            Obstacle treeObstacle_two = new Obstacle(3, 9, ObstacleType.Tree);
            Obstacle treeObstacle_three = new Obstacle(8, 3, ObstacleType.Tree);
            Obstacle treeObstacle_four = new Obstacle(2, 5, ObstacleType.Tree);
            Obstacle treeObstacle_five = new Obstacle(1, 4, ObstacleType.Tree);

            map.AddObstacle(waterObstacle_one);
            map.AddObstacle(waterObstacle_two);
            map.AddObstacle(waterObstacle_three);
            map.AddObstacle(waterObstacle_four);
            map.AddObstacle(waterObstacle_five);
            map.AddObstacle(waterObstacle_six);
            map.AddObstacle(waterObstacle_seven);
            map.AddObstacle(treeObstacle_one);
            map.AddObstacle(treeObstacle_two);
            map.AddObstacle(treeObstacle_three);
            map.AddObstacle(treeObstacle_four);
            map.AddObstacle(treeObstacle_five);

            Robot robot = new Robot(0, 0);
            map.AddRobot(robot);

            map.PrintMap();

            do
            {

                Console.WriteLine("Enter the command: ");
                string command = Console.ReadLine();

                if (command.Equals("quit"))
                {
                    running = false;
                }
                else if (command.Equals("w"))
                {
                    robot.MoveNorth();
                }
                else if (command.Equals("a"))
                {
                    robot.MoveWest();
                }
                else if (command.Equals("s"))
                {
                    robot.MoveSouth();
                }
                else if (command.Equals("d"))
                {
                    robot.MoveEast();
                }
                else if (command.Equals("g"))
                {
                    Jewel jewelToCollect = map.GetJewelAtPosition(robot.X, robot.Y);
                    if (jewelToCollect != null)
                    {
                        robot.CollectJewel(jewelToCollect);
                        map.RemoveJewel(jewelToCollect);
                    }
                }
                // Imprimir o mapa atualizado
                map.UpdateRobotPosition(robot);
                map.PrintMap();

                // Imprimir status da sacola do robô
                robot.PrintBagStatus();
            } while (running);
        }
    }
}
