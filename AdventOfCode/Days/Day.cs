namespace AdventOfCode.Days
{
    public abstract class Day
    {
        private string _path;

        protected Day(string path)
        {
            this._path = path;
        }

        public abstract void PartOne();

        public abstract void PartTwo();
    }
}