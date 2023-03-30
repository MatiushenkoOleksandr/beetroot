using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class Author
    {
        public string Name { get; set; }
        public Biography Biography { get; set; }
        private List<Book> Books { get; set; }
        private int Id { get; set; }

       


        
        public Author (List<Book> books)
        {
            Books = books;
        }
    }
}
