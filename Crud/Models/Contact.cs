using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.Models
{
    public class Contact
    {

        public Contact()
        {
            DateCreation = DateTime.Now;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Objet { get; set; }
        public DateTime DateCreation { get; set; }
        [Required][MaxLength]
        public string Message { get; set; }
        [Required]
        public Type Type { get; set; }
        public Utilisateur Utilisateur { set; get; }

    }
}