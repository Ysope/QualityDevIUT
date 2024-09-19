using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Biblio_Media
{
    internal class DVD : Media
    {
        double v_duree;
        string v_realisateur;

        public void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine(v_duree);
            Console.WriteLine(v_realisateur);
        }

        public DVD(string v_titre, int v_numRef, int v_nbExemDispo, double v_duree, string v_realisateur) : base(v_titre, v_numRef, v_nbExemDispo)
        {
            this.v_duree = v_duree;
            this.v_realisateur = v_realisateur;
        }

        /// <summary>
        /// Surchage de l'opérateur + pour additionner deux DVDs
        /// </summary>
        /// <param name="DVD1">DVD de base</param>
        /// <param name="DVD2">DVD a ajouter</param>
        /// <returns>DVD de base modifié</returns>
        /// <exception cref="InvalidOperationException">les titres des DVDs ne sont pas identiques</exception>
        public static DVD operator +(DVD DVD1, DVD DVD2)
        {
            if (DVD1.Titre == DVD2.Titre)
            {
                // Appel de la surcharge de Media pour additionner le nombre d'exemplaires
                Media resultatMedia = (Media)DVD1 + (Media)DVD2;

                return new DVD(resultatMedia.Titre, resultatMedia.NumRef, resultatMedia.NbExemDispo, DVD1.v_duree, DVD1.v_realisateur);
            }
            else
            {
                throw new InvalidOperationException("Les titres des DVDs doivent être identiques pour les ajouter.");
            }
        }

        /// <summary>
        /// Surchage de l'opérateur - pour soustraire deux DVDs
        /// </summary>
        /// <param name="DVD1">DVD de base</param>
        /// <param name="DVD2">DVD a soustraire</param>
        /// <returns>DVD de base modifié</returns>
        /// <exception cref="InvalidOperationException">Nombre d'exemplaire incorrect et titre non similaire</exception>
        public static DVD operator -(DVD DVD1, DVD DVD2)
        {
            if (DVD1.Titre == DVD2.Titre)
            {
                if (DVD1.NbExemDispo < DVD2.NbExemDispo)
                {
                    throw new InvalidOperationException("Le nombre d'exemplaires du DVD à soustraire est supérieur au nombre d'exemplaires du DVD de base.");
                }
                else
                {
                    Media resultatMedia = (Media)DVD1 - (Media)DVD2;

                    return new DVD(resultatMedia.Titre, resultatMedia.NumRef, resultatMedia.NbExemDispo, DVD1.v_duree, DVD1.v_realisateur);
                }
            }
            else
            {
                throw new InvalidOperationException("Les titres des DVDs doivent être identiques pour les soustraire.");
            }
        }
    }
}

