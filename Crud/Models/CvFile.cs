using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Crud.Models
{
    public class CvFile
    {
        public CvFile()
        {
            DateCreation = DateTime.Now;


        }
        [ForeignKey("User")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Size { get; set; }
        public string Name { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateMaj { get; set; }
        public Status Status { get; set; }
        public string Url { get; set; }
       
        public virtual Utilisateur User { get; set; }

    }
}