using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Biblio_Media
{
    internal class Livre : Media
    {
        string v_auteur;
        string v_genre;

        public void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine(v_auteur);
            Console.WriteLine(v_genre);
        }

        public Livre(string v_titre, int v_numRef, int v_nbExemDispo, string v_auteur, string v_genre) : base(v_titre, v_numRef, v_nbExemDispo)
        {
    
            this.v_auteur = v_auteur;
            this.v_genre = v_genre;
        }


        /// <summary>
        /// Surchage de l'opérateur + pour additionner deux livres
        /// </summary>
        /// <param name="livre1">livre de base</param>
        /// <param name="livre2">livre a ajouter</param>
        /// <returns>livre de base modifié</returns>
        /// <exception cref="InvalidOperationException">les titres des livres ne sont pas identiques</exception>
        public static Livre operator +(Livre livre1, Livre livre2)
        {
            if (livre1.Titre == livre2.Titre)
            {
                // Appel de la surcharge de Media pour additionner le nombre d'exemplaires
                Media resultatMedia = (Media)livre1 + (Media)livre2;

                return new Livre(resultatMedia.Titre, resultatMedia.NumRef, resultatMedia.NbExemDispo, livre1.v_auteur, livre1.v_genre);
            }
            else
            {
                throw new InvalidOperationException("Les titres des livres doivent être identiques pour les ajouter.");
            }
        }

        /// <summary>
        /// Surchage de l'opérateur - pour soustraire deux livres
        /// </summary>
        /// <param name="livre1">Livre de base</param>
        /// <param name="livre2">Livre a soustraire</param>
        /// <returns>LIvre de base modifié</returns>
        /// <exception cref="InvalidOperationException">Nombre d'exemplaire incorrect et titre non similaire</exception>
        public static Livre operator -(Livre livre1, Livre livre2)
        {
            if (livre1.Titre == livre2.Titre)
            {
                if (livre1.NbExemDispo < livre2.NbExemDispo)
                {
                    throw new InvalidOperationException("Le nombre d'exemplaires du livre à soustraire est supérieur au nombre d'exemplaires du livre de base.");
                }
                else
                {
                    Media resultatMedia = (Media)livre1 - (Media)livre2;

                    return new Livre(resultatMedia.Titre, resultatMedia.NumRef, resultatMedia.NbExemDispo, livre1.v_auteur, livre1.v_genre);
                }
            }
            else
            {
                throw new InvalidOperationException("Les titres des livres doivent être identiques pour les soustraire.");
            }
        }
    }
}
