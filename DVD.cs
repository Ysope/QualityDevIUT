using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Biblio_Media
{
    internal class DVD : Media
    {
        private double duree;
        private string realisateur;

        /// <summary>
        /// Méthode pour afficher les informations du DVD
        /// </summary>
        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Durée: {duree}, Réalisateur: {realisateur}");
        }
        
        /// <summary>
        /// Constructeur de la classe DVD
        /// </summary>
        /// <param name="p_titre">Titre du DVD</param>
        /// <param name="p_numeroReference">Numéro de référence du DVD</param>
        /// <param name="p_nombreExemplairesDisponibles">Nombre d'exemlaires disponibles du DVD</param>
        /// <param name="p_duree">Durée du DVD</param>
        /// <param name="p_realisateur">Réalisateur du DVD</param>
        public DVD(string p_titre, int p_numeroReference, int p_nombreExemplairesDisponibles, double p_duree, string p_realisateur) : base(p_titre, p_numeroReference, p_nombreExemplairesDisponibles)
        {
            duree = p_duree;
            realisateur = p_realisateur;
        }
        
        /// <summary>
        /// Getter pour obtenir la durée du DVD
        /// </summary>
        public double Duree
        {
            get { return duree; }
        }
        
        /// <summary>
        /// Getter pour obtenir le réalisateur du DVD
        /// </summary>
        public string Realisateur
        {
            get { return realisateur; }
        }
        
    }
}

