using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookLibraryCSW.Models
{
    public class Books
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public decimal Price { get; set; }

        //Foreign
        [Required]
        [ForeignKey("Author")]
        [Display(Name = "Choose Author")]
        public int idAuthor { get; set; }

        //Foreign
        [Required]
        [ForeignKey("Category")]
        [Display(Name = "Choose Category" )]
        public int idCategory { get; set; }

        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }
        
    }
}