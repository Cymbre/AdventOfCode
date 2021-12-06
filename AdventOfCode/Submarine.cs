using System.Collections.Generic;
using AdventOfCode.Days;

namespace AdventOfCode
{
    public class Submarine
    {
        private List<Day> _days;

        public Submarine()
        {
            _days = new List<Day>
            {
                new Day01(),
                new Day02(),
                new Day03(),
                new Day04(),
                new Day05(),
                new Day06()
            };
        }

        public void ReportDays()
        {
            foreach (var day in _days)
            {
                day.PartOne();
                day.PartTwo();
            }
        }

        public void ReportDay(int day)
        {
            _days[day - 1].PartOne();
            _days[day - 1].PartTwo();
        }

        public void ReportDayPart2(int day)
        {
            _days[day - 1].PartTwo();
        }
    }
}