using System.Collections.Generic;
using AdventOfCode.Days;

namespace AdventOfCode
{
    public class Submarine
    {
        private readonly DayOne _dayOne;
        private readonly DayTwo _dayTwo;
        private List<Day> _days;

        public Submarine()
        {
            _days = new List<Day>();
            _dayOne = new DayOne();
            _dayTwo = new DayTwo();
            _days.Add(new DayThree());
        }

        public void ReportDay01()
        {
            _dayOne.PartOne();
            _dayOne.PartTwo();
        }

        public void ReportDay02()
        {
            _dayTwo.PartOne();
            _dayTwo.PartTwo();
        }

        public void ReportDay03()
        {
            _days[0].PartOne();
            _days[0].PartTwo();
        }
    }
}