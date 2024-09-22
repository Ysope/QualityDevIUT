using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Gestion_Biblio_Media
{
    internal class Media
    {
        private string titre;
        private int numeroReference;
        private int nombreExemplairesDisponibles;
        
        /// <summary>
        /// Méthode pour afficher les informations du média
        /// </summary>
        public virtual void AfficherInfos (){
            Console.WriteLine(titre);
            Console.WriteLine(numeroReference);
            Console.WriteLine(nombreExemplairesDisponibles);

        }
        
        /// <summary>
        /// Constructeur de la classe Média, nommage différent pour désérialisation
        /// </summary>
        /// <param name="titre">Titre du media</param>
        /// <param name="numeroReference">Numéro de référence du média</param>
        /// <param name="nombreExemplairesDisponibles">Nombre d'exemplaires disponibles</param>
        [JsonConstructor]
        public Media(string titre, int numeroReference, int nombreExemplairesDisponibles)
        {
            this.titre = titre;
            this.numeroReference = numeroReference;
            this.nombreExemplairesDisponibles = nombreExemplairesDisponibles;
        }
        

        /// <summary>
        /// Méthode pour obtenir le titre du média
        /// </summary>
        public string Titre
        {
            get { return titre; }
        }
        
        /// <summary>
        /// Méthode pour obtenir le numéro de référence du média
        /// </summary>
        public int NumeroReference
        {
            get { return numeroReference; }
        }

        /// <summary>
        /// Méthode pour obtenir et modifier le nombre d'exemplaires disponibles du média
        /// </summary>
        public int NombreExemplairesDisponibles
        {
            get { return nombreExemplairesDisponibles; }
            set { nombreExemplairesDisponibles = value; }
        }
    }
}
