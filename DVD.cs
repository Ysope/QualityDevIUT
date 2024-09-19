using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Biblio_Media
{
    internal class DVD : Media
    {
        double v_duree;
        string v_realisateur;

        public void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine(v_duree);
            Console.WriteLine(v_realisateur);
        }

        public DVD(string v_titre, int v_numRef, int v_nbExemDispo, double v_duree, string v_realisateur) : base(v_titre, v_numRef, v_nbExemDispo)
        {
            this.v_duree = v_duree;
            this.v_realisateur = v_realisateur;
        }
    }
}
