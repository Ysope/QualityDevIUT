using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Gestion_Biblio_Media
{
    internal class Library
    {
        private List<Media> v_listMedia = new List<Media>();
        private List<Emprunt> v_listEmprunts = new List<Emprunt>();

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
        /// Fonction pour ajouter un média à la bibliothèque
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

        //Méthode pour emprunter un média par un utilisateur en fonction du numéro de référence du média
        //et du nom de l'emprunteur
        public void EmprunterMedia(int numRef, string nomEmprunteur)
        {
            Media mediaAEmprunter = this[numRef];
            if (mediaAEmprunter != null)
            {
                if (mediaAEmprunter.NbExemDispo > 0)
                {
                    mediaAEmprunter.NbExemDispo--;
                    Emprunt emprunt = new Emprunt(mediaAEmprunter, nomEmprunteur);
                    v_listEmprunts.Add(emprunt);
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
        
        //Méthode pour retourner un média en fonction du numéro de référence du media et du nom de l'emprunteur
        public void RetournerMedia(int numRef, string nomEmprunteur)
        {
            Emprunt empruntARetourner = null;
            foreach (var emprunt in v_listEmprunts)
            {
                if (emprunt.v_media.NumRef == numRef && emprunt.v_nomEmprunteur == nomEmprunteur)
                {
                    empruntARetourner = emprunt;
                    v_listEmprunts.Remove(emprunt);
                    break;
                }
            }
            if (empruntARetourner != null)
            {
                empruntARetourner.v_media.NbExemDispo++;
                Console.WriteLine("Média retourné avec succès : " + empruntARetourner.v_media.Titre);
            }
            else
            {
                Console.WriteLine("Média non trouvé avec le numéro de référence : " + numRef + " et l'emprunteur : " + nomEmprunteur);
            }
        }
        
        //Méthode pour afficher les médias empruntés par un utilisateur en fonction de son nom
        public void MediaEmprunteUtilisateur(string nomEmprunteur)
        {
            int nbEmprunts = 0;
            foreach (var emprunt in v_listEmprunts)
            {
                if (emprunt.v_nomEmprunteur == nomEmprunteur)
                {
                    nbEmprunts++;
                    emprunt.v_media.AfficherInfos();
                }
            }
            if (nbEmprunts == 0)
            {
                Console.WriteLine("Aucun média emprunté par : " + nomEmprunteur);
            }

        }
        
        //Méthode pour afficher les statistiques de la bibliothèque
        public void AfficherStatistiques()
        {
            int nbTotalMedias = v_listMedia.Count;
            int nbExemplairesDisponibles = 0;
            int nbTotalExemplairesEmpruntes = v_listEmprunts.Count;
            foreach (var media in v_listMedia)
            {
                nbExemplairesDisponibles += media.NbExemDispo;
            }
 
            Console.WriteLine("Nombre total de médias : " + nbTotalMedias);
            Console.WriteLine("Nombre d'exemplaires disponibles : " + nbExemplairesDisponibles);
            Console.WriteLine("Nombre total d'exemplaires empruntés : " + nbTotalExemplairesEmpruntes);

        }
        
        //Méthode pour sauvegarder l'état de la bibilothèque dans un fichier JSON 
        public void SauvegarderBibliotheque(string cheminFichier)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(this, options);
            File.WriteAllText(cheminFichier, jsonString);
        }

        //Méthode pour charger la bibliothèque depuis un fichier JSON
        public static Library ChargerBibliotheque(string cheminFichier)
        {
            if (!File.Exists(cheminFichier))
            {
                throw new FileNotFoundException("Le fichier spécifié est introuvable.");
            }

            string jsonString = File.ReadAllText(cheminFichier);
            return JsonSerializer.Deserialize<Library>(jsonString);
        }
    }
}
