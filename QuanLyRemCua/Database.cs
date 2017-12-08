using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRemCua
{
    class Database
    {
        public static List<Curtain> curtains = new List<Curtain>();

        public static void UpdateDatabase()
        {
            List<string> lines = new List<string>();
            foreach (Curtain curtain in curtains) {
                StringBuilder line = new StringBuilder();
                Dictionary<string, string> processDictionary = curtain.getData();
                foreach (string key in processDictionary.Keys) {
                    if (key == "name")
                    {
                        line.Append(processDictionary[key]);
                    }
                    else {
                        line.Append("-" + processDictionary[key]);
                    }
                }
                lines.Add(line.ToString());
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"curtains.txt")) {
                foreach (string line in lines) {
                    file.WriteLine(line);
                }
            }
        }

        public static void UpdateDataset() {
            string[] lines = System.IO.File.ReadAllLines(@"curtains.txt");
            foreach (string line in lines) {
                string[] processString = line.Split('-');
                Curtain tempCurtain = new Curtain(processString[0], processString[1], processString[2], processString[3], float.Parse(processString[4]), Convert.ToInt32(processString[5]));
                curtains.Add(tempCurtain);
            }
        }
    }
}
