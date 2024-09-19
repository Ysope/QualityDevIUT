using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Biblio_Media
{
    internal class CD : Media
    {
        string v_artiste;
        string v_edition;

        public void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine(v_artiste);
            Console.WriteLine(v_edition);
        }

        public CD(string v_titre, int v_numRef, int v_nbExemDispo, string v_artiste, string v_edition) : base(v_titre, v_numRef, v_nbExemDispo)
        {
            this.v_artiste = v_artiste;
            this.v_edition = v_edition;
        }
    }
}
