using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Biblio_Media
{
    internal class CD : Media
    {
        private string artiste;
        private string edition;

        /// <summary>
        /// Méthode pour afficher les informations du CD
        /// </summary>
        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Artiste: {artiste}, Edition: {edition}");
        }

        /// <summary>
        /// Constructeur de la classe CD
        /// </summary>
        /// <param name="p_titre">Titre du CD</param>
        /// <param name="p_numeroReference">Numéro de référence du CD</param>
        /// <param name="p_nombreExemplairesDisponibles">Nombre d'exemplaires disponibles du CD</param>
        /// <param name="p_artiste">Artiste du CD</param>
        /// <param name="p_edition">Edition du CD</param>
        public CD(string p_titre, int p_numeroReference, int p_nombreExemplairesDisponibles, string p_artiste, string p_edition) : base(p_titre, p_numeroReference, p_nombreExemplairesDisponibles)
        {
            artiste = p_artiste;
            edition = p_edition;
        }
        
        /// <summary>
        /// Getter pour obtenir l'artiste du CD
        /// </summary>
        public string Artiste
        {
            get { return artiste; }
        }
        
        /// <summary>
        /// Getter pour obtenir l'édition du CD
        /// </summary>
        public string Edition
        {
            get { return edition; }
        }
        
    }
}


