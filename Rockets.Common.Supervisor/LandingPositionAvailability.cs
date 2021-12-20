using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rockets.Common.Supervisor
{
    public class LandingPositionAvailability
    {
        static Dictionary<string, string> _ReservedAreas = new Dictionary<string, string>();
        static int startX = 5;
        static int startY = 5;
        static int PlatformSquareSize = 10;

        static int endX = startX + PlatformSquareSize;
        static int endY = startY + PlatformSquareSize;

        public string LandingPermission(string position)
        {
            ValidateRequest(position);

            int x, y = 0;

            var list = position.Split(',');

            if (!Int32.TryParse(list[0], out x) ||
                !Int32.TryParse(list[1], out y))
            {
                throw new Exception("A valid position must be supplied.");
            }

            if (x <= endX && x >= startX && y <= endY && y >= startY)
            {
                if (_ReservedAreas.ContainsKey(position))
                {
                    return "Clash";
                }
                else
                {
                    ReserveAreaOperation(x, y, position);

                    return "Ok for landing";
                }
            }
            else
            {
                return "Out of platform";
            }


        }

        private void ValidateRequest(string position)
        {
            if (string.IsNullOrEmpty(position) || !position.Contains(","))
            {
                throw new Exception("A valid position must be supplied.");
            }
        }

        private void ReserveAreaOperation(int x, int y, string position)
        {
            string position1 = $"{x - 1},{y}",
                   position2 = $"{x - 1},{y - 1}",
                   position3 = $"{x - 1},{y + 1}",
                   position4 = $"{x},{y + 1}",
                   position5 = $"{x},{y - 1}",
                   position6 = $"{x + 1},{y - 1}",
                   position7 = $"{x + 1},{y + 1}",
                   position8 = $"{x + 1},{y}";

            _ReservedAreas.Add(position, "");
            if (!_ReservedAreas.ContainsKey(position1))
                _ReservedAreas.Add(position1, "");
            if (!_ReservedAreas.ContainsKey(position2))
                _ReservedAreas.Add(position2, "");
            if (!_ReservedAreas.ContainsKey(position3))
                _ReservedAreas.Add(position3, "");
            if (!_ReservedAreas.ContainsKey(position4))
                _ReservedAreas.Add(position4, "");
            if (!_ReservedAreas.ContainsKey(position5))
                _ReservedAreas.Add(position5, "");
            if (!_ReservedAreas.ContainsKey(position6))
                _ReservedAreas.Add(position6, "");
            if (!_ReservedAreas.ContainsKey(position7))
                _ReservedAreas.Add(position7, "");
            if (!_ReservedAreas.ContainsKey(position8))
                _ReservedAreas.Add(position8, "");
        }
    }
}
