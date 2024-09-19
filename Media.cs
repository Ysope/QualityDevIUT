using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Biblio_Media
{
    internal class Media
    {
        string v_titre;
        int v_numRef;
        int v_nbExemDispo;

        public void AfficherInfos (){

            Console.WriteLine(v_titre);
            Console.WriteLine(v_numRef);
            Console.WriteLine(v_nbExemDispo);

        }

        public Media(string v_titre, int v_numRef, int v_nbExemDispo)
        {
            this.v_titre = v_titre;
            this.v_numRef = v_numRef;
            this.v_nbExemDispo = v_nbExemDispo;
        }
    }
}
