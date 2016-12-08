using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace BookLibraryCSW.Models
{
    [Serializable, DataContract]
    public class Category
    {
        public int Id { get; set; }
        
        [Required, DataMember]
        public string Description { get; set; }

        [DataMember]
        public virtual ICollection<Books> Books { get; set; }
    }
}