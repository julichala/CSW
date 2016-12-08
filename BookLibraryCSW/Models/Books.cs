using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace BookLibraryCSW.Models
{    
    [Serializable, DataContract]
    public class Books
    {
        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        [Required]
        public string Title { get; set; }
        
        [DataMember]
        [Required]
        public int Year { get; set; }

        [DataMember]
        [Required]
        public decimal Price { get; set; }

        //Foreign
        [DataMember]
        [Required]
        [ForeignKey("Author")]
        [Display(Name = "Choose Author")]
        public int idAuthor { get; set; }

        //Foreign
        [DataMember]
        [Required]
        [ForeignKey("Category")]
        [Display(Name = "Choose Category" )]
        public int idCategory { get; set; }

        
        public virtual Category Category { get; set; }

        
        public virtual Author Author { get; set; }
        
    }
}