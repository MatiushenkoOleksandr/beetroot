using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_15
{
    public class Vote
    {
       public int Id { get; set; }

        public string Question { get; set; }
        public IDictionary<int, string> Options {get; set; }
        public int CorrectAnswer { get; set; }
    }
}
