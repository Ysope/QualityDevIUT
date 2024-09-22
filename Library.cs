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
        private List<Media> listMedia = new List<Media>();
        private List<Emprunt> listEmprunts = new List<Emprunt>();

        /// <summary>
        /// Méthode pour accéder à un média par son numéro de référence
        /// </summary>
        /// <param name="p_numeroReference">Numero de référence</param>
        /// <returns>le media</returns>
        public Media this[int p_numeroReference]
        {
            get
            {
                foreach (Media v_media in listMedia)
                {
                    if (v_media.NumeroReference == p_numeroReference)
                    {
                        return v_media;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Méthode pour retirer un média de la bibliothèque
        /// </summary>
        /// <param name="p_numeroReference">Numero de référence</param>
        public void RetirerMedia(int p_numeroReference)
        {
            Media v_mediaARetirer = this[p_numeroReference];
            if (v_mediaARetirer != null)
            {
                listMedia.Remove(v_mediaARetirer);
                Console.WriteLine("Média retiré avec succès : " + 
                                  v_mediaARetirer.Titre);
            }
            else
            {
                Console.WriteLine("Média non trouvé avec " +
                                  "le numéro de référence : " + p_numeroReference);
            }
        }


        /// <summary>
        /// Méthode pour ajouter un média à la bibliothèque
        /// </summary>
        /// <param name="p_media">Media a ajouter</param>
        public void AjouterMedia(Media p_media)
        {
            listMedia.Add(p_media);
            Console.WriteLine("Média ajouté avec succès : " 
                              + p_media.Titre);
        }
        

        /// <summary>
        /// Méthode pour emprunter un média en fonction du numéro de référence du média et du nom de l'emprunteur
        /// </summary>
        /// <param name="p_numeroReference">Numéro de référence du média</param>
        /// <param name="p_nomEmprunteur">Nom de l'emprunteur</param>
        public void EmprunterMedia(int p_numeroReference, string p_nomEmprunteur)
        {
            Media v_mediaAEmprunter = this[p_numeroReference];
            try
            {
                if (v_mediaAEmprunter.NombreExemplairesDisponibles > 0)
                {
                    v_mediaAEmprunter.NombreExemplairesDisponibles--;
                    Emprunt v_emprunt = new Emprunt(v_mediaAEmprunter, p_nomEmprunteur);
                    listEmprunts.Add(v_emprunt);
                    Console.WriteLine("Média emprunté avec succès : " + v_mediaAEmprunter.Titre);
                }
                else
                {
                    throw new Exception("Nombre d'exemplaires disponibles insuffisant pour emprunter le média.");
                }
            }
            catch
            {
                throw new NullReferenceException("Le média n'existe pas dans la bibliothèque.");
            }
        }
        
        /// <summary>
        /// Méthode pour retourner un média emprunté en fonction du numéro de référence du média et du nom de l'emprunteur
        /// </summary>
        /// <param name="p_numeroReference">Numéro de référence du média</param>
        /// <param name="p_nomEmprunteur">Nom de l'emprunteur</param>
        public void RetournerMedia(int p_numeroReference, string p_nomEmprunteur)
        {
            Emprunt v_empruntARetourner = null;
            foreach (Emprunt v_emprunt in listEmprunts)
            {   
                if (v_emprunt.Media.NumeroReference == p_numeroReference && 
                    v_emprunt.NomEmprunteur == p_nomEmprunteur)
                {
                    v_empruntARetourner = v_emprunt;
                    listEmprunts.Remove(v_emprunt);
                    break;
                }
            }
            try
            {
                v_empruntARetourner.Media.NombreExemplairesDisponibles++;
                Console.WriteLine("Média retourné avec succès : "
                                  + v_empruntARetourner.Media.Titre);
            }
            catch
            {
                throw new NullReferenceException("Le média n'existe pas dans la bibliothèque.");
            }
        }
        
        /// <summary>
        /// Méthode pour afficher les médias empruntés par un utilisateur
        /// </summary>
        /// <param name="p_nomEmprunteur">Nom de l'emprunteur</param>
        public void MediaEmprunteUtilisateur(string p_nomEmprunteur)
        {
            int v_nbEmprunts = 0;
            foreach (Emprunt v_emprunt in listEmprunts)
            {   
                Console.WriteLine("Emprunté par : " + v_emprunt.NomEmprunteur);
                if (v_emprunt.NomEmprunteur == p_nomEmprunteur)
                {
                    v_nbEmprunts++;
                    v_emprunt.Media.AfficherInfos();
                }
            }
            if (v_nbEmprunts == 0)
            {
                Console.WriteLine("Aucun média emprunté par : "
                                  + p_nomEmprunteur);
            }

        }
        
        /// <summary>
        /// Méthode pour afficher les statistiques de la bibliothèque
        /// </summary>
        public void AfficherStatistiques()
        {
            int v_nbTotalMedias = listMedia.Count;
            int v_nbExemplairesDisponibles = 0;
            int v_nbTotalExemplairesEmpruntes = listEmprunts.Count;
            foreach (Media media in listMedia)
            {
                v_nbExemplairesDisponibles += media.NombreExemplairesDisponibles;
            }
 
            Console.WriteLine("Nombre total de médias : " + v_nbTotalMedias);
            Console.WriteLine("Nombre d'exemplaires disponibles : " + v_nbExemplairesDisponibles);
            Console.WriteLine("Nombre total d'exemplaires empruntés : " + v_nbTotalExemplairesEmpruntes);

        }
        
        /// <summary>
        /// Méthode pour sauvegarder la bibliothèque dans un fichier JSON
        /// </summary>
        /// <param name="p_cheminFichier">Chemin du fichier</param>
        public void SauvegarderBibliotheque(string p_cheminFichier)
        {
            var data = new
            {
                Medias = listMedia,
                Emprunts = listEmprunts
            };
            var v_options = new JsonSerializerOptions { WriteIndented = true };
            string v_jsonString = JsonSerializer.Serialize(data, v_options);
            File.WriteAllText(p_cheminFichier, v_jsonString);
        }

        /// <summary>
        /// Méthode pour charger une bibliothèque à partir d'un fichier JSON
        /// </summary>
        /// <param name="p_cheminFichier">Chemin du fichier</param>
        /// <returns>Une bibliothèque</returns>
        /// <exception cref="FileNotFoundException">Si le fichier n'est pas trouvé</exception>
        public static Library ChargerBibliotheque(string p_cheminFichier)
        {
            if (!File.Exists(p_cheminFichier))
            {
                throw new FileNotFoundException("Le fichier spécifié est introuvable.");
            }

            string v_jsonString = File.ReadAllText(p_cheminFichier);
            var v_data = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(v_jsonString);

            Library bibliotheque = new Library();
            bibliotheque.listMedia = JsonSerializer.Deserialize<List<Media>>(v_data["Medias"].GetRawText());
            bibliotheque.listEmprunts = JsonSerializer.Deserialize<List<Emprunt>>(v_data["Emprunts"].GetRawText());

            return bibliotheque;
        }
        
        public void RechercherMediaTitreOuCreateur(string p_recherche)
        {   
            Boolean v_trouve = false;
            foreach (Media v_media in listMedia)
            {
                if (v_media.Titre.Contains(p_recherche) ||
                    (v_media is Livre livre && livre.Auteur.Contains(p_recherche)) ||
                    (v_media is CD cd && cd.Artiste.Contains(p_recherche)) ||
                    (v_media is DVD dvd && dvd.Realisateur.Contains(p_recherche)))
                {
                    v_media.AfficherInfos();
                    v_trouve = true;
                }
            }
            if (!v_trouve)
            {
                Console.WriteLine("Aucun média trouvé pour la recherche : " + p_recherche);
            }
        }
        
        /// <summary>
        /// Méthode pour ajouter un média à la bibliothèque
        /// </summary>
        /// <param name="p_library">Une bibliothèque</param>
        /// <param name="p_media">Un Média</param>
        /// <returns></returns>
        public static Library operator +(Library p_library, Media p_media)
        {
            Media v_existingMedia = p_library.listMedia.FirstOrDefault(m => m.NumeroReference == p_media.NumeroReference);
            if (v_existingMedia != null)
            {
                v_existingMedia.NombreExemplairesDisponibles += p_media.NombreExemplairesDisponibles;
            }
            else
            {
                p_library.listMedia.Add(p_media);
            }
            return p_library;
        }
        
        /// <summary>
        /// Méthode pour retirer un média de la bibliothèque
        /// </summary>
        /// <param name="p_library"></param>
        /// <param name="p_media"></param>
        /// <returns>Une bibliothèque</returns>
        /// <exception cref="InvalidOperationException">Erreur si le
        /// nombre d'exemplaires est insuffisant
        /// dans la bibliothèque</exception>
        public static Library operator -(Library p_library, Media p_media)
        {
            Media v_existingMedia = p_library.listMedia.FirstOrDefault(m => m.NumeroReference == p_media.NumeroReference);
            if (v_existingMedia != null)
            {
                if (v_existingMedia.NombreExemplairesDisponibles >= p_media.NombreExemplairesDisponibles)
                {
                    v_existingMedia.NombreExemplairesDisponibles -= p_media.NombreExemplairesDisponibles;
                    if (v_existingMedia.NombreExemplairesDisponibles == 0)
                    {
                        p_library.listMedia.Remove(v_existingMedia);
                    }
                }
                else
                {
                    throw new InvalidOperationException("Nombre d'exemplaires disponibles insuffisant pour retirer le média.");
                }
            }
            else
            {
                throw new InvalidOperationException("Le média n'existe pas dans la bibliothèque.");
            }
            return p_library;
        }
    }
}
