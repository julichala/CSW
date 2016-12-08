using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookLibraryCSW.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required]
        public string Description { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}