﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Crud.Models
{
    public class Utilisateur
    {
        public Utilisateur()
        {
            DateCreation = DateTime.Now;

            Date_Modification = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        [NotMapped]
        public String FullName
        {
            get { return Prenom + " " + Nom; }
            set { _fullName = value; }
        }

        private String _fullName;

        public string Num_Tel { get; set; }

        public Status status { get; set; }

        public Role role { get; set; }

        public string Poste { get; set; }

        public string Direction { get; set;}
        public string Etablissement { get; set; }
        public string Manager { get; set; }

        public DateTime? Date_Recrutement { get; set; }

        public DateTime DateCreation { get; set; }

        public DateTime? Date_Modification { get;set; }

    }
}