using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Biblio_Media
{
    internal class Emprunt
    {
        public Media v_media { get; set; }
            public string v_nomEmprunteur { get; set; }
            
            public Emprunt(Media media, String nomEmprunteur)
            {
                v_media = media;
                v_nomEmprunteur = nomEmprunteur;
            }
            
            public void AfficherEmprunt()
            {
                Console.WriteLine("Emprunté par : " + v_nomEmprunteur);
                v_media.AfficherInfos();
            }
            
            public void SupprimerEmprunt()
            {
                v_media = null;
                v_nomEmprunteur = null;
            }
    }
}
