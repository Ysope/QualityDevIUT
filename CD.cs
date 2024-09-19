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

        /// <summary>
        /// Surchage de l'opérateur + pour additionner deux CDs
        /// </summary>
        /// <param name="CD1">CD de base</param>
        /// <param name="CD2">CD a ajouter</param>
        /// <returns>CD de base modifié</returns>
        /// <exception cref="InvalidOperationException">les titres des CD ne sont pas identiques</exception>
        public static CD operator +(CD CD1, CD CD2)
        {
            if (CD1.Titre == CD2.Titre)
            {
                // Appel de la surcharge de Media pour additionner le nombre d'exemplaires
                Media resultatMedia = (Media)CD1 + (Media)CD2;

                return new CD(resultatMedia.Titre, resultatMedia.NumRef, resultatMedia.NbExemDispo, CD1.v_artiste, CD1.v_edition);
            }
            else
            {
                throw new InvalidOperationException("Les titres des CDs doivent être identiques pour les ajouter.");
            }
        }

        /// <summary>
        /// Surchage de l'opérateur - pour soustraire deux CDs
        /// </summary>
        /// <param name="CD1">CD de base</param>
        /// <param name="CD2">CD a soustraire</param>
        /// <returns>CD de base modifié</returns>
        /// <exception cref="InvalidOperationException">Nombre d'exemplaire incorrect et titre non similaire</exception>
        public static CD operator -(CD CD1, CD CD2)
        {
            if (CD1.Titre == CD2.Titre)
            {
                if (CD1.NbExemDispo < CD2.NbExemDispo)
                {
                    throw new InvalidOperationException("Le nombre d'exemplaires du CD à soustraire est supérieur au nombre d'exemplaires du CD de base.");
                }
                else
                {
                    Media resultatMedia = (Media)CD1 - (Media)CD2;

                    return new CD(resultatMedia.Titre, resultatMedia.NumRef, resultatMedia.NbExemDispo, CD1.v_artiste, CD1.v_edition);
                }
            }
            else
            {
                throw new InvalidOperationException("Les titres des CDs doivent être identiques pour les soustraire.");
            }
        }
    }
}


