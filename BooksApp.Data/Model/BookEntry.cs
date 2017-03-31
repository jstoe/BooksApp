using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Data
{
    public class BookEntry
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Book Book { get; set; }

        public string UserName { get; set; }

        public DateTime Saved { get; set; } = DateTime.UtcNow;
    }
}
