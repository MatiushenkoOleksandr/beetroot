using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class Book
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Chapter>  Chapters  { get; set; }
         public List<Author> Authors { get; set; }
         
    }

}
