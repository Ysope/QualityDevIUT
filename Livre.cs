using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Biblio_Media
{
    internal class Livre : Media
    {
        private string auteur;
        private string genre;

        /// <summary>
        /// Méthode pour afficher les informations du livre
        /// </summary>
        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine(auteur);
            Console.WriteLine(genre);
        }
    
        /// <summary>
        /// Constructeur de la classe Livre
        /// </summary>
        /// <param name="p_titre">Titre du Livre</param>
        /// <param name="p_numeroReference">Numéro de référence du Livre</param>
        /// <param name="p_nombreExemplairesDisponibles">Nombre d'exemplaires disponibles du Livre</param>
        /// <param name="p_auteur">Auteur du Livre</param>
        /// <param name="p_genre">Genre du Livre</param>
        public Livre(string p_titre, int p_numeroReference,
            int p_nombreExemplairesDisponibles, string p_auteur,
            string p_genre) : base(p_titre, p_numeroReference,
            p_nombreExemplairesDisponibles)
        {
            auteur = p_auteur;
            genre = p_genre;
        }
        
        /// <summary>
        /// Getter pour obtenir l'auteur du Livre
        /// </summary>
        public string Auteur
        {
            get { return auteur; }
        }
        
        /// <summary>
        /// Getter pour obtenir le genre du Livre
        /// </summary>
        public string Genre
        {
            get { return genre; }
        }
    }
}
