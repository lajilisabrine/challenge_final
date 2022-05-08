using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Crud.Models
{
    public class Type_Formation
    {
        // Informatique,RH,Comptabilité,Microsoft_Office,Communication,Marketing,Langue
        [Key]
        public int id { get; set; }

        public string Libelle { get; set; }
    }
}