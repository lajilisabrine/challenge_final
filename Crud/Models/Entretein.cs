using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Crud.Models
{
    public class Entretein
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        
        public int Année { get; set; }
      
        public string PointForts { get; set; }
     
        [MaxLength]
        public string Freins_Rencontres { get; set; }
        public Etat Etat { get; set; }
      
        [MaxLength]
        public string Commantaire_Employee { get; set; }
        
        [MaxLength]
        public string Commantaire_Manager { get; set; }
        public Appreciation Appreciation { get; set; }
     
        public string Note { get; set; }
        public Utilisateur Utilisateur { set; get; }
        public ICollection<Objectif> Objectifs { get; set; }

    }
}