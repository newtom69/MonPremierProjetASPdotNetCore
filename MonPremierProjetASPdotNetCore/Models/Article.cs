using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MonPremierProjetASPdotNetCore.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Image { get; set; }
        public double Prix { get; set; }
        public int FamilleId { get; set; }
        public int NombreVendus { get; set; }
        public string Description { get; set; }
        public string Allergenes { get; set; }
        public int Grammage { get; set; }
        public int Litrage { get; set; }
        public bool DansCarte { get; set; }

        public FamilleArticle Famille { get; set; }

        //public virtual ICollection<Commande_Article> Commande_Article { get; set; }

        //public virtual ICollection<Panier> Panier { get; set; }
    }
}
