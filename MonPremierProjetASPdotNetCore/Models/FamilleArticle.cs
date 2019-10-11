using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MonPremierProjetASPdotNetCore.Models
{
    public class FamilleArticle
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        // Cette annotation indique que le membre ne doit pas être pris en compte par EF.
        [NotMapped]
        public int Interne { get; private set; } //TEST
    }
}

