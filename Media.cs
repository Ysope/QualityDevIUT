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

        /// <summary>
        /// Surchage de l'opérateur + pour additionner deux médias
        /// </summary>
        /// <param name="media1">media de base</param>
        /// <param name="media2">media a ajouter</param>
        /// <returns>media de base modifié</returns>
        /// <exception cref="InvalidOperationException">Les titres ne sont pas identiques</exception>
        public static Media operator +(Media media1, Media media2)
        {
            if (media1.v_titre == media2.v_titre)
            {
                return new Media(media1.v_titre, media1.v_numRef, media1.v_nbExemDispo + media2.v_nbExemDispo);
            }
            else
            {
                throw new InvalidOperationException("Les titres des médias doivent être identiques pour les ajouter.");
            }
        }

        /// <summary>
        /// Surchage de l'opérateur - pour soustraire deux médias
        /// </summary>
        /// <param name="media1">media de base</param>
        /// <param name="media2">media a soustraire</param>
        /// <returns>media de base modifié</returns>
        /// <exception cref="InvalidOperationException">Les titres ne sont pas identiques et le nombre d'exemplaire incorrect</exception>
        public static Media operator -(Media media1, Media media2)
        {
            if (media1.v_titre == media2.v_titre)
            {
                if(media1.v_nbExemDispo < media2.v_nbExemDispo)
                {
                    throw new InvalidOperationException("Le nombre d'exemplaires du premier média doit être supérieur ou égal au nombre d'exemplaires du second média pour les soustraire.");
                }

                return new Media(media1.v_titre, media1.v_numRef, media1.v_nbExemDispo - media2.v_nbExemDispo);
            }
            else
            {
                throw new InvalidOperationException("Les titres des médias doivent être identiques pour les ajouter.");
            }
        }

        /// <summary>
        /// Fonction pour obtenir le titre du média
        /// </summary>
        public string Titre
        {
            get { return v_titre; }
        }
        
        /// <summary>
        /// Fonction pour obtenir le numéro de référence du média
        /// </summary>
        public int NumRef
        {
            get { return v_numRef; }
        }

        /// <summary>
        /// Fonction pour obtenir et modifier le nombre d'exemplaires disponibles du média
        /// </summary>
        public int NbExemDispo
        {
            get { return v_nbExemDispo; }
            set { v_nbExemDispo = value; }
        }
    }
}
