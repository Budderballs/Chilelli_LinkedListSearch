namespace Chilelli_LinkedListSearch
{
    class MetaData
    {
        private char gender;
        private string name;
        private int rank;
        private static int countAllNodes = 0;
        private static int fCount = 0;
        private static int mCount = 0;


        public MetaData(char gender, string name, int rank)
        {
            this.gender = gender;
            this.name = name;
            this.rank = rank;
            countAllNodes++;
            countGender();
        }
        public char Gender { get { return gender; } }
        public string Name { get { return name; } }
        public int Rank { get { return rank; } }
        public int countNodes { get { return countAllNodes; } }
        public int countM { get { return mCount; } }
        public int countF { get { return fCount; } }
        private void countGender()
        {
            if (Gender == 'M') { mCount++; }
            else { fCount++; }
        }
    }
}
