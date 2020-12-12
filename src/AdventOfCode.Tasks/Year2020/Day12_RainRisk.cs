using AdventOfCode.Shared.Contracts;
using AdventOfCode.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tasks.Year2020
{
    public class Day12_RainRisk : IAdventTask
    {
        private readonly IReadListFromFile _readListFromFile;

        public Day12_RainRisk(IReadListFromFile readListFromFile)
        {
            _readListFromFile = readListFromFile;
        }

        public Task<string> Execute(IEnumerable<string> parameters)
        {
            var part2 = false;
            var waypointX = 1;
            var waypointY = 1;

            if (parameters.Count() == 4)
            {
                part2 = bool.Parse(parameters.ElementAt(1));
                waypointX = int.Parse(parameters.ElementAt(2));
                waypointY = int.Parse(parameters.ElementAt(3));
            }

            var data = _readListFromFile.ReadFile(parameters.First()).ToList().Select(x => new RainRiskActionDto(x.Substring(0, 1), int.Parse(x.Substring(1))));

            if (part2)
                return Task.FromResult(GetManhattanDistancePart2(data, waypointX, waypointY).ToString());

            return Task.FromResult(GetManhattanDistancePart1(data).ToString());
        }

        private int GetManhattanDistancePart1(IEnumerable<RainRiskActionDto> data)
        {
            var x = 0;
            var y = 0;
            var direction = 1;

            foreach (var a in data)
            {
                switch (a.Action)
                {
                    case "N":
                        x += a.Value;
                        break;
                    case "E":
                        y += a.Value;
                        break;
                    case "S":
                        x -= a.Value;
                        break;
                    case "W":
                        y -= a.Value;
                        break;
                    case "L":
                        var changeDirection = direction - (a.Value / 90);
                        if (changeDirection < 0)
                            direction = 3 + changeDirection + 1;
                        else
                            direction = Math.Abs((changeDirection) % 4);
                        break;
                    case "R":
                        direction = Math.Abs((direction + (a.Value / 90)) % 4);
                        break;
                    case "F":
                        switch (direction)
                        {
                            case 0:
                                x += a.Value;
                                break;
                            case 1:
                                y += a.Value;
                                break;
                            case 2:
                                x -= a.Value;
                                break;
                            case 3:
                                y -= a.Value;
                                break;
                        }
                        break;
                }
            }

            return (Math.Abs(x) + Math.Abs(y));
        }

        //NorthWaypoint = 1
        //EastWaypoint = 10
        private int GetManhattanDistancePart2(IEnumerable<RainRiskActionDto> data, int waypointX, int waypointY)
        {
            var x = 0;
            var y = 0;

            foreach (var a in data)
            {
                switch (a.Action)
                {
                    case "N":
                        waypointX += a.Value;
                        break;
                    case "E":
                        waypointY += a.Value;
                        break;
                    case "S":
                        waypointX -= a.Value;
                        break;
                    case "W":
                        waypointY -= a.Value;
                        break;
                    case "L":
                    case "R":
                        var rotateLeftResult = RotateVertex(a.Action, a.Value, x, y, waypointX, waypointY);
                        waypointX = (int)rotateLeftResult.Item1;
                        waypointY = (int)rotateLeftResult.Item2;

                        //var directionLeftCount = (a.Value / 90);
                        //for (int i = 1; i <= directionLeftCount; i++)
                        //{
                        //    if ((northWaypoint >= 0 && eastWaypoint > 0) || (northWaypoint <= 0 && eastWaypoint < 0))
                        //    {
                        //        var tempNorthWaypoint = northWaypoint;
                        //        northWaypoint = eastWaypoint;
                        //        eastWaypoint = tempNorthWaypoint;

                        //        eastWaypoint *= -1;
                        //    }
                        //    else if ((northWaypoint > 0 && eastWaypoint <= 0) || (northWaypoint < 0 && eastWaypoint >= 0))
                        //    {
                        //        var tempNorthWaypoint = northWaypoint;
                        //        northWaypoint = eastWaypoint;
                        //        eastWaypoint = tempNorthWaypoint;

                        //        northWaypoint *= -1;
                        //    }
                        //}
                        break;
                    case "F":
                        var relativeXWaypoint = waypointX - x;
                        var relativeYWaypoint = waypointY - y;

                        x += a.Value * relativeXWaypoint;
                        y += a.Value * relativeYWaypoint;

                        waypointX = x + relativeXWaypoint;
                        waypointY = y + relativeYWaypoint;
                        break;
                }
            }

            return (Math.Abs(x) + Math.Abs(y));
        }

        private (double, double) RotateVertex(string direction, int degrees, int x, int y, int waypointX, int waypointY)
        {
            var relativeXWaypoint = waypointX - x;
            var relativeYWaypoint = waypointY - y;

            if(direction == "R")
            {
                degrees = 0 - degrees;
            }
            var resultNorth = x + relativeYWaypoint * SinDegrees(degrees) + relativeXWaypoint * CosDegrees(degrees);
            var resultEast = y + relativeYWaypoint * CosDegrees(degrees) - relativeXWaypoint * SinDegrees(degrees);

            return (resultNorth, resultEast);

            double SinDegrees(int angle)
            {
                return Math.Round(Math.Sin(angle * Math.PI / 180), 4);
            }

            double CosDegrees(int angle)
            {
                return Math.Round(Math.Cos(angle * Math.PI / 180), 4);
            }
        }
    }
}
