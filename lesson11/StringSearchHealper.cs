using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson11
{
    public class StringSearchHealper
    {
        public string Search(string[] lines, string text)
        {
            foreach (var line in lines)
            {
                if (line == text)
                {
                    return line;
                }
            }
            return "";
        }

        public List<string> Search1(string[] lines, string text)
        {
            var list = new List<string>();
            foreach (var line in lines)
            {
                if (line.Contains(text))
                {
                    list.Add(line);
                }
            }return list;
        }

    }
}
