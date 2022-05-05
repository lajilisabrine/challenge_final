﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Crud.Models
{
    public class Objectif
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [MaxLength]
        public string Titre_Obj { get; set; }
        [Required]
        public string Ponderation { get; }
        [Required]
        public string KPI { get; set; }
        public string Ressultat  { get; set; }
        public string Commantaire_Manager { get; set; }
        public string Commantaire_Employee { get; set; }
        [Required]
        public int Score { get; set; }
        public Entretein Entretein { set; get; }
    }
}