using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Biblio_Media
{
    internal class Livre : Media
    {
        string v_auteur;
        string v_genre;

        public void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine(v_auteur);
            Console.WriteLine(v_genre);
        }

        public Livre(string v_titre, int v_numRef, int v_nbExemDispo, string v_auteur, string v_genre) : base(v_titre, v_numRef, v_nbExemDispo)
        {
    
            this.v_auteur = v_auteur;
            this.v_genre = v_genre;
        }
    }
}
