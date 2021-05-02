using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationDemo.Data.Models
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string EmailAddress { get; set; }
    }
}
