using Gestion_Biblio_Media;

// Partie 1 : Classes, Héritage et Polymorphisme

Livre m_unLivre = new Livre("Ca",4,7,"Stephen King","Thriller");
DVD m_unDVD = new DVD("Narnia",2,3,2.20,"Andrew Adamson");
CD m_unCD = new CD("Civilisation",5,24,"Orelsan","Warner");

m_unLivre.AfficherInfos();
Console.WriteLine("\n");
m_unDVD.AfficherInfos();
Console.WriteLine("\n");
m_unCD.AfficherInfos();
Console.WriteLine("\n");
Console.WriteLine("--------------------");


// Partie 3 : Collections et Indexeurs

Library m_maBibliotheque = new Library();

//Ajout de médias
m_maBibliotheque.AjouterMedia(m_unLivre);
m_maBibliotheque.AjouterMedia(m_unDVD);
m_maBibliotheque.AjouterMedia(m_unCD);
Console.WriteLine("--------------------");

//Retirer un média
m_maBibliotheque.RetirerMedia(4);
Console.WriteLine("--------------------");

//Emprunter un média
m_maBibliotheque.EmprunterMedia(2, "Jean");
m_maBibliotheque.EmprunterMedia(5, "Jean");
Console.WriteLine("--------------------");

//Retourner un média
m_maBibliotheque.RetournerMedia(2, "Jean");
Console.WriteLine("--------------------");

//Rechercher un média
m_maBibliotheque.RechercherMediaTitre("Civilisation");
Console.WriteLine("--------------------");

//Lister les médias empruntés par un utilisateur
m_maBibliotheque.MediaEmprunteUtilisateur("Jean");
Console.WriteLine("--------------------");

//Afficher les statistiques
m_maBibliotheque.AfficherStatistiques();
Console.WriteLine("--------------------");

//Partie 2 : Surchage d'opérateurs
// Ajout de médias
Livre m_unLivre2 = new Livre("Les Misérables", 6, 3, "Victor Hugo", "Drame");
DVD m_unDVD2 = new DVD("Le Roi Lion", 7, 2, 1.30, "Roger Allers");
CD m_unCD2 = new CD("La Bohème", 8, 5, "Charles Aznavour", "EMI");

m_maBibliotheque = m_maBibliotheque + m_unLivre2;
m_maBibliotheque = m_maBibliotheque + m_unDVD2;
m_maBibliotheque = m_maBibliotheque + m_unCD2;

m_maBibliotheque.AfficherStatistiques();
Console.WriteLine("--------------------");

// Retirer un média
m_maBibliotheque = m_maBibliotheque - m_unLivre2;
m_maBibliotheque.AfficherStatistiques();
Console.WriteLine("--------------------");


//Partie 4 : Sérialisation JSON
// Sauvegarde de la bibliothèque
string m_cheminFichier = "bibliotheque.json";
m_maBibliotheque.SauvegarderBibliotheque(m_cheminFichier);
Console.WriteLine("Bibliothèque sauvegardée.");
Console.WriteLine("--------------------");

// Chargement de la bibliothèque
Library bibliothequeChargee = Library.ChargerBibliotheque(m_cheminFichier);
Console.WriteLine("Bibliothèque chargée.");
bibliothequeChargee.AfficherStatistiques();
Console.WriteLine("--------------------");



