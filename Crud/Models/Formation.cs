using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Crud.Models
{
    public class Formation
    {
        public Formation()
        {
            
            this.Utilisateurs = new HashSet<Utilisateur>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public Type_F Type_F{ get; set; }
        public DateTime DateDebut { get; set;}
        public DateTime DateFin { get; set; }
        [MaxLength]
        public string Commantaire { get; set; }
        public ICollection<Utilisateur> Utilisateurs { get; set; }
    }


}