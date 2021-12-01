using AdventOfCode.Days;

namespace AdventOfCode
{
    public class Submarine
    {
        private readonly DayOne _dayOne;
        private readonly DayTwo _dayTwo;

        public Submarine()
        {
            const string path = "..//..//..//InputFiles//";
            _dayOne = new DayOne(path + "day1.txt");
            _dayTwo = new DayTwo(path + "day2.txt");
        }

        public void ReportDayOne()
        {
            _dayOne.PartOne();
            _dayOne.PartTwo();
        }

        public void ReportDayTwo()
        {
            _dayTwo.PartOne();
            _dayTwo.PartTwo();
        }
    }
}