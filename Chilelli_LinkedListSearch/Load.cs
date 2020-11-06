using System;
using System.IO;

namespace Chilelli_LinkedListSearch
{
    class Load
    {
        public static LinkedList LoadFile()
        {
            string line;
            string varies = "";
            char tG = 'T';
            string tN = "";
            int tR = -1;
            MetaData tMD;
            LinkedList list = new LinkedList();
            string filePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "yob2019.txt");
            StreamReader file = new StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                for (int c = 0; c < line.Length; c++)
                {
                    if (line[c] != ',') { varies += line[c]; }
                    if (line[c] == ',')
                    {
                        c++;
                        tN = varies;
                        tG = line[c];
                        c += 2;
                        varies = "";
                        while (c < line.Length)
                        {
                            varies += line[c];
                            c++;
                        }
                        Int32.TryParse(varies, out tR);
                    }
                }
                tMD = new MetaData(tG, tN, tR);
                list.Add(tMD);
                varies = "";
            }
            file.Close();
            return list;
        }
    }
}
