using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookLibraryCSW.Models
{
    [Serializable]
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}