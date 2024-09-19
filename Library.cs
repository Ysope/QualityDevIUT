using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Biblio_Media
{
    internal class Library
    {
        private List<Media> v_listMedia = new List<Media>();

        /// <summary>
        /// Fonction pour accéder à un média par son numéro de référence
        /// </summary>
        /// <param name="numRef">numero de référence</param>
        /// <returns>le media</returns>
        public Media this[int numRef]
        {
            get
            {
                foreach (var media in v_listMedia)
                {
                    if (media.NumRef == numRef)
                    {
                        return media;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Fonction pour retirer un média de la bibliothèque
        /// </summary>
        /// <param name="numRef">Numero de référence</param>
        public void RetirerMedia(int numRef)
        {
            Media mediaARetirer = this[numRef];
            if (mediaARetirer != null)
            {
                v_listMedia.Remove(mediaARetirer);
                Console.WriteLine("Média retiré avec succès : " + mediaARetirer.Titre);
            }
            else
            {
                Console.WriteLine("Média non trouvé avec le numéro de référence : " + numRef);
            }
        }


        /// <summary>
        /// Fonxtion pour ajouter un média à la bibliothèque
        /// </summary>
        /// <param name="media">media a ajouter</param>
        public void AjouterMedia(Media media)
        {
            if (media != null)
            {
                v_listMedia.Add(media);
                Console.WriteLine("Média ajouté avec succès : " + media.Titre);
            }
            else
            {
                Console.WriteLine("Impossible d'ajouter un média null.");
            }
        }

        /// <summary>
        /// Fonction pour emprunter un média
        /// </summary>
        /// <param name="numRef">Numéro de référence</param>
        public void EmprunterMedia(int numRef)
        {
            Media mediaAEmprunter = this[numRef];
            if (mediaAEmprunter != null)
            {
                if (mediaAEmprunter.NbExemDispo > 0)
                {
                    mediaAEmprunter.NbExemDispo--;
                    Console.WriteLine("Média emprunté avec succès : " + mediaAEmprunter.Titre);
                }
                else
                {
                    Console.WriteLine("Aucun exemplaire disponible pour le média : " + mediaAEmprunter.Titre);
                }
            }
            else
            {
                Console.WriteLine("Média non trouvé avec le numéro de référence : " + numRef);
            }
        }

        /// <summary>
        /// Affiche tous les médias de la bibliothèque
        /// </summary>
        public void AfficherTousLesMedias()
        {
            if (v_listMedia.Count == 0)
            {
                Console.WriteLine("Aucun média disponible.");
            }
            else
            {
                Console.WriteLine("Liste des médias dans la bibliothèque :");
                foreach (var media in v_listMedia)
                {
                    media.AfficherInfos();
                    Console.WriteLine("-------------------------");
                }
            }
        }
    }
}
