using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Biblio_Media
{
    internal class Emprunt
    {   
        private Media mediaEmprunte;
        private string nomEmprunteurMedia;
        
        /// <summary>
        /// Constructeur de la classe Emprunt, nommage différent pour désérialisation
        /// </summary>
        /// <param name="media">Media à emprunter</param>
        /// <param name="nomEmprunteur">Nom de l'emprunteur</param>
        public Emprunt(Media media, String nomEmprunteur)
        {
            mediaEmprunte = media;
            nomEmprunteurMedia = nomEmprunteur;
        }
        
        /// <summary>
        /// Méthode pour afficher les informations de l'emprunt
        /// </summary>
        public void AfficherEmprunt()
        {
            Console.WriteLine("Emprunté par : " + nomEmprunteurMedia);
            mediaEmprunte.AfficherInfos();
        }
        
        /// <summary>
        /// Méthode pour supprimer un emprunt
        /// </summary>
        public void SupprimerEmprunt()
        {
            mediaEmprunte = null;
            nomEmprunteurMedia = null;
        }
        
        /// <summary>
        /// Getter et setter pour obtenir le média emprunté
        /// </summary>
        public Media Media {
            get { return mediaEmprunte; }
            set { mediaEmprunte = value; }
        }
        
        /// <summary>
        /// Getter et setter pour obtenir le nom de l'emprunteur
        /// </summary>
        public string NomEmprunteur { 
            get { return nomEmprunteurMedia; }
            set { nomEmprunteurMedia = value; }
        }
    }
}
